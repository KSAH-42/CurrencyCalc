# CurrencyCalc

This application represents a currency converter written in C#/WPF.
There is some similitudes with an the Black–Scholes calculator project, except that this projects used:

* Rest API client to fetch data from a REST service
* The configuration layer implementation is different
* TPL usage for asynchronous calls

Notes:

Alls views models classes are store in a namepsace called Calculator.Windows.Controllers


# Project structure

So here, we have the following projects :

| Project name                 | Assembly type               |
| ---------------------------- | --------------------------- |
| Calculator                   | .exe                        |
| Calculator.Module            | .dll                        |
| Calculator.Module.Tests      | .dll                        |


The majority of the code are located in the following assembly :

> Calculator.Module.dll 

# Additional informations

In this section, you will find the tools and the technologies used during the development for this application :

* Visual Studio Express edition (2017)
* C#
* WPF
* MVVM
* MSTest
* Design patterns
