﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConfigurationManager2
{
    internal class Program
    {
static void Main(string[] args)  
        {  
            ReadAllSettings();  
            ReadSetting("Setting1");  
            ReadSetting("NotValid");  
            AddUpdateAppSettings("NewSetting", "May 7, 2014");  
            AddUpdateAppSettings("Setting1", "May 8, 2014");  
            ReadAllSettings();  
        }  

        static void ReadAllSettings()  
        {  
            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  

                if (appSettings.Count == 0)  
                {  
                    Console.WriteLine("AppSettings is empty.");  
                }  
                else  
                {  
                    foreach (var key in appSettings.AllKeys)  
                    {  
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);  
                    }  
                }  
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error reading app settings");  
            }  
        }  

        static void ReadSetting(string key)  
        {  
            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  
                string result = appSettings[key] ?? "Not Found";  
                Console.WriteLine(result);  
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error reading app settings");  
            }  
        }  

        static void AddUpdateAppSettings(string key, string value)  
        {  
            try  
            {  
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  
                var settings = configFile.AppSettings.Settings;  
                if (settings[key] == null)  
                {  
                    settings.Add(key, value);  
                }  
                else  
                {  
                    settings[key].Value = value;  
                }  
                configFile.Save(ConfigurationSaveMode.Modified);  
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);  
            }  
            catch (ConfigurationErrorsException)  
            {  
                Console.WriteLine("Error writing app settings");  
            }  
        }  

        static void ReadProducts()  
        {  
            var connectionString = ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString;  
            string queryString = "SELECT Id, ProductName FROM dbo.Products;";  
            using (var connection = new SqlConnection(connectionString))  
            {  
                var command = new SqlCommand(queryString, connection);  
                connection.Open();  
                using (var reader = command.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));  
                    }  
                }  
            }  
        }  
    }
}