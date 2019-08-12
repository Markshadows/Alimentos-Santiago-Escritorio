using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class PlatilloController
    {
        private ConexionController conexion;
        private ObjectParameter p_retorno = new ObjectParameter("P_RETORNO", typeof(int));

        public PlatilloController()
        {
            conexion = new ConexionController();
        }

        public object filtroDiaPlatillo(int dia) {

            var listaDiaPlatillos = from dpa in conexion.Entidades.DIA_PLATILLO
                                    join pla in conexion.Entidades.PLATILLO
                                    on dpa.PLATILLO equals pla.PLATILLO_ID
                                    where dpa.DIA == dia
                                    select new
                                    {
                                        Día = dpa.DIA1.NOMBRE,
                                        Platillo = pla.NOMBRE,
                                        Modificacion = dpa.MODIFICACION
                                    };
            return listaDiaPlatillos.ToList();
        }

        public List<Platillo> ListaPlatillos{
            get
            {
                List<PLATILLO> lista_bd = conexion.Entidades.PLATILLO.ToList();
                List<Platillo> lista_clase = new List<Platillo>();

                foreach (PLATILLO item in lista_bd)
                {
                    Platillo platillo = new Platillo
                    {
                        PlatilloId = item.PLATILLO_ID,
                        Valor = item.VALOR,
                        TiempoPreparacion = item.PROMEDIO_PREPARACION,
                        Descripcion = item.DESCRIPCION,
                        Src = item.SRC,
                        Nombre = item.NOMBRE

                    };
                    lista_clase.Add(platillo);
                }
                return lista_clase;
            }
        }

        public List<Dia> ListaDias
        {
            get
            {
                List<DIA> lista_bd = conexion.Entidades.DIA.ToList();
                List<Dia> lista_clase = new List<Dia>();

                foreach (DIA item in lista_bd)
                {
                    Dia dia = new Dia
                    {
                        DiaId = item.DIA_ID,
                        Nombre = item.NOMBRE

                    };
                    lista_clase.Add(dia);
                }
                return lista_clase;
            }
        }

        public int AgregarDisponibilidad(int diaId, int platilloId)
        {
            try
            {
                conexion.Entidades.PROCEDURE_DISPO_PLATILLOS(diaId, platilloId, p_retorno);
                return Convert.ToInt32(p_retorno.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EliminarDisponibilidad(int diaId, int platilloId)
        {
            try
            {
                conexion.Entidades.PROCEDURE_ELIMINAR_DISPO(diaId, platilloId, p_retorno);
                return Convert.ToInt32(p_retorno.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AgregarPlatillo(int valor, int tiempoPreparacion, string descripcion, string src, string nombre)
        {
            try
            {
                conexion.Entidades.PROCEDURE_CREAR_PLATILLO(valor, tiempoPreparacion,
                    descripcion, src, nombre, p_retorno);
                return Convert.ToInt32(p_retorno.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UploadFileAsync(string rutaCompleta, string nombreArchivo)
        {
            //string responseBody = "";
            try
            {
                AmazonS3Client s3Client = new AmazonS3Client("", "", RegionEndpoint.USEast2);
                const string bucketName = "";

                var fileTransferUtility =
                   new TransferUtility(s3Client);


                // Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(rutaCompleta, bucketName, nombreArchivo);
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
    }
}
