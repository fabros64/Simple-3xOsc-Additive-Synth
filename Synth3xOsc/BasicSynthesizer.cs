using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Synth3xOsc
{
    public partial class BasicSynthesizer : Form
    {
        //Deklaracje niezbędnych zmiennych lokalnych

        // tablica przechowująca przekonwertowaną falę o wartościach short na typ byte 
        private byte[] binaryWave = new byte[Program.SAMPLE_RATE * sizeof(short)];
        int time = 0;
        MemoryStream memoryStream;
        IEnumerable<Oscillator> oscillators;

        //****************************************************************************


        public BasicSynthesizer()
        {
            this.BackColor = Color.NavajoWhite;

            oscillators = this.Controls.OfType<Oscillator>().Where(o => o.On);

            Program.wave = new short[Program.SAMPLE_RATE];

            binaryWave = new byte[Program.wave.Length * sizeof(short)];

            InitializeComponent();
        }

        //****************************************************************************

        private void BasicSynthesizer_KeyDown(object sender, KeyEventArgs e)
        {
            foreach(Oscillator oscillator in oscillators)
            switch (e.KeyCode)
            {
                case Keys.Z:
                    oscillator.frequency.Value = (int)65.4f;  // C2
                    break;
                case Keys.X:
                        oscillator.frequency.Value = (int)138.59f;  // C3
                    break;
                case Keys.C:
                        oscillator.frequency.Value = (int)261.62f;  // C4
                    break;
                case Keys.V:
                        oscillator.frequency.Value = (int)523.25f;  // C5
                    break;
                case Keys.B:
                        oscillator.frequency.Value = (int)1046.5f;  // C6
                    break;
                case Keys.N:
                        oscillator.frequency.Value = (int)1200f;  // C7
                    break;
                case Keys.M:
                        oscillator.frequency.Value = (int)1400.01f;  // C8
                    break;
                case Keys.Space:
                    break;
                
            }

            Generate_Signal();
        }

        //****************************************************************************

        // Tworzenie pliku formatu wav zawierający nasz powstały sygnał i odtwarzanie go 
        // link do tworzenia formatu WAV : http://soundfile.sapp.org/doc/WaveFormat/
        // Jeśli stereo to popatrzeć w dokumentacje, gdyż występuje często mnożenie przez NumChannels

        private void Wave_to_Wav_and_Play()
        {

            //konwersja naszej tablicy wave typu short do binaryWave typu byte potrzebnej do zapisu w wav
            Buffer.BlockCopy(Program.wave, 0, binaryWave, 0, Program.wave.Length * sizeof(short));

            //Tworzenie strumienia formatu wav
            using (memoryStream = new MemoryStream())
            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
            {
                short BlockAlign = Program.BITS_PER_SAMPLE / 8;
                int subChunkTwoSize = Program.SAMPLE_RATE * BlockAlign;

                binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                binaryWriter.Write(36 + subChunkTwoSize);
                binaryWriter.Write(new[] { 'W', 'A', 'V', 'E'});
                binaryWriter.Write(new[] { 'f', 'm', 't', ' ' });
                binaryWriter.Write(16);
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)1);  //przetestować dla wartości 2 - stereo  (1 - mono)
                binaryWriter.Write(Program.SAMPLE_RATE);
                binaryWriter.Write(Program.SAMPLE_RATE * BlockAlign);
                binaryWriter.Write(BlockAlign);
                binaryWriter.Write(Program.BITS_PER_SAMPLE);
                binaryWriter.Write(new[] { 'd', 'a', 't', 'a'});
                binaryWriter.Write(subChunkTwoSize);
                binaryWriter.Write(binaryWave);

                //odtwarzanie powstałego sygnału:
                memoryStream.Position = 0;
                new SoundPlayer(memoryStream).PlayLooping();
            }
        }

        //****************************************************************************
        //Czyszczenie tablicy zawierającej sygnał

        void Wave_Clear()
        {
            for (int i = 0; i < Program.SAMPLE_RATE; i++)
                Program.wave[i] = 0;
        }

        //****************************************************************************

        private void BasicSynthesizer_KeyUp(object sender, KeyEventArgs e)
        {
            Wave_Clear();
            time = 0;
            new SoundPlayer(memoryStream).Stop();
        }

        //****************************************************************************
        //Nacisniecie Stop

        private void button2_Click(object sender, EventArgs e)
        {
          
            
            Wave_Clear();
            time = 0;
            new SoundPlayer(memoryStream).Stop();
        }

        //****************************************************************************
        //Nacisniecie Start

        private void button1_Click(object sender, EventArgs e)
        {
            Generate_Signal();
        }

        //****************************************************************************
        //Generowanie sygnału, suma 3 oscylatorów

        private void Generate_Signal()
        {
            time++;
            

            oscillators = this.Controls.OfType<Oscillator>().Where(o => o.On);
            Random random = new Random();
            Program.wave = new short[Program.SAMPLE_RATE];
            binaryWave = new byte[Program.wave.Length * sizeof(short)];
            float volume;
            float frequency_Sine, frequency_Square;
            int oscillatorsCount = oscillators.Count();

            foreach (Oscillator oscillator in oscillators)
            {
                frequency_Sine = oscillator.frequency.Value;
                frequency_Square = oscillator.frequency.Value;

                volume = 320 * oscillator.volume.Value;

                int samplesPerWaveLength = (int)(Program.SAMPLE_RATE / oscillator.frequency.Value);
                short ampStep = (short)((volume * 2) / samplesPerWaveLength);
                short tempSample;

                switch (oscillator.WaveForm)
                {

                    case WaveForm.Sine:
                        {
                            for (int i = 0; i < Program.SAMPLE_RATE; i++)
                            {
                                Program.wave[i] += Convert.ToInt16((volume * Math.Sin(((Math.PI * 2 * frequency_Sine * i) / Program.SAMPLE_RATE))) / oscillatorsCount);
                            }
                            break;
                        }

                    case WaveForm.Square:
                        {
                            for (int i = 0; i < Program.SAMPLE_RATE; i++)
                            {
                                Program.wave[i] += Convert.ToInt16((volume * Math.Sign(Math.Sin((Math.PI * 2 * frequency_Square) / Program.SAMPLE_RATE * i))) / oscillatorsCount);
                            }
                            break;
                        }

                    case WaveForm.Saw:
                        {
                            for (int i = 0; i < Program.SAMPLE_RATE; i++)
                            {
                                tempSample = (short)-volume;
                                for (int j = 0; j < samplesPerWaveLength && i < Program.SAMPLE_RATE; j++)
                                {
                                    tempSample += ampStep;
                                    Program.wave[i++] += Convert.ToInt16(tempSample / oscillatorsCount);
                                }
                                i--;
                            }
                            break;
                        }

                    case WaveForm.Triangle:
                        {
                            tempSample = (short)-volume;

                            for (int i = 0; i < Program.SAMPLE_RATE; i++)
                            {
                                if (Math.Abs(tempSample + ampStep) > volume)
                                {
                                    ampStep = (short)-ampStep;
                                }
                                tempSample += ampStep;
                                Program.wave[i] += Convert.ToInt16(tempSample / oscillatorsCount);
                            }

                            break;
                        }

                    case WaveForm.Noise:
                        {
                            for (int i = 0; i < Program.SAMPLE_RATE; i++)
                            {
                                Program.wave[i] += Convert.ToInt16(random.Next((short)-volume, (int)volume) / oscillatorsCount);
                            }
                            break;
                        }
                }

                if (time <= 1)
                    Wave_to_Wav_and_Play();

            }

        }

        private void oscillograph1_Click(object sender, EventArgs e)
        {

        }

        //****************************************************************************

    }



    //struktura przechowująca podstawowe fale oraz szum
    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise
    }

}
