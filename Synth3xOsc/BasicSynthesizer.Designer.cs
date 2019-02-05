namespace Synth3xOsc
{
    partial class BasicSynthesizer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.bPlay = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.oscillograph1 = new Synth3xOsc.Oscillograph();
            this.oscillator3 = new Synth3xOsc.Oscillator();
            this.oscillator2 = new Synth3xOsc.Oscillator();
            this.oscillator1 = new Synth3xOsc.Oscillator();
            ((System.ComponentModel.ISupportInitialize)(this.oscillograph1)).BeginInit();
            this.SuspendLayout();
            // 
            // bPlay
            // 
            this.bPlay.Location = new System.Drawing.Point(265, 426);
            this.bPlay.Name = "bPlay";
            this.bPlay.Size = new System.Drawing.Size(181, 55);
            this.bPlay.TabIndex = 14;
            this.bPlay.Text = "Play";
            this.bPlay.UseVisualStyleBackColor = true;
            this.bPlay.Click += new System.EventHandler(this.button1_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(501, 426);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(181, 55);
            this.bStop.TabIndex = 15;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // oscillograph1
            // 
            this.oscillograph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oscillograph1.Location = new System.Drawing.Point(49, 223);
            this.oscillograph1.Name = "oscillograph1";
            this.oscillograph1.Size = new System.Drawing.Size(869, 187);
            this.oscillograph1.TabIndex = 0;
            this.oscillograph1.TabStop = false;
            this.oscillograph1.Click += new System.EventHandler(this.oscillograph1_Click);
            // 
            // oscillator3
            // 
            this.oscillator3.BackColor = System.Drawing.Color.Bisque;
            this.oscillator3.Location = new System.Drawing.Point(643, 13);
            this.oscillator3.Name = "oscillator3";
            this.oscillator3.Size = new System.Drawing.Size(309, 193);
            this.oscillator3.TabIndex = 13;
            this.oscillator3.TabStop = false;
            this.oscillator3.Text = "oscillator3";
            // 
            // oscillator2
            // 
            this.oscillator2.BackColor = System.Drawing.Color.Bisque;
            this.oscillator2.Location = new System.Drawing.Point(328, 13);
            this.oscillator2.Name = "oscillator2";
            this.oscillator2.Size = new System.Drawing.Size(309, 193);
            this.oscillator2.TabIndex = 12;
            this.oscillator2.TabStop = false;
            this.oscillator2.Text = "oscillator2";
            // 
            // oscillator1
            // 
            this.oscillator1.BackColor = System.Drawing.Color.Bisque;
            this.oscillator1.Location = new System.Drawing.Point(13, 13);
            this.oscillator1.Name = "oscillator1";
            this.oscillator1.Size = new System.Drawing.Size(309, 193);
            this.oscillator1.TabIndex = 0;
            this.oscillator1.TabStop = false;
            this.oscillator1.Text = "oscillator1";
            // 
            // BasicSynthesizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 506);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bPlay);
            this.Controls.Add(this.oscillograph1);
            this.Controls.Add(this.oscillator3);
            this.Controls.Add(this.oscillator2);
            this.Controls.Add(this.oscillator1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BasicSynthesizer";
            this.Text = "3xOsc";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicSynthesizer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BasicSynthesizer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.oscillograph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Oscillator oscillator1;
        private Oscillator oscillator2;
        private Oscillator oscillator3;
        private Oscillograph oscillograph1;
        private System.Windows.Forms.Button bPlay;
        private System.Windows.Forms.Button bStop;
    }
}

