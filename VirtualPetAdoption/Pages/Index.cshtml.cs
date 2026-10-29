using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PetAdoptionContext _context;

        public IndexModel(PetAdoptionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Name { get; set; } = "";

        [BindProperty]
        public int EnergyPreference { get; set; }

        public Pet? Match { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // The best match is the pet with the closest energy level.
            Match = _context.Pets
                .OrderBy(p => Math.Abs(p.EnergyLevel - EnergyPreference))
                .First();
        }
    }
}

