using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnXUnitTesting {
    public class CalculatorTest {
        /// <summary>
        /// sut mean, system under test
        /// </summary>
        private readonly Calculator _sut;

        public CalculatorTest() {
            _sut = new Calculator();
        }

        [Fact]
        public void AddTwoNumbersSholudEqualTheirEuqual() {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }

        [Theory]
        [InlineData(27, 20, 7)]
        [InlineData(0, 21, -21)]
        [InlineData(99, 90, 9)]

        public void AddTwoNumbersSholudEqualTheirEuqualTheory(decimal expected,
            decimal firstToAdd,
            decimal secondToAdd) {
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersSholudEqualTheirEuqualTheory(
            decimal expected,
            params decimal[] valuesToAdd) {

            foreach (decimal value in valuesToAdd) {
                _sut.Add(value);
            }

            Assert.Equal(expected, _sut.Value);
        }

        public static IEnumerable<object[]> TestData() {
            yield return new object[] { 17, new decimal[] { 4, 2, 4, 4, 3 } };
            yield return new object[] { 27, new decimal[] { 5, 22 } };
            yield return new object[] { 99, new decimal[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 } };
        }

        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivisionManyNumbersSholudEqualTheirEuqualTheory(
            decimal expected,
            params decimal[] valuesToAdd) {

            foreach (decimal value in valuesToAdd) {
                _sut.Divide(value);
            }

            Assert.Equal(expected, _sut.Value);
        }
    }

    public class DivisionTestData : IEnumerable<object[]> {
        public IEnumerator<object[]> GetEnumerator() {
            yield return new object[] { 5, new decimal[] { 15, 3 } };
            yield return new object[] { 0, new decimal[] { 0, 1 } };
            yield return new object[] { 1, new decimal[] { 10, 10 } };
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
