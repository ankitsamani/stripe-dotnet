namespace StripeTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class PaymentIntentServiceTest : BaseStripeTest
    {
        private const string PaymentIntentId = "pi_123";

        private PaymentIntentService service;
        private PaymentIntentCancelOptions cancelOptions;
        private PaymentIntentCaptureOptions captureOptions;
        private PaymentIntentConfirmOptions confirmOptions;
        private PaymentIntentCreateOptions createOptions;
        private PaymentIntentListOptions listOptions;
        private PaymentIntentUpdateOptions updateOptions;

        public PaymentIntentServiceTest()
        {
            this.service = new PaymentIntentService();

            this.cancelOptions = new PaymentIntentCancelOptions
            {
            };

            this.captureOptions = new PaymentIntentCaptureOptions
            {
                AmountToCapture = 123,
            };

            this.confirmOptions = new PaymentIntentConfirmOptions
            {
                SaveSourceToCustomer = true,
            };

            this.createOptions = new PaymentIntentCreateOptions
            {
                AllowedSourceTypes = new List<string>
                {
                    "card",
                },
                Amount = 1000,
                Currency = "usd",
                TransferData = new PaymentIntentTransferDataOptions
                {
                    Amount = 100,
                    Destination = "acct_123",
                }
            };

            this.listOptions = new PaymentIntentListOptions
            {
                Limit = 1,
            };

            this.updateOptions = new PaymentIntentUpdateOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "key", "value" },
                },
            };
        }

        [Fact]
        public void Cancel()
        {
            var intent = this.service.Cancel(PaymentIntentId, this.cancelOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123/cancel");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public async Task CancelAsync()
        {
            var intent = await this.service.CancelAsync(PaymentIntentId, this.cancelOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123/cancel");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public void Capture()
        {
            var intent = this.service.Capture(PaymentIntentId, this.captureOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123/capture");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public async Task CaptureAsync()
        {
            var intent = await this.service.CaptureAsync(PaymentIntentId, this.captureOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123/capture");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public void Confirm()
        {
            var intent = this.service.Confirm(PaymentIntentId, this.confirmOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123/confirm");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public async Task ConfirmAsync()
        {
            var intent = await this.service.ConfirmAsync(PaymentIntentId, this.confirmOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123/confirm");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public void Create()
        {
            var intent = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var intent = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public void Get()
        {
            var intent = this.service.Get(PaymentIntentId);
            this.AssertRequest(HttpMethod.Get, "/v1/payment_intents/pi_123");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var intent = await this.service.GetAsync(PaymentIntentId);
            this.AssertRequest(HttpMethod.Get, "/v1/payment_intents/pi_123");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public void GetWithClientSecret()
        {
            var options = new PaymentIntentGetOptions
            {
                ClientSecret = "pi_client_secret_123",
            };
            var intent = this.service.Get(PaymentIntentId, options);
            this.AssertRequest(HttpMethod.Get, "/v1/payment_intents/pi_123");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public void List()
        {
            var intents = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/payment_intents");
            Assert.NotNull(intents);
            Assert.Equal("list", intents.Object);
            Assert.Single(intents.Data);
            Assert.Equal("payment_intent", intents.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var intents = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/payment_intents");
            Assert.NotNull(intents);
            Assert.Equal("list", intents.Object);
            Assert.Single(intents.Data);
            Assert.Equal("payment_intent", intents.Data[0].Object);
        }

        [Fact]
        public void Update()
        {
            var intent = this.service.Update(PaymentIntentId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var intent = await this.service.UpdateAsync(PaymentIntentId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/payment_intents/pi_123");
            Assert.NotNull(intent);
            Assert.Equal("payment_intent", intent.Object);
        }
    }
}
