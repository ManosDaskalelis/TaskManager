using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Core.Data;
using TaskManager.Core.Service.Implementation;
using TaskManager.Core.Service.Interface;
using TaskManager.WinForms;
using TaskManager.WinForms.Forms;

namespace TaskManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var db = services.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = services.GetRequiredService<LoginForm>();
            var loginResult = loginForm.ShowDialog();

            if (loginResult == DialogResult.OK && loginForm.LoggedInUser != null)
            {
                var mainForm = services.GetRequiredService<MainForm>();
                mainForm.SetLoggedInUser(loginForm.LoggedInUser);


                Application.Run(mainForm);
            }
            else
            {
                Application.Exit();
            }
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite("Data Source=tasks.db"));

                    services.AddScoped<ITaskService, TaskService>();
                    services.AddScoped<IUserService, UserService>();

                    services.AddScoped<MainForm>();
                    services.AddScoped<LoginForm>();
                    services.AddScoped<RegisterForm>();
                });
        }
    }
}