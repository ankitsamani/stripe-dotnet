namespace StripeTests
{
    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class PersonTest : BaseStripeTest
    {
        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/accounts/acct_123/persons/person_123");
            var person = JsonConvert.DeserializeObject<Person>(json);
            Assert.NotNull(person);
            Assert.IsType<Person>(person);
            Assert.NotNull(person.Id);
            Assert.Equal("person", person.Object);
        }
    }
}
