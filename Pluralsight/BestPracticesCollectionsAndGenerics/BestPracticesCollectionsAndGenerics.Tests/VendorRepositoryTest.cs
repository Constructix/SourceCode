// <copyright file="VendorRepositoryTest.cs">Copyright ©  2016</copyright>
using System;
using System.Collections.Generic;
using BestPracticesCollectionsAndGenerics;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;

namespace BestPracticesCollectionsAndGenerics.Tests
{
    /// <summary>This class contains parameterized unit tests for VendorRepository</summary>
    [PexClass(typeof(VendorRepository))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class VendorRepositoryTest
    {
        /// <summary>Test stub for RetrieveWithKeys()</summary>
        [PexMethod]
        public Dictionary<string, Vendor> RetrieveWithKeysTest([PexAssumeUnderTest]VendorRepository target)
        {
            Dictionary<string, Vendor> result = target.RetrieveWithKeys();
            return result;
            // TODO: add assertions to method VendorRepositoryTest.RetrieveWithKeysTest(VendorRepository)
        }
    }
}
