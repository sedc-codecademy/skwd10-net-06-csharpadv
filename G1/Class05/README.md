# Anonymous functions 🍣

## Anonymous functions 🔹

### Lambda expression

Lambda expression is a short and easy way of writing anonymous functions. These lambda expressions are available in C#, but in other languages as well. They are usually used in higher-order methods and are very widely used. The idea of a lambda expression is to have a shorthand way of writing a method, most of the time in one line. Lambda methods can be written in multiple lines as well, but the code needs to be wrapped in { } brackets.

```csharp
List<string> names = new List<string>()
{
    "Bob", "Jill", "Wayne", "Greg", "John", "Anne"
};
List<string> empty = new List<string>();
```

```csharp
// Lambda expression in a Find method
string foundBob = names.Find(x => x == "Bob");
```

### Func with lambda expression

There are entities in C# that basically encapsulate and point to a signature of a method. These definitions for methods are called delegates and Func is one such definition. We can add an anonymous method in this definition easily and use it. The main rule of Func is that the method MUST have a return value and that the type of the return value as well as the parameters that we need, must be decided beforehand.

#### No parameters Func

```csharp
Func<bool> isNamesEmpty = () => names.Count == 0;
Console.WriteLine($"IsNamesEmpty: {isNamesEmpty()}");
```

#### Two parameters Func

```csharp
Func<int, int, int> sum = (x, y) => x + y;
Console.WriteLine($"sum: {sum(2, 3)}");
```

### Action with lambda expression

Action method definition is very similar to Func. They are used and written very similarly. The only difference is the return type. Unlike Func which always returns a value, Action never returns anything, making Action void. So for all methods that we need to be void, we use Action. For all of the methods that we need to return something, we use Func.

#### No parameters Action

```csharp
Action hello = () => Console.WriteLine($"Hello there!");
hello();
```

#### Two parameters Action

```csharp
Action<string, ConsoleColor> printColor = (x, y) =>
{
    Console.ForegroundColor = y;
    Console.WriteLine(x);
    Console.ResetColor();
};
printColor("Error!", ConsoleColor.Red);
```

## Using Func and Action in LINQ

We already covered the basics of LINQ. Basically, there are 2 ways of writing LINQ methods. By using SQL-like syntax and with Lambda expression. But there is another way that we can use LINQ. We can save method templates in Func and then pass them to LINQ chains easily instead of writing the same lambda expression multiple times.

### Standard LINQ query

```csharp
string foundBob = names.FirstOrDefault(x => x == "Bob");
Console.WriteLine(foundBob);
```

### Func LINQ query

```csharp
Func<string, bool> IsBob = x => x == "Bob";
string foundJill = names.FirstOrDefault(IsBob);
Console.WriteLine(foundJill);
```
