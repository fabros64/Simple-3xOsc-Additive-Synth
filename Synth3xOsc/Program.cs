using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synth3xOsc
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BasicSynthesizer());
        }
        

        // Inicjalizacja kluczowych zmiennych

        public const int SAMPLE_RATE = 44100;
        public const short BITS_PER_SAMPLE = 16;
        public static short[] wave = new short[SAMPLE_RATE];
    }
}
