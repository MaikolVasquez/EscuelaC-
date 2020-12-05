using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso : ObejtoEscuelaBase, Ilugar
    {
   
        public TiposJornada Jornada { get; set; }        
        
        public List<Alumno> Alumnos { get; set; }

        public string Direccion { get; set; }

        public void limpiarlugar()
        {
            Console.WriteLine("limpiarLugar");
        }
       
        
    }
}