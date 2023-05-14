using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr12
{
    public partial class Form2 : Form
    {
        private readonly AppDbContext _context;

        public Form2(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = textBox1.Text,
                Email = textBox3.Text,
                Password = textBox2.Text
            };

            _context.User.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }
    }
}
