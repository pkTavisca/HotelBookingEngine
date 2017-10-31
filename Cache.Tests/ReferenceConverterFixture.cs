using HotelBookingServer.Implementations;
using HotelBookingServer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cache.Tests
{
    class Person
    {
        public string Name { get; set; }
    }

    class Student
    {
        public string Name { get; set; }
    }

    [TestClass]
    public class ReferenceConverterFixture
    {
        [TestMethod]
        public void Check_If_Object_Type_Converter_Is_Working_Or_Not()
        {
            Person person = new Person() { Name = "abc" };
            Student converted = ReferenceConverter.Convert<Person, Student>(person);
            Assert.AreEqual("abc", converted.Name);
        }
    }
}
