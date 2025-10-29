using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShop.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string? currentUrl;

        protected override void OnInitialized()
        {
            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = NavigationManager.ToBaseRelativePath(e.Location);
            StateHasChanged();
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}
