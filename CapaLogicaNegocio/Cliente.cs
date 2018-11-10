using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
    public class Cliente
    {
        private Conexion M = new Conexion();

        private String m_Dni;
        private String m_Apellidos;
        private String m_Nombres;
        private String m_Direccion;
        private String m_Telefono;


        public String Dni{
            get { return m_Dni; }
            set { m_Dni = value; }
        }

        public String Apellidos{
            get { return m_Apellidos; }
            set { m_Apellidos = value; }
        }

        public String Nombres{
            get { return m_Nombres; }
            set { m_Nombres = value; }
        }

        public String Telefono{
            get { return m_Telefono; }
            set { m_Telefono = value; }
        }

        public String Direccion{
            get { return m_Direccion; }
            set { m_Direccion = value; }
        }

        public DataTable Listado() {
           return M.Listado("ListarClientes", null);
        }

        public DataTable BuscarCliente(String objDatos) {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@Datos",objDatos));
            return dt=M.Listado("FiltrarDatosCliente",lst);
        }

        public String RegistrarCliente() {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@DNI",m_Dni));
                lst.Add(new Parametro("@Apellidos",m_Apellidos));
                lst.Add(new Parametro("@Nombres",m_Nombres));
                lst.Add(new Parametro("@Direccion",m_Direccion));
                lst.Add(new Parametro("@Telefono",m_Telefono));
                lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("RegistrarCliente", ref lst);
                Mensaje=lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ActualizarCliente()
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@DNI", m_Dni));
                lst.Add(new Parametro("@Apellidos", m_Apellidos));
                lst.Add(new Parametro("@Nombres", m_Nombres));
                lst.Add(new Parametro("@Direccion", m_Direccion));
                lst.Add(new Parametro("@Telefono", m_Telefono));
                lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCliente", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
