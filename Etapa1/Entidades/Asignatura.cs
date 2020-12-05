using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Asignatura : ObejtoEscuelaBase
    {
       
        public List<Evaluacion> Evaluaciones { get; set; }
        
    }
}