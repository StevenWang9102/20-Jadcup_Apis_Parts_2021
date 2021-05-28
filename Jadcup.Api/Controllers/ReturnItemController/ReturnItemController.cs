using System.Threading.Tasks;
using Jadcup.Services.Interface.ReturnItemService;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.ReturnItemModel;
using Microsoft.AspNetCore.Mvc;

namespace Jadcup.Api.Controllers.ReturnItemController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnItemController : Controller
    {
        private readonly IReturnItemManagementService _returnItemManagementService;
        public ReturnItemController(IReturnItemManagementService returnItemManagementService)
        {
            _returnItemManagementService = returnItemManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReturnItem(string ticketId, sbyte? processed)
        {
            return Ok(await _returnItemManagementService.GetAll(ticketId, processed));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReturnItemById(int id)
        {
            return Ok(await _returnItemManagementService.GetById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddReturnItem(AddReturnItemDto request)
        {
            return Ok(await _returnItemManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateReturnItem(UpdateReturnItemDto request)
        {
            return Ok(await _returnItemManagementService.Update(request));
        }

        ///<summary>
        ///returned value is barcodes for printing; 
        ///For human errors, use addbox api below or corresponding box controller to update boxes;
        ///Boxes here haven't gone into warehouse;
        ///To store them into the warehouse, use the same apis for packaging suborder: i.e. addplatebox, then addtempzone;
        ///Do not call this api multiple times to update processed returnitem;
        ///optional ticketId parameter added to getallbox api to get ticket related box
        ///</summary>
        ///<remarks>
        ///processed field: 0 - unprocessed, 1 - reboxed and waiting to be stored into warehouse, 2 - destroyed
        ///</remarks>
        [HttpPut("[action]")]
        public async Task<IActionResult> ProcessReturnItem(UpdateReturnItemDto2 request)
        {
            return Ok(await _returnItemManagementService.Process(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteReturnItem(int id)
        {
            return Ok(await _returnItemManagementService.Delete(id));
        }

        ///<summary>
        ///this api is used to add box mannually to fix any human error when adding box for returned item;Box can be updated and deleted with corresponding box controller
        ///</summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddBox(AddBoxDto request)
        {
            return Ok(await _returnItemManagementService.AddBox(request));
        }
    }
}