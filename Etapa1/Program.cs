using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
           
           var engine = new EscuelaEngine();
           engine.inicializar();
           var objetosEscuela = engine.ListaObj(traerEvaluaciones:false,traerAsignaturas:false);
                           

        Util.printTitle(engine.Escuela.Nombre);
                       
        var dicc = engine.GetObjetosDiccionario();                            


           //Util.Timbrar();
           /*Util.printTitle($"Bienvenidos a la Escuela {escuela1.Escuela.Nombre}");
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
           }*/
            
        }

        
    }
}
