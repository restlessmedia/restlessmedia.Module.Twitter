using System;

namespace restlessmedia.Module.Twitter
{
  public class Tweet
  {
    public Tweet() { }

    public Tweet(DateTime date, string status)
    {
      Date = date;
      Status = status;
    }

    public DateTime Date { get; set; }

    public string Status { get; set; }
  }
}