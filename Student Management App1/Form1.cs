using System.Text;
namespace Student_Management_App1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);
                //this.textBox1.Text = readAllText;
                //this.dataGridView1.Rows.Add()
                
                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string studentRAW = readAllLine[i];
                    string[] studentSplited = studentRAW.Split(',');
                    
                    Sturdent student = new Sturdent(studentSplited[0], studentSplited[1], studentSplited[2]);

                    addDataToGridView("01", "name", "cis");
                }

                


            }
        }
        void addDataToGridView(string id, string name, string major)
        {
            this.dataGridView1.Rows.Add(new string[] { id,name,major });
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string strData = string.Empty;
            
            string filepath = string .Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();   
            saveFileDialog.Filter = "CSV (*.csv)|*.csv";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(saveFileDialog.FileName != string.Empty)
                {
                    filepath = saveFileDialog.FileName;

                   int row = this.dataGridView1.Rows.Count; 
                   
                    for(int i = 0;  i<= row ; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j <= column; j++)
                            strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //ToDo save doate 
                    }


                    //save file
                    File.WriteAllText(saveFileDialog.FileName, strData,Encoding.UTF8);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}