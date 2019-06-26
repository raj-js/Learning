using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LearningEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly TestDbContext _db;

        public DefaultController(TestDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<Person> Get([FromRoute]int id)
        {
            return await _db.People.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        [HttpPost]
        public async Task<Person> Add([FromBody]Person person)
        {
            var entry = await _db.People.AddAsync(person);
            await _db.SaveChangesAsync();

            return entry.Entity;
        }

        [HttpPut]
        public async Task<Person> Update([FromBody]Person current)
        {
            Person original = null;

            try
            {
                original = await _db.People.FindAsync(current.Id);
                original.FirstName = current.FirstName;
                original.LastName = current.LastName;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                foreach (var entry in e.Entries)
                {
                    var currentValues = entry.CurrentValues;
                    var databaseValues = await entry.GetDatabaseValuesAsync();

                    if (entry.Entity is Person person)
                    {
                        // 更新什么值取决于实际需要

                        person.FirstName = currentValues[nameof(Person.FirstName)]?.ToString();
                        person.LastName = currentValues[nameof(Person.LastName)]?.ToString();

                        // 这步操作是为了刷新当前 Tracker 的值， 为了通过下一次的并发检查
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }

                await _db.SaveChangesAsync();
            }

            return original;
        }
    }
}