using System;
using System.Collections.Generic;

#nullable disable

namespace SOL_JHEISSON_VILLAFUERTE.Models
{
    public partial class Curso
    {
        public Curso()
        {
            DetMatricula = new HashSet<DetMatricula>();
        }

        public string CodLineaNegocio { get; set; }
        public string CodCurso { get; set; }
        public string DescCurso { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<DetMatricula> DetMatricula { get; set; }
    }
}
