using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TriStu.BLL;
using TriStu.Models;

namespace TirStu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StuManager stu = new StuManager();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = stu.GetStudents();
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student newStu = new Student();
            newStu.ID = int.Parse(textID.Text);
            newStu.Name = textName.Text;
            newStu.Age = int.Parse(textAge.Text);
            if (stu.AddStudent(newStu))
            {
                MessageBox.Show("added successful");
                dataGridView1.DataSource = stu.GetStudents();
            }
            else
            {
                MessageBox.Show("added failed!");
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("please select one line");
                return;
            }

            Student newStu = new Student();
            newStu.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            newStu.Name = textName.Text;
            newStu.Age = int.Parse(textAge.Text);
            if (stu.UpdataStudent(newStu))
            {
                MessageBox.Show("editted successfully");
                dataGridView1.DataSource = stu.GetStudents();
            }
            else
            {
                MessageBox.Show("ediited failed");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断是否选中dataGridView1里的一行
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择一行进行操作");
                return;
            }
            textID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textAge.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("please select one line");
                return;
            }

            id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            if (stu.DelStudent(id)){
                MessageBox.Show("deleted sucessfully");
                dataGridView1.DataSource = stu.GetStudents();
                textID.Text = "";
                textName.Text = "";
                textAge.Text = "";
            }
            else
            {
                MessageBox.Show("delete failed!");
            }

        }
    }
}
