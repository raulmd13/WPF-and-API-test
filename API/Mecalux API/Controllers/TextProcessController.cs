using Mecalux.Models;
using Mecalux.Models.POCO;
using Mecalux.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mecalux_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextProcessController : ControllerBase
    {
        private readonly ITextProcessService textProcessService;

        public TextProcessController(ITextProcessService textProcessService)
        {
            this.textProcessService = textProcessService;
        }



        // GET: api/GetOrderOptions
        [HttpGet]
        [Route("GetOrderOptions")]
        public IActionResult GetOrderOptions()
        {
            var listOfOptions = textProcessService.GetAllOrderTypes();

            if (listOfOptions.Count() > 0)
            {
                return Ok(listOfOptions);
            }

            return NoContent();
        }

        // GET api/GetOrderedText
        [HttpGet]
        [Route("GetOrderedText")]
        public IActionResult GetOrderedText(string textToOrder, string orderOption)
        {

            if (!textProcessService.isValidOrderOption(orderOption))
            {
                return BadRequest($"{orderOption} no es un tipo de orden valido");
            }

            Enum.TryParse(orderOption, out OrderOption OrderType);

            string OrderedText = textProcessService.OrderText(textToOrder, OrderType);

            return Ok(OrderedText);
        }

        // GET api/GetStatistics
        [HttpGet]
        [Route("GetStatistics")]
        public IActionResult GetStatistics(string text)
        {
            TextStatistics textStatistics = textProcessService.GenerateStatistics(text);

            return Ok(textStatistics);
        }

    }
}
