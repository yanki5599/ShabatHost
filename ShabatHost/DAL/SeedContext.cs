using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ShabatHost.DAL
{
    internal class SeedContext
    {
        DBContext _dbContext;
        
        public SeedContext(DBContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public  void EnsureDataBaseSetup()
        {
            try
            {
                EnsureDataBase();
                EnsureTables();
                //SeedData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

        }
        private static string GetInitConnString()
        {
            var config = new ConfigurationBuilder()
                        .AddUserSecrets<Program>()
                        .Build();
            string? connectionString = config["initConnectionString"];
            if (connectionString == null)
                throw new Exception("Cannot read conn striong from secrets");
            return connectionString;
        }


        private  void EnsureDataBase()
        {
            string quary = @$" 
                use master;
                IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '{DBConfig.databaceName}')
                                BEGIN
                                    CREATE DATABASE [{DBConfig.databaceName}]
                                END";
            ExecuteInitQuary(quary, GetInitConnString());

        }

        public  int ExecuteInitQuary(string queryStr, string connStringinit)
        {
            int affectedRows = 0;

            using (SqlConnection conn = new SqlConnection(connStringinit))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    try
                    {
                        conn.Open();
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("An error occured: " + ex.Message);
                        throw;//return -1;
                    }
                }
            }
            return affectedRows;
        }
        private  void EnsureTables()
        {
            try
            {
                // Create Guests table if not exists
                string createGuestsTableQuery = $@"
                use {DBConfig.databaceName};
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Guests' AND type = 'U')
                BEGIN
		        	create table Guests(
		        		ID int primary key identity,
		        		name nvarchar(20) unique
		        		);
		        END";

                _dbContext.ExecuteNonQuery(createGuestsTableQuery);

                // Create Categories table if not exists
                string createCategoriesTableQuery = $@"
                use {DBConfig.databaceName};
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories' AND type = 'U')
                BEGIN
		        		create table Categories(
                        	ID int primary key identity,
                        	name nvarchar(20) unique
                        );
		        END";

                _dbContext.ExecuteNonQuery(createCategoriesTableQuery);

                // Create Food table if not exists
                string createFoodTableQuery = $@"
                use {DBConfig.databaceName};
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Food' AND type = 'U')
                BEGIN
		        	create table Food(
		        		ID int primary key identity,
		        		Guest_ID int foreign key references Guests(ID),
		        		Category_ID int foreign key references Categories(ID),
		        		name nvarchar(20),
		        		constraint AK_CatFoodGuest unique(Guest_ID,Category_ID,name)
		        	);
		        END";

                _dbContext.ExecuteNonQuery(createFoodTableQuery);



                Console.WriteLine("Tables created or already exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating tables: {ex.Message}");
            }
        }



        /*private void SeedData()
        {
            const string idNat = "315175455";
            const string fname = "Jacob";
            const string lname = "Gottlib";
            const string password = "1234";
            var now = DateTime.Now;
            DateTime tomorrow = new DateTime(now.Year, now.Month, now.Day + 1);

            try
            {
                string quary = $@"
                    
                    
                    
                    
                    

                    
                    
                    
                    
                    end";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter(
                    new SqlParameter(
                    new SqlParameter(
                    new SqlParameter(
                    new SqlParameter(
                };



                DBContext.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error inserting emp and pass:" + ex.Message);
                throw;
            }


        }*/


    }

}
