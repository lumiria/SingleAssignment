using System.Text.Json;
using SignleAssignment;
using SignleAssignment.Extensions;
using Xunit;

namespace SingleAssignment.Test
{
    public class UnitTest
    {
        [Fact]
        public void NormalTest1()
        {
            var once = Once.Create<int>();

            Assert.False(once.HasValue);

            Assert.True(once.TrySet(10));

            Assert.True(once.HasValue);
            Assert.Equal(10, once);
            Assert.Equal(10, once.Value);

            Assert.False(once.TrySet(20));
            Assert.Equal(10, once);
        }

        [Fact]
        public void NormalTest2()
        {
            var once = Once.Create(10);

            Assert.True(once.HasValue);
            Assert.Equal(10, once);
            Assert.Equal(10, once.Value);

            Assert.False(once.TrySet(20));
            Assert.Equal(10, once);
        }

        [Fact]
        public void RunTest()
        {
            var once = Once.Create<int>();

            once.Run(
                value => Assert.Equal(10, value),
                () => Assert.False(once.HasValue));

            once.TrySet(10);
            once.Run(
                value => Assert.Equal(10, value),
                () => Assert.False(once.HasValue));
        }

        [Fact]
        public void GetOrSetTest()
        {
            var once = Once.Create<int>();

            Assert.Equal(10, once.GetOrSet(() => 10));
            Assert.Equal(10, once.GetOrSet(() => 20));
        }

        [Fact]
        public void GetOrDefaultTest()
        {
            var once = Once.Create<int>();

            Assert.Equal(10, once.GetOrDefault(() => 10));
            Assert.False(once.HasValue);

            once.Value = 20;
            Assert.Equal(20, once.GetOrDefault(() => 10));
            Assert.True(once.HasValue);
        }

        [Fact]
        public void SerializeTest()
        {
            var once = Once.Create(10);

            var json = JsonSerializer.Serialize(once);
            Assert.NotEqual("", json);

            var obj = JsonSerializer.Deserialize<Once<int>>(json);
            Assert.True(obj.HasValue);
            Assert.Equal(10, obj);
        }
    }
}
