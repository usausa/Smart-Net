namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    /// <summary>
    /// ComponentContainerTest の概要の説明
    /// </summary>
    public class ComponentContainerTest
    {
        [Fact]
        public void ComponentIsResolved()
        {
            var config = new ComponentConfig();
            config.Add<SimpleObject>();

            using (var container = config.ToContainer())
            {
                var obj = container.Get<SimpleObject>();

                Assert.NotNull(obj);
            }
        }

        [Fact]
        public void ComponentIsMultipleResolved()
        {
            var config = new ComponentConfig();
            config.Add<ICalcService, AddCalcService>();
            config.Add<ICalcService, SubCalcService>();

            using (var container = config.ToContainer())
            {
                var services = container.GetAll<ICalcService>();

                Assert.Equal(services.Count(), 2);
            }
        }

        [Fact]
        public void ComponentIsMultipleResolvedByGetService()
        {
            var config = new ComponentConfig();
            config.Add<ICalcService, AddCalcService>();
            config.Add<ICalcService, SubCalcService>();

            using (var container = config.ToContainer())
            {
                var services = (IEnumerable<ICalcService>)container.GetService(typeof(IEnumerable<ICalcService>));

                Assert.Equal(services.Count(), 2);
            }
        }

        [Fact]
        public void ComponentIsNotResolved()
        {
            var config = new ComponentConfig();

            using (var container = config.ToContainer())
            {
                var obj = container.TryGet<SimpleObject>();

                Assert.Null(obj);
            }
        }

        [Fact]
        public void ComponentIsNotResolvedByGetService()
        {
            var config = new ComponentConfig();

            using (var container = config.ToContainer())
            {
                var obj = container.GetService(typeof(SimpleObject));

                Assert.Null(obj);
            }
        }

        [Fact]
        public void ComponentIsResolvedSameObject()
        {
            var config = new ComponentConfig();
            config.Add<SimpleObject>();

            using (var container = config.ToContainer())
            {
                var obj1 = container.Get<SimpleObject>();
                var obj2 = container.GetService(typeof(SimpleObject));

                Assert.Same(obj1, obj2);
            }
        }

        [Fact]
        public void ComponentIsDisposed()
        {
            var config = new ComponentConfig();
            config.Add<DisposableObject>();

            DisposableObject obj;
            using (var container = config.ToContainer())
            {
                obj = container.Get<DisposableObject>();
            }

            Assert.Equal(obj.Disposed, 1);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "Ignore")]
        [Fact]
        public void ComponentAddedConstIsDisposed()
        {
            var config = new ComponentConfig();
            config.Add(new DisposableObject());

            DisposableObject obj;
            using (var container = config.ToContainer())
            {
                obj = container.Get<DisposableObject>();
            }

            Assert.Equal(obj.Disposed, 1);
        }

        [Fact]
        public void ComponentIsResolvedWithMultipleArgument()
        {
            var config = new ComponentConfig();
            config.Add<ArrayParameterObject>();
            config.Add<ICalcService, AddCalcService>();
            config.Add<ICalcService, SubCalcService>();

            using (var container = config.ToContainer())
            {
                var obj = container.Get<ArrayParameterObject>();

                Assert.Equal(obj.CalcServices.Length, 2);
            }
        }

        [Fact]
        public void ComponentIsResolvedByDefaultConstructor()
        {
            var config = new ComponentConfig();
            config.Add<MultiConstructorObject>();

            using (var container = config.ToContainer())
            {
                var obj = container.Get<MultiConstructorObject>();

                Assert.Equal(obj.Arguments, 0);
                Assert.Null(obj.CalcService);
            }
        }

        [Fact]
        public void ComponentIsResolvedByConstructorWithArguments()
        {
            var config = new ComponentConfig();
            config.Add<MultiConstructorObject>();
            config.Add<ICalcService, AddCalcService>();

            using (var container = config.ToContainer())
            {
                var obj = container.Get<MultiConstructorObject>();

                Assert.Equal(obj.Arguments, 1);
                Assert.NotNull(obj.CalcService);
            }
        }

        protected class SimpleObject
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Ignore")]
        protected interface ICalcService
        {
        }

        protected class AddCalcService : ICalcService
        {
        }

        protected class SubCalcService : ICalcService
        {
        }

        protected sealed class DisposableObject : IDisposable
        {
            public int Disposed { get; set; }

            public void Dispose()
            {
                Disposed++;
            }
        }

        protected class ArrayParameterObject
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Ignore")]
            public ICalcService[] CalcServices { get; set; }

            public ArrayParameterObject(ICalcService[] calcServices)
            {
                CalcServices = calcServices;
            }
        }

        protected class MultiConstructorObject
        {
            public int Arguments { get; set; }

            public ICalcService CalcService { get; set; }

            public MultiConstructorObject()
            {
                Arguments = 0;
            }

            public MultiConstructorObject(ICalcService calcService)
            {
                Arguments = 1;
                CalcService = calcService;
            }
        }
    }
}
