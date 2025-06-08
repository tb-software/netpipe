' 2025-06-08
' Presents messages inside a WPF TextBox
' Author: Codex
' Created: 2025-06-08
' Edited: 2025-06-08

Imports System.Windows.Controls

Public Class WpfOutputPresenter
    Implements IMessagePresenter

    Private ReadOnly outputBox As TextBox

    Public Sub New(box As TextBox)
        outputBox = box
    End Sub

    Public Sub ShowMessage(message As String) Implements IMessagePresenter.ShowMessage
        outputBox.Text = message
    End Sub
End Class
