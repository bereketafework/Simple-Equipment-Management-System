

using Equipment_Management.Domain;
using Equipment_Management.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equipment_Management.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        // an Endpoint that Used To Fetch all equipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>>
            GetAll(IRepository repository)
        {
            var equipments = await repository.GetAll();
            return Ok(equipments);
        }
        // an Endpoint that Used To Fetch Create a New equipments
        [HttpPost]
        public async Task<ActionResult<Equipment>> Add(CreateEquipmentDto equipment, IRepository repository)
        {
            var newequipment = await repository.Add(equipment);

            return (newequipment);
        }
        // an Endpoint that Used To Fetch  equipments by Id

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetById(IRepository repository, Guid id)
        {
            var equpment = await repository.GetById(id);
            if (equpment == null)
            {
                return NotFound();
            }



            return Ok(equpment);



        }

        // an Endpoint that Used To Fetch Update equipments Data

        [HttpPut("{id}")]
        public async Task<ActionResult<Equipment>> Update(UpdateEquipmentDto equipment, IRepository repository, Guid id)
        {
            var findEquipment = await repository.GetById(id);
            if (findEquipment == null)
            {
                return NotFound("Equipment  Not Found");
            }

            var FoundEquipment = await repository.Update(equipment, id);

            return Ok(FoundEquipment);

        }
        // an Endpoint that Used To Fetch Delete equipments
        [HttpDelete("{id}")]
        
        public async Task<ActionResult<Equipment>> Delete(Guid id, IRepository repository)
        {
            var findEquip = await repository.GetById(id);
            if(findEquip == null)
            {
                return NotFound();
            }

            var equipment = await repository.Delete(id);

            return Ok ("Equipmet Deleted");
        }
    }
}