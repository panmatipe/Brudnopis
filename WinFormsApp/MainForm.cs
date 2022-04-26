using DomainModel;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        List<PersonModel> people = new List<PersonModel>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadPeopleList()
        {
            people = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            listPeopleBox.DataSource = null;
            listPeopleBox.DataSource = people;
            listPeopleBox.DisplayMember = "FullName";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listPeopleBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            PersonModel p = new PersonModel();

            p.FirstName = fnTextBox.Text;
            p.LastName = lnTextBox.Text;

            SqliteDataAccess.SavePerson(p);

            fnTextBox.Text = "";
            lnTextBox.Text = "";
        }
    }
}