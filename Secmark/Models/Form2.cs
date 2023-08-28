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
using Secmark.Models;


namespace Secmark.Models
{
    public partial class Form2 : Form
    {
        DepartmentCrud crud2;
        List<Department> list;
        
        public Form2()
        {
            InitializeComponent();
            crud2 = new DepartmentCrud();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            list = crud2.GetDepartmentList();
            cmbempdept.DataSource = list;
            cmbempdept.DisplayMember = "dep_name";
            cmbempdept.ValueMember = "dep_code";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Employee em = new Employee();
                
                em.emp_code = txtempcode.Text;
                em.emp_Name=txtempname.Text;
                em.emp_Dept = (cmbempdept.SelectedValue).ToString();
                int res = crud2.AddEmp(em);
                if (res > 0)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataTable table = crud2.GetEmployee();
            dataGridView1.DataSource = table;
        }
    }
}
