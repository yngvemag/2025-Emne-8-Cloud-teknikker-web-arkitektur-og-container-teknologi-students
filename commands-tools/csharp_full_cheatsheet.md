# C# Cheatsheet – A Complete Guide for Beginners

**Author:** Rinki
**[Link to article](https://www.c-sharpcorner.com/article/c-sharp-cheatsheet-a-complete-guide-for-beginners/)**

---

## Introduction
C# is a powerful and modern programming language developed by Microsoft. It is widely used for building web, desktop, and mobile applications. This cheatsheet covers all the important concepts and syntax in short, easy-to-understand form.

Each topic below contains:
- **Definition** (what it is)
- **Code Example** (minimal)
- **Key Point** (one must-know fact)

---

## 1. Hello World
**Definition:** Basic starting point for any C# console application.

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```
**Key Point:** `Main()` is the entry method where execution begins.

---

## 2. Variables and Data Types
**Definition:** Variables hold data. Each has a type like `int`, `string`, etc.

```csharp
int age       = 25;
string name   = "John";
bool isAdmin  = true;
```
**Key Point:** C# is statically typed; types are fixed.

---

## 3. Constants
**Definition:** A value that cannot change after it's assigned.

```csharp
const double Pi = 3.14;
```
**Key Point:** Must be initialized when declared.

---

## 4. if-else (Conditional Statements)
**Definition:** Used to run code based on conditions.

```csharp
if (age >= 18)
    Console.WriteLine("Adult");
else
    Console.WriteLine("Minor");
```
**Key Point:** Runs only one branch based on a condition.

---

## 5. switch
**Definition:** Multi-branch condition check using a single variable.

```csharp
switch (day)
{
    case 1:
        Console.WriteLine("Mon");
        break;
    default:
        Console.WriteLine("Other day");
        break;
}
```
**Key Point:** Use it when checking a variable against many fixed values.

---
<div style="page-break-after: always;"></div>

## 6. for loop
**Definition:** A Loop that repeats a block of code a set number of times.

```csharp
for (int i = 0; i < 3; i++)
    Console.WriteLine(i);
```
**Key Point:** Use when the number of iterations is known.

---

## 7. while loop
**Definition:** A Loop that runs while a condition is true.

```csharp
int i = 0;
while (i < 3)
{
    Console.WriteLine(i);
    i++;
}
```
**Key Point:** Can run 0 or more times.

---

## 8. foreach loop
**Definition:** Loops through each item in a collection or array.

```csharp
int[] nums = { 1, 2, 3 };
foreach (int n in nums)
    Console.WriteLine(n);
```
**Key Point:** Cleaner than when reading values.

---

## 9. Arrays
**Definition:** Fixed-size collection of the same data type.

```csharp
string[] fruits = { "Apple", "Banana" };
```
**Key Point:** The Index starts from 0.

---

## 10. Strings
**Definition:** A sequence of characters.

```csharp
string s = "Hello";
Console.WriteLine(s.Length);
```
**Key Point:** Strings are immutable; any changes create new strings.

---

## 11. Methods
**Definition:** A Group of statements to perform a task.

```csharp
void Greet(string name)
{
    Console.WriteLine("Hi " + name);
}
```
**Key Point:** Improves code reusability.

---

## 12. Classes and Objects
**Definition:** A Class is a blueprint. Object is an instance.

```csharp
class Person
{
    public string Name;
    public void Speak() => Console.WriteLine("Speaking");
}
```
**Key Point:** C# is object-oriented, and almost everything is a class.

---

## 13. Constructors
**Definition:** A Special method that runs when an object is created.

```csharp
public Person(string name) { this.Name = name; }
```
**Key Point:** The Constructor has the same name as the class.

---

## 14. Access Modifiers
**Definition:** Controls visibility of class members.

| Modifier   | Scope                |
|------------|----------------------|
| public     | Anywhere             |
| private    | Inside the same class|
| protected  | Class + Derived class|
| internal   | Same assembly only   |

**Key Point:** The Default modifier is private.

---

## 15. Inheritance
**Definition:** One class inherits properties/methods of another.

```csharp
class Dog : Animal { }
```
**Key Point:** Use to inherit from the base class.

---

## 16. Interfaces
**Definition:** A contract that defines what methods a class must implement.

```csharp
interface IVehicle { void Start(); }
```
**Key Point:** Cannot have implementation-only method signatures.

---

## 17. Abstract Classes
**Definition:** Cannot be instantiated and may contain abstract methods.

```csharp
abstract class Shape
{
    public abstract void Draw();
}
```
**Key Point:** Can have both implemented and abstract methods.

---

## 18. Exception Handling
**Definition:** Used to catch and handle runtime errors.

```csharp
try { int x = 10 / 0; }
catch (Exception e) { Console.WriteLine("Error"); }
```
**Key Point:** finally block always runs, whether an error happens or not.

---

## 19. Properties
**Definition:** Provide a safe way to access fields in a class.

```csharp
public string Name { get; set; }
```
**Key Point:** Properties replace get/set methods.

---

## 20. Enums
**Definition:** A Set of named constant values.

```csharp
enum Status { Active, Inactive }
```
**Key Point:** Useful for fixed choices (like days, states).

---

## 21. Structs
**Definition:** Value types similar to classes, but stored on the stack.

```csharp
struct Point { public int X, Y; }
```
**Key Point:** Do not support inheritance.

---

## 22. Nullable Types
**Definition:** Allow value types to store null.

```csharp
int? age = null;
```
**Key Point:** Useful when a value may not exist.

---

## 23. LINQ
**Definition:** Query syntax to filter, project, and group data in collections.

```csharp
var evens = nums.Where(n => n % 2 == 0);
```
**Key Point:** Works on arrays, lists, and databases.

---

## 24. async / await
**Definition:** Handles asynchronous operations without blocking the thread.

```csharp
async Task GetData()
{
    await Task.Delay(1000);
}
```
**Key Point:** Use await inside an async method only.

---

## 25. File Handling
**Definition:** Reading from and writing to files.

```csharp
File.WriteAllText("demo.txt", "Hello");
string text = File.ReadAllText("demo.txt");
```
**Key Point:** Use the System.IO namespace.

---

## 26. Namespaces
**Definition:** Group related classes together.

```csharp
namespace MyApp { class Program { } }
```
**Key Point:** Prevents name clashes.

---
<div style="page-break-after: always;"></div>

## 27. Static Keyword
**Definition:** Belongs to the class itself, not an instance.

```csharp
static void Log() => Console.WriteLine("Log");
```
**Key Point:** No need to create an object to use static members.

---

## 28. Collections
**Definition:** Store groups of related items.

```csharp
List<int> nums = new List<int> { 1, 2 };
Dictionary<string, int> map = new Dictionary<string, int>();
```
**Key Point:** Use List<T> for ordered data, Dictionary<K, V> for key-value.

---

## 29. Generics
**Definition:** Create reusable code that works with any type.

```csharp
class Box<T> { public T Value; }
```
**Key Point:** Avoids type casting, increases code safety.

---
<div style="page-break-after: always;"></div>

## 30. Delegates
**Definition:** Type-safe function pointer.

```csharp
delegate void Notify(string msg);
Notify n = Console.WriteLine;
```
**Key Point:** Used in events, callbacks, and LINQ.

### Built-in Delegates: Func<>, Action<>, Predicate<>

**Func<>:** Represents a delegate that returns a value. The last type parameter is the return type, others are input types.

```csharp
Func<int, int, int> add = (a, b) => a + b;
int result = add(2, 3); // result = 5
```

**Action<>:** Represents a delegate that does not return a value (void). All type parameters are input types.

```csharp
Action<string> greet = name => Console.WriteLine($"Hello, {name}");
greet("Alice"); // Output: Hello, Alice
```

**Predicate<>:** Represents a delegate that takes one input and returns a bool.

```csharp
Predicate<int> isEven = n => n % 2 == 0;
bool check = isEven(4); // check = true
```

**Key Point:** These built-in delegates simplify code and are widely used in LINQ and collections.
**Definition:** A Messaging system to signal actions.

## 31. Events

```csharp
public event Action OnAlarm;
```
**Key Point:** Used with delegates for publish-subscribe behavior.

---
<div style="page-break-after: always;"></div>

## 32. Indexers
**Definition:** Allow objects to be indexed like arrays.

```csharp
public int this[int i] => data[i];
```
**Key Point:** A Custom way to access items in a class.

---

## 33. Extension Methods
**Definition:** Add new methods to existing types without modifying them.

```csharp
public static int WordCount(this string s)
    => s.Split(' ').Length;
```
**Key Point:** Method must be in a static class.

---

## Conclusion
This C# cheatsheet gives you a compact but complete summary of all key concepts, from basic syntax to advanced topics like LINQ, delegates, and async/await. Each section includes a clear definition, a short code example, and one important point to remember.

Use this as your go-to sheet whenever you:
- Forget syntax
- Need to explain a topic to someone
- Want to revise fundamentals quickly

C# is a powerful, structured language. The more clearly you understand these building blocks, the easier it is to write clean, safe, and maintainable code.
