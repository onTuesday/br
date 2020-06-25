using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinauralAnalysis;

namespace Forms
{
    public partial class ResultForm : Form
    {
        public WavFile wav;

        public ResultForm()
        {
            InitializeComponent();
        }

        private void resLabel_Click(object sender, EventArgs e)
        {
            FFTGraphicForm graphicForm = new FFTGraphicForm();
        }
    }
}
