using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.      
        /// </summary>
         public static int Evento;

        //Datos del Cliente
         public static Int32 IdCliente;
         public static String DocumentoIdentidad;
         public static String NombreCliente;
         public static String ApellidosCliente;

        //Datos del Producto
         public static Int32 IdProducto;
         public static String Descripcion;
         public static String Marca;
         public static Int32 Stock;
         public static Int32 PrecioVenta;

        //Datos del Empleado
         public static Int32 IdCargo;
         public static String EstadoCivil="";
         public static Int32 IdEmpleado;

        //Variables de Sesion
        public static Int32 IdEmpleadoLogueado;
        public static String NombreEmpleadoLogueado;
        public static String CargoEmpleadoLogueado;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());      
        }
    }
}
