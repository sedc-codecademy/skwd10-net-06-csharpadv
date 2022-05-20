# Coding Conventions

Coding conventions are a set of guidelines for a specific programming language that recommend programming style, practices, and methods for each aspect of a program written in that language. These conventions usually cover file organization, indentation, comments, declarations, statements, white space, naming conventions, programming practices, programming principles, programming rules of thumb, architectural best practices, etc. These are guidelines for software structural quality. Software programmers are highly recommended to follow these guidelines to help improve the readability of their source code and make software maintenance easier. Conventions may be formalized in a documented set of rules that an entire team or company follows, or may be as informal as the habitual coding practices of an individual.

## Good practices while programming in the C# language

In order to increase efficiency and increase productivity in every team there are accepted programming practices. This programming practices help us easier to understand and modify the code that other developers write and to help us write clearer code. When it comes to good practices there are a lot that are used but the most basic ones are the following:
* Indent your code - if you use indentations it is much easier to follow the current  scope that you are in and it is much easier to keep track of the execution flow
* Add Comments - when you write code that is not easy to follow, so in future some other developer need to rework your code or to add additional logic to it
* Don't use one file for more classes
* Method max size should not exceed more than 50 lines, if it exceed then re-factor it and separate it in 2 methods
* Class should not contain more than 700 characters, if it is more than 700 characters than consider using of partial classes
* Add a whitespace around operators, like +, -, ==, etc.

## Naming
There are three type of naming conventions generally used while doing C# programming,
* Pascal Convention – First character of all word is in upper case and other characters are in lower case.
Example: HelloWorld
Used in: Classes, Methods, Interfaces, Fields, Properties, Events, Local Functions

* Camel Case Convention – The first character of all words, except the first word, is upper case and other characters are lower case.
Example: helloWorld
Used in: variables, private and internal fields starting with _, method parameters, 

* Hungarian Case Convention – The data type as prefix is used to define the variable by developers long ago. This convention is not used anywhere now a day’s except local variable declaration.
Example:string m_sName; string strName; int iAge;

## Methods
As we already have seen we need to write methods for separate the code that is related to specific logic. So we write service classes and in it we add methods for each function that is in that specific service. When we write methods we should have the following in mind:
* Keep methods as short as possible short - if the method exceed 50 lines rework it and split it in 2 methods
* Avoid too many parameters - if there is a need for many parameters consider an object that will contain all those parameters and sent the object as method parameter

## Loops
* Use foreach whenever possible
* Don't request fixed values inside a loop, declare a variable outside with the value
* Use break if searching for a value to close the loop when data needed is found
* Counters by convention have one letter name usually: i, j, k or i, ii, iii, etc.

##If/Else statements
* When writing an if statement that results in bool value in any way, don't use comparison with true or false
* Invert If statements to see if you can make else redundant
* Don't use one-liner ifs for more than one line of code
* For longer if/else statements try using a switch instead

#Programming Principles
* DRY ( Don't Repeat Yourself ) The DRY principle is a rule that we need to avoid and try not to repeat implementation in our code. Every piece of logic must have a single and unique representation in our code.
* KISS ( Keep It Simple Stupid ) This principle states that code works best when kept to its simplest form. Always try and find the simplest solution that could work and meet the requirements. Unnecessary complexity and features should be avoided. This makes our code more readable, understandable, and maintainable.
* YAGNI ( You Aren't Gonna Need It ) YAGNI is a principle that is very closely connected to refactoring. It sets a rule that when coding, we need to add code when we need it, not if we think we are going to need it. Together with other principles and practices such as continuous refactoring this principle can help us build and improve our code over time.