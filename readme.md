NCrunchNancyFxBug
=================

The original purpose of this repository was to demonstrate what I thought was a bug in either [NancyFx](http://nancyfx.org/) or [NCrunch](http://www.ncrunch.net/). I was subsequently given a solution by Remco (NCrunch's developer) that resolved the issue (see forum post [here](http://forum.ncrunch.net/yaf_postst1058_Unit-test--failing--in-NCrunch--but-passing-in-all-other-test-runners.aspx)). I'm leaving this repository live, as I posted a link in a number of places, and link rot is awful. Hopefully it'll serve as a reference to anybody else who encounters a similar issue.

UPDATE / SOLUTION
-----------------

Remco proposed the following solution:

> Thanks for reporting this issue and for sharing the sample code to reproduce. It's always much easier to analyse an issue like this when there is sample code available.

>This issue is being caused by an [assembly co-location assumption](http://www.ncrunch.net/documentation/considerations-and-constraints_assembly-colocation-assumptions) inside the Nancy framework source code. This code is expecting all assemblies to exist in the same directory when the test is run - an assumption that doesn't hold true for NCrunch unless the [Copy referenced assemblies to workspace](http://www.ncrunch.net/documentation/reference_project-configuration_copy-referenced-assemblies-to-workspace) setting is set to TRUE.

> Changing this configuration setting should solve the problem. Depending upon your solution structure, you may also need to change the same setting on other projects depended on by your test project.

This solved the problem for me. Very impressed with the support provided by NCrunch.

Original problem description
-------------------

I have a project using NancyFx, as well as some unit tests for that project. All of my tests pass when I use the standard test runner for my unit testing framework (I've tried both xUnit and NUnit). However, when I use NCrunch to automate my testing, any tests that involve the Razor view engine fail in NCrunch (but still pass when run with the standard test runner).

![Test Results](test-results.png?raw=true)

### How to replicate the issue

1. Clone this repository.
2. Install NCrunch (and, optionally, an xUnit test runner).
3. Open the solution in Visual Studio.
4. Build the solution (download the NuGet packages if required), and enable NCrunch.
5. Observe that the `Tests.RazorViewEngine` test fails in NCrunch, but passes in the xUnit test runner. `Tests.SuperSimpleViewEngine` will pass in both.

### Additional observations

* Swapping out xUnit for another test framework (such as NUnit) will not change the result; `Tests.RazorViewEngine` fails in NCrunch but passes in the test runner. `Tests.SuperSimpleViewEngine` passes in both.
* Removing the post-build event added by `Nancy.Viewengines.Razor` does not change the result.
