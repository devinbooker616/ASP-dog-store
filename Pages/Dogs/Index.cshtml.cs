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
    public class IndexModel : PageModel
    {
        private readonly DogStoreTranslation.Data.DogStoreTranslationContext _context;

        public IndexModel(DogStoreTranslation.Data.DogStoreTranslationContext context)
        {
            _context = context;
        }

        public IList<DogProduct> DogProduct { get;set; }

        public async Task OnGetAsync()
        {
            DogProduct = await _context.DogProduct.ToListAsync();
        }
    }
}
