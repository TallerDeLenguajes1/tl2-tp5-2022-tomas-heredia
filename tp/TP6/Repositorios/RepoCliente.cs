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
    public class RepoCliente:IRepoCliente {
        
        //conexion con db
        string connectionString = "Data Source= bases/datos.db;Cache=Shared"  ;
        public RepoCliente(){
        
        }

        public bool cargarCliente(Cliente Cliente){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Cliente (Nombre,Direccion,Telefono,Descripcion_Direccion) VALUES (@nom, @dire, @tel,@dat)", conexion);
                insertar.Parameters.AddWithValue("@nom", Cliente.nombre);
                insertar.Parameters.AddWithValue("@dire", Cliente.direccion);
                insertar.Parameters.AddWithValue("@tel", Cliente.telefono);
                insertar.Parameters.AddWithValue("@dat", Cliente.DatosReferenciaDireccion);
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
        public List<Cliente>ConsultaCliente(){
            List<Cliente> ListaClientes = new List<Cliente>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Cliente", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {   
                var descripcion = "";
                if (query["Descripcion_Direccion"] != System.DBNull.Value)
                {
                    descripcion= query["Descripcion_Direccion"].ToString();
                }
                var Telefono = 0;
                if (query["Telefono"] != System.DBNull.Value)
                {
                    Telefono=Convert.ToInt32( query["Telefono"]);
                }

                                                              //ID,          Nombre               Direc         Telefono           descripcion
                    ListaClientes.Add(new Cliente(query.GetInt32(0), query.GetString(1), query.GetString(3), Telefono, descripcion));
                    }
                conexion.Close();
                }
            return ListaClientes;
      } 
      public bool EliminarCliente(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("DELETE FROM Cliente WHERE Id = @Id", conexion);
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


    }
}