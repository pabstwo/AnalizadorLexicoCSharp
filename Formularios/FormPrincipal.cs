using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexicoCSharp.Formularios
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ventanaAbrir = new OpenFileDialog();

            ventanaAbrir.Title = "Seleccionar archivo de código fuente";
            ventanaAbrir.Filter =
                "Archivos de C# (*.cs)|*.cs|" +
                "Archivos de texto (*.txt)|*.txt|" +
                "Todos los archivos (*.*)|*.*";

            ventanaAbrir.FilterIndex = 1;
            ventanaAbrir.RestoreDirectory = true;

            if (ventanaAbrir.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtbCodigoFuente.Text =
                        File.ReadAllText(ventanaAbrir.FileName);

                    MessageBox.Show(
                        "El archivo se cargó correctamente.",
                        "Archivo cargado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible leer el archivo.\n\n" + ex.Message,
                        "Error de lectura",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
