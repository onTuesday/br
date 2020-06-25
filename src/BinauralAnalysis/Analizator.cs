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
            wav.Length = (int)(((reader.Length * 8) / bitsPerSample) / (reader.WaveFormat.SampleRate * 2));
            wav.Samplerate = reader.WaveFormat.SampleRate;
            int sampleCount = (int)((reader.Length * 8) / reader.WaveFormat.BitsPerSample);

            //Запись в массив
            reader.ToSampleProvider();
            float[] buffer = new float[(reader.Length * 8) / reader.WaveFormat.BitsPerSample];

            //Запись в структуру по левому и правому каналу
            reader.Read(buffer, 0, sampleCount);
            wav.Left = new double[sampleCount];
            wav.Right = new double[sampleCount];

            for (int i = 0, j = 0; i < sampleCount; i+=2, ++j)
            {
                wav.Left[j] = buffer[i];
                wav.Right[j] = buffer[i+1];
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
