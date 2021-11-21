using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrdenEntity : DBEntity
    {
        public OrdenEntity()
        {
            Id = Id ?? new ProductoEntity();
        }
        public int? IdOrden { get; set; }
        public int? IdProducto { get; set; }
        public virtual ProductoEntity Id { get; set; }
        public int CantidadProducto { get; set; }
        public bool Estado { get; set; }
    }
}
