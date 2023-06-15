namespace LB4
{
  internal class Book
  {
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, string publisher, int year)
    {
      Title = title;
      Author = author;
      Publisher = publisher;
      Year = year;
    }
  }

}
