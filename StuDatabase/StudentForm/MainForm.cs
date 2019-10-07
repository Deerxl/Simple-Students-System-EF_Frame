using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentBase;

namespace StudentForm
{
    public partial class MainForm : Form
    {
        SqlFun sqlFun = new SqlFun();

        public MainForm()
        {
            
            InitializeComponent();
            //Student student = new Student("1","1","1","1","1","1");
           // sqlFun.Add(student);
            studentBindingSource.DataSource = sqlFun.Queue();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            List<Student> results;
            if (textBox1.Text.Trim() == "")
            {
                //MessageBox.Show("搜索框不允许为空！");
                studentBindingSource.DataSource = sqlFun.Queue();
            }
            else
            {
                results = sqlFun.Search(textBox1.Text);
                studentBindingSource.DataSource = results;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(null);
            editForm.ShowDialog();

            studentBindingSource.DataSource = sqlFun.Queue();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Student student = (Student)studentBindingSource.Current;
            if (student != null)
            {
                sqlFun.Remove(student.Id);
                studentBindingSource.DataSource = sqlFun.Queue();
            }

            //if (dataGridView1.SelectedRows != null)
            //{
            //    int index = dataGridView1.CurrentRow.Index;
            //    string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            //    //if (id != null)
            //    //{
            //    //   // Student student = sqlFun.SearchById(id);
            //    //    sqlFun.Remove(id);
            //    //    studentBindingSource.DataSource = sqlFun.Queue();
            //    //}              
            //}
            else
            {
                MessageBox.Show("请选中行！");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                Student student = sqlFun.SearchById(id);
                if (id != null)
                {
                    EditForm editForm = new EditForm(student);
                    editForm.ShowDialog();

                    studentBindingSource.DataSource = sqlFun.Queue();
                }
            }
            else
            {
                MessageBox.Show("请选中行！");
            }
        }
    }
}
