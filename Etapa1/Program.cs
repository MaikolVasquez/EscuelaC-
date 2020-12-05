using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
           
           var escuela1 = new EscuelaEngine();
           escuela1.inicializar();
        
           
           //Util.Timbrar();
           Util.printTitle($"Bienvenidos a la Escuela {escuela1.Escuela.Nombre}");
           foreach (var curso in escuela1.Escuela.Cursos)
           {               
               foreach (var al in curso.Alumnos)
               {    
                   Util.printTitle($"{al.Nombre} curso {curso.Nombre}");
                   foreach (var asignatura in al.Asignaturas)
                   {
                       Util.printTitle(asignatura.Nombre);
                       foreach (var evaluacion in asignatura.Evaluaciones)
                       {
                           Console.WriteLine($"{evaluacion.Nombre} Nota {evaluacion.Nota}");
                           
                       }
                   }
               }
           }
            
        }

      

        
    }
}
