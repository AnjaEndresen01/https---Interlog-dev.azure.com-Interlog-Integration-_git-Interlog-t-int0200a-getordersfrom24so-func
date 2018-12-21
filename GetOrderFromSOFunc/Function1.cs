using System;
using System.IO;
using System.Net;
using System.Xml;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace GetOrderFromSOFunc
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            

            private static string GetMD5(string text)
            {
                byte[] hashValue;
                byte[] message = System.Text.Encoding.Unicode.GetBytes(text);

                MD5 hashString = new MD5CryptoServiceProvider();
                string hex = "";

                hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += x.ToString("x2").ToLower();
                }
                return hex;
            }




            //Login to 24SO to get identityes
            string requestUrl = "http://api.24sevenoffice.com/authenticate/v001/authenticate.asmx";
            WebRequest request = WebRequest.Create(requestUrl);
            request.ContentType = "text/xml";
            request.Method = "POST";


            request.Credential credential = new Webservice.Authenticate.Credential
            {
                Username = "myUserName", //Community account, this is always an email address
                Password = GetMD5("myPassword"), // See below for a MD5 encoding example method
                ApplicationId = new Guid("00000000-0000-0000-0000-000000000000"), //YOUR ID HERE
                IdentityId = new Guid("00000000-0000-0000-0000-000000000000") //Default is empty guid (no need to edit this)
            };



            request.Authenticate.Credential credential = new Webservice.Authenticate.Credential


            XmlDocument reqbody = new XmlDocument();
            reqbody.LoadXml("credentials inn her");

            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            var trackResponse = Extensions.DeserializeFromXml<TrackingInformationResponse>(responseFromServer);



        }

    }
}
