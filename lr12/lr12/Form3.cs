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
    public partial class Form3 : Form
    {
        private readonly AppDbContext _context;
        private readonly User _user;

        public Form3(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

            int userId = _user.Id;
            _user = _context.User
                 .Include(u => u.Task)
                 .First(u => u.Id == userId);

            _user.Task = _context.Task.Where(t => t.UserId == _user.Id).ToList();


            Text = $"Библиотека пользователя {_user.Name}";

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _user.Task;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3 = new Form3(_context, _user);
            if (form3.ShowDialog() == DialogResult.OK)
            {
                _user.Task.Add(form3.Task);
                _context.SaveChanges();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Task;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var task = (Book)selectedRow.DataBoundItem;
            _user.Books.Remove(task);
            _context.SaveChanges();

            BooksDataGridView.DataSource = null;
            BooksDataGridView.DataSource = _user.Books;

        }
    }
}
