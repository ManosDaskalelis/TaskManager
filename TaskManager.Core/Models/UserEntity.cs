using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Models
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<TaskItemEntity> Tasks { get; set; }
    }
}
