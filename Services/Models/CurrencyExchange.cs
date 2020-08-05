using System;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services.Models
{
    /// <summary>
    /// Properties for the 3rd party API (https://exchangeratesapi.io/)
    /// </summary>
    public class CurrencyExchange
    {
        public Dictionary<string, decimal> Rates { get; set; } = null!;
        public string Base { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
