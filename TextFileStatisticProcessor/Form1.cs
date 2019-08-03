﻿using System;
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
            worker.DoWork += Worker_DoWork(); 

            worker.ProgressChanged += Worker_ProgressChanged();
        }

        private DoWorkEventHandler Worker_DoWork()
        {
            throw new NotImplementedException();
        }

        private ProgressChangedEventHandler Worker_ProgressChanged()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
