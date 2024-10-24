using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{

    private readonly TwoFactorAuthenticator _tfa;

    public ValuesController()
    {
        _tfa = new TwoFactorAuthenticator();
    }

    [HttpGet("generateqr")]
    public ActionResult<string> GenerateQR(string email)
    {
        
        string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
        SetupCode setupInfo = _tfa.GenerateSetupCode("Garagem do Código (2FA)", email, key, false, 3);

        Console.WriteLine($"Chave gerada: {key}");

        return setupInfo.QrCodeSetupImageUrl;
    }

    [HttpPost("validatecode")]
    public ActionResult<bool> ValidateCode(string code, string key)
    {

        return _tfa.ValidateTwoFactorPIN(key, code);
    }

}