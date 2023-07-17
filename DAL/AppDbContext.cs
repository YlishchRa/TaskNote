//using Domain.Entity;
//using Domain.ViewModels.Task;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Markup;
//using System.Xml.Serialization;
//namespace DAL
//{
//    [Serializable]
//    public class AppDbContext
//    {
//        public static List<TaskEntity> tasks { get; set; }
//        public AppDbContext() 
//        {
//            tasks = new List<TaskEntity>();
//            //Constructor();
//        }
//        public void Constructor()
//        {
//            DeserializeTasks();
//        }
//        private void DeserializeTasks()
//        {
//            using (StreamReader stream = new StreamReader(path))
//            {
//                XmlSerializer xml = new XmlSerializer(typeof(List<TaskEntity>));

//                if (tasks == null)
//                    tasks = new List<TaskEntity>();
//                try
//                {
//                    tasks = (List<TaskEntity>)xml.Deserialize(stream);
//                }
//                catch (Exception e)
//                {
//                    throw new Exception($"Database constructor error: {e.Message}");
//                }
//            }
//        }
//        private async Task SerializeTasks()
//        {
//            await using (StreamWriter stream = new StreamWriter(path))
//            {
//                XmlSerializer xml = new XmlSerializer(typeof(List<TaskEntity>));

//                if (tasks == null)
//                    tasks = new List<TaskEntity>();

//                try
//                {
//                   xml.Serialize(stream,tasks);
//                }
//                catch (Exception e)
//                {
//                    throw new Exception($"Database constructor error: {e.Message}");
//                }
//            }
//        }
//        public async Task Add(TaskEntity task)
//        {
//            task.Id = tasks.Count+1;
//            tasks.Add(task);
//            await SerializeTasks();
//        }
//        public async Task Delete(TaskEntity task)
//        {
//            bool found = false;
//            for(int i = 0; i < tasks.Count; i++) 
//            {
//                if(tasks.ElementAt(i) == task)
//                {
//                    tasks.RemoveAt(i);
//                    found = true;
//                }
//            }

//            if (found)
//            {
//                for (int i = 0; i < tasks.Count; ++i)
//                {
//                    tasks.ElementAt(i).Id = i;
//                }
//                await SerializeTasks();
//            }
//        }
//        public async Task Update(TaskEntity task)
//        {

//            bool changed = false;
//            for(int i =0; i < tasks.Count; i++)
//            {
//                if(tasks.ElementAt(i) == task)
//                {
//                    tasks[i] = task;
//                    changed = true;
//                }
//            }

//            if(changed)
//                await SerializeTasks();

//        }
//        public async Task<TaskEntity> Find(CreateTaskViewModel model)
//        {
//            foreach(TaskEntity taskEntity in tasks)
//            {
//                if (taskEntity.Created == DateTime.Today && taskEntity.Name == model.Name)
//                {
//                    return taskEntity;
//                }
//            }
//            return null;
//        }
//        public List<TaskEntity> GetAll()
//        {
//            return tasks;
//        }
//    }
//}
