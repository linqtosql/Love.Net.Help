using System.IO;
using System.Collections.Generic;
using Xunit;

namespace Love.Net.Help.UnitTest {
    public interface IPagedList<T> {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        IList<T> Items { get; }
    }

    public interface NestedGeneric<TOut, TInner> {
        int TotalCount { get; }
        int TotalPages { get; }
        IList<TOut> Items { get; }
        IPagedList<TInner> PagedList { get; set; }
    }

    public class User {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class TypeJsonExtensionsTest {
        [Fact]
        public void GenericType_Scaffold_Test() {
            var type = typeof(IPagedList<User>);
            var json = type.Scaffold();

            var expected = File.ReadAllText(".\\Scaffold.json");

            Assert.Equal(expected, json.ToString());
        }

        [Fact]
        public void GenericType_Schema_Test() {
            var type = typeof(IPagedList<User>);
            var json = type.Schema();

            var expected = File.ReadAllText(".\\Schema.json");

            Assert.Equal(expected, json.ToString());
        }

        [Fact]
        public void Nested_GenericType_Scaffold_Test() {
            var type = typeof(NestedGeneric<User, User>);
            var json = type.Scaffold();

            var expected = File.ReadAllText(".\\NestedScaffold.json");

            Assert.Equal(expected, json.ToString());
        }

        [Fact]
        public void Nested_GenericType_Schema_Test() {
            var type = typeof(NestedGeneric<User, User>);
            var json = type.Schema();

            var expected = File.ReadAllText(".\\NestedSchema.json");

            Assert.Equal(expected, json.ToString());
        }
    }
}
