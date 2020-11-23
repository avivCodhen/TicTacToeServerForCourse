using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly RoomsRepo _roomsRepo;

        public RoomsController(RoomsRepo roomsRepo)
        {
            _roomsRepo = roomsRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _roomsRepo.RoomsAndBoards.Select(x => x.Key);
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var room = _roomsRepo.RoomsAndBoards[id];
            return Ok(room);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] RequestModel requestModel)
        {
            if (!_roomsRepo.Types.Contains(requestModel.Type, StringComparer.OrdinalIgnoreCase)) return BadRequest("wrong type");
            if (requestModel.x > 2 || requestModel.y > 2 || requestModel.x < 0 || requestModel.y < 0) return BadRequest("invalid dimensions");
            if (_roomsRepo.RoomsAndBoards[requestModel.Room][requestModel.x][requestModel.y] != "empty")
                return BadRequest($"Value already exists in {requestModel.x}, {requestModel.y}");
            
            _roomsRepo.RoomsAndBoards[requestModel.Room][requestModel.y][ requestModel.x] = requestModel.Type;

            return Ok(_roomsRepo.RoomsAndBoards[requestModel.Room]);
        }

        [HttpPut("reset/{id}")]
        public IActionResult Reset(string id)
        {
            _roomsRepo.RoomsAndBoards[id] = _roomsRepo.CreateEmptyBoard();
            return Ok(_roomsRepo.RoomsAndBoards[id]);
        }
    }
}