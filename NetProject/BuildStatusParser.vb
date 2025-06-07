' 2025-06-07
' Parses result text into exit codes
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Public Class BuildStatusParser
    Public Function ParseExitCode(content As String) As Integer
        Const pattern As String = "Exit code:"
        Dim index As Integer = content.IndexOf(pattern)
        If index <> -1 Then
            index += pattern.Length
            Dim lineEnd As Integer = content.IndexOfAny(New Char() {Chr(10), Chr(13)}, index)
            If lineEnd = -1 Then lineEnd = content.Length
            Dim numberString As String = content.Substring(index, lineEnd - index).Trim()
            Dim result As Integer
            If Integer.TryParse(numberString, result) Then
                Return result
            End If
        End If
        Return -1
    End Function
End Class
