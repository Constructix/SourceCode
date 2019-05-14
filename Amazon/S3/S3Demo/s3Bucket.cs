using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;

namespace S3Demo
{
    public class S3Bucket<T>
    {
        public string BucketName
        {
            get;
        }
        public RegionEndpoint RegionEndPoint
        {
            get;
        }
        private IAmazonS3 _client;
        public S3Bucket(RegionEndpoint endpoint, string bucketName)
        {
            _client = new AmazonS3Client(endpoint);
            this.BucketName = bucketName;
        }

        public async Task<bool> PutData(T itemToWrite, string key)
        {
            var writeToBucketRequest = new PutObjectRequest
            {
                BucketName = this.BucketName,
                Key = key,
                ContentBody = JsonConvert.SerializeObject(itemToWrite)
                /////////////////////////////////////////////////////////////////////////////////////////////
                // content type need to investigate if this required to serialise the json string to file.
                //contentType
            };

            try
            {
                var writeToBucketResponse = await _client.PutObjectAsync(writeToBucketRequest);

                Console.WriteLine(writeToBucketResponse.HttpStatusCode);

                return true;
                if (writeToBucketResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Could not write data to S3");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.InnerException.Message);
                throw;
            }

            return false;
        }

        public async Task<T> GetData(string key)
        {
            T ItemToGet;
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = this.BucketName,
                    Key = key
                };

                var responseBody = string.Empty;
                using (GetObjectResponse response = await _client.GetObjectAsync(request))
                using (Stream streamReader = response.ResponseStream)
                using (StreamReader reader = new StreamReader(streamReader))
                {
                    responseBody = reader.ReadToEnd();
                    ItemToGet = JsonConvert.DeserializeObject<T>(responseBody);
                }
                return ItemToGet;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
