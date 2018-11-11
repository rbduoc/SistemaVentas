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
    public class Producto
    {
        private Conexion M = new Conexion();

        private Int32 m_IdP;
        private Int32 m_IdCategoria;
        private String m_Producto;
        private String m_Marca;
        private Int32 m_Stock;
        private Int32 m_Precio;

        public Int32 IdP{
            get { return m_IdP; }
            set{m_IdP=value;}
        }

        public Int32 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

        public String ProductoNombre
        {
            get { return m_Producto; }
            set { m_Producto = value; }
        }

        public String Marca
        {
            get { return m_Marca; }
            set { m_Marca = value; }
        }

        public Int32 Stock
        {
            get { return m_Stock; }
            set { m_Stock = value; }
        }

        public Int32 Precio
        {
            get { return m_Precio; }
            set { m_Precio = value; }
        }

        public DataTable Listar()
        {
            return M.Listado("SVC_SLCT_PRODUCTOS", null);
        }

        public DataTable BusquedaProductos(String objDatos) {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@DATOS", objDatos));
                dt = M.Listado("SVC_SLCT_FILTRA_PRODUCTO_NOMBRE", lst);
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return dt;
        }

        public String RegistrarProductos()
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametro("@ID_CATEGORIA", m_IdCategoria));
                lst.Add(new Parametro("@NOMBRE", m_Producto));
                lst.Add(new Parametro("@MARCA", m_Marca));
                lst.Add(new Parametro("@STOCK", m_Stock));
                lst.Add(new Parametro("@PRECIO", m_Precio));
                lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("SVC_INS_REGISTRAR_PRODUCTO", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ActualizarProductos()
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametro("@ID_PRODUCTO",m_IdP));
                lst.Add(new Parametro("@ID_CATEGORIA", m_IdCategoria));
                lst.Add(new Parametro("@NOMBRE", m_Producto));
                lst.Add(new Parametro("@MARCA", m_Marca));
                lst.Add(new Parametro("@STOCK", m_Stock));
                lst.Add(new Parametro("@PRECIO", m_Precio));
                lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("SVC_UPD_MODIFICA_PRODUCTO", ref lst);
                Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}