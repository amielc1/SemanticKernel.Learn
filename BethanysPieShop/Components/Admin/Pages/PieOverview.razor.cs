using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShop.Components.Admin.Pages
{
    public partial class PieOverview
    {
        public List<Pie> Pies { get; set; } = default!;
        private Pie? _selectedPie;

        [Inject]
        public IPieDataService PieDataService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Pies = (await PieDataService.GetAllPies()).ToList();
        }
    }
}
