namespace Squad_Stats
{
    partial class Form1
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
            this.requestStatsButton = new System.Windows.Forms.Button();
            this.csgoStatsUrlTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // requestStatsButton
            // 
            this.requestStatsButton.Location = new System.Drawing.Point(12, 38);
            this.requestStatsButton.Name = "requestStatsButton";
            this.requestStatsButton.Size = new System.Drawing.Size(337, 20);
            this.requestStatsButton.TabIndex = 1;
            this.requestStatsButton.Text = "Get Stats";
            this.requestStatsButton.UseVisualStyleBackColor = true;
            this.requestStatsButton.Click += new System.EventHandler(this.RequestStatsButton_Click);
            // 
            // csgoStatsUrlTextBox
            // 
            this.csgoStatsUrlTextBox.Location = new System.Drawing.Point(12, 12);
            this.csgoStatsUrlTextBox.Name = "csgoStatsUrlTextBox";
            this.csgoStatsUrlTextBox.Size = new System.Drawing.Size(337, 20);
            this.csgoStatsUrlTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 75);
            this.Controls.Add(this.csgoStatsUrlTextBox);
            this.Controls.Add(this.requestStatsButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestStatsButton;
        private System.Windows.Forms.TextBox csgoStatsUrlTextBox;
    }
}

