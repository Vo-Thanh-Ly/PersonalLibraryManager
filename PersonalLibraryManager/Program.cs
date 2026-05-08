using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonalLibraryManager.Models;

namespace PersonalLibraryManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Đọc configuration từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Lấy connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Tạo DbContext với MySQL (Pomelo)
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            using (var context = new LibraryContext(optionsBuilder.Options))
            {
                Application.Run(new MainForm(context));
            }
        }
    }
}