using Microsoft.VisualStudio.TestTools.UnitTesting;
using CA2._3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2._3.Tests
{
    [TestClass()]
    public class PieceTests
    {
        [TestMethod()]
        public void obTest()
        {
            Piece Move1 = new Piece();
            long ms = TimeSpan.TicksPerMillisecond;

            int mv = Move1.ob();
            Console.WriteLine(DateTime.Now.Millisecond-ms);
            Assert.AreEqual(104744354, mv);
            Assert.Fail();
        }
    }
}