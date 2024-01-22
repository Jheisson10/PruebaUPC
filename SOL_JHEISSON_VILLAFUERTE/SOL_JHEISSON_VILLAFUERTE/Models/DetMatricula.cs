using System;
using System.Collections.Generic;

#nullable disable

namespace SOL_JHEISSON_VILLAFUERTE.Models
{
    public partial class DetMatricula
    {
        public string CodProducto { get; set; }
        public string Seccion { get; set; }
        public string Grupo { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long MatriculaIdMatricula { get; set; }
        public string CursoCodLineaNegocio { get; set; }
        public string CursoCodCurso { get; set; }

        public virtual Curso CursoCod { get; set; }
        public virtual Matricula MatriculaIdMatriculaNavigation { get; set; }
    }
}
