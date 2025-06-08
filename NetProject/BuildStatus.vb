' 2025-06-08
' Determines build status from remote result file
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-08

Public Class BuildStatus
    Public ReadOnly Property ExitCode As Integer
    Public ReadOnly Property RawOutput As String
    Public ReadOnly Property FileSize As Long
    Public ReadOnly Property MappedPath As String
    Public ReadOnly Property FileContent As String

    Public Sub New(code As Integer, raw As String, Optional size As Long = -1, Optional path As String = "", Optional content As String = "")
        ExitCode = code
        RawOutput = raw
        FileSize = size
        MappedPath = path
        FileContent = content
    End Sub

    Public ReadOnly Property IsSuccess As Boolean
        Get
            Return ExitCode = 0
        End Get
    End Property
End Class
