using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Controlador;

namespace TestAWS_S3
{
    class Program
    {
        private const string keyname = "hola.txt";
        private const string bucketName = "";
        private const string ruta = "D:/Alimentos Santiago/Codificacion/Archivos";
        private const string ruta2 = "C:/Users/Miguel/Desktop";
        private static AmazonS3Client s3Client;


        static void Main(string[] args)
        {
            
            s3Client = new AmazonS3Client("", "", RegionEndpoint.USEast2);
            //S3DirectoryInfo dir = new S3DirectoryInfo(s3Client, bucketName, "hola.txt");
            //foreach (IS3FileSystemInfo file in dir.GetFileSystemInfos())
            //{
            //    Console.WriteLine(file.Name);
            //    Console.WriteLine(file.Extension);
            //    Console.WriteLine(file.LastWriteTime);
            //}
            //Console.ReadKey();


            ReadObjectDataAsync().Wait();
            Console.ReadKey();

        }

        static async Task ReadObjectDataAsync()
        {
            //string responseBody = "";
            try
            {
                EmpresaController empc = new EmpresaController();
                var listaPlanillas = empc.PlanillasEmpresa(1);

                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = "Libro1.xlsx"
                };
                using (GetObjectResponse response = await s3Client.GetObjectAsync(request))
                {
                    string title = response.Metadata["x-amz-meta-title"]; // Assume you have "title" as medata added to the object.
                    string contentType = response.Headers["Content-Type"];
                    Console.WriteLine("Object metadata, Title: {0}", title);
                    Console.WriteLine("Content type: {0}", contentType);

                    string dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Libro1.xlsx");
                    if (!File.Exists(dest))
                    {
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

        class algo
        {
            public bool permisos()
            {

                try
                {
                    // Attempt to get a list of security permissions from the folder. 
                    // This will raise an exception if the path is read only or do not have access to view the permissions. 
                    System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(ruta);
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    return false;
                }
            }
        }
    }
}
