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

        private int id_empleado;
        private String user;
        private String password;


        public int IdEmpleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }
       public string User
        {
            get { return user; }
            set { user = value; }
        }
       public string Password
        {
            get { return password; }
            set { password = value; }
        }

       public String  RegistrarUsuarios() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje = "";
           try{
               lst.Add(new Parametro("@ID_EMPLEADO", IdEmpleado));
               lst.Add(new Parametro("@USUARIO", User));
               lst.Add(new Parametro("@PASSWORD", Password));
               lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
               M.EjecutarSP("SVC_INS_REGISTRAR_USUARIO", ref lst);
               return Mensaje = lst[3].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }

       public String IniciarSesion() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje="";
           try{
               lst.Add(new Parametro("@USUARIO",User));
               lst.Add(new Parametro("@PASSWORD", Password));
               lst.Add(new Parametro("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
               M.EjecutarSP("SVC_PRC_INICIA_SESION", ref lst);
               return Mensaje=lst[2].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }

       public DataTable DevolverDatosSesion(String objUser,String objPassword) {
           List<Parametro> lst = new List<Parametro>();
           try{
               lst.Add(new Parametro("@USUARIO", objUser));
               lst.Add(new Parametro("@PASSWORD", objPassword));
               return M.Listado("SVC_PRC_DEVUELVE_SESION", lst);
           }catch (Exception ex){
               throw ex;
           }
       }
    }
}
