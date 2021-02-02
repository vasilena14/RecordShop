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
        public IEnumerable<Format> Formats { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        private List<Currency> CList = new List<Currency>();
        private List<Format> FList = new List<Format>();
        private List<Currency> CreateCurrencyList()
        {
            CList.Add(new Currency("USD", "USD"));
            CList.Add(new Currency("EUR", "EUR"));
            CList.Add(new Currency("BGN", "BGN"));
            return CList;
        }

        private List<Format> CreateFormatList()
        {
            FList.Add(new Format("CD", "CD"));
            FList.Add(new Format("Cassette", "Cassette"));
            FList.Add(new Format("Digital - MP3", "Digital - MP3"));
            FList.Add(new Format("Vinyl", "Vinyl"));
            return FList;
        }

        public RecordAdViewModel()
        {
            Currencies = CreateCurrencyList();
            Formats = CreateFormatList();
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

    public class Format
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public Format(String id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
