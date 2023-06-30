# Touch1File ReadMe

This command line utility improves on **FSTouch** by providing immediate recording
of its actions and straightforward application to a very specific use case, that
of a `web.config` or similar configuration file for which updating the time stamp
is sufficient to cause the application that it controls to re-read it.

## System Requirements

**Touch1File** is implemented in Visual C# for the Microsoft .NET Framework version 4.8.
It runs on any system that supports that version of the framework. It depends on some
components of the **WizardWrx .NET API**, which is documented at https://txwizard.github.io/WizardWrx_NET_API/api/index.html
and is available as a set of NuGet packages. This program requires and incorporates
version **9.0.566** of the `WizardWrx.ConsoleAppAids3` package.

## Availability

The binary package is available at https://github.com/txwizard/Touch1File/blob/main/Touch1File.zip

## Usage

`Touch1File` is intended to be executed from a standard Windows desktop shortcut.

A typical command line as it might appear in the Target field of a Windows desktop
shortcut is as follows.

    C:\bin\Touch1File.exe web.config

The foregoing example assumes that `Touch1File.exe` is installed into directory
`C:\bin` and that `web.config` is installed into directory `C:\inetpub\MyWebSite`
and that it is the current working directory.

The output displays in a standard Windows console (Command Prompt) window, which
closes when you press the ENTER (Return) key to exit the program, and resembles
the following.

    Touch1File, version 1.1.10.0
    Begin @ 06/29/2023 22:36:56.091 (06/30/2023 03:36:56.091 UTC)

    Input File Name                  = C:\inetpub\MyWebSite\Web.config

    Input File Current LastWriteTime = 2023/06/29 22:22:25
    Input File Revised LastWriteTime = 2023/06/29 22:36:56

    Successfully updated

    Touch1File End - 06/29/2023 22:36:56.176 (06/30/2023 03:36:56.176 UTC)
    Elapsed time: 00:00:00.0843416
    Please press the ENTER (Return) key to exit the program.

A shortcut set up with its fields populated as shown in the following table can be
copied into any number of directories to 'touch' the `web.config` file stored in each
directory to force the application installed therein to restart. Such was the use case
that motivated its creation.

|Shortcut Field Label|Shortcut Field Value                                        |
|--------------------|------------------------------------------------------------|
|Target              |C:\bin\Touch1File.exe Web.config                            |
|Start in            |*** Leave BLANK to use directory in which shortcut lives. **|
|Shortcut key        |None                                                        |
|Comment:            |                                                            |
|Run                 |Nomal window                                                |

## Road Map

At present, the road map is empty.

## License

Copyright (C) 2023, David A. Gray.
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

* Neither the name of David A. Gray, nor the names of his contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL David A. Gray BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING
IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY
OF SUCH DAMAGE.