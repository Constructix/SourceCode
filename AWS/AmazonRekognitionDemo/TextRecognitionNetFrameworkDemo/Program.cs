using System;
using System.Threading.Tasks;

using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;
using System.Text;
using Amazon;
using Amazon.S3.Util;

namespace TextRecognitionNetFrameworkDemo
{
    class Program
    {
        
        private const string bucketName = "electricityreadings";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client = null;


        static async Task<string> FindBucketLocationAsync(IAmazonS3 client)
        {
            string bucketLocation;
            var request = new GetBucketLocationRequest()
            {
                BucketName = bucketName
            };
            GetBucketLocationResponse response = await client.GetBucketLocationAsync(request);
            bucketLocation = response.Location.ToString();
            return bucketLocation;
        }

        private static S3ObjectDetail  Creates3ObjectDetail()
        {
            var photo = @"20181231_123556.jpg";

            return  new S3ObjectDetail(photo);
        }

        public static  async Task Main(string[] args)
        {
            // create s3Client
            s3Client = new AmazonS3Client(bucketRegion);
            await CheckBucketExists();

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient();
            ///////////////////////////////////////////////////////////////////////////////
            // this is the item in the bucket, not the item on the client.
            //          
            var s3ObjectDetail  = Creates3ObjectDetail();
            DetectTextRequest detectTextRequest = new DetectTextRequest()
            {
                Image = new Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    {
                        Name = s3ObjectDetail.Name,
                        Bucket = bucketName
                    }
                }
            };

            try
            {
                DetectTextResponse detectTextResponse = await rekognitionClient.DetectTextAsync(detectTextRequest);
                Console.WriteLine("Detected lines and words for " + s3ObjectDetail.Name);
                foreach (TextDetection text in detectTextResponse.TextDetections)
                {
                    Console.WriteLine("Detected: " + text.DetectedText);
                    Console.WriteLine("Confidence: " + text.Confidence);
                    Console.WriteLine("Id : " + text.Id);
                    Console.WriteLine("Parent Id: " + text.ParentId);
                    Console.WriteLine("Type: " + text.Type);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }

        private static async Task CheckBucketExists()
        {
            bool bucketExists = await AmazonS3Util.DoesS3BucketExistAsync(s3Client, bucketName);
            var result = bucketExists ? "Bucket Exists" : "Bucket does not Exist";
            Console.WriteLine($"{result} ");

            if (!bucketExists)
            {
                Console.WriteLine($"Creating bucket : {bucketName}");
                var bucketRequest = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };

                PutBucketResponse putBucketResponse = await s3Client.PutBucketAsync(bucketRequest);

                Console.WriteLine(putBucketResponse.HttpStatusCode);


            }
            var bucketLocation = await FindBucketLocationAsync(s3Client);

            Console.WriteLine($"Bucket Location: { bucketLocation}");
        }

       
    }
}