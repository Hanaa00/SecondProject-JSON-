
using JSONparseClass;

namespace SecondProject_JSON_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            openFileDialog.FilterIndex = 1;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                try
                {
                    string parsedText = ParseJSONfile.ParseDevice(fileName);
                    fileContentTextBox.Text = parsedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }


}
    
