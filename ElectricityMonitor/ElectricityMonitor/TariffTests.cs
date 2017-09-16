using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ElectricityMonitor
{
    public class MeterBuilderTests
    {

        [Fact]
        public void MeterBuildeTest()
        {

            var startRead = new ControlledMeter(value: 17152, recordedOn: DateTime.Parse("16/07/2017"));
            var endRead = new ControlledMeter(value: 17513, recordedOn: DateTime.Parse("14/09/2017"));

            MeterBuilder builder=  new MeterBuilder();
            builder.Build(start: startRead, end: endRead);
            
        }
    }

    public class MeterTests
    {
        [Fact]
        
        public void Meter_instance_NotNull()
        {
            var meter = new ControlledMeter(value : 17152, recordedOn : DateTime.Parse("16/06/2017"));
            Assert.IsType<Meter>(meter);
        }

        [Fact]
        public void Meter_Subtract_Method_On_CurrentInstance()
        {
            var startRead = new ControlledMeter(value:17152, recordedOn:DateTime.Parse("16/07/2017"));
            var endRead = new ControlledMeter(value: 17513, recordedOn: DateTime.Parse("14/09/2017"));

            //var valid = IsMeterReadingsValid(startRead, endRead);
            //if (valid)
            //{
            //    int totalKWh = endRead.Subtract(startRead);
            //    Assert.True(totalKWh == 361);
            //}
            //Assert.True(valid);
        }

        private bool IsMeterReadingsValid(Meter startRead, Meter endRead)
        {
            return startRead.GetType() == endRead.GetType() && endRead.Value >= startRead.Value;

        }
    }

    public class MeterBuilder
    {
        private Meter StartRead { get; }
        private Meter EndRead { get; }



        public MeterBuilder()
        {
           
        }

        bool CanCalculate()
        {
            return StartRead.GetType() == EndRead.GetType() && EndRead.Value >= StartRead.Value;
        }

        public void Build(Meter start, Meter end)
        {

            this.StartRead = start;
            this.EndRead = end;  
            if (CanCalculate())
            {
                
            }
           
        }
    }
    public abstract class Meter
    {

       
        public  int Value { get; }
        public DateTime RecordedOn { get; }

        public Meter(int value, DateTime recordedOn)
        {
            this.Value = value;
            this.RecordedOn = recordedOn;
        }

         protected int Subtract(Meter startRead)
        {
            return this.Value - startRead.Value;
        }
    }


    public class TariffTests
    {

        private ITestOutputHelper helper;


        public TariffTests(ITestOutputHelper helper)
        {
            this.helper = helper;
        }
        [Fact]
        public void Tariff_Instance_Created()
        {
            Tariff tariff = new Tariff("Peak",
                0.2461m,
                ChargeUnit.KWh,
                DateTime.Parse("01/07/2016"),
                DateTime.Parse("30/06/2017"),
                AccountType.Debit);
            Assert.NotNull(tariff);
            Assert.IsType<Tariff>(tariff);
        }

        [Fact]
        public void Tariff_SetCreditTariff()
        {
            Tariff solar = new Tariff(
                    name: "Solar Credit", 
                    rate: 0.52m, 
                    chargeUnit: ChargeUnit.KWh,
                    effectiveFrom: DateTime.Parse("01/07/2016"), 
                    effectiveTo: DateTime.Parse("30/06/2017"),
                    accountType: AccountType.Credit);


            Assert.True(solar.Name.Equals("Solar Credit"));
        }

    }

    public class Tariff 
    {
        public Tariff(string name, 
                        decimal rate, 
                        ChargeUnit chargeUnit, 
                        DateTime effectiveFrom, 
                        DateTime? effectiveTo, 
                        AccountType accountType)
        {
            this.Name = name;
            this.Rate = rate;
            this.ChargeUnit = chargeUnit;
            this.EffectiveFrom = effectiveFrom;
            this.EffectiveTo = effectiveTo;
            this.AccountType = accountType;
        }

        public AccountType AccountType { get; private set; }

        public DateTime? EffectiveTo { get; private  set; }
        public DateTime EffectiveFrom { get; private set; }
        public ChargeUnit ChargeUnit { get; private  set; }
        public decimal Rate { get; private set; }
        public string Name { get; private set; }
    }

   

    public enum ChargeUnit
    {
        KWh,
        Day
    }

    public enum AccountType
    {
        Debit,
        Credit
    }
}

