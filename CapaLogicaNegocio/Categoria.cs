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
   public class Categoria
    {
       private Conexion M = new Conexion();

        private Int32 m_IdC;
        private Int32 m_IdCategoria;
        private String m_Descripcion;

        public Int32 IdC {
            get { return m_IdC; }
            set { m_IdC = value; }
        }
        public Int32 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

        public String Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }

        public DataTable Listar() {
            return M.Listado("SVC_SLCT_CATEGORIA",null);
        }

        public String RegistrarCategoria() {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@Descripcion",m_Descripcion));
                lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("SVC_INS_REGISTRA_CATEGORIA", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BuscarCategoria(String objDescripcin) {
            List<Parametro> lst = new List<Parametro>();
            DataTable dt = new DataTable();
            try
            {
                lst.Add(new Parametro("@Datos", objDescripcin));
                return dt = M.Listado("SVC_SLCT_FILTRA_CATEGORIA", lst);
            }
            catch (Exception ex)
            {    
                throw ex;
            }
        }

        public String ActualizarCategoria() { 
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@IdC",m_IdC));
                lst.Add(new Parametro("@Descripcion",m_Descripcion));
                lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("SVC_UPD_MODIFICA_CATEGORIA", ref lst);
                Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return Mensaje;
        }
    }
}
