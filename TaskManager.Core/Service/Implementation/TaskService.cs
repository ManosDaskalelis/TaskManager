using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Data;
using TaskManager.Core.Exceptions.TaskExceptions;
using TaskManager.Core.Models;
using TaskManager.Core.Service.Interface;

namespace TaskManager.Core.Service.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddTaskAsync(TaskItemEntity task)
        {
            try
            {
                _appDbContext.Add(task);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TaskCreationException("Αποτυχία δημιουργίας εργασίας.", ex);
            }
        }

        public async Task DeleteTaskByIdAsync(int taskId, int userId)
        {
           try
            {
                var taskToDelete = await _appDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

                if (taskToDelete == null)
                {
                    throw new TaskRetrievalException("Η εργασία δεν βρέθηκε.");
                }

                _appDbContext.Tasks.Remove(taskToDelete);
                await _appDbContext.SaveChangesAsync();
            }
            catch (TaskRetrievalException)
            {
                throw;
            }
        }

        public async Task<List<TaskItemEntity>> GetAllTasksForUserAsync(int userId)
        {
            try
            {
                return await _appDbContext.Tasks.Where(t => t.UserId == userId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new TaskRetrievalException("Αποτυχία φόρτωσης εργασιών.", ex);
            }
        }

        public async Task MarkCompletedAsync(int taskId)
        {
            try
            {
                var task = await _appDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
                if (task == null)
                    throw new TaskUpdateException("Η εργασία δεν βρέθηκε.");

                task.IsComplete = true;
                task.UpdatedAt = DateTime.UtcNow;

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not TaskUpdateException)
            {
                throw new TaskUpdateException("Αποτυχία ενημέρωσης εργασίας.", ex);
            }
        }

        public async Task UpdateTaskAsync(int taskId, TaskItemEntity updatedTask)
        {
            try
            {
                var existingTask = await _appDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == updatedTask.UserId);

                if (existingTask == null)
                {
                    throw new Exception("Η εργασία δεν βρέθηκε ή δεν ανήκει στον χρήστη.");
                }

                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.Category = updatedTask.Category;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.UpdatedAt = DateTime.Now;
                existingTask.IsComplete = updatedTask.IsComplete;

                _appDbContext.Tasks.Update(existingTask);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Αποτυχία ενημέρωσης εργασίας.", ex);
            }
        }

    }
}
