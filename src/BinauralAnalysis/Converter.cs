using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Dsp;


namespace BinauralAnalysis
{
    public class Converter
    {
        public static void Mp3ToWav(string path, string outputFile)
        {
            Mp3FileReader reader = new Mp3FileReader(path);
            {
                using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
                {
                    WaveFileWriter.CreateWaveFile(outputFile, pcmStream);
                }
            }
        }

       
    }
}
