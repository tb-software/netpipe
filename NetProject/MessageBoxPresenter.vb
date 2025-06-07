' 2025-06-07
' Provides message display via Windows Forms MessageBox
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Windows.Forms

Public Interface IMessagePresenter
    Sub ShowMessage(message As String)
End Interface

Public Class MessageBoxPresenter
    Implements IMessagePresenter

    Public Sub ShowMessage(message As String) Implements IMessagePresenter.ShowMessage
        MessageBox.Show(message)
    End Sub
End Class
