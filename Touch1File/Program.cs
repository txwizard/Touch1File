/*
    ============================================================================

    Namespace:          Touch1File

    Class Name:         Program

    File Name:          Program.cs

    Synopsis:           Besides defining the entry point, this class is the
                        entire implementation of the application.

    Remarks:            

    Author:             David A. Gray

	License:            Copyright (C) 2023, David A. Gray.
						All rights reserved.

                        Redistribution and use in source and binary forms, with
                        or without modification, are permitted provided that the
                        following conditions are met:

                        *   Redistributions of source code must retain the above
                            copyright notice, this list of conditions and the
                            following disclaimer.

                        *   Redistributions in binary form must reproduce the
                            above copyright notice, this list of conditions and
                            the following disclaimer in the documentation and/or
                            other materials provided with the distribution.

                        *   Neither the name of David A. Gray, nor the names of
                            his contributors may be used to endorse or promote
                            products derived from this software without specific
                            prior written permission.

                        THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
                        CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
                        WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
                        WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
                        PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
                        David A. Gray BE LIABLE FOR ANY DIRECT, INDIRECT,
                        INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
                        (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
                        SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
                        PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
                        ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
                        LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
                        ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
                        IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

    Created:            Wednesday, 28 June 2023

    ----------------------------------------------------------------------------
    Revision History
    ----------------------------------------------------------------------------

    Date       Version By  Description
    ---------- ------- --- -----------------------------------------------------
	2023/06/28 1.0     DAG MVP: Initial release.
    2023/06/29 1.1     DAG Display the absolute (fully qualified) file name in
                           the first message that follows the logo banner, print
                           a confirmation message when the file's LastWriteTime
                           is successfully changed, and color code messages that
                           report success versus failure.
    2023/12/10 1.2     DAG Replace the light green background with a dark green,
                           and scroll the console buffer up two lines.
    ============================================================================
*/

using System;
using System.IO;

using WizardWrx;
using WizardWrx.ConsoleAppAids3;
using WizardWrx.DLLConfigurationManager;


namespace Touch1File
{
    internal class Program
    {
        private static readonly ConsoleAppStateManager s_theApp = ConsoleAppStateManager.GetTheSingleInstance ( );


        static void Main ( string [ ] args )
        {
            const int ERROR_FILE_NAME_MISSING = MagicNumbers.ERROR_RUNTIME + MagicNumbers.PLUS_ONE;
            const int ERROR_FILE_NOT_FOUND = ERROR_FILE_NAME_MISSING + MagicNumbers.PLUS_ONE;
            const int ERROR_FILE_TOUCH_UNSUCCESSFUL= ERROR_FILE_NOT_FOUND + MagicNumbers.PLUS_ONE;

            s_theApp.BaseStateManager.AppExceptionLogger.OptionFlags = s_theApp.BaseStateManager.AppExceptionLogger.OptionFlags
                                                                       | ExceptionLogger.OutputOptions.Stack
                                                                       | ExceptionLogger.OutputOptions.EventLog;
            s_theApp.BaseStateManager.LoadErrorMessageTable (
                new string [ ]
                {
                    Properties.Resources.LOGMSG_FILE_TOUCH_SUCCESSFUL ,			// ERROR_SUCCESS
                    WizardWrx.Common.Properties.Resources.ERRMSG_RUNTIME ,      // ERROR_RUNTIME
                    Properties.Resources.ERRMSG_FILE_NAME_MISSING ,             // ERROR_FILE_NAME_MISSING
                    Properties.Resources.ERRMSG_FILE_NOT_FOUND ,                // ERROR_FILE_NOT_FOUND
                } );
            s_theApp.DisplayBOJMessage ( );

            if ( args.Length > ListInfo.LIST_IS_EMPTY )
            {
                try
                {
                    FileInfo info = new FileInfo ( args [ ArrayInfo.ARRAY_FIRST_ELEMENT ] );
                    Console.WriteLine (
                        Properties.Resources.LOGMSG_SPECIFIED_INPUT_FILENAME ,  // Format Control String
                        info.FullName ,                                         // Format Item 0: Input File Name                  = {0}
                        Environment.NewLine );                                  // Format Item 1: Newline at end of text

                    if ( info.Exists )
                    {
                        FileInfoExtension.enmInitialStatus initialStatus = info.FileAttributeReadOnlyClear ( );
                        DateTime dtmUtcNow = DateTime.UtcNow;
                        Console.WriteLine (
                            Properties.Resources.LOGMSG_INPUT_FILE_CURR_DATE ,  // Format Control String
                            info.LastWriteTime.ToString (                       // Format Item 0: Input File Current LastWriteTime = {0}
                                Properties.Resources.FILETIME_FORMAT ) );       // Format string for LastWriteTime
                        Console.WriteLine (
                            Properties.Resources.LOGMSG_INPUT_FILE_NEW_DATE ,   // Format Control String
                            dtmUtcNow.ToLocalTime ( ).ToString (                // Format Item 0: Input File Revised LastWriteTime = {0}
                                Properties.Resources.FILETIME_FORMAT ) ,        // Format string for LastWriteTime
                        Environment.NewLine );                                  // Format Item 1: Newline at end of text
                        File.SetLastWriteTimeUtc (
                            info.FullName ,                                     // string path
                            dtmUtcNow );                                        // DateTime lastWriteTimeUtc

                        if ( initialStatus == FileInfoExtension.enmInitialStatus.WasSet )
                        {
                            info.FileAttributeReadOnlyReinstate ( initialStatus );
                        }   // if ( initialStatus == FileInfoExtension.enmInitialStatus.WasSet )

                        info.Refresh ( );

                        if ( info.LastWriteTimeUtc == dtmUtcNow )
                        {
                            WizardWrx.ConsoleStreams.MessageInColor messageInColor = new WizardWrx.ConsoleStreams.MessageInColor ( ConsoleColor.White , ConsoleColor.DarkGreen );
                            messageInColor.WriteLine ( Properties.Resources.LOGMSG_FILE_TOUCH_SUCCESSFUL );
                        }   // TRUE (anticipated outcome) block, if ( info.LastWriteTimeUtc == dtmUtcNow )
                        else
                        {
                            WizardWrx.ConsoleStreams.MessageInColor messageInColor = new WizardWrx.ConsoleStreams.MessageInColor ( ConsoleColor.White , ConsoleColor.Red );
                            messageInColor.WriteLine ( Properties.Resources.LOGMSG_FILE_TOUCH_SUCCESSFUL );
                            s_theApp.BaseStateManager.AppReturnCode = ERROR_FILE_TOUCH_UNSUCCESSFUL;
                        }   // FALSE (unanticipated outcome) block, if ( info.LastWriteTimeUtc == dtmUtcNow )
                    }   // TRUE (anticipated outcime) block, if ( info.Exists )
                    else
                    {
                        s_theApp.BaseStateManager.AppReturnCode = ERROR_FILE_NOT_FOUND;
                    }   // FALSE (unanticipated outcime) block, if ( info.Exists )
                }
                catch ( Exception ex )
                {
                    s_theApp.BaseStateManager.AppExceptionLogger.ReportException ( ex );
                }
            }   // TRUE (anticipated outcome) block, if ( args.Length > ListInfo.LIST_IS_EMPTY )
            else
            {
                s_theApp.BaseStateManager.AppReturnCode = ERROR_FILE_NAME_MISSING;
            }   // FALSE (unanticipated outcome) block, if ( args.Length > ListInfo.LIST_IS_EMPTY )

            s_theApp.DisplayEOJMessage ( );
            Console.WriteLine ( ); // Emit two newlines, of which the first also returns the carriage, while the second creates a blank line in the output stream.
            s_theApp.NormalExit ( ConsoleAppStateManager.NormalExitAction.WaitForOperator );
        }   // static void Main
    }   // internal class Program
}   // namespace Touch1File