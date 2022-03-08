using System.IO;

namespace Hackermans
{
    public partial class Form1 : Form
    {
        // Dialogs
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;
        private int _totalTextLength = 0;
        private string _fileName = string.Empty;
        //private RichTextBox richTextBox;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var test = sender;

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
            //if (string.Equals((sender as Button).Name, @"CloseButton"))
            //{
            //    exitToolStripMenuItem_Click(sender, e);
            //}

            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    exitToolStripMenuItem_Click(sender, e);
            //}
        }

        // Creates a new file
        //private void NewFile()
        //{
        //    RichTextBox.cl
        //}

        private void SaveFile()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (_fileName != string.Empty)
            {
                StreamWriter writer = new StreamWriter(_fileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
                _totalTextLength = richTextBox1.Text.Length;
            }
            else
            {
                SaveFile();
            }


        }

        private void SaveAs()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                _fileName = saveFileDialog.FileName;
                _totalTextLength = richTextBox1.Text.Length;
            }
        }

        private void LoadFile()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Open File";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this._fileName = openFileDialog.FileName;
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void newToolStripMenuItem_Click(object sender, FormClosingEventArgs e)
        {   
            
            if (richTextBox1.Text.Length != _totalTextLength)
            {
                var message = "Would you like to save your file?";
                var result = MessageBox.Show(message, "File hasn't been saved", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveAs();
                }

                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }


            }
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventHandler e)
        {
            if (_totalTextLength != richTextBox1.Text.Length)
            {
                var f = new FormClosingEventHandler();
                f.DynamicInvoke 
                newToolStripMenuItem_Click(sender, e);
            }

            
            Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }   
}