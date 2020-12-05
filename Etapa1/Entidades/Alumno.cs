using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno : ObejtoEscuelaBase
    {       
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        
    }
}