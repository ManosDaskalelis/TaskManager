using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models;

namespace TaskManager.Core.Service.Interface
{
    public interface ITaskService
    {
        Task<List<TaskItemEntity>> GetAllTasksForUserAsync(int userId);
        Task AddTaskAsync(TaskItemEntity task);
        Task MarkCompletedAsync(int taskId);
        Task DeleteTaskByIdAsync(int taskId, int userId);
        Task UpdateTaskAsync(int taskId, TaskItemEntity task);
    }
}
