using System;
using System.Linq;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Reporteador
    {
        Dictionary<ListaLaveDiccionario, IEnumerable<ObejtoEscuelaBase>> diccionario;
        public Reporteador(Dictionary<ListaLaveDiccionario, IEnumerable<ObejtoEscuelaBase>> objetoDiccionario)
        {
                if (objetoDiccionario == null)
                {
                    throw new ArgumentException($"the dyctionari is emtpy {nameof(objetoDiccionario)}");                }
                else
                {
                    diccionario = objetoDiccionario;
                }
                
        }

        public IEnumerable<Evaluacion> getEvaluaciones()
        {
            IEnumerable<Evaluacion> rta;
            if(diccionario.TryGetValue(ListaLaveDiccionario.Evaluaciones, out IEnumerable<ObejtoEscuelaBase> evaluaciones))            
            {
                return rta = evaluaciones.Cast<Evaluacion>();
            }
            {
                return rta = new List<Evaluacion>();                
            }
        }
        public IEnumerable<Evaluacion> getNotas()
        {
            var listaTemporalEvaluaciones = getEvaluaciones();
                var Nuevalist = from ev in listaTemporalEvaluaciones
                                where ev.Nota > 4
                                select ev;    
            return Nuevalist;  

            
        }
        
        public void getAlumnos()
        {
            var listaalumnos = diccionario[ListaLaveDiccionario.Alumnos].Cast<Alumno>();
            
            foreach (var alumno in listaalumnos)
            {       
                Console.WriteLine($"Alumno : {alumno.Nombre}");         
                foreach (var asignatura in alumno.Asignaturas)
                {
                    Console.WriteLine(asignatura.Nombre);
                    double nota = 0;
                    foreach (var evaluacion in asignatura.Evaluaciones)
                    {
                       nota += evaluacion.Nota; 
                    }
                    Console.WriteLine($" promedio nota : {Math.Round((nota/5),2)}");
// ya puedo sacar el promedio pero las notas estan dandose igual por cada alumno se debe arreglar                    
                }
            }
            
            
        }

    }
}