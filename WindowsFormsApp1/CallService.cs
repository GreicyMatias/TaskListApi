using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
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
                using (var response = client.PutAsync(TaskUrl, new StringContent(JsonConvert.SerializeObject(task))).Result)
                {
                    var result = response.Content.ReadAsStringAsync().Result;                    
                }
            }
        }
    }
}
