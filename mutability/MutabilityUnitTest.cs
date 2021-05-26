using System;
using System.Collections.Generic;
using Xunit;

namespace mutability
{
    public class MutabilityUnitTest
    {
        [Fact]
        public void Test1()
        {
var x = new Immutability(1);

var y = new NewImmutability { Value = 1 };
        }
    }

public sealed class Mutable
{
    public int Value { get; set; }
}

public sealed class ShallowImmutable
{
    public int Value { get; }

    public List<string> Parts { get; }

    public ShallowImmutable(int value, List<string> parts)
    {
        this.Value = value;
        this.Parts = parts;
    }
}

public sealed class ObesrvablyImmutable
{
    private int cachedHash;
    public string Name { get; }
    public ObesrvablyImmutable(string name)
    {
        this.Name = name;
    }
    public override bool Equals(object obj)
    {
        var other = obj as ObesrvablyImmutable;
        if (other == null) return false;
        return other.Name == this.Name;
    }
    public override int GetHashCode()
    {
        if (this.cachedHash == 0)
            this.cachedHash = this.Name.GetHashCode();
        return this.cachedHash;
    }
}

public class Immutability
{
    public Immutability(int value)
    { this.Value = value; }
    public int Value { get; }
}

public class NewImmutability
{
    public int Value { get; init; }
}
}
