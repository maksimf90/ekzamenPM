using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ekzamenPM
{
    public partial class Admin : Form
    {
        DB db;
        List<Applicat> applicat;
        public Admin()
        {
            InitializeComponent();

            db = new DB("host=localhost; port=5432; username=postgres; password=11111; database=ezkPM");

            List<Applicat> applicat = db.getAppl();

            for (int i = 0; i < applicat.Count; i++)
            {
                dataGridViewAppl.Rows.Add(applicat[i].id, applicat[i].lvl_education, applicat[i].full_name, applicat[i].passport_details, applicat[i].snils, applicat[i].email, applicat[i].phone_number, applicat[i].full_name_parent, applicat[i].educational_institution, applicat[i].use_points, applicat[i].speciality, applicat[i].status, applicat[i].comment, applicat[i].worker);
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewAppl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewAppl.Rows.Count)
            {
                int id = Convert.ToInt32(dataGridViewAppl.Rows[e.RowIndex].Cells[0].Value);
                string lvl_education = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[1].Value);
                string full_name = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[2].Value);
                string passport_details = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[3].Value);
                string snils = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[4].Value);
                string email = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[5].Value);
                string phone_number = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[6].Value);
                string full_name_parent = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[7].Value);
                string educational_institution = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[8].Value);
                string use_points = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[9].Value);
                string speciality = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[10].Value);
                string status = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[11].Value);

                string comment = DBNull.Value.Equals(dataGridViewAppl.Rows[e.RowIndex].Cells[12].Value) ? null : Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[12].Value);

                string worker = Convert.ToString(dataGridViewAppl.Rows[e.RowIndex].Cells[13].Value);

                Applicat product = new Applicat(id, lvl_education, full_name, passport_details, snils, email, phone_number, full_name_parent, educational_institution, use_points, speciality, status, comment, worker);

                FormUpd FormUpd = new FormUpd(product);
                FormUpd.ShowDialog();
                this.Hide();
            }
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            string phone_number = textBoxAppl.Text;
            string full_name = textBoxAppl.Text;

            List<Applicat> applicat = db.findAppl(phone_number, full_name);
            dataGridViewAppl.Rows.Clear();

            for (int i = 0; i < applicat.Count; i++)
            {
                dataGridViewAppl.Rows.Add(applicat[i].id, applicat[i].lvl_education, applicat[i].full_name, applicat[i].passport_details, applicat[i].snils, applicat[i].email, applicat[i].phone_number, applicat[i].full_name_parent, applicat[i].educational_institution, applicat[i].use_points, applicat[i].speciality, applicat[i].status, applicat[i].comment, applicat[i].worker);
            }
        }
    }
}
