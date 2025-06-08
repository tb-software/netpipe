' 2025-06-08 XXX
' Entry point of application
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-08

Imports System.Windows.Forms
Imports System.Collections.Generic

Public Module Program
    Private ReadOnly messagePresenter As IMessagePresenter = New MessageBoxPresenter()

    Sub Main()
        ShowGreeting()
        ShowRemoteResult()
        ShowBuildStatus()
    End Sub

    Public Sub ShowGreeting(Optional customPresenter As IMessagePresenter = Nothing)
        Dim greeting As String = "Hallo von Timo 3l!"
        If customPresenter IsNot Nothing Then
            customPresenter.ShowMessage(greeting)
        Else
            messagePresenter.ShowMessage(greeting)
        End If
    End Sub

    Public Sub ShowRemoteResult(Optional customPresenter As IMessagePresenter = Nothing, Optional reader As IResultReader = Nothing)
        Dim presenter As IMessagePresenter = If(customPresenter, messagePresenter)
        Dim resultReader As IResultReader = If(reader, New ResultReader())
        Dim remoteResult As String = resultReader.FetchRemoteResultAsync().Result
        presenter.ShowMessage(remoteResult)
    End Sub

    Public Sub ShowBuildStatus(Optional customPresenter As IMessagePresenter = Nothing, Optional checker As BuildStatusChecker = Nothing)
        Dim presenter As IMessagePresenter = If(customPresenter, messagePresenter)
        Dim statusChecker As BuildStatusChecker = If(checker, New BuildStatusChecker())
        Dim status As BuildStatus = statusChecker.GetCurrentStatusAsync().Result
        Dim parts As New List(Of String) From {
            $"Exit code: {status.ExitCode}",
            $"Size: {status.FileSize}"
        }
        If Not String.IsNullOrWhiteSpace(status.MappedPath) Then
            parts.Add($"Path: {status.MappedPath}")
        End If
        Dim message As String = String.Join(", ", parts)
        presenter.ShowMessage(message)
    End Sub
End Module
