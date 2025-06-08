' 2025-06-08
' Determines build status from remote result file
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-08

Imports System.Threading.Tasks

Public Class BuildStatusChecker
    Private ReadOnly resultReader As IResultReader

    Public Sub New(Optional reader As IResultReader = Nothing)
        resultReader = If(reader, New ResultReader())
    End Sub

    Public Async Function GetCurrentStatusAsync() As Task(Of BuildStatus)
        Dim content As String = Await resultReader.FetchRemoteResultAsync()
        Dim parser As New BuildStatusParser()
        Dim code As Integer = parser.ParseExitCode(content)
        Dim size As Long = parser.ParseFileSize(content)
        Dim path As String = parser.ParseMappedPath(content)
        Dim fileContent As String = parser.ParseFileContent(content)
        Return New BuildStatus(code, content, size, path, fileContent)
    End Function
End Class
