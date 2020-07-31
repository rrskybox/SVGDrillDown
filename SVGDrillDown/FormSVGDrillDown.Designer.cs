namespace SVGDrillDown
{
    partial class FormSVGDrillDown
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
            this.OpenSVGFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenSVGButton = new System.Windows.Forms.Button();
            this.StockWidthBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DrillDepthBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.PlungeRateBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.FeedRateBox = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveGcodeFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CenterOriginButton = new System.Windows.Forms.RadioButton();
            this.NearLeftOriginButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VerifyGcodeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StockWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrillDepthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlungeRateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedRateBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenSVGFileDialog
            // 
            this.OpenSVGFileDialog.DefaultExt = "svg";
            // 
            // OpenSVGButton
            // 
            this.OpenSVGButton.Location = new System.Drawing.Point(12, 170);
            this.OpenSVGButton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenSVGButton.Name = "OpenSVGButton";
            this.OpenSVGButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OpenSVGButton.Size = new System.Drawing.Size(50, 36);
            this.OpenSVGButton.TabIndex = 0;
            this.OpenSVGButton.Text = "Load SVG";
            this.OpenSVGButton.UseVisualStyleBackColor = true;
            this.OpenSVGButton.Click += new System.EventHandler(this.LoadSVGButton_Click);
            // 
            // StockWidthBox
            // 
            this.StockWidthBox.DecimalPlaces = 2;
            this.StockWidthBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.StockWidthBox.Location = new System.Drawing.Point(146, 11);
            this.StockWidthBox.Name = "StockWidthBox";
            this.StockWidthBox.Size = new System.Drawing.Size(80, 20);
            this.StockWidthBox.TabIndex = 2;
            this.StockWidthBox.Value = new decimal(new int[] {
            85,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Stock Width (inches)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Drill Depth (inches)";
            // 
            // DrillDepthBox
            // 
            this.DrillDepthBox.DecimalPlaces = 2;
            this.DrillDepthBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DrillDepthBox.Location = new System.Drawing.Point(146, 37);
            this.DrillDepthBox.Name = "DrillDepthBox";
            this.DrillDepthBox.Size = new System.Drawing.Size(80, 20);
            this.DrillDepthBox.TabIndex = 5;
            this.DrillDepthBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Plunge Rate  (inches/min)";
            // 
            // PlungeRateBox
            // 
            this.PlungeRateBox.Location = new System.Drawing.Point(146, 88);
            this.PlungeRateBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.PlungeRateBox.Name = "PlungeRateBox";
            this.PlungeRateBox.Size = new System.Drawing.Size(80, 20);
            this.PlungeRateBox.TabIndex = 7;
            this.PlungeRateBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Feed Rate  (inches/min)";
            // 
            // FeedRateBox
            // 
            this.FeedRateBox.Location = new System.Drawing.Point(146, 63);
            this.FeedRateBox.Name = "FeedRateBox";
            this.FeedRateBox.Size = new System.Drawing.Size(80, 20);
            this.FeedRateBox.TabIndex = 9;
            this.FeedRateBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(186, 170);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SaveButton.Size = new System.Drawing.Size(50, 36);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save Gcode";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CenterOriginButton
            // 
            this.CenterOriginButton.AutoSize = true;
            this.CenterOriginButton.Checked = true;
            this.CenterOriginButton.Location = new System.Drawing.Point(49, 19);
            this.CenterOriginButton.Name = "CenterOriginButton";
            this.CenterOriginButton.Size = new System.Drawing.Size(56, 17);
            this.CenterOriginButton.TabIndex = 12;
            this.CenterOriginButton.TabStop = true;
            this.CenterOriginButton.Text = "Center";
            this.CenterOriginButton.UseVisualStyleBackColor = true;
            // 
            // NearLeftOriginButton
            // 
            this.NearLeftOriginButton.AutoSize = true;
            this.NearLeftOriginButton.Location = new System.Drawing.Point(121, 19);
            this.NearLeftOriginButton.Name = "NearLeftOriginButton";
            this.NearLeftOriginButton.Size = new System.Drawing.Size(69, 17);
            this.NearLeftOriginButton.TabIndex = 13;
            this.NearLeftOriginButton.Text = "Near Left";
            this.NearLeftOriginButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CenterOriginButton);
            this.groupBox1.Controls.Add(this.NearLeftOriginButton);
            this.groupBox1.Location = new System.Drawing.Point(0, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 51);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origin";
            // 
            // VerifyGcodeButton
            // 
            this.VerifyGcodeButton.Location = new System.Drawing.Point(106, 170);
            this.VerifyGcodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.VerifyGcodeButton.Name = "VerifyGcodeButton";
            this.VerifyGcodeButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VerifyGcodeButton.Size = new System.Drawing.Size(50, 36);
            this.VerifyGcodeButton.TabIndex = 15;
            this.VerifyGcodeButton.Text = "Verify Gcode";
            this.VerifyGcodeButton.UseVisualStyleBackColor = true;
            this.VerifyGcodeButton.Click += new System.EventHandler(this.VerifyGcodeButton_Click);
            // 
            // FormSVGDrillDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 217);
            this.Controls.Add(this.VerifyGcodeButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FeedRateBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PlungeRateBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DrillDepthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StockWidthBox);
            this.Controls.Add(this.OpenSVGButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSVGDrillDown";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.StockWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrillDepthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlungeRateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedRateBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenSVGFileDialog;
        private System.Windows.Forms.Button OpenSVGButton;
        private System.Windows.Forms.NumericUpDown StockWidthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DrillDepthBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PlungeRateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown FeedRateBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog SaveGcodeFileDialog;
        private System.Windows.Forms.RadioButton CenterOriginButton;
        private System.Windows.Forms.RadioButton NearLeftOriginButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button VerifyGcodeButton;
    }
}

