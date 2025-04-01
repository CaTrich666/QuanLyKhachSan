using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set => instance = value;
        }

        private DataProvider() { }


        private string connectionSTR = @"Data Source=T\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=False";

        public string getConectionstr()
        {
            return connectionSTR;
        }


        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // 🛠 Xử lý tham số đúng cách
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(new char[] { ' ', '\n', '\r', '\t', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;

                        foreach (string s in listPara)
                        {
                            if (s.StartsWith("@") && i < parameter.Length)
                            {
                                command.Parameters.AddWithValue(s, parameter[i] ?? DBNull.Value);
                                i++;
                            }
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }





        public DataTable ExecuteQuery2(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    // Tìm tất cả các tham số trong câu lệnh query
                    string[] listPara = query.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;

                    foreach (string s in listPara)
                    {
                        // Kiểm tra nếu phần tử trong query là tham số bắt đầu bằng '@'
                        if (s.StartsWith("@") && i < parameter.Length)
                        {
                            // Thêm tham số vào lệnh SQL
                            command.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                connection.Close();
            }

            return dt;
        }




        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int dt = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số nếu có
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    dt = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return dt;
        }



        public int ExecuteNonQuery2(string query, object[] parameter = null)//đừng đụng chạm !!
        {
            int dt = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameter != null)
                    {
                        // Sử dụng regex để tìm các tham số
                        var matches = System.Text.RegularExpressions.Regex.Matches(query, @"@\w+");
                        int i = 0;
                        foreach (System.Text.RegularExpressions.Match match in matches)
                        {
                            command.Parameters.AddWithValue(match.Value, parameter[i]);
                            i++;
                        }
                    }
                    dt = command.ExecuteNonQuery();
                }
                connection.Close();
            }

            return dt;
        }


        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object dt = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string s in listPara)
                    {
                        if (s.Contains('@'))
                        {
                            command.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = command.ExecuteScalar();
                connection.Close();
            }
            return dt;
        }
    }
}
