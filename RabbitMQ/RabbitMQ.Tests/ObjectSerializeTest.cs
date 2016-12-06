using System;
using System.Diagnostics;
using Common;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Xunit.Abstractions;
namespace RabbitMQ.Tests
{
    public class ObjectSerializeTest
    {

        private readonly ITestOutputHelper output;

        public ObjectSerializeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ObjectSerializeIsValid()
        {
            Payment payment = new Payment {AmountToPay = 25.0m, CardNumber = "12341234123412341234"};

            byte[] serialised = ObjectSerialise.Serialize(payment);

            Payment paymentDeSerialized = (Payment) ObjectSerialise.DeSerialize(serialised, typeof(Payment));
            Assert.True(payment.CardNumber.Equals(paymentDeSerialized.CardNumber));
        }
    }
}