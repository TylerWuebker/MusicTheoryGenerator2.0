using FluentAssertions;
using MusicTheoryGenerator2._0;

namespace MusicTheoryGenerator2._0Tests
{
    public class GeneratorTests
    {
        private MusicalKeyService sut;
        public GeneratorTests()
        {
            sut = new MusicalKeyService();
        }

        [Fact]
        public void GivenMenuOption_WhenCallingGenerateNoteSequenceMethod_ThenReturnAnyString()
        {
            var actual = sut.GenerateNoteSequence();

            actual.ToString().Should().NotBeNull();
            actual.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenMenuOption_WhenCallingGenerateChordProgressionMethod_ThenReturnAnyString()
        {
            var actual = sut.GenerateChordProgression();

            actual.ToString().Should().NotBeNull();
            actual.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenCallToJsonReadAndSearch_WhenValidJsonSearchCriteriaProvided_ThenReturnCorrectKey()
        {
            var actual = sut.JsonReadAndSearch("GM");

            actual.N4.Should().NotBeNull();
            actual.N4.Should().Be("C");
        }
    }
}