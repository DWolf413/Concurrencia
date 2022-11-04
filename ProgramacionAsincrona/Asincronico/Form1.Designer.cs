namespace Asincronico
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnIniciar = new System.Windows.Forms.Button();
            this.loadingGIF = new System.Windows.Forms.PictureBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.pgProcesamiento = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGIF)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(299, 178);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(154, 37);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "IniciarProceso";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // loadingGIF
            // 
            this.loadingGIF.Image = ((System.Drawing.Image)(resources.GetObject("loadingGIF.Image")));
            this.loadingGIF.Location = new System.Drawing.Point(282, 237);
            this.loadingGIF.Name = "loadingGIF";
            this.loadingGIF.Size = new System.Drawing.Size(181, 130);
            this.loadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGIF.TabIndex = 1;
            this.loadingGIF.TabStop = false;
            this.loadingGIF.Visible = false;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(363, 48);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 23);
            this.txtInput.TabIndex = 2;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(299, 56);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(51, 15);
            this.Nombre.TabIndex = 3;
            this.Nombre.Text = "Nombre";
            // 
            // pgProcesamiento
            // 
            this.pgProcesamiento.Location = new System.Drawing.Point(282, 373);
            this.pgProcesamiento.Name = "pgProcesamiento";
            this.pgProcesamiento.Size = new System.Drawing.Size(181, 23);
            this.pgProcesamiento.TabIndex = 4;
            this.pgProcesamiento.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pgProcesamiento);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.loadingGIF);
            this.Controls.Add(this.btnIniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingGIF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnIniciar;
        private PictureBox loadingGIF;
        private TextBox txtInput;
        private Label Nombre;
        private ProgressBar pgProcesamiento;
    }
}