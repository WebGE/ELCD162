using System;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace ToolBoxes
{
    class ELCD162 : SerialPort
    {
        /// <summary>
        /// Built a COM port with COM2, 19200, None, 8, 1 stop
        /// </summary>
        public ELCD162(String com="COM2", int baudrate=19200, Parity parite = Parity.None, int bits = 8, StopBits stopb = StopBits.One )
            : base(com, baudrate, parite, bits,stopb)
        {
        }

        /// <summary>
        /// Open the communication and send Initiate Byte 0xA
        /// </summary>
        public void Init()
        {
            this.Open();
            this.WriteByte(0xA0);
            Thread.Sleep(200);
        }

        /// <summary>
        /// Convert string in UTF8 end push
        /// </summary>
        /// <param name="str"></param>
        public void PutString(string str) // Pour Comfile Ethis-162
        {
            byte [] buffer = Encoding.UTF8.GetBytes(str);
            this.WriteByte(0xA2);
            this.Write(buffer, 0, buffer.Length);
            this.WriteByte(0);
            Thread.Sleep(1);
        }

        /// <summary>
        /// Clear the screen
        /// </summary>
        public void ClearScreen() // Pour Comfile Ethis-162
        {
            this.WriteByte(0xA3);
            this.WriteByte(0x01);
            Thread.Sleep(1);
        }

        /// <summary>
        /// Put the cursor on
        /// </summary>
        public void CursorOn()  // Pour Comfile Ethis-162
        {
            this.WriteByte(0xA3);
            this.WriteByte(0x0E);
            Thread.Sleep(1);
        }

        /// <summary>
        /// Put the cursor off
        /// </summary>
        public void CursorOff() // Pour Comfile Ethis-162
        {
            this.WriteByte(0xA3);
            this.WriteByte(0x0C);
            Thread.Sleep(1);
        }

        /// <summary>
        /// Put the cursor on (x,y)
        /// </summary>
        /// <param name="x_pos"></param>
        /// <param name="y_pos"></param>
        public void SetCursor(byte x_pos, byte y_pos) // Pour Comfile Ethis-162
        {
            this.WriteByte(0xA1);
            this.WriteByte(x_pos);
            this.WriteByte(y_pos);
            Thread.Sleep(1);
        }
    }
}
