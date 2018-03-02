using System;
using System.IO;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = UploadSection.Settings.Url;
            FileCollection files = UploadSection.Settings.Files;

            while (true)
            {
                var multipartFormDataContent = new MultipartFormDataContent();

                foreach (FileUploadElement file in files)
                {
                    Console.WriteLine($"Adding file {file.Path} to request");
                    FileStream fileStream = File.OpenRead(file.Path);
                    var fileStreamContent = new StreamContent(fileStream);
                    multipartFormDataContent.Add(fileStreamContent, file.Name);
                }

                Console.WriteLine($"Uploading files to {url}");

                using (var httpHandler = new HttpClientHandler { AllowAutoRedirect = false })
                using (var client = new HttpClient(httpHandler))
                {
                    client.Timeout = TimeSpan.FromMinutes(30);

                    HttpResponseMessage response = client.PostAsync(new Uri(url), multipartFormDataContent).Result;

                    Console.WriteLine("Reponse is:\n");
                    Console.WriteLine(response);

                    Console.WriteLine("\n\nPress any key to upload again");
                    Console.ReadKey();
                }
            }
        }
    }
}
