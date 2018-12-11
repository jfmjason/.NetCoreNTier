using AspNetCore.LegacyAuthCookieCompat;
using BA.IService;
using BA.UI.WebV2.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Custom
{
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ILoggerFactory _loggerfactory;
        private readonly IMasterFileService _iMasterFileService;
        private readonly ILogger _iLogger;

        public CustomAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
       ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IMasterFileService iMasterFileService)
                    : base(options, logger, encoder, clock)
        {

            _loggerfactory = logger;
            _iLogger = _loggerfactory.CreateLogger("BA.UI.WebV2.Custom.CustomAuthenticationHandler");
            _iMasterFileService = iMasterFileService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                //var claimsprincipal = CreateClaimsPrincipal();

                var claimsprincipal = GetClaimsPrincipalFromLegacyAuthCookie();

                if (claimsprincipal != null)
                {
                    return await Task.FromResult(
                        AuthenticateResult.Success(
                            new AuthenticationTicket(claimsprincipal, CustomCookieAuthenticationDefaults.AuthenticationScheme)
                        )
                    );
                }
                else
                {
                    return AuthenticateResult.Fail("error message");
                }
            }
            else
            {

                return await Context.AuthenticateAsync(CustomCookieAuthenticationDefaults.AuthenticationScheme);
            }

        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Global.Configuration["Authentication:LoginUri"]);
                return;
            }

            await HandleChallengeAsync(properties);
        }

        //only for .net 3.x to 4.0
        private ClaimsPrincipal GetClaimsPrincipalFromLegacyAuthCookie()
        {
            var claimsprincipal = new ClaimsPrincipal();

            var formauth = Context.Request.Cookies[Global.Configuration["Authentication:AuthCookieName"]];

         
            try
            {
                byte[] decryptionKeyBytes = HexUtils.HexToBinary(Global.Configuration["Authentication:Machinekey:DecryptionKey"]);
                byte[] validationKeyBytes = HexUtils.HexToBinary(Global.Configuration["Authentication:Machinekey:ValidationKey"]);

                var legacyFormsAuthenticationTicketEncryptor = new LegacyFormsAuthenticationTicketEncryptor(decryptionKeyBytes, validationKeyBytes, ShaVersion.Sha1);

                FormsAuthenticationTicket decryptedTicket = legacyFormsAuthenticationTicketEncryptor.DecryptCookie(formauth);

                var userData = decryptedTicket.UserData.Split('|');


                var claims = new List<Claim>
                      {
                          new Claim(ClaimTypes.NameIdentifier, userData[0]),//employeeid
                          new Claim("EmployeeId", userData[0]),//employeeid
                          new Claim("EmployeeNumber", userData[1]),//employeenuber
                          new Claim(ClaimTypes.Name, userData[2]),
                          new Claim("DivisionId", userData[3]),
                          new Claim("DepartmentId", userData[4]),
                          new Claim("IPAddress", GetIPAddress()) 
                      };

                var claimsIdentity = new ClaimsIdentity(claims,
                    CustomCookieAuthenticationDefaults.AuthenticationScheme);

                claimsprincipal = new ClaimsPrincipal(claimsIdentity);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                _iLogger.LogWarning("Custom Authentication /n {ERROR}", error);
                return null;
            }

            return claimsprincipal;
        }

        private ClaimsPrincipal CreateClaimsPrincipal()
        {
            var claimsprincipal = new ClaimsPrincipal();

            var formauth = Context.Request.Cookies[Global.Configuration["Authentication:AuthCookieName"]];
            var empid = Context.Request.Cookies[Global.Configuration["Authentication:EmployeeIdCookieName"]];

            try
            {
                if (formauth != null && empid != null)
                {
                    var employee = _iMasterFileService.GetEmployeeById(int.Parse(empid));

                    var claims = new List<Claim>
                      {
                          new Claim(ClaimTypes.NameIdentifier, employee.Name),//employeeid
                          new Claim("EmployeeId", employee.Id.ToString()),//employeeid
                          new Claim("EmployeeNumber", employee.EmployeeId),//employeenuber
                          new Claim(ClaimTypes.Name, employee.Name),
                          new Claim("DivisionId", employee.DivisionId?.ToString()),
                          new Claim("DepartmentId", employee.DepartmentId?.ToString()),
                          new Claim("DesignationId", employee.DesignationId?.ToString()),
                          new Claim("IPAddress", GetIPAddress())
                      };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CustomCookieAuthenticationDefaults.AuthenticationScheme);

                    claimsprincipal = new ClaimsPrincipal(claimsIdentity);
                }
                else
                {
                    if(formauth == null)
                    _iLogger.LogWarning("Cannot find cookie : " + Global.Configuration["Authentication:AuthCookieName"]);

                    if (empid == null)
                    _iLogger.LogWarning("Cannot find cookie : " + Global.Configuration["Authentication:EmployeeIdCookieName"]);

                    return null;
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                _iLogger.LogWarning("Custom Authentication /n {ERROR}", error);
                return null;
            }

            return claimsprincipal;
        }

        public  string GetIPAddress()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
    }
}
