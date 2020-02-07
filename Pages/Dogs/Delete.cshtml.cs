using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogStoreTranslation.Data;
using DogStoreTranslation.Models;

namespace DogStoreTranslation.Pages.Dogs
{
    public class DeleteModel : PageModel
    {
        private readonly DogStoreTranslation.Data.DogStoreTranslationContext _context;

        public DeleteModel(DogStoreTranslation.Data.DogStoreTranslationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DogProduct DogProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DogProduct = await _context.DogProduct.FirstOrDefaultAsync(m => m.ID == id);

            if (DogProduct == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DogProduct = await _context.DogProduct.FindAsync(id);

            if (DogProduct != null)
            {
                _context.DogProduct.Remove(DogProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
