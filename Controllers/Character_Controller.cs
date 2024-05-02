using Character_backend.ScaffoldDbContext;
using Character_backend.ScaffoldModels;
using Microsoft.AspNetCore.Mvc;

namespace Character_backend.Controllers {

    [ApiController]
    public class Character_Controller: ControllerBase {
        private readonly CharacterCreatorContext _context;

        public Character_Controller(CharacterCreatorContext context) {
            this._context = context;
        }

        [HttpGet("/characters", Name = "GetCharacters")]
        public List<Character> GetCharacters() {
            return this._context.Characters.ToList();
        }

        [HttpPost("/characters")]
        public IActionResult AddCharacter([FromBody] Character character)
        {
            if (character == null)
            {
                return BadRequest("Character data must be provided.");
            }

            try
            {
                _context.Characters.Add(character);
                _context.SaveChanges();
                return CreatedAtRoute("GetCharacters", new { id = character.CharacterId }, character);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }



        [HttpGet("/relationships", Name = "GetRelationships")]
        public List<Relationship> GetRelationships() {
            return this._context.Relationships.ToList();
        }

        [HttpPost("/relationships")]
        public IActionResult AddRelationship([FromBody] Relationship relationship)
        {
            if (relationship == null)
            {
                return BadRequest("Relationship data must be provided.");
            }

            try
            {
                _context.Relationships.Add(relationship);
                _context.SaveChanges();
                return CreatedAtRoute("GetRelationships", new { id = relationship.RelationshipId }, relationship);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("/characters/{id}", Name = "GetCharacterById")]
        public ActionResult<Character> GetCharacterById(int id) {
            var character = _context.Characters.FirstOrDefault(c => c.CharacterId == id);
            if (character == null) {
                return NotFound($"Character with ID {id} not found.");
            }
            return character;
        }
    }
}