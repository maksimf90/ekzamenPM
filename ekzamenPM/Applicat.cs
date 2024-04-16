using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamenPM
{
    public class Applicat
    {
        public int id;
        public string lvl_education;
        public string full_name;
        public string passport_details;
        public string snils;
        public string email;
        public string phone_number;
        public string full_name_parent;
        public string educational_institution;
        public string use_points;
        public string speciality;
        public string status;
        public string comment;
        public string worker;

        public Applicat(int id, string lvl_education, string full_name, string passport_details, string snils, string email,string phone_number,
            string full_name_parent, string educational_institution, string use_points, string speciality, string status, string comment, string worker)
        {
            this.id = id;
            this.lvl_education = lvl_education;
            this.full_name = full_name;
            this.passport_details = passport_details;
            this.snils = snils;
            this.email = email;
            this.phone_number = phone_number;
            this.full_name_parent = full_name_parent;
            this.educational_institution = educational_institution;
            this.use_points = use_points;
            this.speciality = speciality;
            this.status = status;
            this.comment = comment;
            this.worker = worker;
        }
    }
}
