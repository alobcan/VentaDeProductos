using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Ventas
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        
        public Ventas()
        {
            Cantidad = 0;
        }
        public void Vender(int cantidad)
        {
            if (Cantidad == 0)
                Cantidad = cantidad;
            else
                Cantidad += cantidad;
        }
    }
}
