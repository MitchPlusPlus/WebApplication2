using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class MultiSystem : PageModel
    {
        private readonly ILogger<MultiSystem> _logger;

        public MultiSystem(ILogger<MultiSystem> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
