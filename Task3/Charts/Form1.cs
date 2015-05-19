using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NODClassLibrary;
using System.Windows.Forms.DataVisualization.Charting;

namespace Charts
{
    public enum Orient
    {
        vertical,
        horizontal
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            KnownColor[] allColors = new KnownColor[colorsArray.Length];
            Array.Copy(colorsArray, allColors, colorsArray.Length);
            foreach (KnownColor elem in allColors)
                comboBox1.Items.Add(elem.ToString());
            comboBox1.SelectedItem = allColors[0].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
        private void FillingSeries(double speedEucl, double speedStain, Orient myOrient = Orient.vertical, Color color = new Color())
        {
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Series1");
            if (myOrient != Orient.vertical)
                    series.ChartType = SeriesChartType.Bar;
            series.Points.AddXY("Euclidean", speedEucl);
            series.Points.AddXY("Stain", speedStain);
            series.Color = color;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double speedEucl, speedStain;
            NOD.Euclidean(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), out speedEucl);
            NOD.Stain(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), out speedStain);
            if(checkBox1.Checked == true)
                FillingSeries(speedEucl, speedStain, Orient.horizontal, Color.FromName(comboBox1.SelectedItem.ToString()));
            else
                FillingSeries(speedEucl, speedStain, Orient.vertical, Color.FromName(comboBox1.SelectedItem.ToString()));
        }
    }
}
