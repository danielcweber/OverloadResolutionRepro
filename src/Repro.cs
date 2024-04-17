using System;
using System.Linq.Expressions;

namespace OverloadResolutionRepro
{
    public class Foo
    {
        public void Method<S>(params Expression<Func<Bar, S>>[] projections) => throw new NotImplementedException();
        public void Method<S>(params Expression<Func<Bar, Wrapper<S>>>[] projections) => throw new NotImplementedException();
    }

    public class Bar
    {
        public Wrapper<int> WrappedValue { get; set; } = new Wrapper<int>();
    }

    public struct Wrapper<TValue>
    {
    }

    public class EntryPoint
    {
        static void Main()
        {
            new Foo().Method(x => x.WrappedValue);
        }
    }
}
