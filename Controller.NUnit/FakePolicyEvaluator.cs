using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Controllers.NUnit;

public class FakePolicyEvaluator : IPolicyEvaluator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="policy"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual async Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
    {
        const string testScheme = "FakeScheme";
        var principal = new ClaimsPrincipal();
        principal.AddIdentity(new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, "IntegrationTest"),
            new Claim("Permission", "CanViewPage"),
            new Claim("TestAdmin", "yes"),
            new Claim(ClaimTypes.Role, "Test_Administrator"),
            new Claim(ClaimTypes.NameIdentifier, "TestAdmin")
        }, testScheme));
        return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal,
            new AuthenticationProperties(), testScheme)));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="policy"></param>
    /// <param name="authenticationResult"></param>
    /// <param name="context"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    public async Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy,
        AuthenticateResult authenticationResult, HttpContext context, object? resource)
    {
        return await Task.FromResult(PolicyAuthorizationResult.Success());
    }
}