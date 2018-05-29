using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_de_validaciones.Objetos
{
   public class Servicio
    {
        internal TipoDocumento TipoDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public string Nombre { get;set;}
        internal Rango Rango { get; set; }
        public long CostoServicio { get; set; }

    }
}
