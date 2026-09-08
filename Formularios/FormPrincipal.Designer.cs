namespace AnalizadorLexicoCSharp.Formularios
{
    partial class FormPrincipal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            btnCargarArchivo = new Button();
            btnAnalizar = new Button();
            btnLimpiar = new Button();
            btnExportar = new Button();
            lblCodigoFuente = new Label();
            rtbCodigoFuente = new RichTextBox();
            pnlEncabezado = new Panel();
            pnlLineaSuperior = new Panel();
            tabResultados = new TabControl();
            tabTokens = new TabPage();
            dgvTokens = new DataGridView();
            colNumero = new DataGridViewTextBoxColumn();
            colLexema = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colLinea = new DataGridViewTextBoxColumn();
            colColumna = new DataGridViewTextBoxColumn();
            tabErrores = new TabPage();
            dgvErrores = new DataGridView();
            colErrorLexema = new DataGridViewTextBoxColumn();
            colErrorLinea = new DataGridViewTextBoxColumn();
            colErrorColumna = new DataGridViewTextBoxColumn();
            colErrorDescripcion = new DataGridViewTextBoxColumn();
            tabSimbolos = new TabPage();
            dgvSimbolos = new DataGridView();
            colSimboloNombre = new DataGridViewTextBoxColumn();
            colPrimeraLinea = new DataGridViewTextBoxColumn();
            colPrimeraColumna = new DataGridViewTextBoxColumn();
            colTipoDato = new DataGridViewTextBoxColumn();
            colApariciones = new DataGridViewTextBoxColumn();
            pnlEstado = new Panel();
            lblTotalTokens = new Label();
            lblTotalErrores = new Label();
            lblTotalLineas = new Label();
            lblEstado = new Label();
            tabResultados.SuspendLayout();
            tabTokens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTokens).BeginInit();
            tabErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErrores).BeginInit();
            tabSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSimbolos).BeginInit();
            pnlEstado.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.AliceBlue;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(415, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ANALIZADOR LÉXICO DE C#";
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.BackColor = Color.LightSteelBlue;
            btnCargarArchivo.Cursor = Cursors.Hand;
            btnCargarArchivo.FlatAppearance.BorderSize = 0;
            btnCargarArchivo.FlatStyle = FlatStyle.Flat;
            btnCargarArchivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargarArchivo.ForeColor = Color.Black;
            btnCargarArchivo.Location = new Point(20, 65);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(125, 38);
            btnCargarArchivo.TabIndex = 11;
            btnCargarArchivo.Text = "Cargar Archivo";
            btnCargarArchivo.UseVisualStyleBackColor = false;
            // 
            // btnAnalizar
            // 
            btnAnalizar.BackColor = Color.CornflowerBlue;
            btnAnalizar.Cursor = Cursors.Hand;
            btnAnalizar.FlatAppearance.BorderSize = 0;
            btnAnalizar.FlatStyle = FlatStyle.Flat;
            btnAnalizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnalizar.ForeColor = Color.Black;
            btnAnalizar.Location = new Point(155, 65);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(125, 38);
            btnAnalizar.TabIndex = 12;
            btnAnalizar.Text = "Analizar";
            btnAnalizar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gainsboro;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.Black;
            btnLimpiar.Location = new Point(290, 65);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 38);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.Gainsboro;
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportar.ForeColor = Color.Black;
            btnExportar.Location = new Point(410, 65);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(110, 38);
            btnExportar.TabIndex = 14;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // lblCodigoFuente
            // 
            lblCodigoFuente.AutoSize = true;
            lblCodigoFuente.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigoFuente.ForeColor = Color.Black;
            lblCodigoFuente.Location = new Point(20, 120);
            lblCodigoFuente.Name = "lblCodigoFuente";
            lblCodigoFuente.Size = new Size(135, 25);
            lblCodigoFuente.TabIndex = 15;
            lblCodigoFuente.Text = "Código Fuente";
            // 
            // rtbCodigoFuente
            // 
            rtbCodigoFuente.AcceptsTab = true;
            rtbCodigoFuente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtbCodigoFuente.BackColor = Color.White;
            rtbCodigoFuente.BorderStyle = BorderStyle.FixedSingle;
            rtbCodigoFuente.DetectUrls = false;
            rtbCodigoFuente.Font = new Font("Consolas", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbCodigoFuente.ForeColor = Color.Black;
            rtbCodigoFuente.Location = new Point(20, 150);
            rtbCodigoFuente.Name = "rtbCodigoFuente";
            rtbCodigoFuente.Size = new Size(500, 440);
            rtbCodigoFuente.TabIndex = 16;
            rtbCodigoFuente.Text = "";
            rtbCodigoFuente.WordWrap = false;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlEncabezado.BackColor = Color.AliceBlue;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1185, 110);
            pnlEncabezado.TabIndex = 17;
            // 
            // pnlLineaSuperior
            // 
            pnlLineaSuperior.BackColor = Color.SteelBlue;
            pnlLineaSuperior.Location = new Point(0, 0);
            pnlLineaSuperior.Name = "pnlLineaSuperior";
            pnlLineaSuperior.Size = new Size(8, 110);
            pnlLineaSuperior.TabIndex = 18;
            // 
            // tabResultados
            // 
            tabResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabResultados.Controls.Add(tabTokens);
            tabResultados.Controls.Add(tabErrores);
            tabResultados.Controls.Add(tabSimbolos);
            tabResultados.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabResultados.Location = new Point(550, 120);
            tabResultados.Name = "tabResultados";
            tabResultados.SelectedIndex = 0;
            tabResultados.Size = new Size(620, 470);
            tabResultados.TabIndex = 19;
            // 
            // tabTokens
            // 
            tabTokens.BackColor = Color.White;
            tabTokens.Controls.Add(dgvTokens);
            tabTokens.ForeColor = Color.Black;
            tabTokens.Location = new Point(4, 32);
            tabTokens.Name = "tabTokens";
            tabTokens.Padding = new Padding(3);
            tabTokens.Size = new Size(612, 434);
            tabTokens.TabIndex = 0;
            tabTokens.Text = "Tokens";
            // 
            // dgvTokens
            // 
            dgvTokens.AllowUserToAddRows = false;
            dgvTokens.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvTokens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTokens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTokens.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTokens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTokens.ColumnHeadersHeight = 38;
            dgvTokens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTokens.Columns.AddRange(new DataGridViewColumn[] { colNumero, colLexema, colTipo, colLinea, colColumna });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.AliceBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTokens.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTokens.Dock = DockStyle.Fill;
            dgvTokens.EnableHeadersVisualStyles = false;
            dgvTokens.GridColor = Color.Gainsboro;
            dgvTokens.Location = new Point(3, 3);
            dgvTokens.MultiSelect = false;
            dgvTokens.Name = "dgvTokens";
            dgvTokens.ReadOnly = true;
            dgvTokens.RowHeadersVisible = false;
            dgvTokens.RowHeadersWidth = 51;
            dgvTokens.RowTemplate.Height = 28;
            dgvTokens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTokens.Size = new Size(606, 428);
            dgvTokens.TabIndex = 0;
            // 
            // colNumero
            // 
            colNumero.HeaderText = "#";
            colNumero.MinimumWidth = 6;
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // colLexema
            // 
            colLexema.HeaderText = "Lexema";
            colLexema.MinimumWidth = 6;
            colLexema.Name = "colLexema";
            colLexema.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo de token";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colLinea
            // 
            colLinea.HeaderText = "Línea";
            colLinea.MinimumWidth = 6;
            colLinea.Name = "colLinea";
            colLinea.ReadOnly = true;
            // 
            // colColumna
            // 
            colColumna.HeaderText = "Columna";
            colColumna.MinimumWidth = 6;
            colColumna.Name = "colColumna";
            colColumna.ReadOnly = true;
            // 
            // tabErrores
            // 
            tabErrores.BackColor = Color.White;
            tabErrores.Controls.Add(dgvErrores);
            tabErrores.ForeColor = Color.Black;
            tabErrores.Location = new Point(4, 32);
            tabErrores.Name = "tabErrores";
            tabErrores.Padding = new Padding(3);
            tabErrores.Size = new Size(612, 434);
            tabErrores.TabIndex = 1;
            tabErrores.Text = "Errores";
            // 
            // dgvErrores
            // 
            dgvErrores.AllowUserToAddRows = false;
            dgvErrores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dgvErrores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrores.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.MistyRose;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.MistyRose;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvErrores.ColumnHeadersHeight = 38;
            dgvErrores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvErrores.Columns.AddRange(new DataGridViewColumn[] { colErrorLexema, colErrorLinea, colErrorColumna, colErrorDescripcion });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.MistyRose;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvErrores.DefaultCellStyle = dataGridViewCellStyle6;
            dgvErrores.Dock = DockStyle.Fill;
            dgvErrores.EnableHeadersVisualStyles = false;
            dgvErrores.GridColor = Color.Gainsboro;
            dgvErrores.Location = new Point(3, 3);
            dgvErrores.MultiSelect = false;
            dgvErrores.Name = "dgvErrores";
            dgvErrores.ReadOnly = true;
            dgvErrores.RowHeadersVisible = false;
            dgvErrores.RowHeadersWidth = 51;
            dgvErrores.RowTemplate.Height = 28;
            dgvErrores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErrores.Size = new Size(606, 428);
            dgvErrores.TabIndex = 0;
            // 
            // colErrorLexema
            // 
            colErrorLexema.HeaderText = "Lexema o carácter";
            colErrorLexema.MinimumWidth = 6;
            colErrorLexema.Name = "colErrorLexema";
            colErrorLexema.ReadOnly = true;
            // 
            // colErrorLinea
            // 
            colErrorLinea.HeaderText = "Línea";
            colErrorLinea.MinimumWidth = 6;
            colErrorLinea.Name = "colErrorLinea";
            colErrorLinea.ReadOnly = true;
            // 
            // colErrorColumna
            // 
            colErrorColumna.HeaderText = "Columna";
            colErrorColumna.MinimumWidth = 6;
            colErrorColumna.Name = "colErrorColumna";
            colErrorColumna.ReadOnly = true;
            // 
            // colErrorDescripcion
            // 
            colErrorDescripcion.HeaderText = "Descripción";
            colErrorDescripcion.MinimumWidth = 6;
            colErrorDescripcion.Name = "colErrorDescripcion";
            colErrorDescripcion.ReadOnly = true;
            // 
            // tabSimbolos
            // 
            tabSimbolos.BackColor = Color.White;
            tabSimbolos.Controls.Add(dgvSimbolos);
            tabSimbolos.ForeColor = Color.Black;
            tabSimbolos.Location = new Point(4, 32);
            tabSimbolos.Name = "tabSimbolos";
            tabSimbolos.Padding = new Padding(3);
            tabSimbolos.Size = new Size(612, 434);
            tabSimbolos.TabIndex = 2;
            tabSimbolos.Text = "Tabla de símbolos";
            // 
            // dgvSimbolos
            // 
            dgvSimbolos.AllowUserToAddRows = false;
            dgvSimbolos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dgvSimbolos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvSimbolos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSimbolos.BackgroundColor = Color.White;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.LightSteelBlue;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvSimbolos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvSimbolos.ColumnHeadersHeight = 38;
            dgvSimbolos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSimbolos.Columns.AddRange(new DataGridViewColumn[] { colSimboloNombre, colPrimeraLinea, colPrimeraColumna, colTipoDato, colApariciones });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.AliceBlue;
            dataGridViewCellStyle9.SelectionForeColor = Color.Black;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvSimbolos.DefaultCellStyle = dataGridViewCellStyle9;
            dgvSimbolos.Dock = DockStyle.Fill;
            dgvSimbolos.EnableHeadersVisualStyles = false;
            dgvSimbolos.GridColor = Color.Gainsboro;
            dgvSimbolos.Location = new Point(3, 3);
            dgvSimbolos.MultiSelect = false;
            dgvSimbolos.Name = "dgvSimbolos";
            dgvSimbolos.ReadOnly = true;
            dgvSimbolos.RowHeadersVisible = false;
            dgvSimbolos.RowHeadersWidth = 51;
            dgvSimbolos.RowTemplate.Height = 28;
            dgvSimbolos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSimbolos.Size = new Size(606, 428);
            dgvSimbolos.TabIndex = 0;
            // 
            // colSimboloNombre
            // 
            colSimboloNombre.HeaderText = "Nombre";
            colSimboloNombre.MinimumWidth = 6;
            colSimboloNombre.Name = "colSimboloNombre";
            colSimboloNombre.ReadOnly = true;
            // 
            // colPrimeraLinea
            // 
            colPrimeraLinea.HeaderText = "Primera línea";
            colPrimeraLinea.MinimumWidth = 6;
            colPrimeraLinea.Name = "colPrimeraLinea";
            colPrimeraLinea.ReadOnly = true;
            // 
            // colPrimeraColumna
            // 
            colPrimeraColumna.HeaderText = "Primera columna";
            colPrimeraColumna.MinimumWidth = 6;
            colPrimeraColumna.Name = "colPrimeraColumna";
            colPrimeraColumna.ReadOnly = true;
            // 
            // colTipoDato
            // 
            colTipoDato.HeaderText = "Tipo de dato";
            colTipoDato.MinimumWidth = 6;
            colTipoDato.Name = "colTipoDato";
            colTipoDato.ReadOnly = true;
            // 
            // colApariciones
            // 
            colApariciones.HeaderText = "Apariciones";
            colApariciones.MinimumWidth = 6;
            colApariciones.Name = "colApariciones";
            colApariciones.ReadOnly = true;
            // 
            // pnlEstado
            // 
            pnlEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlEstado.BackColor = Color.White;
            pnlEstado.BorderStyle = BorderStyle.FixedSingle;
            pnlEstado.Controls.Add(lblEstado);
            pnlEstado.Controls.Add(lblTotalLineas);
            pnlEstado.Controls.Add(lblTotalErrores);
            pnlEstado.Controls.Add(lblTotalTokens);
            pnlEstado.Location = new Point(0, 605);
            pnlEstado.Name = "pnlEstado";
            pnlEstado.Size = new Size(1185, 45);
            pnlEstado.TabIndex = 20;
            // 
            // lblTotalTokens
            // 
            lblTotalTokens.AutoSize = true;
            lblTotalTokens.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotalTokens.ForeColor = Color.Black;
            lblTotalTokens.Location = new Point(15, 12);
            lblTotalTokens.Name = "lblTotalTokens";
            lblTotalTokens.Size = new Size(73, 20);
            lblTotalTokens.TabIndex = 0;
            lblTotalTokens.Text = "Tokens: 0";
            // 
            // lblTotalErrores
            // 
            lblTotalErrores.AutoSize = true;
            lblTotalErrores.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotalErrores.ForeColor = Color.Black;
            lblTotalErrores.Location = new Point(130, 12);
            lblTotalErrores.Name = "lblTotalErrores";
            lblTotalErrores.Size = new Size(74, 20);
            lblTotalErrores.TabIndex = 1;
            lblTotalErrores.Text = "Errores: 0";
            // 
            // lblTotalLineas
            // 
            lblTotalLineas.AutoSize = true;
            lblTotalLineas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotalLineas.ForeColor = Color.Black;
            lblTotalLineas.Location = new Point(245, 12);
            lblTotalLineas.Name = "lblTotalLineas";
            lblTotalLineas.Size = new Size(69, 20);
            lblTotalLineas.TabIndex = 2;
            lblTotalLineas.Text = "Líneas: 0";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.Black;
            lblEstado.Location = new Point(500, 12);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(89, 20);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Estado: listo";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1217, 693);
            Controls.Add(pnlEstado);
            Controls.Add(tabResultados);
            Controls.Add(lblTitulo);
            Controls.Add(pnlLineaSuperior);
            Controls.Add(rtbCodigoFuente);
            Controls.Add(lblCodigoFuente);
            Controls.Add(btnExportar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAnalizar);
            Controls.Add(btnCargarArchivo);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1100, 650);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Analizador léxico - C#";
            tabResultados.ResumeLayout(false);
            tabTokens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTokens).EndInit();
            tabErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvErrores).EndInit();
            tabSimbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSimbolos).EndInit();
            pnlEstado.ResumeLayout(false);
            pnlEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnCargarArchivo;
        private Button btnAnalizar;
        private Button btnLimpiar;
        private Button btnExportar;
        private Label lblCodigoFuente;
        private RichTextBox rtbCodigoFuente;
        private Panel pnlEncabezado;
        private Panel pnlLineaSuperior;
        private TabControl tabResultados;
        private TabPage tabTokens;
        private TabPage tabErrores;
        private DataGridView dgvTokens;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colLexema;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colLinea;
        private DataGridViewTextBoxColumn colColumna;
        private TabPage tabSimbolos;
        private DataGridView dgvErrores;
        private DataGridViewTextBoxColumn colErrorLexema;
        private DataGridViewTextBoxColumn colErrorLinea;
        private DataGridViewTextBoxColumn colErrorColumna;
        private DataGridViewTextBoxColumn colErrorDescripcion;
        private DataGridView dgvSimbolos;
        private DataGridViewTextBoxColumn colSimboloNombre;
        private DataGridViewTextBoxColumn colPrimeraLinea;
        private DataGridViewTextBoxColumn colPrimeraColumna;
        private DataGridViewTextBoxColumn colTipoDato;
        private DataGridViewTextBoxColumn colApariciones;
        private Panel pnlEstado;
        private Label lblEstado;
        private Label lblTotalLineas;
        private Label lblTotalErrores;
        private Label lblTotalTokens;
    }
}