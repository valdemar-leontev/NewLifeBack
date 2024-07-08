using System.Net.Mail;

public sealed class EmailHelper
{
  public static bool IsValid(string emailAddress)
  {
    try
    {
      var m = new MailAddress(emailAddress);

      return true;
    }
    catch (FormatException)
    {
      return false;
    }
  }
}