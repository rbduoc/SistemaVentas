using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class Usuarios
    {
       Conexion M = new Conexion();

       public int IdEmpleado { get; set; }
       public string User { get; set; }
       public string Password { get; set; }

       public String RegistrarUsuarios() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje = "";
           try{
               lst.Add(new Parametro("@IdEmpleado", IdEmpleado));
               lst.Add(new Parametro("@Usuario", User));
               lst.Add(new Parametro("@Contraseña", Password));
               lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
               M.EjecutarSP("RegistrarUsuario",ref lst);
               return Mensaje = lst[3].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }

       public String IniciarSesion() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje="";
           try{
               lst.Add(new Parametro("@Usuario",User));
               lst.Add(new Parametro("@Contraseña", Password));
               lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
               M.EjecutarSP("IniciarSesion",ref lst);
               return Mensaje=lst[2].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }

       public DataTable DevolverDatosSesion(String objUser,String objPassword) {
           List<Parametro> lst = new List<Parametro>();
           try{
               lst.Add(new Parametro("@Usuario", objUser));
               lst.Add(new Parametro("@Contraseña", objPassword));
               return M.Listado("DevolverDatosSesion",lst);
           }catch (Exception ex){
               throw ex;
           }
       }
    }
}
