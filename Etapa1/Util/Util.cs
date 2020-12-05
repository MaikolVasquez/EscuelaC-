using System;

namespace CoreEscuela.Entidades
{
    class Util
    {
        public static void printline(int tamaño, char caracter)
        {
            Console.WriteLine("".PadLeft(tamaño, caracter));
        }

        public static void printTitle(string titulo)
        {
            printline(titulo.Length, '=');
            Console.WriteLine(titulo);
            printline(titulo.Length, '=');
        }
               public static void Timbrar()
                {           
            // Las Campanas de westminster
            System.Console.Beep(395*2,500);
            System.Console.Beep(352*2,500);
            System.Console.Beep(313*2,500);
            System.Console.Beep(234*2,1000);
            System.Console.Beep(234*2,500);
            System.Console.Beep(352*2,500);
            System.Console.Beep(395*2,500);
            System.Console.Beep(313*2,1000);
                }
    }
}