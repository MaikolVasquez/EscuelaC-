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
            //AppDomain.CurrentDomain.ProcessExit += finalizarAplicacion;
            //AppDomain.CurrentDomain.ProcessExit += (o, s)=> Console.WriteLine("Adios  Adios");
           
           var engine = new EscuelaEngine();
           engine.inicializar();
           var objetosEscuela = engine.ListaObj(traerEvaluaciones:false,traerAsignaturas:false);
                                                                  

        var nuevoReporteador = new Reporteador(engine.GetObjetosDiccionario());        
        nuevoReporteador.getNotas();
                

        //engine.imprimirDiccionario(dicc);                        


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

        private static void finalizarAplicacion(object sender, EventArgs e)
        {
            Util.Timbrar();
            Util.printTitle("Finzalizando la eschuela chaoooo ");
        }
    }
}
