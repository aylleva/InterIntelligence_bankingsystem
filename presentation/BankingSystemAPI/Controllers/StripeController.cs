using BankingSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using Stripe.FinancialConnections;
using Stripe.TestHelpers;
using CustomerService = Stripe.CustomerService;


namespace BankingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly StripeModel _model;
        private readonly Stripe.CustomerService customerservice;
        private readonly ProductService productservice;

        public StripeController(IOptions<StripeModel> model,CustomerService customerservice,ProductService productservice)
        {
            _model = model.Value;
            this.customerservice = customerservice;
            this.productservice = productservice;
        }

        [HttpPost("Pay")]
        public IActionResult Pay(string  priceId)
        {
            StripeConfiguration.ApiKey= _model.SecretKey;

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = priceId,
                        Quantity = 1
                    }
                },
                Mode = "payment"
              
            };

            options.Customer = "cus_S26RDQ1ypMf5Yg";
            var service = new Stripe.Checkout.SessionService();

            var session = service.Create(options);

            return Ok(session.Url);
        }

        [HttpPost("[Action]")]
        [Authorize]
        public async Task<dynamic> CustumerCreate([FromForm] StripeCustomer customer)
        {
            StripeConfiguration.ApiKey = _model.SecretKey;

            var customeroptions = new CustomerCreateOptions
            {
                Email = customer.Email,
                Name = customer.Username
            };

            var customerinf= await customerservice.CreateAsync(customeroptions);

            return new { customerinf };
        }

        [HttpGet("[Action]")]
        public  IActionResult GetProducts()
        {
            StripeConfiguration.ApiKey = _model.SecretKey;

            var options= new ProductListOptions {Expand= new List<string>() {"data.default_price"} };

            var products= productservice.List(options);
            return Ok(products);
        }
    }
}
