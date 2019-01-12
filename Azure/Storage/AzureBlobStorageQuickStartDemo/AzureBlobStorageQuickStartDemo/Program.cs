using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureBlobStorageQuickStartDemo
{
    class Program
    {
        public  static async Task Main(string[] args)
        {

            Console.WriteLine($"{ new string('-', 80)}");
            Console.WriteLine("Purpose of this demo is to demonstrates Azure Blob storage.");
            Console.WriteLine($"{new string('-', 80)}");

            await UploadFileToStorage();
            await ReadBlobContainer();
        }

        public static async Task ReadBlobContainer()
        {
            // connection string to storage
            const string connectionStringToCloudStorage = "DefaultEndpointsProtocol=https;AccountName=zeusconstructixstorage;AccountKey=vojDR4oWr4gZ6yKODaaq0/U1EffAd7iJJ4FfEa/9TYGG7l3yBzjveAl91vLyyIEjbn2vgA3ZqdGbE0vRkVl/3A==;EndpointSuffix=core.windows.net";
            CloudBlobContainer cloudBlobContainer = null;
            CloudStorageAccount storageAccount = null;
            if (CloudStorageAccount.TryParse(connectionStringToCloudStorage, out storageAccount))
            {

                // create blob client
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                cloudBlobContainer = cloudBlobClient.GetContainerReference("readingscontainer");
                // make sure blob container exists.
                if(await cloudBlobContainer.ExistsAsync())
                {
                    //set permissions
                    BlobContainerPermissions permissions = new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);
                    List<string> listOfUrl = new List<string>();
                    BlobContinuationToken token = null;


                    var destinationFolder = @"D:\Files\AzureStorage";
                    if (!System.IO.Directory.Exists(destinationFolder))
                    {
                        System.IO.Directory.CreateDirectory(destinationFolder);
                    }

                    int counter = 1;
                    do
                    {
                        var results = await cloudBlobContainer.ListBlobsSegmentedAsync(null, token);
                        token = results.ContinuationToken;
                        foreach (IListBlobItem item in results.Results)
                        {
                            Console.WriteLine($"{item.Uri}");
                            listOfUrl.Add(item.Uri.ToString());
                            var fileName = String.Concat(destinationFolder, @"\", counter.ToString(), ".jpg");
                            // download the blob 

                            CloudBlockBlob cloundBlockBlob = item as CloudBlockBlob;
                            await cloundBlockBlob.DownloadToFileAsync(fileName, System.IO.FileMode.Create);
                            counter++;

                        }
                    } while (token != null);                  
                  
                }
            }

        }

        public static async Task UploadFileToStorage()
        {
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;

            // connection string to storage
            string connectionStringToCloudStorage = "DefaultEndpointsProtocol=https;AccountName=zeusconstructixstorage;AccountKey=vojDR4oWr4gZ6yKODaaq0/U1EffAd7iJJ4FfEa/9TYGG7l3yBzjveAl91vLyyIEjbn2vgA3ZqdGbE0vRkVl/3A==;EndpointSuffix=core.windows.net";

            if (CloudStorageAccount.TryParse(connectionStringToCloudStorage, out storageAccount))
            {
                try
                {
                    // create blob client
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    cloudBlobContainer = cloudBlobClient.GetContainerReference("readingscontainer");

                    if (!await cloudBlobContainer.ExistsAsync())
                    {
                        await cloudBlobContainer.CreateAsync();                        
                        Console.WriteLine($"container has been created -> {cloudBlobContainer.Name}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Info: Container already exists.");
                    }

                    //set permissions
                    BlobContainerPermissions permissions = new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);


                    // get image.
                    const string imageFile = @"D:\Photos from Phone\IMG_20190109_124717.jpg";

                    Console.WriteLine($"Uploading {imageFile} to Azure storage.");
                    CloudBlockBlob cloundBlockBlob = cloudBlobContainer.GetBlockBlobReference( "Reading" + Guid.NewGuid().ToString());
                    await cloundBlockBlob.UploadFromFileAsync(imageFile);
                    
                    Console.WriteLine($"Image has been uploaded...");

                    Console.WriteLine($"Listing all blobs in {cloudBlobContainer.Name}");

                    
                    Console.WriteLine($"Blobs: ");
                    Console.WriteLine(new string('-', 80));
                    
                   
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                    throw;
                }
            }
            else
                Console.WriteLine(
                   "A connection string has not been defined in the system environment variables. " +
                   "Add a environment variable named 'storageconnectionstring' with your storage " +
                   "connection string as a value.");


        }
    }
}
