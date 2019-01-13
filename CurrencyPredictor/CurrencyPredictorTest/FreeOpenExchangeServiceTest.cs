using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CurrencyPredictor.Model;
using CurrencyPredictor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyPredictorTest
{
    [TestClass]
    public class FreeOpenExchangeServiceTest
    {
        private Mock<IExchangeRateService> exchangeRateMock;
        private FreeOpenExchangeService freeOpenExchangeService;
        [TestInitialize]
        public void SetUp()
        {
            this.exchangeRateMock = new Mock<IExchangeRateService>();
            this.freeOpenExchangeService = new FreeOpenExchangeService(exchangeRateMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Input values")]
        public void GetPredictedCurrencyExchangeRateInvalidInputException()
        {
            var listRates = new List<CurrencyExchangeModel>();
            exchangeRateMock.Setup(x => x.GetAllExchangeRate()).Returns(listRates);

            var result = this.freeOpenExchangeService.GetPredictedCurrencyExchangeRate("", "VND");
        }

        [TestMethod]
        public void GetPredictedCurrencyExchangeRateSuccessfully()
        {
            var listRates = new List<CurrencyExchangeModel>
            {
                new CurrencyExchangeModel
                {
                    Base = "USD",
                    Rates = new Dictionary<string, double>()
                    {
                        {"VND", 22464.216667 }
                    }
                },
                new CurrencyExchangeModel
                {
                    Base = "USD",
                    Rates = new Dictionary<string, double>()
                    {
                        {"VND", 22248.333333 }
                    }
                },
                new CurrencyExchangeModel
                {
                    Base = "USD",
                    Rates = new Dictionary<string, double>()
                    {
                        {"VND", 22343.05 }
                    }
                }
            };
            exchangeRateMock.Setup(x => x.GetAllExchangeRate()).Returns(listRates);

            var result = this.freeOpenExchangeService.GetPredictedCurrencyExchangeRate("", "VND");

            Assert.IsNotNull(result);
            Assert.AreEqual(result, 22209.063094845216);
        }
    }
}
