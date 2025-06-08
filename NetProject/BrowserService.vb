' 2025-06-07
' Provides ability to open URLs in default browser
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Diagnostics

Public Interface IBrowserService
    Sub OpenUrl(url As String)
End Interface

Public Class DefaultBrowserService
    Implements IBrowserService

    Public Sub OpenUrl(url As String) Implements IBrowserService.OpenUrl
        Dim startInfo As New ProcessStartInfo With {
            .FileName = url,
            .UseShellExecute = True
        }
        Process.Start(startInfo)
    End Sub
End Class
