using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleadosBlazor.Shared.Models
{
    public class Empleado
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        public string? NombreEmp { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        public string? EmpresaEmp { get; set; }

        public string? CorreoAsigEmp { get; set; }

        [RegularExpression((@"^\d+$"), ErrorMessage = "Ingrese unicamente números")]
        public string? CelAsigEmp { get; set; }

        [RegularExpression((@"^\d+$"), ErrorMessage = "Ingrese unicamente números")]
        public string? TelFijoAsigEmp { get; set; }

        [RegularExpression((@"^\d+$"), ErrorMessage = "Ingrese unicamente números")]
        public int? ExtAsigEmp { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
