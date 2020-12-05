using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqID { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }        
        
        public List<Alumno> Alumnos { get; set; }
        public Curso()
        {
            UniqID = Guid.NewGuid().ToString();
        }
        
    }
}