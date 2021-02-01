using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecordShop.Models.ViewModels
{
    public class RecordAdViewModel
    {
        public RecordAd RecordAd { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        private List<Currency> CList = new List<Currency>();
        private List<Currency> CreateList()
        {
            CList.Add(new Currency("USD", "USD"));
            CList.Add(new Currency("EUR", "EUR"));
            CList.Add(new Currency("BGN", "BGN"));
            return CList;
        }

        public RecordAdViewModel()
        {
            Currencies = CreateList();
        }

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

    public class Currency
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public Currency(String id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
