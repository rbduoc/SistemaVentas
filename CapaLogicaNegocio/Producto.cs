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
        private Decimal m_PrecioCompra;
        private Decimal m_PrecioVenta;
        private DateTime m_FechaVencimiento;

        public Int32 IdP{
            get { return m_IdP; }
            set{m_IdP=value;}
        }

        public Int32 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

        public String Producto
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

        public Decimal PrecioCompra
        {
            get { return m_PrecioCompra; }
            set { m_PrecioCompra = value; }
        }

        public Decimal PrecioVenta
        {
            get { return m_PrecioVenta; }
            set { m_PrecioVenta = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return m_FechaVencimiento; }
            set { m_FechaVencimiento = value; }
        }

        public DataTable Listar()
        {
            return M.Listado("ListadoProductos", null);
        }

        public DataTable BusquedaProductos(String objDatos) {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@Datos", objDatos));
                dt = M.Listado("FiltrarDatosProducto", lst);
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
                lst.Add(new Parametro("@IdCategoria", m_IdCategoria));
                lst.Add(new Parametro("@Nombre", m_Producto));
                lst.Add(new Parametro("@Marca", m_Marca));
                lst.Add(new Parametro("@Stock", m_Stock));
                lst.Add(new Parametro("@PrecioCompra", m_PrecioCompra));
                lst.Add(new Parametro("@PrecioVenta", m_PrecioVenta));
                lst.Add(new Parametro("@FechaVencimiento", m_FechaVencimiento));
                lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarProducto", ref lst);
                Mensaje = lst[7].Valor.ToString();
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
                lst.Add(new Parametro("@IdProducto",m_IdP));
                lst.Add(new Parametro("@IdCategoria", m_IdCategoria));
                lst.Add(new Parametro("@Nombre", m_Producto));
                lst.Add(new Parametro("@Marca", m_Marca));
                lst.Add(new Parametro("@Stock", m_Stock));
                lst.Add(new Parametro("@PrecioCompra", m_PrecioCompra));
                lst.Add(new Parametro("@PrecioVenta", m_PrecioVenta));
                lst.Add(new Parametro("@FechaVencimiento", m_FechaVencimiento));
                lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarProducto", ref lst);
                Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}