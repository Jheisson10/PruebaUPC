using System;
using System.Collections.Generic;

#nullable disable

namespace SOL_JHEISSON_VILLAFUERTE.Models
{
    public partial class Matricula
    {
        public Matricula()
        {
            DetMatricula = new HashSet<DetMatricula>();
        }

        public long IdMatricula { get; set; }
        public string CodLineaNegocio { get; set; }
        public string CodModalEst { get; set; }
        public string CodPeriodo { get; set; }
        public string CodAlumno { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<DetMatricula> DetMatricula { get; set; }
    }
}
