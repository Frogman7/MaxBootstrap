# MaxBootstrap
A versatile custom bootstrapper for use with the Wix Toolset burn engine.  This library assumes you already have an understand of the Wix toolset and it's included burn chainer.  This library is designed to help developers familiar with the Wix toolset to build simple or complicated installers with custom C# code and WPF user interface.

# Usage
Will do a writeup when a more 'complete' release is nearing release.

## Version
No releases yet.

## Development Status
The project has two primary components:

MaxBootstrap.Core which will contain all the logic for interacting with the Wix Burn engine and MaxBootstrap.UI which will provide a quick solution for building a rich customizable installer user interface.

The MaxBootstrap.Core library is mostly complete, meaning it might be usable today but it is still very much a 'work in progress'.  That said at this point in time for another developer to use the library they would not only need a pretty good understanding of the code in the library but they would still need to build all their views and do all their own error handling.  So I'm spending the majority of development time actively working on getting it to a state where I feel someone with no knowledge of this engine could pick it up and get something running in say a half hour or less (assuming they've already taken care of the Wix toolset bundle/product code).

Planned Features
- Visual Studio Templates for both the Bootstrapper UI and for Wix Burn
- Nuget package
- Complete MaxBootstrap.UI class by making views configurable (preferably through XML or JSON)
- Completed sample implementations that demonstrate practical application of the library
- Lots of logging
- More tests, significantly more tests

## Design Notes
The lack of a IoC or MVVM framework is not due to lack of experience but because I wanted to keep the dependencies to a minimum in order to keep the installers as small as possible.

## Special Thanks
I want to give credit where credit is due and these projects were my starting point when coming up with this project and ideas for my implementation were taken from both.

tpalacino on CodePlex (https://www.codeplex.com/site/users/view/tpalacino) for the WixWPF project (https://wixwpf.codeplex.com/)

AntonKr on CodePlex (https://www.codeplex.com/site/users/view/AntonKr) for the Wix Bootstrapper Windows 8 Theme project (https://wixbootstrapper.codeplex.com/)
