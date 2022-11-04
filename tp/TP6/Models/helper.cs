using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyApp;


namespace LectorCSV
{
    
    public class HelperCsv
    {
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
        public void cargarPedido(Pedido pedido){
            string padth = @"Models\Pedidos.csv";
            string cadena = $"{pedido.Nro},{pedido.Obs},{pedido.cliente},{pedido.estado}\n";
            System.IO.File.AppendAllText(padth,cadena);
        }
        public void cargarCadete(Cadete cadete){
            string padth = @"Cadetes.csv";
            string cadena = $"{cadete.id},{cadete.nombre},{cadete.descripcion},{cadete.telefono}\n";
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
                Cliente nuevo_cliente = new Cliente(Convert.ToInt32(cliente_aux[0]),cliente_aux[1],cliente_aux[2],Convert.ToInt32(cliente_aux[3]),cliente_aux[4]);
                Pedido nuevo= new Pedido(Convert.ToInt32(Fila[0]),Fila[1],nuevo_cliente,Fila[3]);
                LecturaDelArchivo.Add(nuevo);
            }
            
            StrReader.Close();
            return LecturaDelArchivo;
        }

        public void EliminarCadete(int id)
        {
            List<Cadete> cadetes = new List<Cadete>();
            cadetes = this.LeerCsvCadete(@"Models\Cadetes.csv");
            System.IO.File.WriteAllText(@"Models\Cadetes.csv","");
            foreach (var item in cadetes)
            {
                if (id != item.id)
                {
                    this.cargarCadete(item);
                }
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
