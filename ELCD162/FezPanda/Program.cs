using System.Threading;
using testMicroToolsKit.Hardware.Display;

namespace FezPanda
{
    public class Program
    {
        public static void Main()
        {
            // Documentation on http://webge.github.io/ELCD162/
            var counter = 0;

            // ELCD-162 object (default : COM2, 19200, None, 8, 1)
            ELCD162 display = new ELCD162("COM1");

            // Init display serial port
            display.Init(); display.ClearScreen(); display.CursorOff();

            while (true)
            {
                var counter_string = "Compte:" + counter.ToString();
                display.PutString(counter_string);
                counter++;
                Thread.Sleep(1000); display.ClearScreen();
            }
        }
    }
}
