using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        public List<Movie> Movies;

        [BindProperty]
        public string Search { get; set; }

        [BindProperty]
        public List<string> Mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float? MinIMDB { get; set; }

        [BindProperty]
        public float? MaxIMDB { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost(string search, List<string> rating, float? minIMDB, float? maxIMDB)
        {
            Search = search;
            Mpaa = rating;
            MinIMDB = minIMDB;
            MaxIMDB = maxIMDB;
            Movies = MovieDatabase.All;
            if(search != null)
            {
                Movies = MovieDatabase.Search(Movies, search);
            }
            if(rating.Count != 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, rating);
            }
            if(minIMDB != null)
            {
                Movies = MovieDatabase.FilterByMinIMDB(Movies, (float)minIMDB);
            }
            if(maxIMDB != null)
            {
                Movies = MovieDatabase.FilterByMaxIMDB(Movies, (float)maxIMDB);
            }

            //if(search != null && rating.Count != 0)
            //{
            //    Movies = movieDatabase.SearchAndFilter(search, rating);
            //}
            //else if(rating.Count != 0)
            //{
            //    Movies = movieDatabase.Filter(rating);
            //}
            //else if(search != null)
            //{
            //    Movies = movieDatabase.Search(search);
            //}
            //else
            //{
            //    Movies = movieDatabase.All;
            //}
        }
    }
}
