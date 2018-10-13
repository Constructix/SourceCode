using System;
using System.Text.RegularExpressions;
using CleanSkinGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanSkinGenerator.Tests
{
    [TestClass]
    public class FactTests
    {
        [TestMethod]
        public void ToXml()
        {

            Fact testFact = new Fact()
            {
                Name = "Declaration.StatementType.Code",
                SequenceNumber = 89,
                ParentNumber = 88,
                Context = "RP",
                Value = "TrueAndCorrect"
            };
            Assert.IsTrue(!String.IsNullOrWhiteSpace(testFact.ToXml()));
            Console.WriteLine(testFact.ToXml());
        }

        [TestMethod]
        public void CheckRegEx()
        {
            string pattern = @"\[AddressDetails.Usage.Code='POS']";
            string text = "RP.[AddressDetails.Usage.Code='POS'].[AddressDetails.Currency.Code='C']";

            string expectedString = "AddressDetails.Usage.Code";
            var match = Regex.Match(text, pattern);


            var startBrackPos = match.Value.IndexOf("[", StringComparison.Ordinal);
            var equalSignPos = match.Value.IndexOf("=", StringComparison.Ordinal);
            var endBracketPos = match.Value.IndexOf("]", StringComparison.Ordinal);

            string actualResult = string.Empty;

            if (startBrackPos >= 0 && equalSignPos > startBrackPos && endBracketPos > equalSignPos)
            {
                actualResult = match.Value.Substring(startBrackPos + 1, equalSignPos - 1 - startBrackPos);
                Console.WriteLine(actualResult);
            }

            Assert.IsTrue(match.Success);
            Assert.IsTrue(expectedString.Equals(actualResult));
        }

        [TestMethod]
        public void ExtractValue()
        {
            string pattern = @"\[AddressDetails.Usage.Code='POS']";
            string text = "RP.[AddressDetails.Usage.Code='POS'].[AddressDetails.Currency.Code='C']";

            string expectedString = "POS";
            var match = Regex.Match(text, pattern);
            
            var equalSignPos = match.Value.IndexOf("=", StringComparison.Ordinal);
            var endBracketPos = match.Value.IndexOf("]", StringComparison.Ordinal);
            string actualResult = string.Empty;

            if (equalSignPos > 0 && endBracketPos > equalSignPos)
            {
                actualResult = match.Value.Substring(equalSignPos + 2, endBracketPos - 2 - equalSignPos-1);
                Console.WriteLine(actualResult);
            }
            Assert.IsTrue(expectedString.Equals(actualResult));
        }
    }

    public class ContextInstanceExtractor
    {
        public static void Extract(Fact factToAssignTo, string contextInstance)
        {

            if (VerifyContextInstanceIsValid(factToAssignTo, contextInstance))
            {
                string pattern = string.Format(@"\[{0}='\w+']", factToAssignTo.Name);
                var match = Regex.Match(factToAssignTo.Context, pattern);
                var equalSignPos = match.Value.IndexOf("=", StringComparison.Ordinal);
                var endBracketPos = match.Value.IndexOf("]", StringComparison.Ordinal);
                if (equalSignPos > 0 && endBracketPos > equalSignPos)
                {
                    factToAssignTo.Value =
                        match.Value.Substring(equalSignPos + 2, endBracketPos - 2 - equalSignPos - 1);
                }

            }
        }


        private static bool VerifyContextInstanceIsValid(Fact fact, string contextInstance)
            {
                string pattern = string.Format(@"\[{0}='\w+']", fact.Name);


                var match = Regex.Match(contextInstance, pattern);

                var equalSignPos = match.Value.IndexOf("=", StringComparison.Ordinal);
                var endBracketPos = match.Value.IndexOf("]", StringComparison.Ordinal);
                string actualResult = string.Empty;

                if (equalSignPos > 0 && endBracketPos > equalSignPos)
                {
                    actualResult = match.Value.Substring(equalSignPos + 2, endBracketPos - 2 - equalSignPos - 1);
                    if (!string.IsNullOrWhiteSpace(actualResult))
                        return (fact.Name.Equals(actualResult));
                }

                return false;
            }
        }

    }


    public class FactFactory
        {
            public static bool Create(int sequenceNumber, int parentNumber, string name, string contextInstance,
                out Fact newFact)
            {
                newFact = new Fact {Name = name, ParentNumber = parentNumber, SequenceNumber = sequenceNumber};
                BreakUpContext(newFact, contextInstance);
                return true;

            }

            private static void BreakUpContext(Fact fact, string contextInstance)
            {

            }
        }
    
