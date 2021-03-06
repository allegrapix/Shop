using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.BeginOrder;
using Shop.WithRepository.Application.PresentShelf;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Pages
{
    public class ShelfModel : PageModel
    {
        private readonly IMediator mediator;

        public List<ProductViewModel> Products { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        public ShelfModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet()
        {
            PresentShelfRequest request = new PresentShelfRequest();
            List<ProductWithReservations> products = await mediator.Send(request);

            Products = products
                .Select(x => new ProductViewModel(x))
                .ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                BeginOrderRequest request = new BeginOrderRequest
                {
                    ProductId = ProductId
                };

                Order order = await mediator.Send(request);

                return RedirectToPage("Payment", new { OrderId = order.Id });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}