# Touch1File ChangeLog

This file is a chronological history of development of `Touch1File.exe`
from inception.

As I do with _every_ ChangeLog that I publish, revisions appear most recent
first, so that the latest changes are visible without scrolling.

## 2023/12/10, Version 2.0

This version implements three major new features.

1. Options beyond awaiting user input upon program termination are supported, including timed wait and no wait.
2. The timed wait interval defaults to 30 seconds, but can be set to a higher or lower value by command line.
3. On exit, the program emits a line feed, so that the next line of script begins on a new line in the output stream.

## 2023/12/10, Version 1.2

This version makes two significant improvements.

1. The garish green background is replaced by something more nearly resembling forest green.
2. On exit, the console buffer is scrolled up by two lines, leaving a blank line after the final prompt.

Additionally, the dependent libraries are updated to versions that explicitly target Microsoft .NET Framework version 4.8.

## 2023/06/29, Version 1.1

This version makes two significant improvements.

1. The absolute (fully qualified) name of the touched file is displayed, making it practical to leverage the value of the current working directory to make a desktop shortcut work correctly in any directory of an application that is installed into multiple locations, while giving unambiguous evidence of the name of the affected file.
2. A confirmation message is displayed when the update is confirmed by reading back the LastWriteTime from the FileInfo object that tracks it from beginning to end.
3. Confirmation of success is displayed as white text on a green background, while failure messages appear as white text on a red background.

## 2023/06/28, Version 1.0

This first version is the Minimum Viable Product.