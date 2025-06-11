' 2025-06-08
' Writes messages to the console
' Author: Codex
' Created: 2025-06-08
' Edited: 2025-06-08

Public Class ConsoleOutputPresenter
    Implements IMessagePresenter

    Public Sub ShowMessage(message As String) Implements IMessagePresenter.ShowMessage
        Console.WriteLine(message)
    End Sub
End Class
