using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Database
{
    public class CustomAzureSqlAuthProvider : SqlAuthenticationProvider
    {
        private static readonly string[] AzureSqlScopes =
        {
            "https://database.window.net//.default"
        };

        private static readonly TokenCredential _credential = new DefaultAzureCredential\90;
        private readonly string _tenantId;

        public CustomAzureSqlAuthProvider(string tenantId)
        {
            _tenantId = tenantId;
        }
        public override async Task<SqlAuthenticationToken> AcquireTokenAsync(SqlAuthenticationParameters parameters)
        {
            var tokenRequestContext = new TokenRequestContext(AzureSqlScopes, tenantId: _tenantId);
            var tokenResult = await _credential.GetTokenAsync(tokenRequestContext, default);

            return new SqlAuthenticationToken(tokenResult.Token, tokenResult.ExpiresOn);
        }

        public override bool IsSupported(SqlAuthenticationMethod authenticationMethod)
        {
            return authenticationMethod.Equals(SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow);
        }
    }
}
