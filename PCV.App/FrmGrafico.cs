using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCV.App
{
    public partial class FrmGrafico : Form
    {
        public FrmGrafico()
        {
            InitializeComponent();
        }

        public void CarregaGrafico(List<int[]> pontos)
        {
            chart.Series["SeriesGenetico"].Points.Clear();
            foreach (var item in pontos)
            {
                chart.Series["SeriesGenetico"].Points.AddXY(item.ElementAt(1), item.ElementAt(0));
            }
        }

    }
}
