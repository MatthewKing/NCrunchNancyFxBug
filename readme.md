NCrunchNancyFxBug
=================

The purpose of this repository is to demonstrate what I think is a bug in either [NancyFx](http://nancyfx.org/) or [NCrunch](http://www.ncrunch.net/).

Problem description
-------------------

I have a project using NancyFx, as well as some unit tests for that project. All of my tests pass when I use the standard test runner for my unit testing framework (I've tried both xUnit and NUnit). However, when I use NCrunch to automate my testing, any tests that involve the Razor view engine fail in NCrunch (but still pass when run with the standard test runner).

![Test Results](test-results.png?raw=true)

How to replicate the issue
--------------------------

1. Clone this repository.
2. Install NCrunch (and, optionally, an xUnit test runner).
3. Open the solution in Visual Studio.
4. Build the solution (download the NuGet packages if required), and enable NCrunch.
5. Observe that the `Tests.RazorViewEngine` test fails in NCrunch, but passes in the xUnit test runner. `Tests.SuperSimpleViewEngine` will pass in both.

Additional observations
-----------------------

* Swapping out xUnit for another test framework (such as NUnit) will not change the result; `Tests.RazorViewEngine` fails in NCrunch but passes in the test runner. `Tests.SuperSimpleViewEngine` passes in both.
* Removing the post-build event added by `Nancy.Viewengines.Razor` does not change the result. 