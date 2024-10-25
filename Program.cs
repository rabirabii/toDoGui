using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Services;
using ToDoApp.Ui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ToDoApp
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Setup DI
            var services = new ServiceCollection();

            // Register configuration instance
            services.AddSingleton(Configuration);

            // Register TodoServiceClass
            services.AddScoped<TodoServiceClass>();

            // Register your main form
            services.AddTransient<MainForm>();

            // Build service provider
            ServiceProvider = services.BuildServiceProvider();

            // Run application
            using (var scope = ServiceProvider.CreateScope())
            {
                var todoUi = scope.ServiceProvider.GetRequiredService<MainForm>();
                Application.Run(todoUi);
            }
        }
    }
}