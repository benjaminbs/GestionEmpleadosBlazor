using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleadosBlazor.Shared.Models
{
    public class EmpleadoList
    {
        public List<Empleado>? Empleados { get; set; }
        public string? stringSearch { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
