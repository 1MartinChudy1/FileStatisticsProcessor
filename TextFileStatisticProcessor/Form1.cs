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

        delegate void SetPercentageCallback(int value);

        /// <summary>
        /// When the progress in operation occurs, this method sets the correct percentage value and
        /// progress to the progress bar in Form
        /// </summary>
        /// <param name="sender">Background worker object</param>
        /// <param name="e">Background worker progress changed events</param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetPercentage(e.ProgressPercentage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SetPercentage(int value)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetPercentageCallback d = new SetPercentageCallback(SetPercentage);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                progressBar1.Value = value;
                progressBar1.CreateGraphics().DrawString(value.ToString() + "%",
                    new Font("Arial", (float)8.25, FontStyle.Regular),
                    Brushes.Black,
                    new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));


                if (progressBar1.Value == 100)
                {
                    progressBar1.Value = 0;
                    percentageLabel.Text = string.Empty;
                }
            }
        }
        
        /// <summary>
        /// Method registers click on the input button, opens a window with an option to select file
        /// and then depending on file type either sets the path to input file or throws an exception
        /// saying that the file type is not supported.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectInputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFile = inputFileDialog.FileName;
                if (IncorrectType(inputFile))
                    throw new Exception("Incorrect file type.");
            }

            EnableControls();
        }

        /// <summary>
        /// Method registers click on the output button, opens a window with an option to select file
        /// and then depending on file type either sets the path to input file or throws an exception
        /// saying that the file type is not supported.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectOutputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog outputFileDialog = new OpenFileDialog();
            if (outputFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFile = outputFileDialog.FileName;
                if (IncorrectType(outputFile))
                    throw new Exception("Incorrect file type.");
            }

            EnableControls();
        }

        /// <summary>
        /// Method checks if input and output file paths are set.
        /// If they are, Buttons for operations are enabled.
        /// </summary>
        private void EnableControls()
        {
            if (inputFile != string.Empty && outputFile != string.Empty)
            {
                copyButton.Enabled = true;
                omitEmptyLines.Enabled = true;
                omitSpacesAndInterpunctionButton.Enabled = true;
                omitDiacriticsButton.Enabled = true;
            }
        }

        private void DisableControls(bool disable = true)
        {
            copyButton.Enabled = !disable;
            copyButton.Refresh();
            omitEmptyLines.Enabled = !disable;
            omitEmptyLines.Refresh();
            omitSpacesAndInterpunctionButton.Enabled = !disable;
            omitSpacesAndInterpunctionButton.Refresh();
            omitDiacriticsButton.Enabled = !disable;
            omitDiacriticsButton.Refresh();
        }
        
        /// <summary>
        /// Checks whether file is of supported type.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>true or false</returns>
        private bool IncorrectType(string fileName)
            => !new FileInfo(fileName).Extension.ContainsAny(Enum.GetNames(typeof(AllowedTypes)));

        /// <summary>
        /// Engages Copy operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CopyButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            IOperation operation = new Copy(inputFile, outputFile, worker);
            await Task.Run(() => operation.EngageOperation());
            SetDiagnosticResults(operation.Diagnostic);
            DisableControls(false);
        }

        /// <summary>
        /// Engages Diacritics omit operation.
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">button parameter event arguments</param>
        private async void OmitDiacriticsButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            IOperation operation = new OmitDiacritics(inputFile, outputFile, worker);
            await Task.Run(() => operation.EngageOperation());
            SetDiagnosticResults(operation.Diagnostic);
            DisableControls(false);
        }

        /// <summary>
        /// Engages empty lines omit operation.
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">button parameter event arguments</param>
        private async void OmitEmptyLines_Click(object sender, EventArgs e)
        {
            DisableControls();
            IOperation operation = new OmitEmptyLines(inputFile, outputFile, worker);
            await Task.Run(() => operation.EngageOperation());
            SetDiagnosticResults(operation.Diagnostic);
            DisableControls(false);
        }

        /// <summary>
        /// Engages space and interpunction omit operation.
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">button parameter event arguments</param>
        private async void OmitSpacesAndInterpunctionButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            IOperation operation = new OmitSpacesAndInterpunction(inputFile, outputFile, worker);
            await Task.Run(() => operation.EngageOperation());
            SetDiagnosticResults(operation.Diagnostic);
            DisableControls(false);
        }


        /// <summary>
        /// Sets the result of diagnostics of output file after the operation is complete to the labels in Form.
        /// </summary>
        /// <param name="diagnostic">Object of output file diagnostics</param>
        private void SetDiagnosticResults(FileDiagnostic diagnostic)
        {
            rowCountValue.Text = diagnostic.RowCount.ToString();
            sentenceCountValue.Text = diagnostic.SentenceCount.ToString();
            wordCountValue.Text = diagnostic.WordCount.ToString();
            characterCountValue.Text = diagnostic.CharacterCount.ToString();
        }
    }
}
