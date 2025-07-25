﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Models
{
    public class TaskItemEntity : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Category { get; set; }
        public bool IsComplete { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
