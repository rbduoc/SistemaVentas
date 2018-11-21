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

        private Int32 v_IdP;
        private Int32 v_IdCategoria;
        private String v_Producto;
        private String v_Marca;
        private Int32 v_Stock;
        private Int32 v_Precio;

        public Int32 IdP{
            get { return v_IdP; }
            set{ v_IdP = value;}
        }

        public Int32 IdCategoria
        {
            get { return v_IdCategoria; }
            set { v_IdCategoria = value; }
        }

        public String ProductoNombre
        {
            get { return v_Producto; }
            set { v_Producto = value; }
        }

        public String Marca
        {
            get { return v_Marca; }
            set { v_Marca = value; }
        }

        public Int32 Stock
        {
            get { return v_Stock; }
            set { v_Stock = value; }
        }

        public Int32 Precio
        {
            get { return v_Precio; }
            set { v_Precio = value; }
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
                lst.Add(new Parametro("@ID_CATEGORIA", v_IdCategoria));
                lst.Add(new Parametro("@NOMBRE", v_Producto));
                lst.Add(new Parametro("@MARCA", v_Marca));
                lst.Add(new Parametro("@STOCK", v_Stock));
                lst.Add(new Parametro("@PRECIO", v_Precio));
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
                lst.Add(new Parametro("@ID_PRODUCTO",v_IdP));
                lst.Add(new Parametro("@ID_CATEGORIA", v_IdCategoria));
                lst.Add(new Parametro("@NOMBRE", v_Producto));
                lst.Add(new Parametro("@MARCA", v_Marca));
                lst.Add(new Parametro("@STOCK", v_Stock));
                lst.Add(new Parametro("@PRECIO", v_Precio));
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

        public String EliminarProducto(String id_producto)
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametro("@ID_PRODUCTO", id_producto));
                lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("SVC_DEL_ELIMINA_PRODUCTO", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}