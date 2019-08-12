using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controlador
{
    public class EmpresaController
    {
        private ConexionController conexion;

        public EmpresaController()
        {
            conexion = new ConexionController();
        }

        public List<Cl_ConvenioEmpresa> Empresas
        {

            get
            {
                List<CONVENIO_EMPRESA> lista_bd = conexion.Entidades.CONVENIO_EMPRESA.ToList();
                List<Cl_ConvenioEmpresa> lista_clase = new List<Cl_ConvenioEmpresa>();

                foreach (CONVENIO_EMPRESA item in lista_bd)
                {
                    Cl_ConvenioEmpresa convenio_empresa = new Cl_ConvenioEmpresa
                    {
                        Id = item.CONVENIO_EMPRESA_ID,
                        Nombre = item.NOMBRE,
                        Rut = item.RUT,
                        Direccion = item.DIRECCION,
                        FechaInicio = (DateTime)item.FECHA_INICIO,
                        FechaTermino = (DateTime)item.FECHA_TERMINO

                    };
                    lista_clase.Add(convenio_empresa);
                }
                return lista_clase;
            }
        }

        public object PlanillasEmpresa(byte idEmpresa)
        {

            try
            {

                var x = from cem in conexion.Entidades.CONVENIO_EMPRESA
                        join plt in conexion.Entidades.PLANILLA_TRABAJADORES
                        on cem.CONVENIO_EMPRESA_ID equals plt.CONVENIO_EMPRESA_ID
                        where cem.CONVENIO_EMPRESA_ID == idEmpresa
                        select new
                        {
                            IdPlanilla = plt.PLANILLA_ID,
                            FechaSubida = plt.FECHA_SUBIDA,
                            NombreArchivo = plt.NOMBRE_ARCHIVO,
                            IdEmpresa = plt.CONVENIO_EMPRESA_ID
                        };
                return x.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
                throw;
            }
        }

        public object BuscarPlanilla(byte planillaId, byte empresaId)
        {

            try
            {

                var x = from plt in conexion.Entidades.PLANILLA_TRABAJADORES
                        where plt.CONVENIO_EMPRESA_ID == empresaId && plt.PLANILLA_ID == planillaId
                        select new
                        {
                            IdPlanilla = plt.PLANILLA_ID,
                            FechaSubida = plt.FECHA_SUBIDA,
                            NombreArchivo = plt.NOMBRE_ARCHIVO
                        };
                return x.First();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
                throw;
            }
        }

        public async Task ReadObjectDataAsync(string nombreArchivo)
        {
            //string responseBody = "";
            try
            {
                AmazonS3Client s3Client = new AmazonS3Client("", "", RegionEndpoint.USEast2);
                const string bucketName = "";

                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = nombreArchivo
                };
                using (GetObjectResponse response = await s3Client.GetObjectAsync(request))
                {
                    string dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);
                    if (!File.Exists(dest))
                    {
                        response.WriteObjectProgressEvent += Response_WriteObjectProgressEvent;
                        await response.WriteResponseStreamToFileAsync(dest, true, CancellationToken.None);
                    }
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
        private void Response_WriteObjectProgressEvent(object sender, WriteObjectProgressArgs e)
        {
            Console.WriteLine($"Tansfered: {e.TransferredBytes}/{e.TotalBytes} - Progress: {e.PercentDone}%");
        }
    }
}
