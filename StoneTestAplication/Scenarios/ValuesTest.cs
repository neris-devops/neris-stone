using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;
using System.Net;
using StoneWebApi;
using Xunit;
using TestAplication.Fixtures;

namespace TestAplication.Scenarios
{
    public class ValuesTest
    {

        private readonly TestContex _testContext;
        public ValuesTest()
        {
            _testContext = new TestContex();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/Cards/GetAllCards");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetById_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync("/Transactions/GetTransactions");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
