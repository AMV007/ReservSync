using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RezervSync
{
    public partial class CommitDialog : Form
    {
        public CommitResult.QuestionResult Result = CommitResult.QuestionResult.Cancel;
        public CommitDialog(string TextSource, string TextDestination, string Caption)
        {
            InitializeComponent();
            this.Text = Caption;
            labelDestination.Text = TextDestination;
            labelSource.Text = TextSource;
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            Result = CommitResult.QuestionResult.Replace;
            this.Close();
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {
            Result = CommitResult.QuestionResult.ReplaceAll;
            this.Close();
        }

        private void buttonMiss_Click(object sender, EventArgs e)
        {
            Result = CommitResult.QuestionResult.Miss;
            this.Close();
        }

        private void buttonMissAll_Click(object sender, EventArgs e)
        {
            Result = CommitResult.QuestionResult.MissAll;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Result = CommitResult.QuestionResult.Cancel;
            this.Close();
        }       
    }

    public class CommitResult
    {
        public enum QuestionResult
        {
            Replace,
            ReplaceAll,
            Miss,
            MissAll,
            Cancel,
            OK
        }
        public static QuestionResult GetResult(string Caption, string TextSource, string TextDestination)
        {
            CommitDialog ThisForm = new CommitDialog(TextSource, TextDestination, Caption);
            ThisForm.ShowDialog();
            return ThisForm.Result;
        }
    }
}