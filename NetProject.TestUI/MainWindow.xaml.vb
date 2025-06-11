' 2025-06-08
' Interactive WPF window for testing
' Author: Codex
' Created: 2025-06-08
' Edited: 2025-06-08

Imports System.Windows
Imports NetProject

Partial Class MainWindow
    Inherits Window

    Private ReadOnly presenter As WpfOutputPresenter

    Public Sub New()
        InitializeComponent()
        presenter = New WpfOutputPresenter(OutputBox)
        AddHandler ShowGreetingButton.Click, AddressOf ShowGreeting
        AddHandler ShowRemoteResultButton.Click, AddressOf ShowRemoteResult
        AddHandler ShowBuildStatusButton.Click, AddressOf ShowBuildStatus
    End Sub

    Private Sub ShowGreeting(sender As Object, e As RoutedEventArgs)
        Program.ShowGreeting(presenter)
    End Sub

    Private Sub ShowRemoteResult(sender As Object, e As RoutedEventArgs)
        Program.ShowRemoteResult(presenter)
    End Sub

    Private Sub ShowBuildStatus(sender As Object, e As RoutedEventArgs)
        Program.ShowBuildStatus(presenter)
    End Sub
End Class
