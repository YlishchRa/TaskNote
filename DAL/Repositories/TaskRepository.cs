using DAL.Interfaces;
using Domain.Entity;
using Domain.ViewModels.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace DAL.Repositories
{
    public class TaskRepository : IBaseRepository<TaskEntity>
    {
        public List<TaskEntity> tasks { get; set; }
        string path = @"../Database/";

        public TaskRepository()
        {
            Constructor();
        }
        //public async Task Create(TaskEntity entity)
        //{
        //   await _appDbContext.Add(entity);
        //}
        //public async Task Delete(TaskEntity entity)
        //{
        //    await _appDbContext.Delete(entity);
        //}

        //public async Task<TaskEntity> Find(CreateTaskViewModel entity)
        //{
        //    return await _appDbContext.Find(entity);
        //}

        //public List<TaskEntity> GetAll()
        //{
        //   return _appDbContext.GetAll();
        //}
        //public async Task<TaskEntity> Update(TaskEntity entity)
        //{
        //    await _appDbContext.Update(entity);
        //    return entity;
        //}

        static bool IsFileEmpty(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.Length == 0;
        }

        public void Constructor()
        {
            DeserializeTasks();
        }
        private void DeserializeTasks()
        {
            using (StreamReader file = new StreamReader(path + "data.xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<TaskEntity>));

                if (tasks == null)
                    tasks = new List<TaskEntity>();
                
                try
                {
                    if(!IsFileEmpty(path + "data.xml"))
                    {
                        tasks = xml.Deserialize(file) as List<TaskEntity>;
                    }
                }
                catch (Exception e) 
                {
                    throw new Exception($"Deserialize error: {e.Message}");
                }
            }
        }
        private async Task SerializeTasks()
        {
            await using (StreamWriter stream = new StreamWriter(path + "data.xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<TaskEntity>));

                if (tasks == null)
                    tasks = new List<TaskEntity>();

                try
                {
                    xml.Serialize(stream, tasks);
                }
                catch (Exception e)
                {
                    throw new Exception($"Serialize error error: {e.Message}");
                }
            }
        }
        public async Task Add(TaskEntity task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            await SerializeTasks();
        }
        public async Task Delete(TaskEntity task)
        {
            bool found = false;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks.ElementAt(i) == task)
                {
                    tasks.RemoveAt(i);
                    found = true;
                }
            }

            if (found)
            {
                for (int i = 0; i < tasks.Count; ++i)
                {
                    tasks.ElementAt(i).Id = i;
                }
                await SerializeTasks();
            }
        }
        public async Task<TaskEntity> Update(TaskEntity task)
        {

            bool changed = false;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks.ElementAt(i) == task)
                {
                    tasks[i] = task;
                    changed = true;
                }
            }

            if (changed)
                await SerializeTasks();

            return task;

        }
        public async Task<TaskEntity> Find(CreateTaskViewModel model)
        {
            foreach (TaskEntity taskEntity in tasks)
            {
                if (taskEntity.Created == DateTime.Today && taskEntity.Name == model.Name)
                {
                    return taskEntity;
                }
            }
            return null;
        }
        public List<TaskEntity> GetAll()
        {
            return tasks;
        }

        public async Task Create(TaskEntity entity)
        {
            entity.Id = tasks.Count + 1;
            tasks.Add(entity);
            await SerializeTasks();
        }

    }
}
