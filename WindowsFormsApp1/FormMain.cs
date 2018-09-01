using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using TaskList.Domain.Entities;
using TaskList.EF.Contexts;
using WindowsFormsTaskList;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        private CallService _service;

        public FormMain()
        {
            InitializeComponent();

            var t = new TaskListContext();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            //var t = new TaskListContext();

            //t.Tasks.Add(new TaskList.Domain.Entities.Task());

            //t.SaveChanges();

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:5874");

            //    dynamic object 


            //    var content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
            //                        Encoding.UTF8,
            //                        "application/json");

            //    var result = await client.PostAsync("/api/Task", content);
            //    string resultContent = await result.Content.ReadAsStringAsync();
            //    Console.WriteLine(resultContent);
            //}

            //dynamic obj =
            //    obj.Id = 1;
            //obj.Name = "nome task";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _service = new CallService();

            dgvTaskList.DataSource = _service.GetAllAsync();
            dgvTaskList.Columns[0].ReadOnly = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_service.Delete(Convert.ToInt32(dgvTaskList.SelectedRows[0].Cells[0].Value)))
                dgvTaskList.Rows.Remove(dgvTaskList.SelectedRows[0]);
        }

        private void dgvTaskList_SelectionChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = (dgvTaskList.SelectedRows.Count > 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _service.Update((Task)dgvTaskList.SelectedRows[0].DataBoundItem);
        }

        private void lblRefresh_Click(object sender, EventArgs e)
        {
            dgvTaskList.DataSource = _service.GetAllAsync();
            dgvTaskList.Columns[0].ReadOnly = true;
        }
    }
}
