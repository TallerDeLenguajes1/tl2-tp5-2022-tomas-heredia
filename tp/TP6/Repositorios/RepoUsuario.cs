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
    public class RepoUsuario:IRepoUsuario {
        
        //conexion con db
        string connectionString = "Data Source= bases/datos.db;Cache=Shared"  ;
        public RepoUsuario(){
        
        }
        public void cargarUsuario(Usuario usuario){
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Usuario (Nombre,Usuario,Contrasenia,rol) VALUES (@nom, @us, @con,@rol)", conexion);
                insertar.Parameters.AddWithValue("@nom", usuario.nombre);
                insertar.Parameters.AddWithValue("@us", usuario.usuario);
                insertar.Parameters.AddWithValue("@con", usuario.contrasenia);
                insertar.Parameters.AddWithValue("@rol", usuario.rol);
                try
                {
                    insertar.ExecuteReader();
                    conexion.Close();
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    conexion.Close();
                    
                }
            }
        }

        public bool verificarUsuario(Usuario Usuario){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("Select * from Usuario WHERE Usuario= @usuario and Contraseña = @contrasenia", conexion);
               
                insertar.Parameters.AddWithValue("@usuario", Usuario.usuario);
                insertar.Parameters.AddWithValue("@contrasenia", Usuario.contrasenia);
           
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
        public List<Usuario> ConsultaUsuario(){
            List<Usuario> ListaUsuarios = new List<Usuario>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Usuario", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {   
               

                                                              //ID,          Nombre               usuario         contraseña           rol
                    ListaUsuarios.Add(new Usuario(query.GetInt32(0), query.GetString(1), query.GetString(2), query.GetString(4), query.GetString(5)));
                    }
                conexion.Close();
                }
            return ListaUsuarios;
      } 
      public bool EliminarUsuario(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("DELETE FROM Usuario WHERE Id = @Id", conexion);
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