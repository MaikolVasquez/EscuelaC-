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
        public void getNotas()
        {
            var listaTemporalEvaluaciones = getEvaluaciones();
                var Nuevalist = from ev in listaTemporalEvaluaciones
                                where ev.Nota > 3
                                select ev;      
//si esta haciendo la consulta pero esta tomando los datos donde las notas son 0          
            
        }
        

    }
}