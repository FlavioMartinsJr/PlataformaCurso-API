using System.Net.Mail;

namespace PlataformaCursos.Infrastructure.Data.Helpers
{
    public class EmailAddressHelper
    {
        public bool IsValid(string emailAddress)
        {
            try
            {
                MailAddress email = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
