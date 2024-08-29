
namespace RealState.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1, 2)]
        [TestCase(6, 5, 12)]
        public void Add__should_return_sum(int a, int b, int expectedResult)
        {
            var result = Add(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(-1, 2, 1)]
        public void Add__should_throw_exception_when_input_is_negative(int a, int b, int expectedResult)
        {

            var ex = Assert.Throws<ArgumentOutOfRangeException>( ()=> Add(a,b));

            Assert.That(ex.Message == "Number is negative");
        }

        private int Add(int a, int b)
        {
            if (a < 0 || b<0)
            {
                throw new ArgumentOutOfRangeException("Number is negative");
            }

            return a + b;
        }
    }
}