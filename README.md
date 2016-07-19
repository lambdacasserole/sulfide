# Sulfide
Some useful libraries and frameworks for integrated development environments. 

Sulfide is a starting point for developing your own IDE. All it really is is a text editor (AvalonEdit) bundled with docking window system (DockPanel Suite) with everything wired in and working for syntax highlighting, basic clipboard operations and opening/saving files. Printing is very basic but works. The rest is down to you.

![Screenshot](https://github.com/lambdacasserole/sulfide/raw/master/Assets/screenshot.png)

## Limitations

Sulfide is not a text editor program or IDE by itself (like Notepad++ or Eclipse) but is designed as a starting point for building your own. Also, it is not built with any grand design patterns like dependency injection or MVC/MVVM. If you require a bit more structure in the IDE you're developing you it shouldn't be too difficult to add it in yourself. 

If you're looking for something a bit grander, try [Gemini](https://github.com/tgjones/gemini). It's WPF (rather than WinForms based) but offers a whole bunch more structure and some awesome tools.

There are no tests of any kind in this whole project. It seems to work, make sure you write tests before shipping your own Sulfide-based IDE.

## Acknowledgements

The amazing [Fugue icon pack](http://p.yusukekamiyamane.com/) by Yusuke Kamiyamane is used in this application and is licensed under the [Creative Commons Attribution 3.0](http://creativecommons.org/licenses/by/3.0/) license.

The awesome [DockPanel Suite](https://github.com/dockpanelsuite/dockpanelsuite) library is used for docking windows in the editor as well as the editor's MDI interface. It's licensed under the [MIT license](https://opensource.org/licenses/MIT).

The incredible [AvalonEdit](https://github.com/icsharpcode/AvalonEdit) WPF code editor control is used in the application to view and edit syntax-highlighted code. It's also licensed under the [MIT license](https://opensource.org/licenses/MIT).
