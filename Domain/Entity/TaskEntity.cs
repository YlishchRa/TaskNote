using Domain.Enums;
namespace Domain.Entity
{
    [Serializable]
    public class TaskEntity : IEquatable<TaskEntity>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
        public Priority priority { get; set; }
        public DateTime Created { get; set; }
        public bool Equals(TaskEntity? other)
        {
            if(other != null)
                return Id == other.Id;

            return false;
        }
    }
}
