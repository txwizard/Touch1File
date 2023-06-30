# Touch1File ChangeLog

This file is a chronological history of development of `Touch1File.exe`
from inception.

As I do with _every_ ChangeLog that I publish, revisions appear most recent
first, so that the latest changes are visible without scrolling.

## 2023/06/29, Version 1.1

This version makes two significant improvements.

1. The absolute (fully qualified) name of the touched file is displayed, making it practical to leverage the value of the current working directory to make a desktop shortcut work correctly in any directory of an application that is installed into multiple locations, while giving unambiguous evidence of the name of the affected file.
2. A confirmation message is displayed when the update is confirmed by reading back the LastWriteTime from the FileInfo object that tracks it from beginning to end.
3. Confirmation of success is displayed as white text on a green background, while failure messages appear as white text on a red background.

## 2023/06/28, Version 1.0

This first version is the Minimum Viable Product.