using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObejtoEscuelaBase
    {
        public ObejtoEscuelaBase()
        {
            UniqID = Guid.NewGuid().ToString();
        }

        public string UniqID { get; private set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }




}