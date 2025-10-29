using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using BethanysPieShop.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BethanysPieShop.Components.Pages
{
    public partial class SupportAdd
    {
        [SupplyParameterFromForm]
        public Ticket Ticket { get; set; }

        [SupplyParameterFromForm]
        public string InitialMessage { get; set; } = string.Empty;

        [Inject]
        public ITicketDataService? TicketDataService{ get; set; }

        [Inject]
        public IPieDataService PieDataService { get; set; }

        [Inject]
        public IHttpContextAccessor httpContextAccessor { get; set; }

        protected string Message = string.Empty;
        protected bool IsSaved = false;

        public List<Pie> Pies { get; set; } = [];


        protected async override Task OnInitializedAsync()
        {
            Ticket ??= new();
            
            Pies = (await PieDataService.GetAllPies()).ToList();
            Pies.Insert(0, new Pie { Id = 0, Name = "Not related" });
        }

        private async Task OnSubmit()
        {
            Ticket.TicketMessages =
            [
                new TicketMessage { Message = InitialMessage, CreatedDate = DateTime.Now, IsSupportMessage = false },
            ];

            Ticket.CustomerId = httpContextAccessor.HttpContext.User.Identity.Name;
            await TicketDataService.AddTicket(Ticket);

            IsSaved = true;
            Message = "Ticket submitted successfully";
        
        }

    }
}
