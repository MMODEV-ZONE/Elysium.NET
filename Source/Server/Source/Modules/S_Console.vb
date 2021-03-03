Imports System.Threading

Module S_Console
    Private threadConsole As Thread

    Sub Main()
        threadConsole = New Thread(New ThreadStart(AddressOf ConsoleThread))
        threadConsole.Start()

        ' Spin up the server on the main thread
        InitServer()
    End Sub

    Private Sub ConsoleThread()
        Dim line As String, parts As String()

        Console.WriteLine("Inicializando loop do console")

        While (True)
            line = Console.ReadLine()

            parts = line.Split(" ") : If (parts.Length < 1) Then Continue While

            Select Case parts(0).Trim().ToLower()
                Case "/ajuda"

#Region " Body "

                    Console.WriteLine("/ajuda, mostra esta mensagem.")
                    Console.WriteLine("/sair, encerra o servidor.")
                    Console.WriteLine("/setadmin, seta o nível de acesso de um jogador; sintaxe: '/setadmin nome-do-jogador nivel-de-acesso', com o último indo de 0 a 4.")
                    Console.WriteLine("/chutar, chuta o usuário do servidor; sintaxe: '/chutar nome-do-jogador'")
                    Console.WriteLine("/banir, bane o jogador; sintaxe: '/banir nome-do-jogador'")

#End Region

                Case "/sair"

#Region " Body "

                    DestroyServer()

#End Region

                Case "/setadmin"
                    If parts.Length < 3 Then Continue While

#Region " Body "

                    Dim Name As String = parts(1)
                    Dim Pindex As Integer = FindPlayer(Name)
                    Dim Power As Integer : Integer.TryParse(parts(2), Power)

                    If Not Pindex > 0 Then
                        Console.WriteLine("Nome do jogador está vazio ou inválido. [Nome não encontrado]")
                    Else
                        Select Case Power
                            Case 0
                                SetPlayerAccess(Pindex, Power)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Seu Acesso foi setado para Jogador!", ColorType.BrightCyan)
                                Console.WriteLine("Nível de acesso " & Power & " setado para " & Name & " com sucesso")
                            Case 1
                                SetPlayerAccess(Pindex, Power)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Seu Acesso foi setado para Monitor!", ColorType.BrightCyan)
                                Console.WriteLine("Nível de acesso " & Power & " setado para " & Name & " com sucesso")
                            Case 2
                                SetPlayerAccess(Pindex, Power)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Seu Acesso foi setado para Mapeador!", ColorType.BrightCyan)
                                Console.WriteLine("Nível de acesso " & Power & " setado para " & Name & " com sucesso")
                            Case 3
                                SetPlayerAccess(Pindex, Power)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Seu Acesso foi setado para Desenvolvedor!", ColorType.BrightCyan)
                                Console.WriteLine("Nível de acesso " & Power & " setado para " & Name & " com sucesso")
                            Case 4
                                SetPlayerAccess(Pindex, Power)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Seu Acesso foi setado para Administrador!", ColorType.BrightCyan)
                                Console.WriteLine("Nível de acesso " & Power & " setado para " & Name & " com sucesso")
                            Case Else
                                Console.WriteLine("Falha em definir o acesso " & Power & " para o jogador " & Name)
                        End Select
                    End If

#End Region

                Case "/chutar"
                    If parts.Length < 2 Then Continue While

#Region " Body "

                    Dim Name As String = parts(1)
                    Dim Pindex As Integer = FindPlayer(Name)
                    If Not Pindex > 0 Then
                        Console.WriteLine("Nome do jogador está vazio ou inválido. [Nome não encontrado]")
                    Else
                        AlertMsg(Pindex, "Você foi chutado do servidor!", True)
                        LeftGame(Pindex)
                    End If

#End Region

                Case "/banir"
                    If parts.Length < 2 Then Continue While

#Region " Body "

                    Dim Name As String = parts(1)
                    Dim Pindex As Integer = FindPlayer(Name)
                    If Not Pindex > 0 Then : Console.WriteLine("Nome do jogador está vazio ou inválido. [Nome não encontrado]")
                    Else : ServerBanIndex(Pindex) : End If

#End Region

                Case "/veljogo"
                    If parts.Length < 2 Then Exit Sub

#Region " Body "

                    Dim speed As Double
                    Double.TryParse(parts(1), speed)
                    Time.Instance.GameSpeed = speed
                    Console.WriteLine("Velocidade do jogo modificada para " & Time.Instance.GameSpeed & " segundos por segundo")

#End Region

                Case "" : Continue While
                Case Else : Console.WriteLine("Comando inválido. Se você está inseguro das funções disponíveis, digite '/ajuda'.")
            End Select
        End While
    End Sub

End Module