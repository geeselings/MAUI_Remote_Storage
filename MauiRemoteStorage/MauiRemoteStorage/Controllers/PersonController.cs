using MauiRemoteStorage.Models;
using MauiRemoteStorage.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace MauiRemoteStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new PersonData().GetPeople();
        }

        [HttpPost]
        public void Post([FromBody] Person value)
        {
            var pd = new PersonData();
            pd.SavePerson(value);
        }
    }
}