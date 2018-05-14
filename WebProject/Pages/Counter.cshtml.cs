using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.CounterService;

namespace WebProject.Pages
{
    public class CounterModel : PageModel
    {
        private readonly ICounterService _counterService;
        public int CurrentCount => _counterService.PageRequestCounter;

        public CounterModel(ICounterService counterService)
        {
            _counterService = counterService;
        }

        public void OnGet()
        {
            _counterService.PageRequestCounter++;
        }
    }
}
