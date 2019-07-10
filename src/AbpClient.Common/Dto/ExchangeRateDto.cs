using System;

namespace QSMS.QsDto
{
    public class CreateExchangeRateDto
    {
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime? Date { get; set; }
    }

    public class ExchangeRateDto : CreateExchangeRateDto
    {
        public int Id { get; set; }


    }
}