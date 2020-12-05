using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso : ObejtoEscuelaBase
    {
   
        public TiposJornada Jornada { get; set; }        
        
        public List<Alumno> Alumnos { get; set; }
       
        
    }
}