using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DatingApp.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _connection;
        public ValuesController(DataContext connection)
        {
            _connection = connection;

        }

        [HttpGet]
        public async Task<IActionResult> GetValue()
        {
            var values=await _connection.Values.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value=await _connection.Values.FirstOrDefaultAsync(x => x.Id==id);
            return Ok(value);
        }
    }
}