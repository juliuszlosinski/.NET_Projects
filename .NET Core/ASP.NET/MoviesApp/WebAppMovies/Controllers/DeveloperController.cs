using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMovies.Models;
using WebAppMovies.Units;

namespace WebAppMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetPopularDevelopers([FromQuery]int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);
        }

        [HttpPost]
        public IActionResult AddDeveloperAndProject()
        {
            var dev = new Developer
            {
                Followers = 40,
                Name = "Jack Back"
            };
            var proj = new Project
            {
                Name="C# Advanced!"
            };
            _unitOfWork.Developers.Add(dev);
            _unitOfWork.Projects.Add(proj);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
