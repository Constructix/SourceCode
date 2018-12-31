using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Threading.Tasks;

namespace TextRecognitionDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            String photo = @"D:\Downloads\TextRecognition\20181231_123556.jpg";
            String bucket = "constructixelectricityreading";

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient();

            DetectTextRequest detectTextRequest = new DetectTextRequest()
            {
                Image = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Name = photo,
                        Bucket = bucket
                    }
                }
            };

            try
            {
                DetectTextResponse detectTextResponse = await  rekognitionClient.DetectTextAsync(detectTextRequest);
                Console.WriteLine("Detected lines and words for " + photo);
                foreach (TextDetection text in detectTextResponse.TextDetections)
                {
                    Console.WriteLine("Detected: " + text.DetectedText);
                    Console.WriteLine("Confidence: " + text.Confidence);
                    Console.WriteLine("Id : " + text.Id);
                    Console.WriteLine("Parent Id: " + text.ParentId);
                    Console.WriteLine("Type: " + text.Type);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
}
