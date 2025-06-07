' 2025-06-07
' Entry point of application
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Windows.Forms

Public Module Program
    Private ReadOnly messagePresenter As IMessagePresenter = New MessageBoxPresenter()

    Sub Main()
        ShowGreeting()
    End Sub

    Public Sub ShowGreeting(Optional customPresenter As IMessagePresenter = Nothing)
        Dim greeting As String = "Hallo von Timo 3l!"
        If customPresenter IsNot Nothing Then
            customPresenter.ShowMessage(greeting)
        Else
            messagePresenter.ShowMessage(greeting)
        End If
    End Sub
End Module
