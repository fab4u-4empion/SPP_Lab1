using Lab1.Tracer.TraceResults;
using Lab1.Tracer;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Tracer _tracer = new();

        private void Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            Method2();
            _tracer.StopTrace();
        }

        private void Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            _tracer.StopTrace();
        }

        [TestInitialize]
        public void Init()
        {
            Method();
        }

        [TestMethod]
        public void TestThreadTime()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.IsTrue(traceResult.Threads[0].Time > 1000 && traceResult.Threads[0].Time < 1100);
        }

        [TestMethod]
        public void TestThreadsCount()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual(1, traceResult.Threads.Count);
        }

        [TestMethod]
        public void TestThreadMethodsCount()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual(1, traceResult.Threads[0].Methods.Count);
        }

        [TestMethod]
        public void TestMethodExecutionTime()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.IsTrue(traceResult.Threads[0].Methods[0].ExecutionTime > 1000 && traceResult.Threads[0].Methods[0].ExecutionTime < 1100);
        }

        [TestMethod]
        public void TestMethod2ExecutionTime()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.IsTrue(traceResult.Threads[0].Methods[0].ChildMethods[0].ExecutionTime > 500 && traceResult.Threads[0].Methods[0].ChildMethods[0].ExecutionTime < 600);
        }

        [TestMethod]
        public void TestMethodClassName()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual("UnitTest1", traceResult.Threads[0].Methods[0].ClassName);
        }

        [TestMethod]
        public void TestMethod2ClassName()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual("UnitTest1", traceResult.Threads[0].Methods[0].ChildMethods[0].ClassName);
        }

        [TestMethod]
        public void TestMethodName()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual("Method", traceResult.Threads[0].Methods[0].MethodName);
        }

        [TestMethod]
        public void TestMethod2Name()
        {
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual("Method2", traceResult.Threads[0].Methods[0].ChildMethods[0].MethodName);
        }
    }
}