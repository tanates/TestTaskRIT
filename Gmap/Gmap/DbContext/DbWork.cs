using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmap.DbContext
{
    class DbWork
    {
        string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";
        public List<Marker> markers { get; set; }
        private bool CheckDatabaseExists()//Метод для проверки есть ли у нас База данных MarkersDB 
        {
            bool result = false;
            string databaseName = "MarkersDB";//переменная с именем БД
            try
            {
                SqlConnection connection = new SqlConnection(con);
                string sqlCreateDbQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);//Запрос  каторый запрашивает id по имени каторый мы передае в databaseName 
                //если что там нам данный звпрос возврашает  то значить БД сушиствует , а в другом случии значет ее нет
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(sqlCreateDbQuery,connection))
                    {
                        connection.Open();
                        object resultObj = command.ExecuteScalar();//создаю обьект в каторый передаю результат 
                        int databaseID = 0;
                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }
                        connection.Close();
                        result = (databaseID > 0);//по сути запрос возврашает id нашей дб , если дб не будет не чего не вернется ,в данном случии будет id=5 , главное не ноль если ноль то нет БД
                    }
                }
            } 
            catch {
                result = false;
            }

            return result;
        }
        private bool CheckTableExists()//метод для проверки есть ли у  нас Таблица Markers
        {
            bool result = false;
            string tableName = "Markers";
            try
            {
                SqlConnection connection = new SqlConnection(con);
                string sqlCreatTableQuery = string.Format(" USE MarkersDB ; SELECT COUNT(*) FROM sys.sysobjects WHERE name='{0}'", tableName);
                using (connection) {

                    using (SqlCommand command=  new SqlCommand(sqlCreatTableQuery, connection))
                    {
                        connection.Open();
                        object resultObj = command.ExecuteScalar();
                        int tableID = 0;
                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out tableID);
                        }
                        connection.Close();
                        result = (tableID > 0);
                    }
                
                }
            }
            catch
            {

                result = false;
            }


            return result;
        }
        public void TableCreat ()/*данный метод отвечает , за вставку данных */
        {


            bool resultDbCheck = CheckDatabaseExists();
            bool resultTableCheck = CheckTableExists(); 
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                try
                {

                    if (!resultDbCheck)
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = "CREATE DATABASE MarkersDB;";
                        command.ExecuteNonQuery();
                        TableCreat();
                    }
                    else
                    {
                        if (!resultTableCheck)
                        {
                            try
                            {
                               
                                SqlCommand command = new SqlCommand();
                                command.Connection = connection;
                                command.CommandText = "USE MarkersDB; CREATE TABLE Markers (ID INT PRIMARY KEY IDENTITY(1,1),Latitude FLOAT,Longitude FLOAT);" +
                                    " INSERT INTO Markers (Latitude, Longitude) VALUES (55.7558, 37.6173); " +
                                    "INSERT INTO Markers (Latitude, Longitude) VALUES (40.7128, -74.0060);";
                                command.ExecuteNonQuery();
                                TableCreat();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            
                        }

                    }
                    
                }
                catch (SqlException ex)
                {  
                    
                }
            }

        }
         
        public List<Marker> getValue()
        {
           
               using (SqlConnection connection = new SqlConnection(con))
                {
                try
                {
                    markers =  new List<Marker>();
                    string sqlQuery = string.Format(" USE MarkersDB ;SELECT * FROM dbo.Markers");
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Marker marker = new Marker()
                        {
                            longitude = double.Parse(reader["Longitude"].ToString()),
                            latitude = double.Parse(reader["Latitude"].ToString()),
                            id = Int32.Parse(reader["id"].ToString())
                        };

                        markers.Add(marker);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"{ex}");
                }
                  


                }
            
            return markers;
        }

        public  void addTableValue(Marker marker)
        {
            try
            {
                string sqlInsertNewMarker = "USE MarkersDB; UPDATE Markers SET Latitude = @latitude, Longitude = @longitude WHERE ID = @id";
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlInsertNewMarker,connection))
                    {
                        command.Parameters.AddWithValue("@latitude", marker.latitude);
                        command.Parameters.AddWithValue("@longitude", marker.longitude);
                        command.Parameters.AddWithValue("@id", marker.id);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show($"{ex}");
            }
        }

 
    }
}
