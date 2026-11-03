namespace AnalizadorLexicoCSharp.Formularios
{
    partial class FormDiccionario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblLexema = new Label();
            txtLexema = new TextBox();
            lblTipoToken = new Label();
            cmbTipoToken = new ComboBox();
            chkEsTipoDato = new CheckBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            lblTotalRegistros = new Label();
            dgvDiccionario = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDiccionario).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.MidnightBlue;
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(368, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DICCIONARIO LÉXICO";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.DimGray;
            lblSubtitulo.Location = new Point(28, 60);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(614, 23);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Agregue, consulte, edite o elimine los elementos reconocidos por el analizador.";
            // 
            // lblLexema
            // 
            lblLexema.AutoSize = true;
            lblLexema.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLexema.ForeColor = Color.DimGray;
            lblLexema.Location = new Point(28, 105);
            lblLexema.Name = "lblLexema";
            lblLexema.Size = new Size(71, 23);
            lblLexema.TabIndex = 2;
            lblLexema.Text = "Lexema";
            // 
            // txtLexema
            // 
            txtLexema.Font = new Font("Segoe UI", 10F);
            txtLexema.Location = new Point(28, 130);
            txtLexema.MaxLength = 50;
            txtLexema.Name = "txtLexema";
            txtLexema.Size = new Size(260, 30);
            txtLexema.TabIndex = 3;
            // 
            // lblTipoToken
            // 
            lblTipoToken.AutoSize = true;
            lblTipoToken.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoToken.ForeColor = Color.DimGray;
            lblTipoToken.Location = new Point(310, 105);
            lblTipoToken.Name = "lblTipoToken";
            lblTipoToken.Size = new Size(122, 23);
            lblTipoToken.TabIndex = 4;
            lblTipoToken.Text = "Tipo de token";
            // 
            // cmbTipoToken
            // 
            cmbTipoToken.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoToken.Font = new Font("Segoe UI", 10F);
            cmbTipoToken.FormattingEnabled = true;
            cmbTipoToken.Location = new Point(310, 130);
            cmbTipoToken.Name = "cmbTipoToken";
            cmbTipoToken.Size = new Size(260, 31);
            cmbTipoToken.TabIndex = 5;
            // 
            // chkEsTipoDato
            // 
            chkEsTipoDato.AutoSize = true;
            chkEsTipoDato.Font = new Font("Segoe UI", 10F);
            chkEsTipoDato.Location = new Point(600, 132);
            chkEsTipoDato.Name = "chkEsTipoDato";
            chkEsTipoDato.Size = new Size(332, 27);
            chkEsTipoDato.TabIndex = 6;
            chkEsTipoDato.Text = "Este lexema representa un tipo de dato";
            chkEsTipoDato.UseVisualStyleBackColor = true;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescripcion.ForeColor = Color.DimGray;
            lblDescripcion.Location = new Point(28, 180);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(103, 23);
            lblDescripcion.TabIndex = 7;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Location = new Point(28, 205);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(820, 55);
            txtDescripcion.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Blue;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(28, 280);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 40);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.LightBlue;
            btnEditar.Enabled = false;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(170, 280);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(160, 40);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Guardar cambios";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.LightCoral;
            btnEliminar.Enabled = false;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(342, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 40);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightCoral;
            btnCancelar.Enabled = false;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(484, 280);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 40);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar edición";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRegistros.ForeColor = Color.DimGray;
            lblTotalRegistros.Location = new Point(800, 292);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(104, 23);
            lblTotalRegistros.TabIndex = 13;
            lblTotalRegistros.Text = "Registros: 0";
            // 
            // dgvDiccionario
            // 
            dgvDiccionario.AllowUserToAddRows = false;
            dgvDiccionario.AllowUserToDeleteRows = false;
            dgvDiccionario.AllowUserToResizeRows = false;
            dgvDiccionario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDiccionario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiccionario.BackgroundColor = Color.White;
            dgvDiccionario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiccionario.Location = new Point(28, 340);
            dgvDiccionario.MultiSelect = false;
            dgvDiccionario.Name = "dgvDiccionario";
            dgvDiccionario.ReadOnly = true;
            dgvDiccionario.RowHeadersVisible = false;
            dgvDiccionario.RowHeadersWidth = 51;
            dgvDiccionario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiccionario.Size = new Size(975, 245);
            dgvDiccionario.TabIndex = 14;
            // 
            // FormDiccionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1032, 603);
            Controls.Add(dgvDiccionario);
            Controls.Add(lblTotalRegistros);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(chkEsTipoDato);
            Controls.Add(cmbTipoToken);
            Controls.Add(lblTipoToken);
            Controls.Add(txtLexema);
            Controls.Add(lblLexema);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(900, 550);
            Name = "FormDiccionario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administración del diccionario léxico";
            ((System.ComponentModel.ISupportInitialize)dgvDiccionario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblLexema;
        private TextBox txtLexema;
        private Label lblTipoToken;
        private ComboBox cmbTipoToken;
        private CheckBox chkEsTipoDato;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
        private Label lblTotalRegistros;
        private DataGridView dgvDiccionario;
    }
}