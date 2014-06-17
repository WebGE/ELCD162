using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

using Serial;

namespace NetduinoELCD_162
{
    public class Program
    {
        public static void Main()
        {  // Relier l'afficheur au connecteur O5 de la carte Tinkerkit
          int counter = 0;
          // Création d'un objet Afficheur LCD série (par défaut: COM2, 19200, None, 8, 1)

          SerialELCD162 ELCD162 = new SerialELCD162();
          
          ELCD162.Init(); ELCD162.ClearScreen(); ELCD162.CursorOff();
         
          while (true)
          {             
              // Création d'une chaine de caractères
              string counter_string = "Compte:" + counter.ToString() ;             
              // Envoie des octets au port série
              ELCD162.PutString(counter_string);                    
              // Incrémentation du compteur
              counter++;
              // Attente de 1s entre deux envois
              Thread.Sleep(1000); ELCD162.ClearScreen();
          }
        }
    }
}
