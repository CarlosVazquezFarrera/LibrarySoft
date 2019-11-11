using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySoft.Bibliotecaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void placeHolder(String texto, String texto2, Color color)
        {
            if (txtMatricula.Text == texto)
            {
                txtMatricula.Text = texto2;
                txtMatricula.ForeColor = color;
            }
        }

        private void txtMatricula_Leave(object sender, EventArgs e)
        {
            placeHolder("", "Matrícula del alumno", Color.Silver);
        }

        private void txtMatricula_Enter(object sender, EventArgs e)
        {
            placeHolder("Matrícula del alumno", "", Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMatricula.Text) || txtMatricula.Text == "Matrícula del alumno" || txtMatricula.Text.Length < 7)
            {
                MessageBox.Show("Ingresa una matrícula", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {                
                if (txtMatricula.Text.ToLower() == "a150063")
                {
                    MessageBox.Show("El alumno actualmente tiene un adeudo en la biblioteca ", "Adeudo de libros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
            }
       
        }
        private void escribir(System.Drawing.Printing.PrintPageEventArgs e, String texto, Font font,  int x, int y)
        {
            e.Graphics.DrawString(texto, font, Brushes.Black, x, y);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagen = Properties.Resources.unach_logo;
            Image logo = imagen;
            Font normal = new Font("Arial", 14, FontStyle.Regular);
            Font italica = new Font("Arial", 14, FontStyle.Italic);
            Font negrita = new Font("Arial", 14, FontStyle.Bold);

            int inicio = 270;
            int interlineado = 50;

            e.Graphics.DrawImage(logo, 10, 10, logo.Width/4, logo.Height/4);
            escribir(e, "Constancia de no adeudo de libros", negrita, 270, 10);
            escribir(e, "Fecha: " + DateTime.Today.ToShortDateString(), negrita, 660, 60);

            escribir(e, "La presente hace constar que el alumno ",normal, 130, inicio);
            escribir(e, "Carlos Alberto Vazquez Farrera", negrita, 475, inicio);
            escribir(e, ",", normal, 760, inicio);

            escribir(e, "con Matrícula", normal, 40, inicio + interlineado);
            escribir(e, "A150064", negrita, 160, inicio + interlineado);
            escribir(e, ", actualmente no tiene ningún adeudo en la biblioteca de esta área", normal, 235, inicio + interlineado);

            escribir(e, "y plantel educativo.", normal, 40, (inicio + interlineado * 2));

            escribir(e, "Se extiende la presente constancia a petición del interesado(a) y para los", normal, 130, (inicio + interlineado * 5));
            escribir(e, "fines que a este convenga.", normal, 40, (inicio + interlineado * 6));


            escribir(e, "ATENTAMENTE", negrita, 345, (inicio + interlineado * 10));
            escribir(e, "\"POR LA CONCIENCIA DE LA NECESISDAD DE SERVIR\"", negrita, 160, (inicio + interlineado * 11));




            escribir(e, "Biblioteca de la Licenciatura en Sistemas Computacionales", italica, 330, 1075);

        }
    }
}
