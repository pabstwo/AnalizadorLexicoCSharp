using System;
using System.Windows.Forms;
using AnalizadorLexicoCSharp.Analisis;
using AnalizadorLexicoCSharp.Modelos;

namespace AnalizadorLexicoCSharp.Formularios
{
    public partial class FormDiccionario : Form
    {
        private readonly DiccionarioLexico diccionarioLexico;

        private string? lexemaSeleccionado;

        public FormDiccionario()
        {
            InitializeComponent();

            diccionarioLexico =
                DiccionarioLexico.Instancia;

            ConfigurarEventos();
            ConfigurarTabla();
            CargarTiposToken();
            CargarDatos();

            CambiarModoEdicion(false);
        }

        private void ConfigurarEventos()
        {
            
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvDiccionario.CellClick +=
                dgvDiccionario_CellClick;

            diccionarioLexico.DiccionarioCambiado +=
                DiccionarioLexico_DiccionarioCambiado;

            FormClosed += FormDiccionario_FormClosed;
        }

        private void ConfigurarTabla()
        {
            dgvDiccionario.AutoGenerateColumns = false;
            dgvDiccionario.Columns.Clear();

            DataGridViewTextBoxColumn columnaLexema =
                new DataGridViewTextBoxColumn
                {
                    Name = "colLexema",
                    HeaderText = "Lexema",
                    DataPropertyName = "Lexema",
                    FillWeight = 22
                };

            DataGridViewTextBoxColumn columnaTipo =
                new DataGridViewTextBoxColumn
                {
                    Name = "colTipo",
                    HeaderText = "Tipo de token",
                    DataPropertyName = "Tipo",
                    FillWeight = 25
                };

            DataGridViewTextBoxColumn columnaDescripcion =
                new DataGridViewTextBoxColumn
                {
                    Name = "colDescripcion",
                    HeaderText = "Descripción",
                    DataPropertyName = "Descripcion",
                    FillWeight = 38
                };

            DataGridViewCheckBoxColumn columnaEsTipoDato =
                new DataGridViewCheckBoxColumn
                {
                    Name = "colEsTipoDato",
                    HeaderText = "Tipo de dato",
                    DataPropertyName = "EsTipoDato",
                    FillWeight = 15
                };

            dgvDiccionario.Columns.Add(columnaLexema);
            dgvDiccionario.Columns.Add(columnaTipo);
            dgvDiccionario.Columns.Add(columnaDescripcion);
            dgvDiccionario.Columns.Add(columnaEsTipoDato);

            dgvDiccionario.DefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            dgvDiccionario.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            dgvDiccionario.ColumnHeadersHeight = 35;
            dgvDiccionario.RowTemplate.Height = 32;

            dgvDiccionario.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(
                    240,
                    245,
                    252
                );

            dgvDiccionario.EnableHeadersVisualStyles = false;

            dgvDiccionario.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(
                    176,
                    196,
                    222
                );

            dgvDiccionario.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.Black;
        }

        private void CargarTiposToken()
        {
            cmbTipoToken.DataSource =
                Enum.GetValues(typeof(TipoToken));

            cmbTipoToken.SelectedItem =
                TipoToken.PalabraReservada;
        }

        private void CargarDatos()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CargarDatos));
                return;
            }

            dgvDiccionario.DataSource = null;

            dgvDiccionario.DataSource =
                diccionarioLexico.ObtenerEntradas();

            lblTotalRegistros.Text =
                $"Registros: {dgvDiccionario.Rows.Count}";

            dgvDiccionario.ClearSelection();
        }

        private EntradaDiccionario?
            CrearEntradaDesdeControles()
        {
            if (cmbTipoToken.SelectedItem is not TipoToken tipo)
            {
                MessageBox.Show(
                    "Debe seleccionar un tipo de token.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbTipoToken.Focus();
                return null;
            }

            return new EntradaDiccionario(
                txtLexema.Text.Trim(),
                tipo,
                txtDescripcion.Text.Trim(),
                chkEsTipoDato.Checked
            );
        }

        private void btnAgregar_Click(
            object? sender,
            EventArgs e)
        {
            EntradaDiccionario? nuevaEntrada =
                CrearEntradaDesdeControles();

            if (nuevaEntrada == null)
            {
                return;
            }

            bool agregado = diccionarioLexico.Agregar(
                nuevaEntrada,
                out string mensaje
            );

            if (!agregado)
            {
                MessageBox.Show(
                    mensaje,
                    "No se pudo agregar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLexema.Focus();
                return;
            }

            MessageBox.Show(
                mensaje,
                "Diccionario actualizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimpiarCampos();
        }

        private void btnEditar_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                lexemaSeleccionado))
            {
                MessageBox.Show(
                    "Seleccione una entrada de la tabla.",
                    "Entrada no seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            EntradaDiccionario? entradaActualizada =
                CrearEntradaDesdeControles();

            if (entradaActualizada == null)
            {
                return;
            }

            bool editado = diccionarioLexico.Editar(
                lexemaSeleccionado,
                entradaActualizada,
                out string mensaje
            );

            if (!editado)
            {
                MessageBox.Show(
                    mensaje,
                    "No se pudo editar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                mensaje,
                "Diccionario actualizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimpiarCampos();
        }

        private void btnEliminar_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                lexemaSeleccionado))
            {
                MessageBox.Show(
                    "Seleccione una entrada de la tabla.",
                    "Entrada no seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult confirmacion =
                MessageBox.Show(
                    $"¿Desea eliminar el lexema " +
                    $"\"{lexemaSeleccionado}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            bool eliminado = diccionarioLexico.Eliminar(
                lexemaSeleccionado,
                out string mensaje
            );

            if (!eliminado)
            {
                MessageBox.Show(
                    mensaje,
                    "No se pudo eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                mensaje,
                "Diccionario actualizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimpiarCampos();
        }

        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvDiccionario_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvDiccionario.Rows[e.RowIndex];

            if (fila.DataBoundItem
                is not EntradaDiccionario entrada)
            {
                return;
            }

            lexemaSeleccionado = entrada.Lexema;

            txtLexema.Text = entrada.Lexema;
            cmbTipoToken.SelectedItem = entrada.Tipo;
            txtDescripcion.Text = entrada.Descripcion;
            chkEsTipoDato.Checked = entrada.EsTipoDato;

            CambiarModoEdicion(true);
        }

        private void LimpiarCampos()
        {
            lexemaSeleccionado = null;

            txtLexema.Clear();
            txtDescripcion.Clear();

            chkEsTipoDato.Checked = false;

            cmbTipoToken.SelectedItem =
                TipoToken.PalabraReservada;

            dgvDiccionario.ClearSelection();

            CambiarModoEdicion(false);

            txtLexema.Focus();
        }

        private void CambiarModoEdicion(
            bool editando)
        {
            btnAgregar.Enabled = !editando;
            btnEditar.Enabled = editando;
            btnEliminar.Enabled = editando;
            btnCancelar.Enabled = editando;
        }

        private void
            DiccionarioLexico_DiccionarioCambiado()
        {
            CargarDatos();
        }

        private void FormDiccionario_FormClosed(
            object? sender,
            FormClosedEventArgs e)
        {
            diccionarioLexico.DiccionarioCambiado -=
                DiccionarioLexico_DiccionarioCambiado;
        }
    }
}