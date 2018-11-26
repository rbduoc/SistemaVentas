using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Presentacion
{
   public class Venta
    {
       public Int32 IdVenta { get; set; }
       public Int32 Cantidad { get; set; }
       public string Descripcion { get; set; }
       public Int32 PrecioVenta { get; set; }
       public Int32 IdProducto { get; set; }
       public double Iva { get; set; }
       public Int32 SubTotal { get; set; }

       public Venta() {
           Cantidad = 0;
           Descripcion = "";
           PrecioVenta = 0;
           IdVenta = 0;
           IdProducto = 0;
            Iva = 0;
           SubTotal = 0;
       }
       public Venta(int objIdVenta,int objCantidad,string objDescripcion, Int32 objPVenta,
           int objIdProducto, double objIva, Int32 objSubTotal){
           IdVenta = objIdVenta;
           Cantidad =objCantidad;
           Descripcion = objDescripcion;
           PrecioVenta = objPVenta;
           IdProducto = objIdProducto;
            Iva = objIva;
           SubTotal = objSubTotal;
       }

    }
}
