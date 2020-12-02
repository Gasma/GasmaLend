using AutoFixture;
using gasmaTools.Domain.Base;
using System.Collections.Generic;

namespace gasmaTools.Test.Shared
{
    public static class FixtureCreateObject
    {
        public static T EntityGenerator<T>() where T : Entity
        {
            Fixture fixture = new Fixture();
            return fixture.Create<T>();
        }

        public static IEnumerable<T> EntityListGenerator<T>()
            where T : Entity
        {
            Fixture fixture = new Fixture();
            return fixture.CreateMany<T>();
        }

        public static T ViewModelGenerator<T>()
           where T : class
        {
            Fixture fixture = new Fixture();
            return fixture.Create<T>();
        }
    }
}