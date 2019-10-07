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
    public partial class EditForm : Form
    {
        private bool add = true;
        public Student temp { get; set; }
        SqlFun sqlFun = new SqlFun();

        public EditForm(Student student) : this()
        {
            if (student == null)
            {
                temp = new Student();
            }
            else
            {
                temp = student;
                add = false;
            }
            studentBindingSource.DataSource = temp;
        }

        public EditForm()
        {
            InitializeComponent();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!add)
            {
                textBox1.Enabled = false;
            }

            if(textBox1.Text == null || textBox2.Text == null || textBox3.Text == null
                || textBox4.Text == null || textBox5.Text == null || textBox6.Text == null)
            {
                MessageBox.Show("不允许为空！");
            }
            else if (add)
            {
                if (sqlFun.SearchById(textBox1.Text) != null)
                {
                    MessageBox.Show("学号不允许重名！");
                }
                else
                {
                    Student student = new Student(textBox1.Text, textBox2.Text, textBox3.Text,
                        textBox4.Text, textBox5.Text, textBox6.Text);
                    sqlFun.Add(student);
                    this.Close();
                }
            }
            else
            {
                Student student = new Student(textBox1.Text, textBox2.Text, textBox3.Text,
                        textBox4.Text, textBox5.Text, textBox6.Text);
                sqlFun.Update(student);
                this.Close();
            }
        }
    }
}
