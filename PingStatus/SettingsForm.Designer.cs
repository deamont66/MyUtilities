namespace PingStatus
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.adressTextField = new MetroFramework.Controls.MetroTextBox();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.saveButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.delayLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // adressTextField
            // 
            this.adressTextField.Lines = new string[] {
        "www.seznam.cz"};
            this.adressTextField.Location = new System.Drawing.Point(30, 95);
            this.adressTextField.MaxLength = 32767;
            this.adressTextField.Name = "adressTextField";
            this.adressTextField.PasswordChar = '\0';
            this.adressTextField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.adressTextField.SelectedText = "";
            this.adressTextField.Size = new System.Drawing.Size(240, 23);
            this.adressTextField.TabIndex = 0;
            this.adressTextField.Text = "www.seznam.cz";
            this.adressTextField.UseSelectable = true;
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(136, 135);
            this.metroTrackBar1.Maximum = 5000;
            this.metroTrackBar1.Minimum = 100;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(134, 23);
            this.metroTrackBar1.TabIndex = 1;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Value = 500;
            this.metroTrackBar1.ValueChanged += new System.EventHandler(this.metroTrackBar1_ValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(195, 175);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseSelectable = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(129, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Enter adress to ping:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 135);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Ping delay";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(99, 135);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(31, 19);
            this.delayLabel.TabIndex = 5;
            this.delayLabel.Text = "0,5s";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 219);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.metroTrackBar1);
            this.Controls.Add(this.adressTextField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Resizable = false;
            this.Text = "Ping Status - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox adressTextField;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroButton saveButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel delayLabel;
    }
}

