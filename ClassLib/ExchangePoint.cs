using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{

    public interface ICalulatingMachine
    {
        int CalculateSum( List<int> rubles );
    }

    public class CalulatingMachine : ICalulatingMachine
    {
        public int CalculateSum( List<int> rubles )
        {
            return rubles.Sum();
        }
    }

    /*    public class StubCalculatingMachine : ICalulatingMachine
        {
            public Func<List<int>, int> CalculateSumDelegate { get; set; }

            public int CalculateSum( List<int> rubles )
            {
                return CalculateSumDelegate( rubles );
            }
        }*/

    public interface ICurrencyConverter
    {
        int ConvertToUsd( int rubles );
    }

    public class CurrencyConverter : ICurrencyConverter
    {
        public int ConvertToUsd( int rubles )
        {
            return rubles / 10;
        }
    }
    /*
        public class StubCurrencyConverter : ICurrencyConverter
        {
            public Func<int, int> ConvertToUsdDelegate { get; set; }

            public int ConvertToUsd( int rubles )
            {
                return ConvertToUsdDelegate( rubles );
            }
        }*/

    public class ExchangePoint
    {
        readonly ICalulatingMachine _calulatingMachine;
        readonly ICurrencyConverter _currencyConverter;

        public ExchangePoint( ICalulatingMachine calulatingMachine, ICurrencyConverter currencyConverter, int comissionPercent )
        {
            _calulatingMachine = calulatingMachine;
            _currencyConverter = currencyConverter;

            ComissionPercent = comissionPercent;
        }

        private int ComissionPercent { get; set; }

        public int ExchangeMoney( List<int> rubles )
        {
            var rublesSum = _calulatingMachine.CalculateSum( rubles );
            var exchanged = _currencyConverter.ConvertToUsd( rublesSum );

            var result = exchanged * ( 1 - ( ( double )ComissionPercent ) / 100 );

            return ( int )result;
        }
    }
}
