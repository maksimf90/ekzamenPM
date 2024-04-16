using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;


namespace ekzamenPM
{
    public static class NpgsqlDataReaderExtensions
    {
        public static string GetNullableString(this NpgsqlDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }
    }
    public class DB
    {
        NpgsqlConnection connection;

        public DB(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public NpgsqlConnection getConnection()
        {
            return connection;
        }
        
        public List<Applicat> getAppl()
        {
            List<Applicat> result = new List<Applicat>();

            connection.Open();
            string commandString = "SELECT * FROM application";
            var command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string comment = reader.GetNullableString(12);
                string worker = reader.GetNullableString(13);

                result.Add(new Applicat(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), comment, worker));
            }
            connection.Close();

            return result;
        }

        public List<Applicat> findAppl(string full_name, string phone_number)
        {
            List<Applicat> result = new List<Applicat>();

            connection.Open();
            string commandString = $"SELECT * FROM application WHERE full_name LIKE '%{full_name}%' OR phone_number LIKE '%{phone_number}%'";
            var command = new NpgsqlCommand(commandString, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Applicat(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13)));
            }

            connection.Close();
            return result;
        }

        public void addAppl(string lvl_education, string full_name, string passport_details, string snils, string email, string phone_number,
            string full_name_parent, string educational_institution, string use_points, string speciality, string status)
        {

            connection.Open();

            string searchCommandString = $"SELECT COUNT (*) FROM application WHERE phone_number = '{phone_number}'";
            var searchCommand = new NpgsqlCommand(searchCommandString, connection);
            var count = (Int64)searchCommand.ExecuteScalar();


            if (count == 0)
            {
                string addCommandString = $"INSERT INTO application (lvl_education,full_name,passport_details,snils,email,phone_number,full_name_parent,educational_institution,use_points,speciality,status) " +
                    $"VALUES ('{lvl_education}','{full_name}','{passport_details}','{snils}','{email}','{phone_number}','{full_name_parent}','{educational_institution}','{use_points}','{speciality}','{status}')";
                var addCommand = new NpgsqlCommand(addCommandString, connection);
                addCommand.ExecuteNonQuery();
            }

            else
            {
                MessageBox.Show("Данный студент уже есть в списке");
            }
            connection.Close();
        }

        public void delAppl(int id)
        {
            connection.Open();

            string delAppl = $"DELETE FROM application WHERE id = '{id}'";
            var delCommand = new NpgsqlCommand(delAppl, connection);
            delCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void updAppl(int id, string lvl_education, string full_name, string passport_details, string snils, string email, string phone_number,
            string full_name_parent, string educational_institution, string use_points, string speciality, string status, string comment, string worker)
        {
            connection.Open();

            string updCommandString = $"UPDATE application SET lvl_education='{lvl_education}',full_name='{full_name}',passport_details='{passport_details}',snils='{snils}',email='{email}',phone_number='{phone_number}'," +
                $"full_name_parent='{full_name_parent}',educational_institution='{educational_institution}',use_points='{use_points}',speciality='{speciality}',status='{status}', comment = '{comment}', worker='{worker}' WHERE id='{id}'";
            var updCommand = new NpgsqlCommand(updCommandString, connection);
            updCommand.ExecuteNonQuery();

            connection.Close();

        }
    }
}
