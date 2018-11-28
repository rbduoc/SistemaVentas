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
   public class Cargo
    {
       private Conexion M = new Conexion();

        Int32 m_IdCargo;
        String m_Descripcion;

        public Int32 IdCargo
        {
            get { return m_IdCargo; }
            set { m_IdCargo = value; }
        }

        public String Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }

        public DataTable Listar() {
            return M.Listado("SVC_SLCT_CARGO", null);
        }

        public String RegistrarCargo() {
            String Mensaje = "";
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@Descripcion", m_Descripcion));
                lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("SVC_INS_REGISTRA_CARGO", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {               
               throw ex;
            }
            return Mensaje;
        }

      public String ActualizarCargo() {
            String Mensaje = "";
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@IdCargo", m_IdCargo));
                lst.Add(new Parametro("@Descripcion", m_Descripcion));
                lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,100));
                M.EjecutarSP("SVC_UPD_MODIFICA_CARGO", ref lst);
                Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {               
               throw ex;
            }
            return Mensaje;
        }

        public DataTable BusquedaCargo(String objDescripcion) {
            DataTable dt=new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@Descripcion",objDescripcion));
                return dt = M.Listado("SVC_SLCT_FILTRA_CARGO", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
