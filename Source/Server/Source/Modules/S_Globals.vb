Module S_Globals
    Friend Debugging As Boolean
    Friend DebugTxt As Boolean = False
    Friend ConsoleText As String
    Friend ErrorCount As Integer

    ' Usado para fechar portas importantes de novo
    Friend KeyTimer As Integer

    ' Usado para dar HP de volta aos NPCs gradualmente
    Friend GiveNPCHPTimer As Integer

    Friend GiveNPCMPTimer As Integer

    ' Usado para Logs
    Friend ServerLog As Boolean

    ' Usado para o loop do servidor
    Friend ServerOnline As Boolean

    ' Usado para colocar texto de output
    Friend NumLines As Integer

    ' Usado para desativar servidor com contagem regressiva.
    Friend isShuttingDown As Boolean

    Friend Secs As Integer
    Friend TempMapData As Byte

    Friend Gettingmap As Boolean
    Friend EKeyPair As New ASFW.IO.Encryption.KeyPair()
End Module