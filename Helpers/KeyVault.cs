using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace APIProject.Helpers
{
    public class KeyVault
    {
        private static string tenantid = "5274e0ff-b00d-4522-9b2e-418283781063";
        private static string clientid = "49560cd7-009c-42d3-9b2e-6e23d079de5f";
        private static string clientsecret = "PU68Q~JPv1ox2QsJkgCmY6b1IFu~cNXbzGuGCdzq";
        private static string keyvault_url = "https://demokeyvault-jaya.vault.azure.net/";
        public static string GetSecret(string secretkey)
        {
            ClientSecretCredential clientSecret = new ClientSecretCredential(tenantid, clientid, clientsecret);
            SecretClient secretClient = new SecretClient(new Uri(keyvault_url), clientSecret);
            var secret = secretClient.GetSecret(secretkey);
            return secret.Value.Value;
        }
    }
}
