using System.Threading;
using ToolBoxes;

namespace TestNetduinoELCD_162
{
    public class Program
    {
        public static void Main()
        {// Documentation de la classe SerialELCD162 http://webge.github.io/ELCD162/
            // Pour accéder au COM2, relier l'afficheur au connecteur O5 de la carte Tinkerkit
            
            // Valeur à afficher
            var counter = 0;

            // Création d'un objet afficheur série ELCD-162 (par défaut: COM2, 19200, None, 8, 1)
            ELCD162 display = new ELCD162();

            // Initialisation du port série et de l’afficheur
            display.Init(); display.ClearScreen(); display.CursorOff();

            while (true)
            {
                // Création d'une chaine de caractères
                string counter_string = "Compte:" + counter.ToString();
                // Envoie des octets au port série de l'afficheur
                display.PutString(counter_string);
                // Incrémentation du compteur
                counter++;
                // Attente de 1s entre deux envois
                Thread.Sleep(1000); display.ClearScreen();
            }
        }
    }
}