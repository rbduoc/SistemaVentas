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

       public int IdCargo { get; set; }
       public int IdEmpleado { get; set; }
       public String Dni{get;set;}
       public String Apellidos{get;set;}
       public String Nombres { get; set; }
       public Char Sexo { get; set; }
       public DateTime FechaNac { get; set; }
       public String Direccion { get; set; }
       public Char EstadoCivil { get; set; }


       public String MantenimientoEmpleados() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje = "";
           try{
               lst.Add(new Parametro("@IdEmpleado", IdEmpleado));
               lst.Add(new Parametro("@IdCargo", IdCargo));
               lst.Add(new Parametro("@Dni", Dni));
               lst.Add(new Parametro("@Apellidos", Apellidos));
               lst.Add(new Parametro("@Nombres", Nombres));
               lst.Add(new Parametro("@Sexo", Sexo));
               lst.Add(new Parametro("@FechaNac", FechaNac));
               lst.Add(new Parametro("@Direccion", Direccion));
               lst.Add(new Parametro("@EstadoCivil", EstadoCivil));
               lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,100));
               M.EjecutarSP("MantenimientoEmpleados",ref lst);
               return Mensaje = lst[9].Valor.ToString();

           }
           catch (Exception ex){
               throw ex;
           }
       }

       public DataTable ListadoEmpleados() {
          return M.Listado("ListadoEmpleados", null);
       }

       public String GenerarIdEmpleado() {
           List<Parametro> lst = new List<Parametro>();
           int objIdEmpleado;
           try{
               lst.Add(new Parametro("@IdEmpleado","",SqlDbType.Int,ParameterDirection.Output,4));
               M.EjecutarSP("GenerarIdEmpleado", ref lst);
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
           return dt = M.Listado("Buscar_Empleado", lst);
       }

    }
}
