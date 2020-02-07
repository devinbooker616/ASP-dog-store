using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogStoreTranslation.Data;
using DogStoreTranslation.Models;

namespace DogStoreTranslation.Pages.Dogs
{
    public class CreateModel : PageModel
    {
        private readonly DogStoreTranslation.Data.DogStoreTranslationContext _context;

        public CreateModel(DogStoreTranslation.Data.DogStoreTranslationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DogProduct DogProduct { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DogProduct.Add(DogProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
