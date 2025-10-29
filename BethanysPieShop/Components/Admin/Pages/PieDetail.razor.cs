using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShop.Components.Admin.Pages
{
    public partial class PieDetail
    {
        public Pie Pie { get; set; } = new Pie();

        [Parameter]
        public int PieId { get; set; }

        [Inject]
        public IPieDataService? PieDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Pie = await PieDataService.GetPieDetails(PieId);
        }

    }
}
