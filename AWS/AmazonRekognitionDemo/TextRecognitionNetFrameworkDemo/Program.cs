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
        public static  async Task Main(string[] args)
        {


            // create s3Client
            s3Client =  new AmazonS3Client(bucketRegion);

            bool bucketExists = await AmazonS3Util.DoesS3BucketExistAsync(s3Client, bucketName);


            var result =  bucketExists ? "Bucket Exists" : "Bucket does not Exist";
            Console.WriteLine($"{result} ");

            if(!bucketExists)
            {
                Console.WriteLine($"Creating bucket : {bucketName}");
                var bucketRequest = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };

                PutBucketResponse putBucketResponse =  await s3Client.PutBucketAsync(bucketRequest);

                Console.WriteLine(putBucketResponse.HttpStatusCode);

                
            }
            var bucketLocation =   await FindBucketLocationAsync(s3Client);

            Console.WriteLine($"Bucket Location: { bucketLocation}");

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient();
            var photo = @"20181231_123556.jpg";
            DetectTextRequest detectTextRequest = new DetectTextRequest()
            {
                Image = new Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    {
                        Name = photo,
                        Bucket = bucketName
                    }
                }
            };

            try
            {
                DetectTextResponse detectTextResponse = await rekognitionClient.DetectTextAsync(detectTextRequest);
                Console.WriteLine("Detected lines and words for " + photo);
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

        //public static string GetServiceOutput()
        //{
        //    StringBuilder sb = new StringBuilder(1024);
        //    using (StringWriter sr = new StringWriter(sb))
        //    {
        //        sr.WriteLine("===========================================");
        //        sr.WriteLine("Welcome to the AWS .NET SDK!");
        //        sr.WriteLine("===========================================");

        //        // Print the number of Amazon EC2 instances.
        //        IAmazonEC2 ec2 = new AmazonEC2Client();
        //        DescribeInstancesRequest ec2Request = new DescribeInstancesRequest();

        //        try
        //        {
        //            DescribeInstancesResponse ec2Response = ec2.DescribeInstances(ec2Request);
        //            int numInstances = 0;
        //            numInstances = ec2Response.Reservations.Count;
        //            sr.WriteLine(string.Format("You have {0} Amazon EC2 instance(s) running in the {1} region.",
        //                                       numInstances, ConfigurationManager.AppSettings["AWSRegion"]));
        //        }
        //        catch (AmazonEC2Exception ex)
        //        {
        //            if (ex.ErrorCode != null && ex.ErrorCode.Equals("AuthFailure"))
        //            {
        //                sr.WriteLine("The account you are using is not signed up for Amazon EC2.");
        //                sr.WriteLine("You can sign up for Amazon EC2 at http://aws.amazon.com/ec2");
        //            }
        //            else
        //            {
        //                sr.WriteLine("Caught Exception: " + ex.Message);
        //                sr.WriteLine("Response Status Code: " + ex.StatusCode);
        //                sr.WriteLine("Error Code: " + ex.ErrorCode);
        //                sr.WriteLine("Error Type: " + ex.ErrorType);
        //                sr.WriteLine("Request ID: " + ex.RequestId);
        //            }
        //        }
        //        sr.WriteLine();

        //        // Print the number of Amazon SimpleDB domains.
        //        IAmazonSimpleDB sdb = new AmazonSimpleDBClient();
        //        ListDomainsRequest sdbRequest = new ListDomainsRequest();

        //        try
        //        {
        //            ListDomainsResponse sdbResponse = sdb.ListDomains(sdbRequest);

        //            int numDomains = 0;
        //            numDomains = sdbResponse.DomainNames.Count;
        //            sr.WriteLine(string.Format("You have {0} Amazon SimpleDB domain(s) in the {1} region.",
        //                                       numDomains, ConfigurationManager.AppSettings["AWSRegion"]));
        //        }
        //        catch (AmazonSimpleDBException ex)
        //        {
        //            if (ex.ErrorCode != null && ex.ErrorCode.Equals("AuthFailure"))
        //            {
        //                sr.WriteLine("The account you are using is not signed up for Amazon SimpleDB.");
        //                sr.WriteLine("You can sign up for Amazon SimpleDB at http://aws.amazon.com/simpledb");
        //            }
        //            else
        //            {
        //                sr.WriteLine("Caught Exception: " + ex.Message);
        //                sr.WriteLine("Response Status Code: " + ex.StatusCode);
        //                sr.WriteLine("Error Code: " + ex.ErrorCode);
        //                sr.WriteLine("Error Type: " + ex.ErrorType);
        //                sr.WriteLine("Request ID: " + ex.RequestId);
        //            }
        //        }
        //        sr.WriteLine();

        //        // Print the number of Amazon S3 Buckets.
        //        IAmazonS3 s3Client = new AmazonS3Client();

        //        try
        //        {
        //            ListBucketsResponse response = s3Client.ListBuckets();
        //            int numBuckets = 0;
        //            if (response.Buckets != null &&
        //                response.Buckets.Count > 0)
        //            {
        //                numBuckets = response.Buckets.Count;
        //            }
        //            sr.WriteLine("You have " + numBuckets + " Amazon S3 bucket(s).");
        //        }
        //        catch (AmazonS3Exception ex)
        //        {
        //            if (ex.ErrorCode != null && (ex.ErrorCode.Equals("InvalidAccessKeyId") ||
        //                ex.ErrorCode.Equals("InvalidSecurity")))
        //            {
        //                sr.WriteLine("Please check the provided AWS Credentials.");
        //                sr.WriteLine("If you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
        //            }
        //            else
        //            {
        //                sr.WriteLine("Caught Exception: " + ex.Message);
        //                sr.WriteLine("Response Status Code: " + ex.StatusCode);
        //                sr.WriteLine("Error Code: " + ex.ErrorCode);
        //                sr.WriteLine("Request ID: " + ex.RequestId);
        //            }
        //        }
        //        sr.WriteLine("Press any key to continue...");
        //    }
        //    return sb.ToString();
        //}
    }
}