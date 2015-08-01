using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Permut.Tests
{
    [TestClass]
    public class UnitTests
    {
        private IEnumerable<int> CreateReversedArray(int n)
        {
            for (int i = n; i > 0; i--)
            {
                yield return i;
            }
        }

        [TestMethod]
        public void FindPermut_Should_WorkForBigN()
        {
            // Arrange
            BigInteger i = BigInteger.Parse("30414093201713378043612608166064768844377641568960511999999999999");
            int n = 50;
            var expected = CreateReversedArray(n).ToArray();

            // Act
            var result = Program.FindIthPermutation(n, i);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
