# MaxBootstrap
A versatile custom bootstrapper for use with the Wix Toolset burn engine.  This library assumes you already have an understand of the Wix toolset and it's included burn chainer.  This library is designed to help developers familiar with the Wix toolset to build simple or complicated installers with custom C# code and WPF user interface.

# Usage
Will do a writeup when a more 'complete' release is nearing release.

## Version
0.2.0

## Development Status
The MaxBootstrap.Core library is mostly complete, meaning it might be usable today but it is still very much a 'work in progress'.  That said at this point in time for another developer to use the library they would not only need a pretty good understanding of the code in the library but they would still need to build all their views and do all their own error handling.  So I'm still actively working on getting it to a state where I feel someone with no knowledge of this engine could pick it up and get something running in say a half hour or less (assuming they've already taken care of the Wix toolset bundle/product code).

Planned Features
- Visual Studio Templates for both the Bootstrapper UI and for Wix Burn
- Nuget package
- Complete MaxBootstrap.UI class by making views onfigurable (preferably through XML or JSON)
- Completed sample implementations that demonstrate practical application of the library
- Lots of logging
- More tests, significantly more tests
