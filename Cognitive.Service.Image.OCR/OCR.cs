using Cognitive.Service.Image.OCR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.Service.Image.OCR
{
    public class OCR
    {
        public async Task<string> GetImageOCR(string key, string imagePath, string endPoint = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr")
        {
            var errorsList = new List<string>();
            string extractedResult = "";
            ImageInfo data = new ImageInfo();
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                string requestParameters = "language=unk&detectOrientation=true";
                string uri = endPoint + "?" + requestParameters;
                HttpResponseMessage response;
                byte[] byteData = ByteImage(imagePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");
                    response = await httpClient.PostAsync(uri, content);
                }
                string resultString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<ImageInfo>(resultString,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Include,
                            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                            {
                                errorsList.Add(earg.ErrorContext.Member.ToString());
                                earg.ErrorContext.Handled = true;
                            }
                        }
                    );
                    var dataLinesCount = data.regions[0].lines.Count;
                    for (int i = 0; i < dataLinesCount; i++)
                    {
                        var dataWordsCount = data.regions[0].lines[i].words.Count;
                        for (int j = 0; j < dataWordsCount; j++)
                        {
                            extractedResult += data.regions[0].lines[i].words[j].text + " ";
                        }
                        extractedResult += Environment.NewLine;
                    }
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
            return extractedResult;
        }

        static byte[] ByteImage(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
