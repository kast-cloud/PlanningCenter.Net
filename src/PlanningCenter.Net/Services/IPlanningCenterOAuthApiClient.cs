using PlanningCenter.Net.Models.Authentication;
using RestEase;
using System.Threading.Tasks;

namespace Kast.Connectivity.PlanningCenter.Services
{
    public interface IPlanningCenterOAuthApiClient
    {
        [Post]
        Task<RefreshTokenResponse> RefreshTokenAsync([Body] RefreshTokenRequest refreshTokenRequest);

        [Post]
        Task<OAuthResponse> GetAccessTokenAsync([Body] OAuthRequest oauthRequest);
    }
}
