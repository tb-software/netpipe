' 2025-06-08
' Parses result text into build details
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-08

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

    Public Function ParseFileSize(content As String) As Long
        Const pattern As String = "File size:"
        Dim index As Integer = content.IndexOf(pattern, StringComparison.OrdinalIgnoreCase)
        If index <> -1 Then
            index += pattern.Length
            Dim lineEnd As Integer = content.IndexOfAny(New Char() {Chr(10), Chr(13)}, index)
            If lineEnd = -1 Then lineEnd = content.Length
            Dim numberString As String = content.Substring(index, lineEnd - index).Trim()
            numberString = numberString.Replace("bytes", "", StringComparison.OrdinalIgnoreCase).Trim()
            numberString = numberString.Replace("byte", "", StringComparison.OrdinalIgnoreCase).Trim()
            Dim result As Long
            If Long.TryParse(numberString, result) Then
                Return result
            End If
        End If
        Return -1
    End Function

    Public Function ParseMappedPath(content As String) As String
        Const pattern As String = "Mapped path:"
        Dim index As Integer = content.IndexOf(pattern, StringComparison.OrdinalIgnoreCase)
        If index <> -1 Then
            index += pattern.Length
            Dim lineEnd As Integer = content.IndexOfAny(New Char() {Chr(10), Chr(13)}, index)
            If lineEnd = -1 Then lineEnd = content.Length
            Return content.Substring(index, lineEnd - index).Trim()
        End If
        Return String.Empty
    End Function

    Public Function ParseFileContent(content As String) As String
        Const pattern As String = "Content:"
        Dim index As Integer = content.IndexOf(pattern, StringComparison.OrdinalIgnoreCase)
        If index <> -1 Then
            index += pattern.Length
            Return content.Substring(index).Trim()
        End If
        Return String.Empty
    End Function
End Class
