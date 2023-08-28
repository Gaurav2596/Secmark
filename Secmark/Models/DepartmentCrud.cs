using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace Secmark.Models
{
    public class DepartmentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public DepartmentCrud()
        {
            string connestr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(connestr);
        }
        public int Adddept(Department dept)
        {
            string qry = "insert into Department values(@dep_code,@dep_name)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dep_code", dept.dept_code);
            cmd.Parameters.AddWithValue("@dep_name", dept.dep_name);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateDepartment(Department dept)
        {
            string qry = "update Department set dep_name=@dep_name, where dep_code=@dep_code";
            cmd = new SqlCommand(qry, con); 
            cmd.Parameters.AddWithValue("@dep_code",dept.dept_code);
            cmd.Parameters.AddWithValue("@dep_name", dept.dep_name);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }
        public List<Department> GetDepartmentList()
        {
            List<Department> list = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.dept_code = dr["dep_code"].ToString();
                    dept.dep_name = dr["dep_name"].ToString();
                    list.Add(dept);
                }
            }
            con.Close();
            return list;
        }
        public int AddEmp(Employee emp)
        {

            string qry = "insert into Employee values(@emp_code,@emp_Name,@emp_Dept)";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@emp_code", emp.emp_code);
            cmd.Parameters.AddWithValue("@emp_Name", emp.emp_Name);
            cmd.Parameters.AddWithValue("@emp_Dept", emp.emp_Dept);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;  
        }
        public DataTable GetEmployee()
        {
            DataTable dt = new DataTable();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }

    }
}
