' 2025-06-07 XXX
' Entry point of application
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Windows.Forms

Public Module Program
    Private ReadOnly messagePresenter As IMessagePresenter = New MessageBoxPresenter()

    Sub Main()
        ShowGreeting()
        ShowRemoteResult()
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
End Module
