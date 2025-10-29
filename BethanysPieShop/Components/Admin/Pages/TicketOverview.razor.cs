using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShop.Components.Admin.Pages
{
    public partial class TicketOverview
    {
        public List<Ticket> Tickets { get; set; } = default!;
        private Pie? _selectedPie;

        [Inject]
        public ITicketDataService TicketDataService { get; set; }

        [Inject]
        public IHttpContextAccessor httpContextAccessor { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var userName = httpContextAccessor.HttpContext.User.Identity.Name;

            Tickets = (await TicketDataService.GetTicketsByStatus(TicketStatus.Open)).ToList();
        }
    }
}
