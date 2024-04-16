using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace ekzamenPM
{
    public partial class FormUpd : Form
    {
        DB db;
        Applicat applicat;
        public FormUpd(Applicat applicat)
        {
            InitializeComponent();

            db = new DB("host=localhost; username=postgres; port=5432; database=ezkPM; password=11111");

            this.applicat = applicat;

            comboBoxLvlEducation.Text = applicat.lvl_education;
            textBoxFullName.Text = applicat.full_name;
            textBoxPassportDetails.Text = applicat.passport_details;
            textBoxSnils.Text = applicat.snils;
            textBoxEmail.Text = applicat.email;
            textBoxPhoneNumber.Text = applicat.phone_number;
            textBoxFullNameParent.Text = applicat.full_name_parent;
            textBoxEducationalInstitution.Text = applicat.educational_institution;
            textBoxUsePoints.Text = applicat.use_points;
            comboBoxSpeciality.Text = applicat.speciality;
        }

        private void FormUpd_Load(object sender, EventArgs e)
        {

        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            string lvl_education = comboBoxLvlEducation.Text;
            string full_name = textBoxFullName.Text;
            string passport_details = textBoxPassportDetails.Text;
            string snils = textBoxSnils.Text;
            string email = textBoxEmail.Text;
            string phone_number = textBoxPhoneNumber.Text;
            string full_name_parent = textBoxFullNameParent.Text;
            string educational_institution = textBoxEducationalInstitution.Text;
            string use_points = textBoxUsePoints.Text;
            string speciality = comboBoxSpeciality.Text;
            string comment = textBoxComment.Text;
            string worker = textBoxWorker.Text;
            string status = comboBoxStatus.Text;



            db.updAppl( applicat.id,  lvl_education,  full_name,  passport_details,  snils,  email,  phone_number,
                 full_name_parent,  educational_institution,  use_points,  speciality,  status,  comment,  worker);

            Admin Admin = new Admin();
            Admin.Show();
            this.Close();

            MessageBox.Show("Данные успешно обновлены.");
        }

        private void comboBoxSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxLvlEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                comboBoxSpeciality.Items.Clear();
                string selectedItem = comboBoxLvlEducation.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "СПО":
                        comboBoxSpeciality.Items.Add("11.01.01 Монтажник радиоэлектронной аппаратуры и приборов");
                        comboBoxSpeciality.Items.Add("08.02.01 Строительство и эксплуатация зданий и сооружений");
                        comboBoxSpeciality.Items.Add("08.02.05 Строительство и эксплуатация автомобильных дорог и аэродромов");
                        comboBoxSpeciality.Items.Add("08.02.08 Монтаж и эксплуатация оборудования и систем газоснабжения");
                        break;

                    case "Бакалавриат":
                        comboBoxSpeciality.Items.Add("07.03.01 Архитектура");
                        comboBoxSpeciality.Items.Add("07.03.02 Реконструкция и реставрация архитектурного наследия ");
                        comboBoxSpeciality.Items.Add("07.03.03 Дизайн архитектурной среды ");
                        comboBoxSpeciality.Items.Add("07.03.04 Градостроительство ");
                        break;

                    case "Специалитет":
                        comboBoxSpeciality.Items.Add("10.05.02 Информационная безопасность телекоммуникационных систем");
                        comboBoxSpeciality.Items.Add("11.05.01 Радиоэлектронные системы и комплексы");
                        comboBoxSpeciality.Items.Add("24.05.02 Проектирование авиационных и ракетных двигателей");
                        comboBoxSpeciality.Items.Add("24.05.07 Самолето- и вертолетостроение");
                        break;

                    case "Магистратура":
                        comboBoxSpeciality.Items.Add("07.04.01 Архитектура ");
                        comboBoxSpeciality.Items.Add("07.04.02 Реконструкция и реставрация архитектурного наследия ");
                        comboBoxSpeciality.Items.Add("07.04.03 Дизайн архитектурной среды ");
                        break;

                    default:
                        break;
                
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            db.delAppl(applicat.id);

            Admin Admin = new Admin();
            Admin.Show();
            this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Admin Admin = new Admin();
            Admin.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
