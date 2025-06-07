' 2025-06-07
' Determines build status from remote result file
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Public Class BuildStatus
    Public ReadOnly Property ExitCode As Integer
    Public ReadOnly Property RawOutput As String

    Public Sub New(code As Integer, raw As String)
        ExitCode = code
        RawOutput = raw
    End Sub

    Public ReadOnly Property IsSuccess As Boolean
        Get
            Return ExitCode = 0
        End Get
    End Property
End Class
