using Microsoft.Extensions.Configuration;
using ShabatHost.DAL;

namespace ShabatHost
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DBContext dBContext = new DBContext(GetConnString());
            SeedContext seedContext = new SeedContext(dBContext);
            seedContext.EnsureDataBaseSetup();

            Application.Run(new HostForm(dBContext));
        }
        private static string GetConnString()
        {
            var config = new ConfigurationBuilder()
                        .AddUserSecrets<Program>()
                        .Build();
            string? connectionString = config["connectionString"];
            if (connectionString == null)
                throw new Exception("Cannot read conn striong from secrets");
            return connectionString;
        }
    }
}