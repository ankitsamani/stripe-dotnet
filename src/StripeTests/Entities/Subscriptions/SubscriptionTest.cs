namespace StripeTests
{
    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class SubscriptionTest : BaseStripeTest
    {
        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/subscriptions/sub_123");
            var subscription = JsonConvert.DeserializeObject<Subscription>(json);
            Assert.NotNull(subscription);
            Assert.IsType<Subscription>(subscription);
            Assert.NotNull(subscription.Id);
            Assert.Equal("subscription", subscription.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
            };

            string json = GetFixture("/v1/subscriptions/sub_123", expansions);
            var subscription = JsonConvert.DeserializeObject<Subscription>(json);
            Assert.NotNull(subscription);
            Assert.IsType<Subscription>(subscription);
            Assert.NotNull(subscription.Id);
            Assert.Equal("subscription", subscription.Object);

            Assert.NotNull(subscription.Customer);
            Assert.Equal("customer", subscription.Customer.Object);
        }
    }
}
