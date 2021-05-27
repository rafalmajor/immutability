using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace builder
{
    public class BuilderUnitTest
    {
        [Fact]
        public void Test1()
        {
            var jon = new Person.Builder
            {
                Name = "Jon",
                Phones = { new PhoneNumber.Builder{ PhoneType = PhoneType.Mobile, Number = "123456"}.Build() }
            }.Build();
        }
    }

    public class Person
    {
        private Person(Person.Builder builder)
        {
            this.Name = builder.Name;
            this.Phones = builder.Phones.ToImmutableList();
        }
        public string Name { get; }
        public IImmutableList<PhoneNumber> Phones { get; } 

        public class Builder
        {
            public string Name { get; set;}
            public List<PhoneNumber> Phones { get; } = new List<PhoneNumber>(); 

            public Person Build()
            {
                return new Person(this);
            }
        }
    }

    public class PhoneNumber
    {
        public PhoneNumber(Builder builder)
        {
            this.PhoneType = builder.PhoneType;
            this.Number = builder.Number;
        }

        public PhoneType PhoneType { get; }

        public string Number { get; }

        public class Builder
        {
            public PhoneType PhoneType { get; set; }
            public string Number { get; set; }

            public PhoneNumber Build()
            {
                return new PhoneNumber(this);
            }
        }

    }

    public enum PhoneType
    {
        Mobile,

        Home,
    }
}
