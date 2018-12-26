namespace Stripe
{
    using System;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class Event : StripeEntity, IHasId, IHasObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonProperty("data")]
        public EventData Data { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("pending_webhooks")]
        public long PendingWebhooks { get; set; }

        #region Request
        /* This is handled like an expandable attribute, but it's not. Rather, older API versions
         * (< 2017-05-25) return `request` as a string, while newer API versions return a hash.
         * The Stripe.net library is pinned to a specific API version, so we generally aren't
         * concerned with supporting older API versions, but events are a special case: when
         * sending webhooks, Stripe formats event objects according to the account's default API
         * version, which may be different from the version the library is pinned to. That's why
         * we make a best effort to deserialize the event anyway.
         */

        [JsonIgnore]
        public string RequestId { get; set; }

        [JsonIgnore]
        public EventRequest Request { get; set; }

        [JsonProperty("request")]
        internal object InternalRequest
        {
            get
            {
                return this.Request ?? (object)this.RequestId;
            }

            set
            {
                StringOrObject<EventRequest>.Map(value, s => this.RequestId = s, o => this.Request = o);
            }
        }
        #endregion

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
