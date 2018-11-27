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

        private Int32 v_IdEmpleado;
        private Int32 v_IdCliente;
        private String v_TipoDocumento;
        private DateTime v_FechaVenta;
        private Int32 v_Total;


        public Int32 IdEmpleado { 
            get { return v_IdEmpleado; }
            set { v_IdEmpleado = value; }
        }

       public Int32 IdCliente {
            get { return v_IdCliente; }
            set { v_IdCliente = value; }

       }
       public String TipoDocumento
       {
           get { return v_TipoDocumento; }
           set { v_TipoDocumento = value; }

       }
        public DateTime FechaVenta {
            get { return v_FechaVenta; }
            set { v_FechaVenta = value; }
       }
       public Int32 Total {
            get { return v_Total; }
            set { v_Total = value; }
       }

       //public String GenerarSerieDocumento()
       //{
       //    List<Parametro> lst = new List<Parametro>();
       //    String Serie="";
       //    try{
       //        lst.Add(new Parametro("@Serie", "", SqlDbType.VarChar, ParameterDirection.Output, 5));
       //        M.EjecutarSP("[Serie Documento]", ref lst);
       //        Serie = Convert.ToString(lst[0].Valor.ToString());
       //    }catch (Exception ex){
       //        throw ex;
       //    }
       //    return Convert.ToString(Serie);
       //}

       //public String NumeroComprobante() {
       //    List<Parametro> lst = new List<Parametro>();
       //    String NroCorrelativo="";
       //    try{
       //        lst.Add(new Parametro("@NUMERO_CORRELATIVO", "", SqlDbType.VarChar, ParameterDirection.Output, 7));
       //        M.EjecutarSP("SVC_PRC_GENERA_CORRELATIVO", ref lst);
       //        NroCorrelativo = Convert.ToString(lst[0].Valor.ToString());
       //    }catch (Exception ex){ 
       //        throw ex;
       //    }
       //    return Convert.ToString(NroCorrelativo);
       //}

       public String GenerarIdVenta() {
           List<Parametro> lst = new List<Parametro>();
           int objIdVenta;
           try{
               lst.Add(new Parametro("@IdVenta", "", SqlDbType.Int, ParameterDirection.Output, 4));
               M.EjecutarSP("SVC_PRC_GENERA_ID_VENTA", ref lst);
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
                lst.Add(new Parametro("@TipoDocumento", TipoDocumento));
                lst.Add(new Parametro("@FechaVenta",FechaVenta));
               lst.Add(new Parametro("@Total",Total));
               lst.Add(new Parametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
               M.EjecutarSP("SVC_INS_REGISTRA_VENTA", ref lst);
               return Mensaje=lst[5].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }
    }
}
