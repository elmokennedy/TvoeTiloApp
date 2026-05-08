using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TvoeTiloApp.Api.Auth
{
    public class AuthOptions
    {
        public const string Issuer = "TvoeTiloAppServer";
        public const string Audience = "TvoeTiloAppClient";
        const string KEY = "tvoetiloapp_supersecretkey12092805";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
