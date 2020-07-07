namespace Quispe.Fernando._2D
{
    partial class FrmEvaluaciones
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
            this.components = new System.ComponentModel.Container();
            this.btnIniciarEvaluacion = new System.Windows.Forms.Button();
            this.lstAlumnosEnEspera = new System.Windows.Forms.ListBox();
            this.lstAlumnosEvaluando = new System.Windows.Forms.ListBox();
            this.lblAlumnosEnEspera = new System.Windows.Forms.Label();
            this.lstAlumnosEvaluados = new System.Windows.Forms.ListBox();
            this.lblAlumnosEvaluando = new System.Windows.Forms.Label();
            this.lblAlumnosEvaluados = new System.Windows.Forms.Label();
            this.alumnosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jardinUtnDataSet = new Quispe.Fernando._2D.JardinUtnDataSet();
            this.alumnosTableAdapter = new Quispe.Fernando._2D.JardinUtnDataSetTableAdapters.AlumnosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jardinUtnDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarEvaluacion
            // 
            this.btnIniciarEvaluacion.Location = new System.Drawing.Point(25, 321);
            this.btnIniciarEvaluacion.Name = "btnIniciarEvaluacion";
            this.btnIniciarEvaluacion.Size = new System.Drawing.Size(164, 36);
            this.btnIniciarEvaluacion.TabIndex = 0;
            this.btnIniciarEvaluacion.Text = "Iniciar Evaluacion";
            this.btnIniciarEvaluacion.UseVisualStyleBackColor = true;
            this.btnIniciarEvaluacion.Click += new System.EventHandler(this.btnIniciarEvaluacion_Click);
            // 
            // lstAlumnosEnEspera
            // 
            this.lstAlumnosEnEspera.FormattingEnabled = true;
            this.lstAlumnosEnEspera.ItemHeight = 16;
            this.lstAlumnosEnEspera.Location = new System.Drawing.Point(25, 98);
            this.lstAlumnosEnEspera.Name = "lstAlumnosEnEspera";
            this.lstAlumnosEnEspera.Size = new System.Drawing.Size(293, 180);
            this.lstAlumnosEnEspera.TabIndex = 1;
            this.lstAlumnosEnEspera.SelectedIndexChanged += new System.EventHandler(this.lstAlumnoIngresado_SelectedIndexChanged);
            // 
            // lstAlumnosEvaluando
            // 
            this.lstAlumnosEvaluando.FormattingEnabled = true;
            this.lstAlumnosEvaluando.ItemHeight = 16;
            this.lstAlumnosEvaluando.Location = new System.Drawing.Point(346, 98);
            this.lstAlumnosEvaluando.Name = "lstAlumnosEvaluando";
            this.lstAlumnosEvaluando.Size = new System.Drawing.Size(297, 180);
            this.lstAlumnosEvaluando.TabIndex = 2;
            // 
            // lblAlumnosEnEspera
            // 
            this.lblAlumnosEnEspera.AutoSize = true;
            this.lblAlumnosEnEspera.Location = new System.Drawing.Point(22, 57);
            this.lblAlumnosEnEspera.Name = "lblAlumnosEnEspera";
            this.lblAlumnosEnEspera.Size = new System.Drawing.Size(132, 17);
            this.lblAlumnosEnEspera.TabIndex = 4;
            this.lblAlumnosEnEspera.Text = "Alumnos En Espera";
            this.lblAlumnosEnEspera.Click += new System.EventHandler(this.lblAlumno_Click);
            // 
            // lstAlumnosEvaluados
            // 
            this.lstAlumnosEvaluados.FormattingEnabled = true;
            this.lstAlumnosEvaluados.ItemHeight = 16;
            this.lstAlumnosEvaluados.Location = new System.Drawing.Point(668, 98);
            this.lstAlumnosEvaluados.Name = "lstAlumnosEvaluados";
            this.lstAlumnosEvaluados.Size = new System.Drawing.Size(321, 180);
            this.lstAlumnosEvaluados.TabIndex = 5;
            // 
            // lblAlumnosEvaluando
            // 
            this.lblAlumnosEvaluando.AutoSize = true;
            this.lblAlumnosEvaluando.Location = new System.Drawing.Point(343, 57);
            this.lblAlumnosEvaluando.Name = "lblAlumnosEvaluando";
            this.lblAlumnosEvaluando.Size = new System.Drawing.Size(133, 17);
            this.lblAlumnosEvaluando.TabIndex = 6;
            this.lblAlumnosEvaluando.Text = "Alumnos Evaluando";
            // 
            // lblAlumnosEvaluados
            // 
            this.lblAlumnosEvaluados.AutoSize = true;
            this.lblAlumnosEvaluados.Location = new System.Drawing.Point(675, 57);
            this.lblAlumnosEvaluados.Name = "lblAlumnosEvaluados";
            this.lblAlumnosEvaluados.Size = new System.Drawing.Size(132, 17);
            this.lblAlumnosEvaluados.TabIndex = 7;
            this.lblAlumnosEvaluados.Text = "Alumnos Evaluados";
            // 
            // alumnosBindingSource
            // 
            this.alumnosBindingSource.DataMember = "Alumnos";
            this.alumnosBindingSource.DataSource = this.jardinUtnDataSet;
            // 
            // jardinUtnDataSet
            // 
            this.jardinUtnDataSet.DataSetName = "JardinUtnDataSet";
            this.jardinUtnDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alumnosTableAdapter
            // 
            this.alumnosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmEvaluaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1016, 406);
            this.Controls.Add(this.lblAlumnosEvaluados);
            this.Controls.Add(this.lblAlumnosEvaluando);
            this.Controls.Add(this.lstAlumnosEvaluados);
            this.Controls.Add(this.lblAlumnosEnEspera);
            this.Controls.Add(this.lstAlumnosEvaluando);
            this.Controls.Add(this.lstAlumnosEnEspera);
            this.Controls.Add(this.btnIniciarEvaluacion);
            this.Name = "FrmEvaluaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Evaluaciones";
            this.Load += new System.EventHandler(this.Evaluaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jardinUtnDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarEvaluacion;
        private System.Windows.Forms.ListBox lstAlumnosEnEspera;
        private System.Windows.Forms.ListBox lstAlumnosEvaluando;
        private System.Windows.Forms.Label lblAlumnosEnEspera;
        private System.Windows.Forms.ListBox lstAlumnosEvaluados;
        private System.Windows.Forms.Label lblAlumnosEvaluando;
        private System.Windows.Forms.Label lblAlumnosEvaluados;
        private JardinUtnDataSet jardinUtnDataSet;
        private System.Windows.Forms.BindingSource alumnosBindingSource;
        private JardinUtnDataSetTableAdapters.AlumnosTableAdapter alumnosTableAdapter;
    }
}