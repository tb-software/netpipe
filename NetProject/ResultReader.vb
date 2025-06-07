' 2025-06-07
' Fetches remote build results from NetPipeRemoteDotNet
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Net.Http
Imports System.Threading.Tasks

Public Class ResultReader
    Private ReadOnly httpClient As HttpClient
    Private Const ResultUrl As String = "http://t78.ch/apps/netpipe/result.ashx"

    Public Sub New(Optional customClient As HttpClient = Nothing)
        httpClient = If(customClient, New HttpClient())
    End Sub

    Public Async Function FetchRemoteResultAsync() As Task(Of String)
        Dim response As HttpResponseMessage = Await httpClient.GetAsync(ResultUrl)
        response.EnsureSuccessStatusCode()
        Return Await response.Content.ReadAsStringAsync()
    End Function
End Class
