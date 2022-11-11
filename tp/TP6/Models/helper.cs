using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyApp;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.Sqlite;

namespace LectorCSV
{
    
    public class HelperCsv
    {
        //para bace de datos
        string conexion = "Data Source=datos.db;Cache=Shared"  ;
        //usar este

        /* public void EscribirLinea( List<Alumno> ListadoElementos,string ruta)
        {
           
                using TextWriter streamWriter = File.AppendText(ruta );
                foreach (Alumno elemento in ListadoElementos)
                    {
                        Console.WriteLine(elemento);
                        
                        
                        streamWriter.WriteLine(elemento.Apellido+", "+elemento.Nombre+", " +elemento.Dni+", " + elemento.Id );
                       
                        
                    }
                
            
            
            
        } */

        //bace de datos
         public bool SubirCadetes(Cadete Cadete){
            conexion.Open();
            SqliteCommand insertar = new("INSERT INTO cadetes (Nombre,Direccion,Telefono,Id) VALUES (@nom, @dire, @tel, @id_cad)", conexion);
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
        public List<Cadete> LeerCsvCadete( string nombreDeArchivo)
        {
            FileStream MiArchivo = new FileStream(nombreDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea = "";
            List<Cadete> LecturaDelArchivo = new List<Cadete>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(',');
                Cadete nuevo= new Cadete(Convert.ToInt32(Fila[0]),Fila[1],Fila[2],Convert.ToInt32(Fila[3]));
                LecturaDelArchivo.Add(nuevo);
            }
            
            StrReader.Close();
            return LecturaDelArchivo;
        }

        //Base de datos
        public bool SubirPedido(Pedido Pedido){
            conexion.Open();
            SqliteCommand insertar = new("INSERT INTO pedidos (Obs,Id_cliente,Id_cadete,Estado) VALUES (@obs, @idcli, @idca, @est)", conexion);
            insertar.Parameters.AddWithValue("@obs", Pedido.Obs);
            insertar.Parameters.AddWithValue("@idcli", Pedido.id_cliente);
            insertar.Parameters.AddWithValue("@idca", Pedido.id_cadete);
            insertar.Parameters.AddWithValue("est",Pedido.estado);
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
         public List<Pedido> LeerCsvPedido( string nombreDeArchivo)
        {
            FileStream MiArchivo = new FileStream(nombreDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea = "";
            List<Pedido> LecturaDelArchivo = new List<Pedido>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(',');
                string[] cliente_aux = Fila[2].Split(',');
                Pedido nuevo= new Pedido(Convert.ToInt32(Fila[0]),Fila[1],Convert.ToInt32(Fila[2]),Fila[3],Convert.ToInt32(Fila[4]));
                LecturaDelArchivo.Add(nuevo);
            }
            
            StrReader.Close();
            return LecturaDelArchivo;
        }

        //base de datos
        public bool EliminarCadete(int ID){
            conexion.Open();
            SqliteCommand select = new SqliteCommand("DELETE FROM Cadete WHERE id = @Id", conexion);
            select.Parameters.AddWithValue("@id",Int32.Parse(ID));
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
        //base de datos
        public bool EliminarPedido(string Nro){
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("DELETE FROM pedido WHERE Nro = @id", conexion);
                    select.Parameters.AddWithValue("@id",Int32.Parse(Nro));
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
        public void EliminarPedido(int id)
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = this.LeerCsvPedido(@"Models\Pedidos.csv");
            System.IO.File.WriteAllText(@"Models\Pedidos.csv","");
            foreach (var item in pedidos)
            {
                if (id != item.Nro)
                {
                    this.cargarPedido(item);
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
