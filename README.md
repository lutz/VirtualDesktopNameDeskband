# VirtualDesktopNameDeskband

This is a deskband to show the name of current virtual desktop. It based on the great projects [CSDeskBand](https://github.com/dsafa/CSDeskBand) by dsafa and [VirtualDesktop](https://github.com/MScholtes/VirtualDesktop) by MScholtes.

## Functions

This deskband is showing the name of current virtual desktop and implement the possibility to switch through the desktops via shortcut <kbd>CTRL</kbd>+\[<kbd>1</kbd>-<kbd>9</kbd>\]. Since **v1.1** there a new shortcuts <kbd>CTRL</kbd>+<kbd>WIN</kbd>+[<kbd>T</kbd>/<kbd>R</kbd>] to move the active window to the left/right desktop beside the current and switch to it.

![Te](assets/taskbar.png)

## Installation

Clone the repository and generate an `*.pfx` file for a strong name signed assembly. After building you can use the small scripts (you can edit the `*.bat` files for fix the correct path to the _regasm_ tool) to register the assembly. Restart the **Explorer.exe** and add the deskband via contextmenu.

## Knowing problems

Currently there are reload problems of deskband after shutdown or reboot of windows (see [here](https://github.com/dsafa/CSDeskBand/issues/25)).

## License

This project is licensed under the [MIT](LICENSE) License
