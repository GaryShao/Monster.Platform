using Microsoft.Owin.Hosting;
using Monster.OutPatientClinic.Models;
using Monster.Platform;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.OutPatientClinic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Task.Run(() => {
                using (WebApp.Start<Startup>("http://localhost:12345"))
                {
                    while (true)
                    {
                        //donothing
                    }
                }
            });            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            patientBindingSource.Add(new Patient
            {
                Id = new Guid(),
                Name = "gary shao",
                Birth = new DateTime(1992, 2, 6),
                ConsultingTime = new DateTime(2018, 1, 1),
                Prescription = "shit",
                Symptom = "emmmm"
            });
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show($"{e.ColumnIndex}, {e.RowIndex}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
