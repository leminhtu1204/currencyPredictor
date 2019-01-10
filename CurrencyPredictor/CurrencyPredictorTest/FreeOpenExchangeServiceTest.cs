using System;
using System.Collections.Generic;
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

            var result = this.freeOpenExchangeService.GetPredictedCurrencyExchangeRate("", "");
        }

        [TestMethod]
        public void GetPredictedCurrencyExchangeRateSuccessfully()
        {
            var listRates = new List<CurrencyExchangeModel>();
            exchangeRateMock.Setup(x => x.GetAllExchangeRate()).Returns(listRates);

            var result = this.freeOpenExchangeService.GetPredictedCurrencyExchangeRate("", "");
        }
    }
}
