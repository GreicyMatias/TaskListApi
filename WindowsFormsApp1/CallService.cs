using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TaskList.Domain.Entities;

namespace WindowsFormsTaskList
{
    public class CallService
    {
        private string _taskUrl;
        public string TaskUrl
        {
            get
            {
                if (_taskUrl == null)
                    _taskUrl = ConfigurationManager.AppSettings["TaskListAPIURL"].ToString();

                return _taskUrl;
            }
        }

        public List<Task> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(TaskUrl).Result)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Task>>(result);
                }
            }
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.DeleteAsync(TaskUrl+id).Result)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                        return true;
                }
            }

            return false;
        }

        public void Update(Task task)
        {
            using (var client = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(task);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = client.PutAsync(TaskUrl, byteContent).Result)
                {
                    var result = response.Content.ReadAsStringAsync().Result;                    
                }
            }
        }
    }
}
