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

        private int rut;
        private String dv;
        private String apellidos;
        private String nombres;
        private String direccion;
        private String telefono;


        public int Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        public String Dv
        {
            get { return dv; }
            set { dv = value; }
        }

        public String Apellidos{
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Nombres{
            get { return nombres; }
            set { nombres = value; }
        }

        public String Telefono{
            get { return telefono; }
            set { telefono = value; }
        }

        public String Direccion{
            get { return direccion; }
            set { direccion = value; }
        }

        public DataTable Listado() {
           return M.Listado("SVC_SLCT_CLIENTES", null);
        }

        public DataTable BuscarCliente(String objDatos) {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@DATOS", objDatos));
            return dt=M.Listado("SVC_SLCT_FILTRA_CLIENTE", lst);
        }

        public String RegistrarCliente() {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@RUT", rut));
                lst.Add(new Parametro("@DV", dv));
                lst.Add(new Parametro("@NOMBRES", nombres));
                lst.Add(new Parametro("@APELLIDOS",apellidos));
                lst.Add(new Parametro("@DIRECCION",direccion));
                lst.Add(new Parametro("@TELEFONO",telefono));
                lst.Add(new Parametro("@MENSAJE","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("SVC_INS_REGISTRAR_CLIENTE", ref lst);
                Mensaje=lst[6].Valor.ToString();
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
                lst.Add(new Parametro("@RUT", rut));
                lst.Add(new Parametro("@DV", dv));
                lst.Add(new Parametro("@APELLIDOS", apellidos));
                lst.Add(new Parametro("@NOMBRES", nombres));
                lst.Add(new Parametro("@DIRECCION", direccion));
                lst.Add(new Parametro("@TELEFONO", telefono));
                lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("SVC_UPD_MODIFICA_CLIENTE", ref lst);
                Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String EliminaCliente(String id_cliente)
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@ID_CLIENTE", id_cliente));
                lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("SVC_DEL_ELIMINA_CLIENTE", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable RankingClientes()
        {
            return M.Listado("SVC_SLCT_RANKING_CLIENTES", null);
        }
    }
}
