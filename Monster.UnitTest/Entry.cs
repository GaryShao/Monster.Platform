using Xunit;

namespace Monster.UnitTest
{
    public class Entry
    {
        [Fact]
        public void Test()
        {
            Point p = new Point(11, 12);
            Point p2 = p;
            p.X = 13;
            Assert.Equal(p, new Point(13, 12));
            Assert.Equal(p2, new Point(11, 12));
        }
    }
}
