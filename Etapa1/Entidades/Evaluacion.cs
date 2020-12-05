using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string UniqID { get; private set; }
        public string Nombre { get; set; }

        public Alumno Alumno { get; set; }
        
        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public Evaluacion()
        {
            UniqID = Guid.NewGuid().ToString();
        }
    }
}