' 2025-06-07
' Determines build status from remote result file
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Threading.Tasks

Public Class BuildStatus
    Public ReadOnly Property ExitCode As Integer
    Public ReadOnly Property RawOutput As String

    Public Sub New(code As Integer, raw As String)
        ExitCode = code
        RawOutput = raw
    End Sub

    Public ReadOnly Property IsSuccess As Boolean
        Get
            Return ExitCode = 0
        End Get
    End Property
End Class

Public Class BuildStatusChecker
    Private ReadOnly resultReader As ResultReader

    Public Sub New(Optional reader As ResultReader = Nothing)
        resultReader = If(reader, New ResultReader())
    End Sub

    Public Async Function GetCurrentStatusAsync() As Task(Of BuildStatus)
        Dim content As String = Await resultReader.FetchRemoteResultAsync()
        Dim code As Integer = ParseExitCode(content)
        Return New BuildStatus(code, content)
    End Function

    Private Function ParseExitCode(content As String) As Integer
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
