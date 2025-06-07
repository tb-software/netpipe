' 2025-06-07
' Provides abstraction for reading remote results
' Author: Codex
' Created: 2025-06-07
' Edited: 2025-06-07

Imports System.Threading.Tasks

Public Interface IResultReader
    Function FetchRemoteResultAsync() As Task(Of String)
End Interface
