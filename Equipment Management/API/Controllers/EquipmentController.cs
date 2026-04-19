

using Equipment_Management.Domain;
using Equipment_Management.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equipment_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>>
            GetAll(IRepository repository)
        {
            var equipments = await repository.GetAll();
            return Ok(equipments);
        }

        [HttpPost]
        public async Task<ActionResult<Equipment>> Add(CreateEquipmentDto equipment, IRepository repository)
        {
            var newequipment = await repository.Add(equipment);

            return (newequipment);
        }

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

       

        [HttpPut("{id}")]
        public async Task<ActionResult<Equipment>> Update(Equipment equipment, IRepository repository, Guid id)
        {
            var findEquipment = await repository.GetById(id);
            if (findEquipment == null)
            {
                return NotFound("Equipment id  Not Found");
            }

            var FoundEquipment = await repository.Update(equipment, id);

            return Ok(FoundEquipment);

        }
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