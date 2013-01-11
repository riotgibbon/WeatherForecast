using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Toolbox.NETMF.Hardware;

namespace ColdAlert
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            var weatherReader = new WeatherReader(new JsonWeatherSource());
            var data = weatherReader.GetTemp("1");

            // The Adafruit LCD Shield uses a MCP23017 IC as multiplex chip
            var Mux = new Mcp23017();
            // Pins 9 to 15 are connected to the HD44780 LCD
            var Display = new Hd44780Lcd(
                Data: Mux.CreateParallelOut(9, 4),
                ClockEnablePin: Mux.Pins[13],
                ReadWritePin: Mux.Pins[14],
                RegisterSelectPin: Mux.Pins[15]
            );


            Display.ClearDisplay();
            Display.Write("Temp: " + data);
        }

    }
}
