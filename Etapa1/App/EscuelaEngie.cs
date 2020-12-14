using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreEscuela.Entidades

{

    class EscuelaEngine
        {
            public Escuela Escuela { get; set; }

            public List<ObejtoEscuelaBase> ListaObj(
                    bool traerCursos = true,
                    bool traerAlumnos = true,
                    bool traerAsignaturas = true,                    
                    bool traerEvaluaciones = true
            
            )
            {
                var ListaObjetos = new List<ObejtoEscuelaBase>();

                ListaObjetos.Add(Escuela);
                 if(traerCursos){ListaObjetos.AddRange(Escuela.Cursos);};
                foreach (var Curso in Escuela.Cursos)
                {
                    if(traerAlumnos){ListaObjetos.AddRange(Curso.Alumnos);};
                    foreach (var Alumno in Curso.Alumnos)
                    {
                        if(traerAsignaturas){ListaObjetos.AddRange(Alumno.Asignaturas);};
                        foreach (var asignatura in Alumno.Asignaturas)
                        {
                            if(traerEvaluaciones){ListaObjetos.AddRange(asignatura.Evaluaciones);};
                        }
                    }
                }
                return ListaObjetos;
            }
            public void EscuelaEngie()
            {
                                               
            
            }
            public Dictionary<ListaLaveDiccionario, IEnumerable<ObejtoEscuelaBase>> GetObjetosDiccionario()
            {
                var lista = new Dictionary<ListaLaveDiccionario, IEnumerable<ObejtoEscuelaBase>>();
                
                    lista.Add(ListaLaveDiccionario.Escuela, new[] {Escuela});
                    lista.Add(ListaLaveDiccionario.Cursos, Escuela.Cursos); 
                    var listaTempAlumnos = new List<Alumno>();
                    var listaTempAsignaturas = new List<Asignatura>();
                    var listaTempEvaluaciones = new List<Evaluacion>();


                    foreach (var cursos in Escuela.Cursos)
                    {
                        
                        listaTempAlumnos.AddRange(cursos.Alumnos); 
                        foreach (var Alumno in cursos.Alumnos)
                        {
                            listaTempAsignaturas.AddRange(Alumno.Asignaturas); 
                            foreach (var Asignatura in Alumno.Asignaturas)
                            {
                                listaTempEvaluaciones.AddRange(Asignatura.Evaluaciones);                                
                            }
                        }
                    }
                    lista.Add(ListaLaveDiccionario.Alumnos, listaTempAlumnos); 
                    lista.Add(ListaLaveDiccionario.Asignaturas, listaTempAsignaturas); 
                    lista.Add(ListaLaveDiccionario.Evaluaciones, listaTempEvaluaciones); 
                return lista;
            }
            public void imprimirDiccionario(Dictionary<ListaLaveDiccionario, IEnumerable<ObejtoEscuelaBase>> diccionario, bool dameAlumnos = true)
            {                
                foreach (var keyValuePair in diccionario)
                {                    
                    Util.printTitle(keyValuePair.Key.ToString());
                    foreach (var llaves in keyValuePair.Value)
                    {
                        switch (llaves)
                        {
                            case Curso cursos:
                                 Console.WriteLine(cursos.Nombre);
                            break;

                            case Alumno alumnos:
                                 
                                 foreach (var asignatura in alumnos.Asignaturas)
                                 {
                                    Console.WriteLine($"Alumno : {alumnos.Nombre}\nMateria :{asignatura.Nombre}");
                                    foreach (var evaluaciones in asignatura.Evaluaciones)
                                    {
                                        Console.WriteLine($"  {evaluaciones.Nombre} >> Nota : {evaluaciones.Nota}");
                                    }                                    
                                 }
                            break;
                                                       
                            default:

                            break;
                        }
                    }
                }
            }
            public void inicializar()
            {
                    Escuela = new Escuela("Platzi M", 2020);  
                    Escuela.Ciudad = "Bogota";
                    Escuela.Pais = "Colombia";
                    Escuela.TipoEscuela = TiposEscuela.Primaria; 


                    cargarCursos();                                          
                    
                    cargarAsignaturas();

                    cargarEvaluaciones();

                    cargarNotas();
                    
                        
            }

        private List<Evaluacion> GenerarEvaluaciones()
        {
            string[] tema = { "Inicial", "Formativa", "Parcial", "Sumativa", "Global", "Previa", "Final" };        
            string[] nivel = { "Basica", "Quiz", "Media", "Completa", "reiterativa"};

            var ListaEvaluaciones = from t in tema
                               from n in nivel                               
                               select new Evaluacion{Nombre=$"{t} {n}"};                               
            return ListaEvaluaciones.OrderBy((al)=> al.UniqID).Take(5).ToList();
        }



        public void cargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {                    
                    foreach (var asignatura in alumno.Asignaturas)
                    {     
                            asignatura.Evaluaciones = GenerarEvaluaciones();                        
                    }
                }
            }
        }
        public void cargarNotas()
        {
            
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {                    
                    foreach (var asignatura in alumno.Asignaturas)
                    {     
                            foreach (var evaluacion in asignatura.Evaluaciones)
                            {
                                Random numerorandom = new Random();
                                double numerogenerado = (numerorandom.Next(1,5) + numerorandom.NextDouble());
                                evaluacion.Nota = Math.Round(numerogenerado, 2);
                            }                     
                    }
                }
            }
        }


        private void cargarAsignaturas()
        {
            var Asignaturas = new List<Asignatura>()            
            {
                new Asignatura{Nombre = "Matematicas"},
                new Asignatura{Nombre = "Español"},
                new Asignatura{Nombre = "Biologia"},
                new Asignatura{Nombre = "Fisica"},
                new Asignatura{Nombre = "Deporte"},
                new Asignatura{Nombre = "Programacion"}
            };
                                                    
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var al in curso.Alumnos)
                {
                    al.Asignaturas = Asignaturas;                   
                }
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno{Nombre=$"{n1} {n2} {a1}"};                
            return listaAlumnos.OrderBy((al)=> al.UniqID).Take(cantidad).ToList();
            // i did change the place of the order .Take() due to the list had only one firstname
        }

        private void cargarCursos()
        {
            Escuela.Cursos = new List<Curso>()
                            {
                                new Curso(){Nombre = "101", Jornada = TiposJornada.Tarde},
                                new Curso(){Nombre = "201", Jornada = TiposJornada.Tarde },
                                new Curso(){Nombre = "301", Jornada = TiposJornada.Tarde }
                            };

            
                    foreach (var curso in Escuela.Cursos)
                    {
                        Random cantidad = new Random();
                        int cantidadrandom = cantidad.Next(30, 50);
                        curso.Alumnos = GenerarAlumnos(cantidadrandom);
                    }

        }

        public override string ToString()
        {
            return $"{Escuela.Nombre}\n{Escuela.AñoDeCreacion}\n{Escuela.Ciudad}\n{Escuela.Pais}\n";
        }

 

        }

}