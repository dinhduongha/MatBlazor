using System;

namespace AbpCommon.Dto
{
    public class CreateCurrencyDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class CurrencyDto : CreateCurrencyDto
    {
        public int Id { get; set; }

    }
}