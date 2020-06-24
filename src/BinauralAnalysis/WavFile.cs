using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinauralAnalysis
{
    /// <summary>
    /// Структура wav файла, сожержащая необходимый данные для анализа
    /// </summary>
    public struct WavFile
    {
        public string Name { get; }
        public double[] Left { get; set; }
        public double[] Right { get; set; }
        public double[] FFTdata { get; set; }
        public int Samplerate { get; set; }
        public int Length{ get; set; }

        public WavFile(string name)
        {
            this.Name = name;
            this.Left = new double[1];
            this.Right = new double[1];
            this.FFTdata = new double[1];
            this.Samplerate = 0;
            this.Length = 0;
        }
    }
}
