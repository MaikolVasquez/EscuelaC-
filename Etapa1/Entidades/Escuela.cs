using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela : ObejtoEscuelaBase, Ilugar
    {
        
        public int AñoDeCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }
        
        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        public string Direccion { get; set; }

        public Escuela(string nombre, int año)
        {
            
            this.Nombre = nombre;
            this.AñoDeCreacion = año;
        }
        


        public override string ToString()
        {
            return $"Nombre : {Nombre}\n{AñoDeCreacion}\n{TipoEscuela}\n{Pais} {Ciudad}";
        }

        public void limpiarlugar()
        {
            Util.printTitle("la escuela esta limpia");
        }
    }
}