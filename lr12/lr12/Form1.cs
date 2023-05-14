namespace lr12
{
    public partial class Form1 : Form
    {
        private AppDbContext context;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form2 form2 = new Form2(new AppDbContext());
            Hide();
            form2.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            User user;
            using (var context = new AppDbContext())
            {
                var email = textBox1.Text;
                var password = textBox2.Text;

                user = context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            }


            if (user != null)
            {
                MessageBox.Show("Вы успешно авторизовались!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 form3 = new Form3(new AppDbContext(), user);
                Hide();
                form3.form1 = this;
                form3.ShowDialog();
/*                DialogResult dialogResult = MessageBox.Show("Закрыть программу?", "Думай", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    Close();
                else if (dialogResult == DialogResult.No)
                    Show();*/
            }
            else
            {
                MessageBox.Show("Неправильный email или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}