

namespace CoreEscuela.Entidades
{
    public class Evaluacion : ObejtoEscuelaBase
    {
        

        public Alumno Alumno { get; set; }
        
        public Asignatura Asignatura { get; set; }

        public double Nota { get; set; }

      
    }
}