' 2025-06-08
' Provides interactive UI to test program features
' Author: Codex
' Created: 2025-06-08
' Edited: 2025-06-08

Imports System.Windows
Imports System.Windows.Controls

Partial Class MainWindow
    Inherits Window

    Private ReadOnly presenter As WpfOutputPresenter

    Public Sub New()
        InitializeComponent()
        presenter = New WpfOutputPresenter(OutputBox)
    End Sub

    Private Sub ShowGreetingButton_Click(sender As Object, e As RoutedEventArgs)
        Program.ShowGreeting(presenter)
    End Sub

    Private Sub ShowRemoteResultButton_Click(sender As Object, e As RoutedEventArgs)
        Program.ShowRemoteResult(presenter)
    End Sub

    Private Sub ShowBuildStatusButton_Click(sender As Object, e As RoutedEventArgs)
        Program.ShowBuildStatus(presenter)
    End Sub
End Class
