using System;
using System.Collections.Generic;
using TaskList.Domain.Entities;
using TaskList.Domain.Mappers;
using TaskList.Domain.Models;
using TaskList.EF.Repositories;

namespace TaskList.Application.Services
{
    public class TaskService
    {
        TaskRepository repository = new TaskRepository();

        public void Add(TaskModel model)
        {
            Task newTask = AutoMapperConfig.Mapper.Map<Task>(model);
            
            repository.Add(newTask);
        }

        public void Remove(Int32 taskId)
        {
            repository.Remove(taskId);
        }

        public List<TaskModel> GetAll()
        {
            List<Task> taskList = repository.GetAll();

            List<TaskModel> taskListModel = AutoMapperConfig.Mapper.Map<List<TaskModel>>(taskList);
            
            return taskListModel;
        }

        public TaskModel Get(Int32 taskId)
        {
            Task dbTask = repository.Get(taskId);

            TaskModel taskModel = AutoMapperConfig.Mapper.Map<TaskModel>(dbTask);

            return taskModel;
        }
        
        public void Update(TaskModel model)
        {
            var dbTask = repository.Get(model.Id);

            dbTask.Description = model.Description;
            dbTask.Name = model.Name;
            dbTask.AddEvent(model.Status);

            repository.Update(dbTask);
        }
    }
}
