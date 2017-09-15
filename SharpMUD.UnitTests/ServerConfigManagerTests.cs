using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using SharpMUD.Interfaces;

namespace SharpMUD.UnitTests
{
    [TestFixture]
    public class ServerConfigManagerTests
    {
        [Test]
        public void GetSettingByName_LookupStringThatExists_ReturnsString()
        {
            using (var fake = new AutoFake())
            {
                var configmanager = fake.Resolve<IServerConfigManager>();

                int testvar = configmanager.GetSettingByName<int>("intlookup");

            }

        }

        [Test]
        public void GetSettingByName_LookupIntFromConfig_ReturnsInt()
        {
            
        }

        [Test]
        public void GetSettingByName_LookupListFromConfig_ReturnsList()
        {
            
        }

        [Test]
        public void GetSettingByName_QueryStringNotFound_ReturnsNull()
        {

        }
    }
}