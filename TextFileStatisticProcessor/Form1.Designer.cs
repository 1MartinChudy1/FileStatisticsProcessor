namespace TextFileStatisticProcessor
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.copyButton = new System.Windows.Forms.Button();
            this.omitDiacriticsButton = new System.Windows.Forms.Button();
            this.omitEmptyLines = new System.Windows.Forms.Button();
            this.omitSpacesAndInterpunctionButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.sentenceCountText = new System.Windows.Forms.Label();
            this.sentenceCountValue = new System.Windows.Forms.Label();
            this.wordCountText = new System.Windows.Forms.Label();
            this.wordCountValue = new System.Windows.Forms.Label();
            this.characterCountText = new System.Windows.Forms.Label();
            this.characterCountValue = new System.Windows.Forms.Label();
            this.rowCountText = new System.Windows.Forms.Label();
            this.rowCountValue = new System.Windows.Forms.Label();
            this.selectInputButton = new System.Windows.Forms.Button();
            this.selectOutputButton = new System.Windows.Forms.Button();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // copyButton
            // 
            this.copyButton.Enabled = false;
            this.copyButton.Location = new System.Drawing.Point(264, 31);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(194, 23);
            this.copyButton.TabIndex = 0;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // omitDiacriticsButton
            // 
            this.omitDiacriticsButton.Enabled = false;
            this.omitDiacriticsButton.Location = new System.Drawing.Point(264, 60);
            this.omitDiacriticsButton.Name = "omitDiacriticsButton";
            this.omitDiacriticsButton.Size = new System.Drawing.Size(194, 23);
            this.omitDiacriticsButton.TabIndex = 1;
            this.omitDiacriticsButton.Text = "Omit diacritics";
            this.omitDiacriticsButton.UseVisualStyleBackColor = true;
            this.omitDiacriticsButton.Click += new System.EventHandler(this.OmitDiacriticsButton_Click);
            // 
            // omitEmptyLines
            // 
            this.omitEmptyLines.Enabled = false;
            this.omitEmptyLines.Location = new System.Drawing.Point(264, 89);
            this.omitEmptyLines.Name = "omitEmptyLines";
            this.omitEmptyLines.Size = new System.Drawing.Size(194, 23);
            this.omitEmptyLines.TabIndex = 2;
            this.omitEmptyLines.Text = "Omit empty lines";
            this.omitEmptyLines.UseVisualStyleBackColor = true;
            this.omitEmptyLines.Click += new System.EventHandler(this.OmitEmptyLines_Click);
            // 
            // omitSpacesAndInterpunctionButton
            // 
            this.omitSpacesAndInterpunctionButton.Enabled = false;
            this.omitSpacesAndInterpunctionButton.Location = new System.Drawing.Point(264, 118);
            this.omitSpacesAndInterpunctionButton.Name = "omitSpacesAndInterpunctionButton";
            this.omitSpacesAndInterpunctionButton.Size = new System.Drawing.Size(194, 23);
            this.omitSpacesAndInterpunctionButton.TabIndex = 3;
            this.omitSpacesAndInterpunctionButton.Text = "Omit spaces and interpunction";
            this.omitSpacesAndInterpunctionButton.UseVisualStyleBackColor = true;
            this.omitSpacesAndInterpunctionButton.Click += new System.EventHandler(this.OmitSpacesAndInterpunctionButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(61, 167);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(342, 13);
            this.progressBar1.TabIndex = 4;
            // 
            // sentenceCountText
            // 
            this.sentenceCountText.AutoSize = true;
            this.sentenceCountText.Location = new System.Drawing.Point(167, 198);
            this.sentenceCountText.Name = "sentenceCountText";
            this.sentenceCountText.Size = new System.Drawing.Size(86, 13);
            this.sentenceCountText.TabIndex = 5;
            this.sentenceCountText.Text = "Sentence count:";
            // 
            // sentenceCountValue
            // 
            this.sentenceCountValue.AutoSize = true;
            this.sentenceCountValue.Location = new System.Drawing.Point(287, 198);
            this.sentenceCountValue.Name = "sentenceCountValue";
            this.sentenceCountValue.Size = new System.Drawing.Size(33, 13);
            this.sentenceCountValue.TabIndex = 6;
            this.sentenceCountValue.Text = "None";
            // 
            // wordCountText
            // 
            this.wordCountText.AutoSize = true;
            this.wordCountText.Location = new System.Drawing.Point(168, 224);
            this.wordCountText.Name = "wordCountText";
            this.wordCountText.Size = new System.Drawing.Size(66, 13);
            this.wordCountText.TabIndex = 7;
            this.wordCountText.Text = "Word count:";
            // 
            // wordCountValue
            // 
            this.wordCountValue.AutoSize = true;
            this.wordCountValue.Location = new System.Drawing.Point(287, 224);
            this.wordCountValue.Name = "wordCountValue";
            this.wordCountValue.Size = new System.Drawing.Size(33, 13);
            this.wordCountValue.TabIndex = 8;
            this.wordCountValue.Text = "None";
            // 
            // characterCountText
            // 
            this.characterCountText.AutoSize = true;
            this.characterCountText.Location = new System.Drawing.Point(168, 248);
            this.characterCountText.Name = "characterCountText";
            this.characterCountText.Size = new System.Drawing.Size(86, 13);
            this.characterCountText.TabIndex = 10;
            this.characterCountText.Text = "Character count:";
            // 
            // characterCountValue
            // 
            this.characterCountValue.AutoSize = true;
            this.characterCountValue.Location = new System.Drawing.Point(287, 248);
            this.characterCountValue.Name = "characterCountValue";
            this.characterCountValue.Size = new System.Drawing.Size(33, 13);
            this.characterCountValue.TabIndex = 11;
            this.characterCountValue.Text = "None";
            // 
            // rowCountText
            // 
            this.rowCountText.AutoSize = true;
            this.rowCountText.Location = new System.Drawing.Point(167, 273);
            this.rowCountText.Name = "rowCountText";
            this.rowCountText.Size = new System.Drawing.Size(62, 13);
            this.rowCountText.TabIndex = 12;
            this.rowCountText.Text = "Row count:";
            // 
            // rowCountValue
            // 
            this.rowCountValue.AutoSize = true;
            this.rowCountValue.Location = new System.Drawing.Point(287, 273);
            this.rowCountValue.Name = "rowCountValue";
            this.rowCountValue.Size = new System.Drawing.Size(33, 13);
            this.rowCountValue.TabIndex = 13;
            this.rowCountValue.Text = "None";
            // 
            // selectInputButton
            // 
            this.selectInputButton.Location = new System.Drawing.Point(61, 31);
            this.selectInputButton.Name = "selectInputButton";
            this.selectInputButton.Size = new System.Drawing.Size(173, 52);
            this.selectInputButton.TabIndex = 14;
            this.selectInputButton.Text = "Select input file";
            this.selectInputButton.UseVisualStyleBackColor = true;
            this.selectInputButton.Click += new System.EventHandler(this.selectInputButton_Click);
            // 
            // selectOutputButton
            // 
            this.selectOutputButton.Location = new System.Drawing.Point(61, 89);
            this.selectOutputButton.Name = "selectOutputButton";
            this.selectOutputButton.Size = new System.Drawing.Size(173, 52);
            this.selectOutputButton.TabIndex = 15;
            this.selectOutputButton.Text = "Select output file";
            this.selectOutputButton.UseVisualStyleBackColor = true;
            this.selectOutputButton.Click += new System.EventHandler(this.selectOutputButton_Click);
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(425, 167);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(0, 13);
            this.percentageLabel.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(529, 344);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.selectOutputButton);
            this.Controls.Add(this.selectInputButton);
            this.Controls.Add(this.rowCountValue);
            this.Controls.Add(this.rowCountText);
            this.Controls.Add(this.characterCountValue);
            this.Controls.Add(this.characterCountText);
            this.Controls.Add(this.wordCountValue);
            this.Controls.Add(this.wordCountText);
            this.Controls.Add(this.sentenceCountValue);
            this.Controls.Add(this.sentenceCountText);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.omitSpacesAndInterpunctionButton);
            this.Controls.Add(this.omitEmptyLines);
            this.Controls.Add(this.omitDiacriticsButton);
            this.Controls.Add(this.copyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Text file statistics processor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button omitDiacriticsButton;
        private System.Windows.Forms.Button omitEmptyLines;
        private System.Windows.Forms.Button omitSpacesAndInterpunctionButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label sentenceCountText;
        private System.Windows.Forms.Label sentenceCountValue;
        private System.Windows.Forms.Label wordCountText;
        private System.Windows.Forms.Label wordCountValue;
        private System.Windows.Forms.Label characterCountText;
        private System.Windows.Forms.Label characterCountValue;
        private System.Windows.Forms.Label rowCountText;
        private System.Windows.Forms.Label rowCountValue;
        private System.Windows.Forms.Button selectInputButton;
        private System.Windows.Forms.Button selectOutputButton;
        private System.Windows.Forms.Label percentageLabel;
    }
}

