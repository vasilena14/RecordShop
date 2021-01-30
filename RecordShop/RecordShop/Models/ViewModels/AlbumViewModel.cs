using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecordShop.Models.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Artist> Items)
        {
            List<SelectListItem> ArtistList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "-----Select-----",
                Value = "0"
            };
            ArtistList.Add(sli);
            foreach (var item in Items)
            {
                sli = new SelectListItem
                {
                    Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                    Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString()
                };
                ArtistList.Add(sli);
            }
            return ArtistList;
        }
    }
}
