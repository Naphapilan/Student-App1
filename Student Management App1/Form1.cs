using System.Text;
namespace Student_Management_App1
{
    public partial class Form1 : Form
    {
        GPACal oGPAcal = new GPACal();
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
                    
                    Student student = new Student(studentSplited[0], studentSplited[1], studentSplited[2],studentSplited[3]);

                    addDataToGridView("01", "name", "cis","3.5");
                }                          
            }
        }
        void addDataToGridView(string id, string name, string major,string gpa)
        {
            this.dataGridView1.Rows.Add(new string[] { id,name,major,gpa });
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string filepath = string .Empty;   
            
            if (dataGridView1.Rows.Count > 0)
            {
                
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        } 
 
        private void button1_Click(object sender, EventArgs e)
        {
            //TODO add data to dataGridView
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxID.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxName.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBoxMajor.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBoxGPA.Text;
            //TODO Calculate GPAx,Max,Min
            string input =this.textBoxGPA.Text;

            double dInput = Convert.ToDouble(input);
            oGPAcal.addGPA(dInput, Name);

            double gpax = oGPAcal.gatGPAx();
            textBoxGPAx.Text = gpax.ToString();

            double max = oGPAcal.getMax();
            textBoxMax.Text = max.ToString();

            double min = oGPAcal.gatMin();
            textBoxMin.Text = min.ToString();
        }
    }
}