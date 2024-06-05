using Microsoft.AspNetCore.Authentication;

internal class JwtBearerDefaults
{
    internal static void AuthenticationScheme(AuthenticationOptions options)
    {
        // Burada AuthenticationOptions'ı yapılandırın veya belirli bir davranış sağlayın
        // Örneğin:
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
    }
}
