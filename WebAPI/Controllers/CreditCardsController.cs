using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : Controller
    {
        private ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }


        [HttpPost("buy")]
        public IActionResult Buy(BuyDetailDto buyDto)
        {
            var result = _creditCardService.Buy(buyDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("refund")]
        public IActionResult Refund(BuyDetailDto buyDto)
        {
            var result = _creditCardService.Refund(buyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
