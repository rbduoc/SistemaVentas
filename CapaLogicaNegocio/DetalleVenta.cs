using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class DetalleVenta
    {
       Conexion M = new Conexion();
       public Int32 IdProducto { get; set; }
       public Int32 IdVenta { get; set; }
       public Int32 Cantidad { get; set; }
       public Decimal PUnitario { get; set; }
       public Decimal Igv { get; set; }
       public Decimal SubTotal { get; set; }

       public String RegistrarDetalleVenta() {
           List<Parametro> lst = new List<Parametro>();
           String Mensaje = "";
           try{
               lst.Add(new Parametro("@IdProducto", IdProducto));
               lst.Add(new Parametro("@IdVenta",IdVenta));
               lst.Add(new Parametro("@Cantidad",Cantidad));
               lst.Add(new Parametro("@PrecioUnitario",PUnitario));
               lst.Add(new Parametro("@Igv",Igv));
               lst.Add(new Parametro("@SubTotal",SubTotal));
               lst.Add(new Parametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,100));
               M.EjecutarSP("RegistrarDetalleVenta", ref lst);
               Mensaje = lst[6].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
           return Mensaje;
       }
    }
}
