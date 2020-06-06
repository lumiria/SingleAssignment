# SingleAssignment
Provides an object that can be assigned only once.

## Install
~~~
PM > Install-Package SingleAssignment
~~~

## Usage
There are two initialization methods.
```csharp
// Initializes with a specified value.
var greeting = Once.Create("Hello");

// Initializes with empty.
var no = Once.Create<int>();
```

Threre are two ways to assign value.
```csharp
// Value property
no.Value = 10;

// or

// TrySet method
no.TrySet(10);
```

The value cannot be overwirtten.
```csharp
if (!once.TrySet(newValue))
{
    Console.WriteLine($"Cannot overwrite : {(T)once}");
}

try
{
    once.Value = newValue;
}
catch (InvalidOperationException)
{
    Console.WriteLine("InvalidOperationException occurred.");
}
```

To get the value, use the Value property or a cast.
```csharp
var once = Once.Create("Hello");

// Value property
Console.WriteLine($"{once.Value}");

// Explicit cast.
Console.WriteLine($"{(string)once}");
// Implicit cast.
string greeting = once;
Console.WriteLine($"{greeting}");
```

## License
This library is under the MIT License.
