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

            rtbCodigoFuente.TextChanged += rtbCodigoFuente_TextChanged;
            rtbCodigoFuente.VScroll += rtbCodigoFuente_VScroll;

            ActualizarNumerosLinea();
        }
        private void rtbCodigoFuente_TextChanged(
    object? sender,
    EventArgs e)
        {
            ActualizarNumerosLinea();
        }

        private void rtbCodigoFuente_VScroll(
            object? sender,
            EventArgs e)
        {
            SincronizarNumerosLinea();
        }

        private void ActualizarNumerosLinea()
        {
            int cantidadLineas = Math.Max(
                1,
                rtbCodigoFuente.Lines.Length);

            StringBuilder numeros = new StringBuilder();

            for (int numero = 1; numero <= cantidadLineas; numero++)
            {
                numeros.AppendLine(numero.ToString());
            }

            rtbNumerosLinea.Text = numeros.ToString();

            rtbNumerosLinea.SelectAll();
            rtbNumerosLinea.SelectionAlignment =
                HorizontalAlignment.Right;
            rtbNumerosLinea.DeselectAll();

            SincronizarNumerosLinea();
        }

        private void SincronizarNumerosLinea()
        {
            int primerCaracterVisible =
                rtbCodigoFuente.GetCharIndexFromPosition(
                    new Point(0, 0));

            int primeraLineaVisible =
                rtbCodigoFuente.GetLineFromCharIndex(
                    primerCaracterVisible);

            int posicionNumero =
                rtbNumerosLinea.GetFirstCharIndexFromLine(
                    primeraLineaVisible);

            if (posicionNumero >= 0)
            {
                rtbNumerosLinea.SelectionStart = posicionNumero;
                rtbNumerosLinea.SelectionLength = 0;
                rtbNumerosLinea.ScrollToCaret();
            }
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvTokens.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debe realizar un análisis léxico.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using SaveFileDialog ventanaGuardar = new SaveFileDialog();

            ventanaGuardar.Title = "Exportar resultados del análisis";
            ventanaGuardar.Filter = "Archivo CSV (*.csv)|*.csv";
            ventanaGuardar.FileName = "Resultados_Analisis_Lexico.csv";
            ventanaGuardar.DefaultExt = "csv";
            ventanaGuardar.AddExtension = true;

            if (ventanaGuardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string CampoCsv(object? valor)
                {
                    string texto = valor?.ToString() ?? string.Empty;

                    return "\"" + texto.Replace("\"", "\"\"") + "\"";
                }

                StringBuilder contenido = new StringBuilder();

               
                contenido.AppendLine("TOKENS");
                contenido.AppendLine(
                    "Numero;Lexema;Tipo de token;Linea;Columna");

                foreach (DataGridViewRow fila in dgvTokens.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    contenido.AppendLine(
                        CampoCsv(fila.Cells[0].Value) + ";" +
                        CampoCsv(fila.Cells[1].Value) + ";" +
                        CampoCsv(fila.Cells[2].Value) + ";" +
                        CampoCsv(fila.Cells[3].Value) + ";" +
                        CampoCsv(fila.Cells[4].Value));
                }

                contenido.AppendLine();

               
                contenido.AppendLine("ERRORES");
                contenido.AppendLine(
                    "Lexema o caracter;Linea;Columna;Descripcion");

                foreach (DataGridViewRow fila in dgvErrores.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    contenido.AppendLine(
                        CampoCsv(fila.Cells[0].Value) + ";" +
                        CampoCsv(fila.Cells[1].Value) + ";" +
                        CampoCsv(fila.Cells[2].Value) + ";" +
                        CampoCsv(fila.Cells[3].Value));
                }

                contenido.AppendLine();

                
                contenido.AppendLine("TABLA DE SIMBOLOS");
                contenido.AppendLine(
                    "Nombre;Primera linea;Primera columna;Tipo de dato;Apariciones");

                foreach (DataGridViewRow fila in dgvSimbolos.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    contenido.AppendLine(
                        CampoCsv(fila.Cells[0].Value) + ";" +
                        CampoCsv(fila.Cells[1].Value) + ";" +
                        CampoCsv(fila.Cells[2].Value) + ";" +
                        CampoCsv(fila.Cells[3].Value) + ";" +
                        CampoCsv(fila.Cells[4].Value));
                }

                contenido.AppendLine();

                
                contenido.AppendLine("ESTADISTICAS");
                contenido.AppendLine(CampoCsv(lblTotalTokens.Text));
                contenido.AppendLine(CampoCsv(lblTotalErrores.Text));
                contenido.AppendLine(CampoCsv(lblTotalLineas.Text));
                contenido.AppendLine(CampoCsv(lblEstado.Text));

                File.WriteAllText(
                    ventanaGuardar.FileName,
                    contenido.ToString(),
                    Encoding.UTF8);

                MessageBox.Show(
                    "Los resultados se exportaron correctamente.",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible exportar los resultados.\n\n" +
                    ex.Message,
                    "Error de exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
