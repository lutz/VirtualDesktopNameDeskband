# VirtualDesktopNameDeskband

This is a deskband to show the name of current virtual desktop. It based on the great projects [SharpShell](https://github.com/dwmkerr/sharpshell/) by dwmkerr and [VirtualDesktop](https://github.com/MScholtes/VirtualDesktop) by MScholtes.

## Functions

This deskband is showing the name of current virtual desktop and implement the possibility to switch through the desktops via shortcut <kbd>CTRL</kbd>+\[<kbd>1</kbd>-<kbd>9</kbd>\].

![Te](assets/taskbar.png)

## Installation

Clone the repository and generate an `*.pfx` file for a strong name signed assembly. After building you can use the small scripts (you can edit the `*.bat` files for fix the correct path to the _regasm_ tool) to register the assembly. Restart the **Explorer.exe** and add the deskband via contextmenu.

## History

**Version 2**

Remove moving function and use SharpShell instead of CDeskbandName library. Now there is no known issues currently yet.

**Version 1.1**

Support shortcuts to move window to another desktop.

**Version 1**

Initial release

## License

This project is licensed under the [MIT](LICENSE) License
