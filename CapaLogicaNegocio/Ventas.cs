using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class Ventas
    {
       Conexion M = new Conexion();

       public int IdEmpleado { get; set; }
       public int IdCliente { get; set; }
       public string Serie { get; set; }
       public string NroComprobante { get; set; }
       public string TipoDocumento { get; set; }
       public DateTime FechaVenta { get; set; }
       public decimal Total { get; set; }

       public String GenerarSerieDocumento()
       {
           List<Parametro> lst = new List<Parametro>();
           String Serie="";
           try{
               lst.Add(new Parametro("@Serie", "", SqlDbType.VarChar, ParameterDirection.Output, 5));
               M.EjecutarSP("[Serie Documento]", ref lst);
               Serie = Convert.ToString(lst[0].Valor.ToString());
           }catch (Exception ex){
               throw ex;
           }
           return Convert.ToString(Serie);
       }

       public String NumeroComprobante(String objTipoDocumento) {
           List<Parametro> lst = new List<Parametro>();
           String NroCorrelativo="";
           try{
               lst.Add(new Parametro("@TipoDocumento", objTipoDocumento));
               lst.Add(new Parametro("@NroCorrelativo", "", SqlDbType.VarChar, ParameterDirection.Output, 7));
               M.EjecutarSP("[Numero Correlativo]", ref lst);
               NroCorrelativo = Convert.ToString(lst[1].Valor.ToString());
           }catch (Exception ex){ 
               throw ex;
           }
           return Convert.ToString(NroCorrelativo);
       }

       public String GenerarIdVenta() {
           List<Parametro> lst = new List<Parametro>();
           int objIdVenta;
           try{
               lst.Add(new Parametro("@IdVenta", "", SqlDbType.Int, ParameterDirection.Output, 4));
               M.EjecutarSP("GenerarIdVenta", ref lst);
               objIdVenta = Convert.ToInt32(lst[0].Valor.ToString());
           }catch (Exception ex){
               throw ex;
           }
           return Convert.ToString(objIdVenta);
       }

       public String RegistrarVenta() {
           String Mensaje = "";
           List<Parametro> lst = new List<Parametro>();
           try{
               lst.Add(new Parametro("@IdEmpleado",IdEmpleado));
               lst.Add(new Parametro("@IdCliente",IdCliente));
               lst.Add(new Parametro("@Serie",Serie));
               lst.Add(new Parametro("@NroDocumento",NroComprobante));
               lst.Add(new Parametro("@TipoDocumento",TipoDocumento));
               lst.Add(new Parametro("@FechaVenta",FechaVenta));
               lst.Add(new Parametro("@Total",Total));
               lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
               M.EjecutarSP("RegistrarVenta", ref lst);
               return Mensaje=lst[7].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }
    }
}
