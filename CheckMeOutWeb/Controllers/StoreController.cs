using AutoMapper;
using CheckMeOut.Interfaces;
using CheckMeOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CheckMeOut.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StoreController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICheckout _checkout;
		public StoreController(IMapper mapper, ICheckout checkout)
		{
			_mapper = mapper;
			_checkout = checkout;
		}

		[HttpGet("[action]")]
		public ActionResult Products()
		{
			var products = _checkout.GetProducts().Select(s => s.Value).ToArray();
			return Ok(products);
		}

		[HttpPost("[action]")]
		public ActionResult Add(Stock product)
		{
			return NoContent();
		}

		[HttpPost("[action]")]
		public ActionResult Remove(Stock product)
		{
			return NoContent();
		}
	}
}