using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ControlDesktopDomainModel.Service.ApiProvider
{
    public static class ApiMediator
    {
        private static SingletonHttpClient httpClient = SingletonHttpClient.GetInstance();
        public static Task<(string, HttpStatusCode)> Register(string login, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "login", login },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(values);

            return PostTextContentAsync(URIWrapper.Register(), httpClient, content);
        }

        public static Task<(string, HttpStatusCode)> ChangeRegisterData(string oldLogin, string oldPassword,
            string newLogin,
            string newPassword)
        {
            var values = new Dictionary<string, string>
            {
                { "old_login", oldLogin },
                { "old_password", oldPassword },
                { "new_login", newLogin },
                { "new_password", newPassword }
            };

            var content = new FormUrlEncodedContent(values);

            return PostTextContentAsync(URIWrapper.ChangeRegisterData(), httpClient, content);
        }

        public static Task<(string, HttpStatusCode)> GetCommand(string login, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "login", login },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(values);

            return PostTextContentAsync(URIWrapper.GetCommand(), httpClient, content);
        }

        public static Task<(string, HttpStatusCode)> SendFile(string login, string password, string path)
        {
            var content = new MultipartFormDataContent();

            var values = new Dictionary<string, string>
            {
                { "login", login },
                { "password", password }
            };

            foreach (var keyValuePair in values)
            {
                content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
            }

            var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(path));
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = Path.GetFileName(path),
            };
            content.Add(fileContent);

            return PostTextContentAsync(URIWrapper.SendFile(), httpClient, content);
        }

        public static Task<(string, HttpStatusCode)> SendReport(string login, string password, string report)
        {
            var values = new Dictionary<string, string>
            {
                { "login", login },
                { "password", password },
                { "report", report }
            };

            

            var content = new FormUrlEncodedContent(values);

            return PostTextContentAsync(URIWrapper.SendReport(), httpClient, content);
        }

        private static async Task<(string, HttpStatusCode)> PostTextContentAsync(string uri, HttpClient httpClient, HttpContent urlEncodedContent)
        {
            using HttpResponseMessage httpResponse = await httpClient.PostAsync(uri, urlEncodedContent);

            var content= await httpResponse.Content.ReadAsStringAsync();
            var status = httpResponse.StatusCode;

            return (content, status);
        }

        private static async Task<T> GetDeserializedJsonContentAsync<T>(string uri, HttpClient httpClient)
            where T : class
        {
            using HttpResponseMessage httpResponse = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            //TODO: Обработать ситуацию при отсутствии интернета
            try
            {
                httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299
            }
            catch (HttpRequestException ex)
            {
                switch (ex.StatusCode)
                {
                    case System.Net.HttpStatusCode.BadRequest:
                        throw new HttpRequestException("Запрос не может быть воспринят сервером");
                    case System.Net.HttpStatusCode.NotFound:
                        throw new HttpRequestException("Страница не найдена");
                    case System.Net.HttpStatusCode.RequestTimeout:
                        throw new HttpRequestException("Превышено время ожидания от сервера");
                    default:
                        break;
                }
            }


            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    return serializer.Deserialize<T>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    throw new JsonReaderException("Недействительный JSON");
                }
            }
            else
            {
                //("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;
        }
    }
}