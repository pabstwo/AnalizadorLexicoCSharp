using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalizadorLexicoCSharp.Analisis;
using AnalizadorLexicoCSharp.Modelos;
using ClosedXML.Excel;

namespace AnalizadorLexicoCSharp.Formularios
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            btnDiccionario.Click += btnDiccionario_Click;

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
                dgvCategorias.Rows.Clear();

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
                var categorias = resultado.Tokens
    .GroupBy(token => token.Tipo)
    .OrderBy(grupo => grupo.Key.ToString());

                foreach (var categoria in categorias)
                {
                    dgvCategorias.Rows.Add(
                        categoria.Key.ToString(),
                        categoria.Count()
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
            dgvCategorias.Rows.Clear();

            lblTotalTokens.Text = "Tokens: 0";
            lblTotalErrores.Text = "Errores: 0";
            lblTotalLineas.Text = "Líneas: 0";
            lblEstado.Text = "Estado: listo";

            tabResultados.SelectedTab = tabTokens;

            rtbCodigoFuente.Focus();
        }
        private void btnDiccionario_Click(
    object? sender,
    EventArgs e)
        {
            using FormDiccionario formularioDiccionario =
                new FormDiccionario();

            formularioDiccionario.ShowDialog(this);
        }
        private void btnExportar_Click(
     object? sender,
     EventArgs e)
        {
            if (dgvTokens.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debe realizar un análisis léxico.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using SaveFileDialog ventanaGuardar =
                new SaveFileDialog();

            ventanaGuardar.Title =
                "Exportar resultados del análisis";

            ventanaGuardar.Filter =
                "Libro de Excel (*.xlsx)|*.xlsx";

            ventanaGuardar.FileName =
                "Resultados_Analisis_Lexico.xlsx";

            ventanaGuardar.DefaultExt = "xlsx";
            ventanaGuardar.AddExtension = true;

            if (ventanaGuardar.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            try
            {
                using XLWorkbook libroExcel =
                    new XLWorkbook();

                ExportarDataGridView(
                    libroExcel,
                    dgvTokens,
                    "Tokens",
                    "TablaTokens",
                    XLTableTheme.TableStyleMedium2
                );

                ExportarDataGridView(
                    libroExcel,
                    dgvErrores,
                    "Errores",
                    "TablaErrores",
                    XLTableTheme.TableStyleMedium4
                );

                ExportarDataGridView(
                    libroExcel,
                    dgvSimbolos,
                    "Simbolos",
                    "TablaSimbolos",
                    XLTableTheme.TableStyleMedium9
                );

                ExportarDataGridView(
                    libroExcel,
                    dgvCategorias,
                    "Categorias",
                    "TablaCategorias",
                    XLTableTheme.TableStyleMedium5
                );

                ExportarResumen(libroExcel);
                ExportarDiccionario(libroExcel);

                libroExcel.SaveAs(
                    ventanaGuardar.FileName
                );

                MessageBox.Show(
                    "Los resultados se exportaron " +
                    "correctamente en tablas de Excel.",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible exportar los resultados." +
                    "\n\n" + ex.Message,
                    "Error de exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
            private void ExportarDataGridView(
    XLWorkbook libroExcel,
    DataGridView tablaOrigen,
    string nombreHoja,
    string nombreTabla,
    XLTableTheme tema)
        {
            IXLWorksheet hoja =
                libroExcel.Worksheets.Add(nombreHoja);

            int totalColumnas =
                tablaOrigen.Columns.Count;

            // Crear encabezados.
            for (int columna = 0;
                 columna < totalColumnas;
                 columna++)
            {
                hoja.Cell(1, columna + 1).Value =
                    tablaOrigen.Columns[columna].HeaderText;
            }

            int filaExcel = 2;

            // Copiar las filas del DataGridView.
            foreach (DataGridViewRow filaOrigen
                     in tablaOrigen.Rows)
            {
                if (filaOrigen.IsNewRow)
                {
                    continue;
                }

                for (int columna = 0;
                     columna < totalColumnas;
                     columna++)
                {
                    string valor =
                        filaOrigen.Cells[columna].Value?
                            .ToString() ??
                        string.Empty;

                    hoja.Cell(
                        filaExcel,
                        columna + 1
                    ).Value = valor;
                }

                filaExcel++;
            }

            // Una tabla de Excel necesita un rango.
            // Cuando no existen registros se conserva una fila vacía.
            int ultimaFila = Math.Max(
                2,
                filaExcel - 1
            );

            IXLRange rangoTabla = hoja.Range(
                1,
                1,
                ultimaFila,
                totalColumnas
            );

            IXLTable tablaExcel =
                rangoTabla.CreateTable(nombreTabla);

            tablaExcel.Theme = tema;
            tablaExcel.ShowAutoFilter = true;
            tablaExcel.ShowRowStripes = true;

            AplicarFormatoHoja(
                hoja,
                totalColumnas
            );
        }
        private void ExportarResumen(
    XLWorkbook libroExcel)
        {
            IXLWorksheet hoja =
                libroExcel.Worksheets.Add("Resumen");

            hoja.Cell("A1").Value = "Indicador";
            hoja.Cell("B1").Value = "Resultado";

            hoja.Cell("A2").Value = "Tokens";
            hoja.Cell("B2").Value =
                ExtraerValorEtiqueta(
                    lblTotalTokens.Text
                );

            hoja.Cell("A3").Value = "Errores";
            hoja.Cell("B3").Value =
                ExtraerValorEtiqueta(
                    lblTotalErrores.Text
                );

            hoja.Cell("A4").Value = "Líneas";
            hoja.Cell("B4").Value =
                ExtraerValorEtiqueta(
                    lblTotalLineas.Text
                );

            hoja.Cell("A5").Value = "Estado";
            hoja.Cell("B5").Value =
                ExtraerValorEtiqueta(
                    lblEstado.Text
                );

            hoja.Cell("A6").Value =
                "Fecha de exportación";

            hoja.Cell("B6").Value =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm:ss"
                );

            IXLTable tablaResumen =
                hoja.Range("A1:B6")
                    .CreateTable("TablaResumen");

            tablaResumen.Theme =
                XLTableTheme.TableStyleMedium2;

            tablaResumen.ShowAutoFilter = true;
            tablaResumen.ShowRowStripes = true;

            AplicarFormatoHoja(hoja, 2);
        }
        private string ExtraerValorEtiqueta(
    string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return string.Empty;
            }

            int posicionDosPuntos =
                texto.IndexOf(':');

            if (posicionDosPuntos < 0)
            {
                return texto.Trim();
            }

            return texto
                .Substring(posicionDosPuntos + 1)
                .Trim();
        }
    
    private void ExportarDiccionario(
    XLWorkbook libroExcel)
        {
            IXLWorksheet hoja =
                libroExcel.Worksheets.Add(
                    "Diccionario"
                );

            hoja.Cell("A1").Value = "Lexema";
            hoja.Cell("B1").Value = "Tipo de token";
            hoja.Cell("C1").Value = "Descripción";
            hoja.Cell("D1").Value = "Es tipo de dato";

            List<EntradaDiccionario> entradas =
                DiccionarioLexico.Instancia
                    .ObtenerEntradas();

            int filaExcel = 2;

            foreach (EntradaDiccionario entrada
                     in entradas)
            {
                hoja.Cell(filaExcel, 1).Value =
                    entrada.Lexema;

                hoja.Cell(filaExcel, 2).Value =
                    entrada.Tipo.ToString();

                hoja.Cell(filaExcel, 3).Value =
                    entrada.Descripcion;

                hoja.Cell(filaExcel, 4).Value =
                    entrada.EsTipoDato
                        ? "Sí"
                        : "No";

                filaExcel++;
            }

            int ultimaFila = Math.Max(
                2,
                filaExcel - 1
            );

            IXLTable tablaDiccionario =
                hoja.Range(
                    1,
                    1,
                    ultimaFila,
                    4
                ).CreateTable(
                    "TablaDiccionario"
                );

            tablaDiccionario.Theme =
                XLTableTheme.TableStyleMedium9;

            tablaDiccionario.ShowAutoFilter = true;
            tablaDiccionario.ShowRowStripes = true;

            AplicarFormatoHoja(hoja, 4);
        }
        private void AplicarFormatoHoja(
    IXLWorksheet hoja,
    int totalColumnas)
        {
            hoja.SheetView.FreezeRows(1);

            hoja.Row(1).Height = 24;

            hoja.Row(1).Style.Font.Bold = true;
            hoja.Row(1).Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center;

            hoja.Row(1).Style.Alignment.Vertical =
                XLAlignmentVerticalValues.Center;

            hoja.Columns(
                1,
                totalColumnas
            ).AdjustToContents();

            for (int columna = 1;
                 columna <= totalColumnas;
                 columna++)
            {
                if (hoja.Column(columna).Width > 45)
                {
                    hoja.Column(columna).Width = 45;
                }

                if (hoja.Column(columna).Width < 12)
                {
                    hoja.Column(columna).Width = 12;
                }
            }

            hoja.CellsUsed().Style.Alignment
                .Vertical =
                XLAlignmentVerticalValues.Center;

            hoja.CellsUsed().Style.Alignment
                .WrapText = true;
        }
    }
}
