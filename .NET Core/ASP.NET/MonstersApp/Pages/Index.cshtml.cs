using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MonstersApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonstersApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MonsterService monsterService;

        public IndexModel(ILogger<IndexModel> logger, MonsterService monsterService)
        {
            _logger = logger;
            this.monsterService = monsterService;
        }

        public IEnumerable<Monster> Monsters { get; set; }

        public void OnGet()
        {
            Monsters = monsterService.GetAll();
        }
    }
}
