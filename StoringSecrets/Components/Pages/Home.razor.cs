using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace StoringSecrets.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IOptions<ModelSecrets> ModelSecrets { get; set; }

        public string SecretValue  { get; set; }

        protected override void OnInitialized()
        {
            SecretValue = ModelSecrets.Value.ApiKey;    
        }
    }
}
