using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace CreateCertRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:55000/v1/hello");
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "text/html; charset=UTF-8";
            request.ClientCertificates.Add(new X509Certificate2(
                @"C:\Users\Jorge\Desktop\hic_interview_tasks-master\client_certs\user1.p12", "000user1"));
            request.Accept =
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            //request.TransferEncoding = "gzip, deflate, br";
            request.Host = "localhost:55000";
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";

            var response = request.GetResponse();

            using StreamReader sr =
                new StreamReader(response.GetResponseStream());
            var result = sr.ReadToEnd();

            sr.Close();
        }
    }
}
