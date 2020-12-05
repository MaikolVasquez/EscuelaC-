using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string name;
       public string Name
       {
           get { return name; }
           set { name = value; }
       }
        public string UniqID { get; private set; }
        public int AñoDeCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año)
        {
            UniqID = Guid.NewGuid().ToString();
            this.Name = nombre;
            this.AñoDeCreacion = año;
        }
        


        public override string ToString()
        {
            return $"Nombre : {name}\n{AñoDeCreacion}\n{TipoEscuela}\n{Pais} {Ciudad}";
        }
    }
}