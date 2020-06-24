using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using Accord.Math;
using System.Numerics;

namespace BinauralAnalysis
{
    public class Analizator
    {
        /// <summary>
        /// Открытвает аудиофайл и заполняет данными (массив байтов и частота дискретизации)
        /// </summary>
        /// <param name="file"></param>
        public static void GetWaveData(ref WavFile wav)
        {
            //Чтение аудиофайла
            AudioFileReader reader = new AudioFileReader(wav.Name);
            if (reader.WaveFormat.Channels != 2)
                throw new NotStereoException();

            int bitsPerSample = reader.WaveFormat.BitsPerSample;
            wav.Length = (int)( ((reader.Length * 8) / bitsPerSample) / (reader.WaveFormat.SampleRate * 2));
            wav.Samplerate = reader.WaveFormat.SampleRate;

            byte[] buffer = new byte[reader.Length];
            reader.Read(buffer, 0, (int)reader.Length);
            Console.WriteLine(reader.WaveFormat.BitsPerSample);

            //Конвертация битовых сэмплов в double и запись 
            wav.Left = new double[(reader.Length * 8) / bitsPerSample / 2];
            wav.Right = new double[(reader.Length * 8) / bitsPerSample / 2];
            bool left = true;
            for(int i = 0; i < reader.Length; i+= bitsPerSample )
            {
                int sampleIndex = 0;
                int intSample = buffer[i];
                for ( int j = i + 1; j < i + reader.WaveFormat.BitsPerSample; ++j)
                {
                    intSample = (intSample << bitsPerSample) | buffer[j];
                }

                if (left)
                {
                    wav.Left[sampleIndex] = intSample;
                    left = false;
                }
                else
                {
                    wav.Right[sampleIndex] = intSample;
                    left = true;
                }
                sampleIndex++;
            }
        }

        /// <summary>
        /// Выполняет БПФ массива
        /// Размер массива должен быть 2^n
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            Complex[] fftComplex = new Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                fftComplex[i] = new Complex(data[i], 0.0);
            }

            Accord.Math.FourierTransform.FFT(fftComplex, FourierTransform.Direction.Forward);

            for (int i = 0; i < data.Length / 2; i++)
            {
                fft[i] = fftComplex[i].Magnitude;
            }

            return fft;
        }
    }
}
