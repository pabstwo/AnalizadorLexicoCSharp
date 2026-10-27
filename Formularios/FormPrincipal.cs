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
using System.Diagnostics;
using AnalizadorLexicoCSharp.Analisis;

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

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbCodigoFuente.Text))
            {
                MessageBox.Show(
                    "Debe escribir o cargar código fuente antes de analizar.",
                    "Código vacío",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbCodigoFuente.Focus();
                return;
            }

            try
            {
                Stopwatch cronometro = Stopwatch.StartNew();

                AnalizadorLexico analizador = new AnalizadorLexico();

                var resultado = analizador.Analizar(
                    rtbCodigoFuente.Text
                );
                cronometro.Stop();

                dgvTokens.Rows.Clear();
                dgvErrores.Rows.Clear();
                dgvSimbolos.Rows.Clear();

                foreach (var token in resultado.Tokens)
                {
                    dgvTokens.Rows.Add(
                        token.Numero,
                        token.Lexema,
                        token.Tipo.ToString(),
                        token.Linea,
                        token.Columna
                    );
                }

                foreach (var error in resultado.Errores)
                {
                    dgvErrores.Rows.Add(
                        error.Lexema,
                        error.Linea,
                        error.Columna,
                        error.Descripcion
                    );
                }
                foreach (var simbolo in resultado.Simbolos)
                {
                    dgvSimbolos.Rows.Add(
                        simbolo.Nombre,
                        simbolo.PrimeraLinea,
                        simbolo.PrimeraColumna,
                        simbolo.TipoDato,
                        simbolo.TotalApariciones
                    );
                }

                lblTotalTokens.Text =
                    "Tokens: " + resultado.Tokens.Count;

                lblTotalErrores.Text =
                    "Errores: " + resultado.Errores.Count;

                lblTotalLineas.Text =
                    "Líneas: " + rtbCodigoFuente.Lines.Length;

                lblEstado.Text =
                    "Estado: completado en " +
                    cronometro.Elapsed.TotalMilliseconds.ToString("F2") +
                    " ms";

                MessageBox.Show(
                    "El análisis léxico finalizó correctamente.",
                    "Análisis terminado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un problema durante el análisis.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rtbCodigoFuente.Clear();

            dgvTokens.Rows.Clear();
            dgvErrores.Rows.Clear();
            dgvSimbolos.Rows.Clear();

            lblTotalTokens.Text = "Tokens: 0";
            lblTotalErrores.Text = "Errores: 0";
            lblTotalLineas.Text = "Líneas: 0";
            lblEstado.Text = "Estado: listo";

            tabResultados.SelectedTab = tabTokens;

            rtbCodigoFuente.Focus();
        }
    }
}
