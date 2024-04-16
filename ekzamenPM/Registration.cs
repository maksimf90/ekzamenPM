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

namespace ekzamenPM
{
    
    public partial class Registration : Form
    {
        DB db;
        public Registration()
        {
            InitializeComponent();

            db = new DB("host=localhost; port=5432; username=postgres; password=11111; database=ezkPM");

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            
            
            db.addAppl(lvl_education, full_name, passport_details, snils, email, phone_number, full_name_parent, educational_institution, use_points, speciality, "В обработке");

            MessageBox.Show("Данные отправлены.");
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

        private void textBoxUsePoints_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
