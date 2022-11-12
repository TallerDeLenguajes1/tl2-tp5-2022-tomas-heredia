using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyApp;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace LectorCSV
{
    
    public class Helper
    {
        //para bace de datos
        string connectionString = "Data Source= bases/datos.db;Cache=Shared"  ;
        //usar este

         public Helper(){
        
      }

        //bace de datos
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
       

        
      public List<Cadete>ConsultaCadete(){
            List<Cadete> ListaCadetes = new List<Cadete>();
        
        using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
            conexion.Open();
            SqliteCommand select = new SqliteCommand("SELECT * FROM Cadete", conexion);
            var query = select.ExecuteReader();
            while (query.Read())
                {                                          //ID,          Nombre               Direc         Telefono           
                    ListaCadetes.Add(new Cadete(query.GetInt32(0), query.GetString(1), query.GetString(3), query.GetInt32(2)));
                }
            conexion.Close();
            }
            return ListaCadetes;
      } 

        //Base de datos
        public bool cargarPedido(Pedido Pedido){

            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Pedido (Obs,Id_cliente,Id_cadete,Estado) VALUES (@obs, @idcli, @idca, @est)", conexion);
                insertar.Parameters.AddWithValue("@obs", Pedido.Obs);
                insertar.Parameters.AddWithValue("@idcli", Pedido.id_cliente);
                insertar.Parameters.AddWithValue("@idca", Pedido.id_cadete);
                insertar.Parameters.AddWithValue("@est",Pedido.estado);
                
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
         
        public List<Pedido>ConsultaPedido(){
            List<Pedido> ListaPedidos = new List<Pedido>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Pedido", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {                                                    
                        ListaPedidos.Add(new Pedido(query.GetInt32(0), query.GetString(1), query.GetInt32(2), query.GetString(3),query.GetInt32(4)));
                    }
                conexion.Close();
                }
                return ListaPedidos;
        } 

        //base de datos
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
        //base de datos
        public bool EliminarPedido(int Nro){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("DELETE FROM pedido WHERE Nro = @id", conexion);
                    select.Parameters.AddWithValue("@id",Nro);
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
       

        public void cambiarCadete(int nro, int id_cadete){

            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Pedido SET Id_Cadete = @id_cadete WHERE Nro = @nro", conexion);
                    
                    try
                    {
                        select.ExecuteReader();
                        conexion.Close();
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        conexion.Close();
                        
                    }
            }
        }

        public List<Pedido>PedidoPorCadete(){
            List<Pedido> ListaPedidos = new List<Pedido>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Pedido ORDER BY Id_Cadete", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {                                                    
                        ListaPedidos.Add(new Pedido(query.GetInt32(0), query.GetString(1), query.GetInt32(2), query.GetString(3),query.GetInt32(4)));
                    }
                conexion.Close();
                }
                return ListaPedidos;
        } 

         public List<Pedido>PedidoPorCadete(){
            List<Pedido> ListaPedidos = new List<Pedido>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Pedido ORDER BY Id_Cliente", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {                                                    
                        ListaPedidos.Add(new Pedido(query.GetInt32(0), query.GetString(1), query.GetInt32(2), query.GetString(3),query.GetInt32(4)));
                    }
                conexion.Close();
                }
                return ListaPedidos;
        } 
        

    }

  
}
