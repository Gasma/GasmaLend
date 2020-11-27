using AutoFixture;
using gasmaTools.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace gasmaTools.Test.Shared
{
    public static class FixtureCreateObject
    {
        public static T CriarEntidade<T>() where T : Entity
        {
            Fixture fixture = new Fixture();
            return fixture.Create<T>();
        }

        public static IEnumerable<T> CriarEntidades<T>()
            where T : Entity
        {
            Fixture fixture = new Fixture();
            return fixture.CreateMany<T>();
        }

        public static T CriarViewModel<T>()
           where T : class
        {
            Fixture fixture = new Fixture();
            return fixture.Create<T>();
        }
    }
}