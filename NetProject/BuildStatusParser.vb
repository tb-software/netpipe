' 2025-06-07
' Parses result text into exit codes
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-08

Public Class BuildStatusParser
    Public Function ParseExitCode(content As String) As Integer
        Const pattern As String = "Exit code:"
        Dim index As Integer = content.IndexOf(pattern)
        If index = -1 Then
            Throw New FormatException("Exit code pattern not found in content.")
        End If

        index += pattern.Length
        Dim lineEnd As Integer = content.IndexOfAny(New Char() {Chr(10), Chr(13)}, index)
        If lineEnd = -1 Then lineEnd = content.Length

        Dim numberString As String = content.Substring(index, lineEnd - index).Trim()
        Dim result As Integer
        If Integer.TryParse(numberString, result) Then
            Return result
        End If

        Throw New FormatException($"Failed to parse exit code from '{numberString}'.")
    End Function
End Class
