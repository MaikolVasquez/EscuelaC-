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
    
            public void inicializar()
            {
                    Escuela = new Escuela("Platzi M", 2020);  
                    Escuela.Ciudad = "Bogota";
                    Escuela.Pais = "Colombia";
                    Escuela.TipoEscuela = TiposEscuela.Primaria; 


                    cargarCursos();                                          
                    
                    cargarAsignaturas();
                    
                        
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
                    foreach (var asignatura in al.Asignaturas)
                    {
                        asignatura.Evaluaciones = GenerarEvaluaciones();
                        foreach (var evaluacion in asignatura.Evaluaciones)
                        {
                            Random cantidad = new Random();
                            double cantidadrandom = (cantidad.NextDouble() + cantidad.Next(1,5));
                            evaluacion.Nota = Math.Round(cantidadrandom,1);
                        }
                    }
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

            
                    foreach (var item in Escuela.Cursos)
                    {
                        Random cantidad = new Random();
                        int cantidadrandom = cantidad.Next(30, 50);
                        item.Alumnos = GenerarAlumnos(cantidadrandom);
                    }

        }

        public override string ToString()
        {
            return $"{Escuela.Nombre}\n{Escuela.AñoDeCreacion}\n{Escuela.Ciudad}\n{Escuela.Pais}\n";
        }

 

        }

}