namespace LB4
{
  internal partial class PublisherDialog : Form
  {
    public PublisherDialog()
    {
      InitializeComponent();
    }
    
    public string SelectedPublisher { get; private set; }

    public PublisherDialog(string current, List<string> BookAuthors)
    {
      InitializeComponent();
      comboBox1.DataSource = BookAuthors;
      comboBox1.SelectedItem = current;
    }

    private void applyPublisher_Click(object sender, EventArgs e)
    {
      SelectedPublisher = (string)comboBox1.SelectedItem;
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
