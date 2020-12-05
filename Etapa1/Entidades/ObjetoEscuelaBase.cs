using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObejtoEscuelaBase
    {
        public string UniqID { get; private set; }
        public string Nombre { get; set; }

        public void ObjetoEscuelaBase()
        {
            UniqID = Guid.NewGuid().ToString();
        }

    }




}