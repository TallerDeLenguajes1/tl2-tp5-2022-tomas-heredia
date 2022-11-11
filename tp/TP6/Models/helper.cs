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
         public bool SubirCadetes(Cadete Cadete){

            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                
                SqliteCommand insertar = new("INSERT INTO Cadete (Nombre,Direccion,Telefono,Id) VALUES (@nom, @dire, @tel, @id_cad)", conexion);
                insertar.Parameters.AddWithValue("@nom", Cadete.nombre);
                insertar.Parameters.AddWithValue("@dire", Cadete.direccion);
                insertar.Parameters.AddWithValue("@tel", Cadete.telefono);
                insertar.Parameters.AddWithValue("@id_cad", Cadete.id);
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
        public void cargarPedido(Pedido pedido){
            string padth = @"Models\Pedidos.csv";
            string cadena = $"{pedido.Nro},{pedido.Obs},{pedido.id_cadete},{pedido.estado},{pedido.id_cadete}\n";
            System.IO.File.AppendAllText(padth,cadena);
        }
        public void cargarCadete(Cadete cadete){
            string padth = @"Cadetes.csv";
            string cadena = $"{cadete.id},{cadete.nombre},{cadete.direccion},{cadete.telefono}\n";
            System.IO.File.AppendAllText(padth,cadena);
        }

        public List<Cliente> LeerCsvCliente( string nombreDeArchivo)
        {
            FileStream MiArchivo = new FileStream(nombreDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea = "";
            List<Cliente> LecturaDelArchivo = new List<Cliente>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(',');
                Cliente nuevo= new Cliente(Convert.ToInt32(Fila[0]),Fila[1],Fila[2],Convert.ToInt32(Fila[3]),Fila[4]);
                LecturaDelArchivo.Add(nuevo);
            }
            
            return LecturaDelArchivo;
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
        public bool SubirPedido(Pedido Pedido){

            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Pedido (Obs,Id_cliente,Id_cadete,Estado,Nro) VALUES (@obs, @idcli, @idca, @est,@nro)", conexion);
                insertar.Parameters.AddWithValue("@obs", Pedido.Obs);
                insertar.Parameters.AddWithValue("@idcli", Pedido.id_cliente);
                insertar.Parameters.AddWithValue("@idca", Pedido.id_cadete);
                insertar.Parameters.AddWithValue("@est",Pedido.estado);
                insertar.Parameters.AddWithValue("@nro",Pedido.Nro);
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
        /* public void archivoCSV (List<Alumno> ListadoElementos, string NombreArchivo){
        

            if(!File.Exists(NombreArchivo)){
                File.Create(NombreArchivo);
                
            }
                FileStream filestream = new FileStream(NombreArchivo, FileMode.Open);
                StreamWriter streamWriter = new StreamWriter(filestream);

                foreach (Alumno elemento in ListadoElementos)
                    {
                        Console.WriteLine(elemento);
                        
                        
                        streamWriter.WriteLine(elemento.Apellido+", "+elemento.Nombre+", " +elemento.Dni+", " + elemento.Id );
                       
                        
                    }

                streamWriter.Close();    //importante
                filestream.Close();
    } */


    }

   /*  public static void LeerArchivo(string ruta)
    {
        if (!File.Exists(ruta))
        {
            Logger.Info("El archivo que se desea leer no existe");
        }

        try
        {
            using TextReader streamReader = new StreamReader(ruta + ExtensionCsv);
            var textoEnArchivo = streamReader.ReadToEnd();
            textoEnArchivo = textoEnArchivo.Replace(";", " ");
            Console.WriteLine(textoEnArchivo);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Excepción al tratar de escribir en el archivo");
        }
        
        Logger.Debug("Se leyó correctamente el archivo: " + ruta);
    } */
}
