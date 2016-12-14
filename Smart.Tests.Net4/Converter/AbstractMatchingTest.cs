namespace Smart.Converter
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Converter.Converters;

    public abstract class AbstractMatchingTest
    {
        protected IList<MatchingConverterFactoryWrapper> Factories { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Factories = DefaultObjectFactories.Create()
                .Select(x => new MatchingConverterFactoryWrapper(x))
                .ToList();
            ObjectConverter.Default.SetFactories(Factories.Cast<IConverterFactory>().ToList());
        }

        protected IConverterFactory FindMatchngFactory()
        {
            return Factories.FirstOrDefault(x => x.Match)?.Factory;
        }
    }
}
