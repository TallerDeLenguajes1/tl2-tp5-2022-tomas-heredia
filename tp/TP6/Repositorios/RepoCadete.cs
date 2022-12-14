using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyApp;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace Repo
{
    public class RepoCadete:IRepoCadete {
        
        //conexion con db
        string connectionString = "Data Source= bases/datos.db;Cache=Shared"  ;
        public RepoCadete(){
        
        }

        public bool cargarCadete(Cadete Cadete){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Cadete (Nombre,Direccion,Telefono) VALUES (@nom, @dire, @tel)", conexion);
                insertar.Parameters.AddWithValue("@nom", Cadete.nombre);
                insertar.Parameters.AddWithValue("@dire", Cadete.direccion);
                insertar.Parameters.AddWithValue("@tel", Cadete.telefono);
                try
                {
                    insertar.ExecuteReader();
                    conexion.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    conexion.Close();
                    return false;
                }
            }

        }
        public List<Cadete>GetCadetes(){
            List<Cadete> ListaCadetes = new List<Cadete>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Cadete", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {               
                        var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }
                                                   //ID,          Nombre               Direc         Telefono           
                        ListaCadetes.Add(new Cadete(query.GetInt32(0), query.GetString(1), query.GetString(3), Telefono));
                    }
                conexion.Close();
                }
            return ListaCadetes;
      } 
      public bool EliminarCadete(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("DELETE FROM Cadete WHERE Id = @Id", conexion);
                select.Parameters.AddWithValue("@Id",id);
                try
                {
                    select.ExecuteReader();
                    conexion.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    conexion.Close();
                    return false;
                }
            }


        }
    public Cadete TomarCadete(int id){
         using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                Cadete nuevo = new Cadete();
                conexion.Open();
                SqliteCommand insertar = new("SELECT * FROM Cadete WHERE Id = @Id ", conexion);
                insertar.Parameters.AddWithValue("@Id",id);
                var query = insertar.ExecuteReader();
                 while (query.Read())
                    {               
                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }
                                                   //ID,          Nombre               Direc         Telefono           
                     nuevo = new Cadete(query.GetInt32(0), query.GetString(1), query.GetString(3), Telefono);
                    }
                conexion.Close();
                
            return nuevo;
            }
    }
    public void ActualizarCadete(Cadete Cadete){
        using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Cadete SET Nombre = @nom, Direccion = @dire, Telefono = @tel  WHERE Id = @Id", conexion);
                    select.Parameters.AddWithValue("@nom", Cadete.nombre);
                    select.Parameters.AddWithValue("@dire", Cadete.direccion);
                    select.Parameters.AddWithValue("@tel", Cadete.telefono);
                    select.Parameters.AddWithValue("@Id",Cadete.id);
                    try
                    {
                        select.ExecuteNonQuery();
                        conexion.Close();
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        conexion.Close();
                        
                    }
            }
    }

    }
}