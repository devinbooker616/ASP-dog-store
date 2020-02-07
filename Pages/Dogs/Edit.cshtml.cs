using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogStoreTranslation.Data;
using DogStoreTranslation.Models;

namespace DogStoreTranslation.Pages.Dogs
{
    public class EditModel : PageModel
    {
        private readonly DogStoreTranslation.Data.DogStoreTranslationContext _context;

        public EditModel(DogStoreTranslation.Data.DogStoreTranslationContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DogProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogProductExists(DogProduct.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DogProductExists(int id)
        {
            return _context.DogProduct.Any(e => e.ID == id);
        }
    }
}
