using System;
using Xunit;
using Xunit.Abstractions;

namespace LearnXUnitTesting {
    /// <summary>
    /// for reusing instance using IClassFixture
    /// </summary>
    public class GuidGeneratorTestOne : IClassFixture<GuidGenerator> {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestOne(ITestOutputHelper output, GuidGenerator guidGenerator) {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne() {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"the guid was {guid}");
        }

        [Fact]
        public void GuidTestTwo() {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"the guid was {guid}");
        }
    }


    /// <summary>
    /// for the class using this collection definition name will 
    /// get the same instance (context)
    /// </summary>
    [CollectionDefinition("Guid Generator")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { }

    [Collection("Guid Generator")]
    public class GuidGeneratorTestTwo {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestTwo(ITestOutputHelper output, GuidGenerator guidGenerator) {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne() {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"the guid was {guid}");
        }

        [Fact]
        public void GuidTestTwo() {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"the guid was {guid}");
        }
    }

    [Collection("Guid Generator")]
    public class GuidGeneratorTestThree {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestThree(ITestOutputHelper output, GuidGenerator guidGenerator) {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne() {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"the guid was {guid}");
        }

        [Fact]
        public void GuidTestTwo() {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"the guid was {guid}");
        }
    }

}
