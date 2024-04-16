using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekzamenPM
{
    public partial class Student : Form
    {
        DB db;

        public Student()
        {
            InitializeComponent();

            db = new DB("host=localhost; port=5432; username=postgres; password=11111; database=ezkPM");

            List<Applicat> applicat = db.getAppl();

            for (int i = 0; i < applicat.Count; i++)
            {
                dataGridViewAppl.Rows.Add(applicat[i].id, applicat[i].lvl_education, applicat[i].full_name, applicat[i].passport_details, applicat[i].snils, applicat[i].email, applicat[i].phone_number, applicat[i].full_name_parent, applicat[i].educational_institution, applicat[i].use_points, applicat[i].speciality, applicat[i].status);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
