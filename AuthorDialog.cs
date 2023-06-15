namespace LB4
{
  internal partial class AuthorDialog : Form
  {
    public AuthorDialog()
    {
      InitializeComponent();
    }

    public string SelectedAuthor { get; private set; }

    public AuthorDialog(string currentGenre, List<string> BookAuthors)
    {
      InitializeComponent();
      comboBox1.DataSource = BookAuthors;
      comboBox1.SelectedItem = currentGenre;
    }

    private void applyAuthor_Click(object sender, EventArgs e)
    {
      SelectedAuthor = (string)comboBox1.SelectedItem;
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
