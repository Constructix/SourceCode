using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Billing;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Interfaces;

namespace Constructix.Home.Electricity.Business.DomainModels.Services
{
    public class BillingService
    {


        public List<Meter> _meters;

        private List<ITariff> _tariffs;
        private readonly TariffService _tariffSvc;
        public BillingService(TariffService tariffService)
        {
            _tariffSvc = tariffService;
        }

        public Invoice Create(List<Meter> meters)
        {
            Invoice newInvoice = new Invoice();
            // Need to see if the tariffs are > 1 then have to split up the bill and the amounts
            // workout accordingley to break up the rates due to the rates increasing over the period from 
            // readings.
            foreach (var meter in meters)
            {
                var currentTariffs = _tariffSvc.GetTariffs(meter.PreviousReading, meter.LatestReading);
                newInvoice.ElectricityUsage = ReadingCalculatorService.CalculateReadings(meter.PreviousReading, meter.LatestReading).TotalUsage * currentTariffs.FirstOrDefault<ITariff>().Rate;
                newInvoice.SupplyCharge = 10.00m;
            }
            return newInvoice;
        }
    }
}