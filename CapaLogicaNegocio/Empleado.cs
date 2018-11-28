using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class Empleado
    {
       Conexion M = new Conexion();

        private int id_cargo;
        private int id_empleado;
        private Int32 rut;
        private String dv;
        private String apellidos;
        private String nombres;
        private Char sexo;
        private DateTime fecha_nacimiento;
        private String direccion;


       public int IdCargo
        {
            get { return id_cargo; }
            set { id_cargo = value; }
        }
       public int IdEmpleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }
       public Int32 Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public String Dv
        {
            get { return dv; }
            set { dv = value; }
        }
        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
       public String Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
       public Char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
       public DateTime FechaNac
        {
            get { return fecha_nacimiento; }
            set { fecha_nacimiento = value; }
        }
       public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }


       public String RegistrarEmpleado() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje = "";
           try{
               lst.Add(new Parametro("@ID_EMPLEADO", IdEmpleado));
               lst.Add(new Parametro("@ID_CARGO", IdCargo));
               lst.Add(new Parametro("@RUT", Rut));
               lst.Add(new Parametro("@DV", Dv));
               lst.Add(new Parametro("@NOMBRES", Nombres));
               lst.Add(new Parametro("@APELLIDOS", Apellidos));
               lst.Add(new Parametro("@SEXO", Sexo));
               lst.Add(new Parametro("@FECHA_NAC", FechaNac));
               lst.Add(new Parametro("@DIRECCION", Direccion));
               lst.Add(new Parametro("@MENSAJE","",SqlDbType.VarChar,ParameterDirection.Output,100));
               M.EjecutarSP("SVC_INS_REGISTRAR_EMPLEADO", ref lst);
               return Mensaje = lst[9].Valor.ToString();

           }
           catch (Exception ex){
               throw ex;
           }
       }

        public String ActualizarEmpleado()
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@ID_EMPLEADO", IdEmpleado));
                lst.Add(new Parametro("@ID_CARGO", IdCargo));
                lst.Add(new Parametro("@RUT", Rut));
                lst.Add(new Parametro("@DV", Dv));
                lst.Add(new Parametro("@APELLIDOS", Apellidos));
                lst.Add(new Parametro("@NOMBRES", Nombres));
                lst.Add(new Parametro("@SEXO", Sexo));
                lst.Add(new Parametro("@FECHA_NAC", FechaNac));
                lst.Add(new Parametro("@DIRECCION", Direccion));
                lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("SVC_UPD_MODIFICA_EMPLEADO", ref lst);
                return Mensaje = lst[9].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String EliminarEmpleado(String id_empleado)
        {
            List<Parametro> lst = new List<Parametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametro("@ID_EMPLEADO", id_empleado));
                lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("SVC_DEL_ELIMINA_EMPLEADO", ref lst);
                return Mensaje = lst[1].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListadoEmpleados() {
          return M.Listado("SVC_SLCT_EMPLEADOS", null);
       }

       public String GenerarIdEmpleado() {
           List<Parametro> lst = new List<Parametro>();
           int objIdEmpleado;
           try{
               lst.Add(new Parametro("@ID_EMPLEADO", "",SqlDbType.Int,ParameterDirection.Output,4));
               M.EjecutarSP("SVC_PRC_GENERA_ID_EMPLEADO", ref lst);
               objIdEmpleado = Convert.ToInt32(lst[0].Valor.ToString());
           }catch (Exception ex){
               throw ex;
           }
           return Convert.ToString(objIdEmpleado);
       }

       public DataTable BuscarEmpleado(String objDatos)
       {
           DataTable dt = new DataTable();
           List<Parametro> lst = new List<Parametro>();
           lst.Add(new Parametro("@Datos", objDatos));
           return dt = M.Listado("SVC_SLCT_FILTRA_EMPLEADO", lst);
       }

        public DataTable VentasPorVendedor()
        {
            return M.Listado("SVC_SLCT_VENTAS_POR_VENDEDOR", null);
        }

    }
}
