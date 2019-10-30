using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Student
    {
        [Key]
        public int StundentID { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [Required]
        public string StudentAddress { get; set; }

        public bool? Activo { get; set; }

    }
}
