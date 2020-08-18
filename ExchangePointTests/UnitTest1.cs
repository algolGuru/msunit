using System;
using System.Collections.Generic;
using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangePointTests
{
    [TestClass]
    public class ExchangePointTests
    {
        /*        [TestMethod]
                /// ТестируемыйКласс_ТестируемыйМетод_Условия_ОжидаемыйРезультат
                public void ExchangePoint_ExchangeMoney_UseImplementations_CorrectResult()
                {
                    // Инициализация
                    // Arrange
                    var exchangePoint = new ExchangePoint( new CalulatingMachine(), new CurrencyConverter(), 10 );

                    // Вызов тестируемого метода
                    // Act
                    var result = exchangePoint.ExchangeMoney( new List<int> { 10, 20, 30, 40 } );

                    // Проверка результата
                    // Assert
                    Assert.AreEqual( 9, result );
                }*/

        /*        [TestMethod]
                /// ТестируемыйКласс_ТестируемыйМетод_Условия_ОжидаемыйРезультат
                public void ExchangePoint_ExchangeMoney_UseAbstractions_CorrectResult()
                {
                    // Инициализация
                    // Arrange
                    var rubles = new List<int> { 1, 2, 3, 4 };

                    bool wasSumCalulating = false;
                    var calculatingMachine = new StubCalculatingMachine
                    {
                        CalculateSumDelegate = ( arg ) =>
                        {
                            wasSumCalulating = true;
                            Assert.AreEqual( 1, arg[0] );
                            Assert.AreEqual( 2, arg[1] );
                            Assert.AreEqual( 3, arg[2] );
                            Assert.AreEqual( 4, arg[3] );
                            return 100;
                        }
                    };

                    var currencyConverter = new StubCurrencyConverter
                    {
                        ConvertToUsdDelegate = ( arg ) =>
                        {
                            Assert.AreEqual( 100, arg );
                            return 10;
                        }
                    };

                    var exchangePoint = new ExchangePoint( calculatingMachine, currencyConverter, 10 );

                    // Вызов тестируемого метода
                    // Act
                    var result = exchangePoint.ExchangeMoney( rubles );

                    // Проверка результата
                    // Assert
                    Assert.AreEqual( 9, result );
                    Assert.IsTrue( wasSumCalulating );
                }*/

        [TestMethod]
        /// ТестируемыйКласс_ТестируемыйМетод_Условия_ОжидаемыйРезультат
        public void ExchangePoint_ExchangeMoney_UseMsFakes_CorrectResult()
        {
            // Инициализация
            // Arrange
            var rubles = new List<int> { 1, 2, 3, 4 };

            bool wasSumCalulating = false;
            var calculatingMachine = new StubICalculatingMachine // TODO replace to MsFake
            {
                CalculateSumDelegate = ( arg ) =>
                {
                    wasSumCalulating = true;
                    Assert.AreEqual( 1, arg[0] );
                    Assert.AreEqual( 2, arg[1] );
                    Assert.AreEqual( 3, arg[2] );
                    Assert.AreEqual( 4, arg[3] );
                    return 100;
                }
            };

            var currencyConverter = new StubICurrencyConverter // TODO replace to MsFake
            {
                ConvertToUsdDelegate = ( arg ) =>
                {
                    Assert.AreEqual( 100, arg );
                    return 10;
                }
            };

            var exchangePoint = new ExchangePoint( calculatingMachine, currencyConverter, 10 );

            // Вызов тестируемого метода
            // Act
            var result = exchangePoint.ExchangeMoney( rubles );

            // Проверка результата
            // Assert
            Assert.AreEqual( 9, result );
            Assert.IsTrue( wasSumCalulating );
        }
    }

    // В MSTests есть фейки. Они сами нам генерят стабы
    // Задача - написать ExchangePoint_ExchangeMoney_UseMsFakes_CorrectResult используя MSFakes 
}

