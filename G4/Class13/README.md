# C# Conventions, Practices, and Principles

## Good Practices 🚀

In C# as in any other language, there are some Good Practices or Invisible Rules that we need to follow for our code to be better, more efficient, and for the most part, better understood. Keeping up with good practices and conventions can result in scalable, readable, and easy to maintain code. Sometimes we find ourselves writing code that doesn't follow some of these practices, but we must always strive to make our code as good as we possibly can. Here are some good practices that can be used to write better C# code:

### Naming ☄

* **Variables** and **Parameters** are always written in **camelCase**
* **Classes, Methods, Properties** are written in **PascalCase**
* **Private fields** are always written with **underscore camelCase** ( ex: \_privateField )

### Properties and Fields ☄

* Use properties for values in any Class
* Avoid using fields unless they are private
* Use **private fields** to hide values and instances that are exclusive to a class and need to be hidden from the outside world
* Write **boolean names** so that they can be answered with **yes or no** ( IsDeleted, CanLogin, HasCheckedIn )
* Always add Exception suffix when creating custom Exception classes
* Always add the I prefix when writing Interfaces

### Methods ☄

* Write Service Classes and group/organize methods
* Keep methods short
* Avoid too many parameters
* If a method has too many lines of code or it has too many parameters, think about splitting it into multiple smaller methods if possible

### Loops ☄

* Use foreach whenever possible
* Don't request fixed values inside a loop, declare a variable outside with the value
* Use break if searching for a value to close the loop when data needed is found
* Counters by convention have one letter name usually: i, j, k or i, ii, iii, etc.

### If/Else statements ☄

* When writing an if statement that results in bool value in any way, don't use comparison with true or false
* Invert If statements to see if you can make else redundant
* Don't use one-liner ifs for more than one line of code
* For longer if/else statements try using a switch instead

## Resources
### General
* [CodeProject - C# Best Practices](https://www.codeproject.com/Articles/118853/Some-Best-Practices-for-C-Application-Developmen)
* [Microsoft Guide To Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
### Naming
* Most Common Programming Case Types - [chaseadams.io](https://chaseadams.io/posts/most-common-programming-case-types/)
* Case Styles: Camel, Pascal, Snake, and Kebab Case - [betterprogramming.pub](https://betterprogramming.pub/string-case-styles-camel-pascal-snake-and-kebab-case-981407998841)