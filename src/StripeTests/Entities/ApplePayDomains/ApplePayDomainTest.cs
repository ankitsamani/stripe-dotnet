namespace StripeTests
{
    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class ApplePayDomainTest : BaseStripeTest
    {
        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/apple_pay/domains/apwc_123");
            var domain = JsonConvert.DeserializeObject<ApplePayDomain>(json);
            Assert.NotNull(domain);
            Assert.IsType<ApplePayDomain>(domain);
            Assert.NotNull(domain.Id);
            Assert.Equal("apple_pay_domain", domain.Object);
        }
    }
}
