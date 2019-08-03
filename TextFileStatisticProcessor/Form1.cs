using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileStatisticProcessor
{
    public partial class Form1 : Form
    {

        private string inputFile = string.Empty;
        private string outputFile = string.Empty;
        BackgroundWorker worker = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.CreateGraphics().DrawString(e.ProgressPercentage.ToString() + "%",
                new Font("Arial", (float)8.25, FontStyle.Regular),
                Brushes.Black,
                new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                MessageBox.Show("Operation completed successfuly");
                percentageLabel.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            copyButton.Enabled = true;
        }

        private void selectInputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFile = inputFileDialog.FileName;
                if (IncorrectType(inputFile))
                    throw new Exception("Incorrect file type.");
            }

            EnableControlls();
        }

        private void selectOutputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog outputFileDialog = new OpenFileDialog();
            if (outputFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFile = outputFileDialog.FileName;
                if (IncorrectType(outputFile))
                    throw new Exception("Incorrect file type.");
            }

            EnableControlls();
        }

        private void EnableControlls()
        {
            if (inputFile != string.Empty && outputFile != string.Empty)
            {
                copyButton.Enabled = true;
                omitEmptyLines.Enabled = true;
                omitSpacesAndInterpunctionButton.Enabled = true;
                omitDiacriticsButton.Enabled = true;
            }
        }

        private bool IncorrectType(string fileName)
            => new FileInfo(fileName).Extension.ContainsAny(Enum.GetNames(typeof(AllowedTypes))) ? false : true;

        private void CopyButton_Click(object sender, EventArgs e)
        {
            IOperation operation = new Copy(inputFile, outputFile, worker);
            operation.EngageOperation();
        }

        private void OmitDiacriticsButton_Click(object sender, EventArgs e)
        {
            IOperation operation = new OmitDiacritics(inputFile, outputFile, worker);
            operation.EngageOperation();
        }

        private void OmitEmptyLines_Click(object sender, EventArgs e)
        {
            IOperation operation = new OmitEmptyLines(inputFile, outputFile, worker);
            operation.EngageOperation();
        }

        private void OmitSpacesAndInterpunctionButton_Click(object sender, EventArgs e)
        {
            IOperation operation = new OmitSpacesAndInterpunction(inputFile, outputFile, worker);
            operation.EngageOperation();
        }
    }
}
