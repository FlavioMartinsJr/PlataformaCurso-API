using System.Security.Claims;

namespace PlataformaCursos.Infrastructure.IOC
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("id")!.Value);
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")!.Value;
        }
    }
}
