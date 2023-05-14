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
    public partial class Form4 : Form
    {
        private readonly AppDbContext _context;
        private readonly User _user;

        public Task Task { get; private set; }

        public Form4(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = new Task
            {
                Name = textBox1.Text,
                Description = richTextBox1.Text,
                Ststus = false,
                UserId = _user.Id
            };

            _context.Task.Add(task);
            _context.SaveChanges();

            Task = task;
            DialogResult = DialogResult.OK;

        }
    }
}
