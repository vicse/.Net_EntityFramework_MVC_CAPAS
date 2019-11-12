using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class StudentModel
    {

        public int? StundentID { get; set; }
        
        public string Codigo { get; set; }
        
        public string StudentName { get; set; }
        
        public string LastName { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        
        public string StudentAddress { get; set; }

        public bool? Activo { get; set; }

    }
}