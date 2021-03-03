Imports System.IO

Module S_General
    'Friend Declare Function GetQueueStatus Lib "user32" (fuFlags As Integer) As Integer
    Friend ServerDestroyed As Boolean
    Friend MyIPAddress As String
    Friend myStopWatch As New Stopwatch()

    Friend Function GetTimeMs() As Integer
        Return myStopWatch.ElapsedMilliseconds
    End Function

    Sub InitServer()
        Dim i As Integer, F As Integer, x As Integer
        Dim time1 As Integer, time2 As Integer

        myStopWatch.Start()

        If Debugger.IsAttached Then
            ' Como há um debugger embarcado,
            ' assuma que estamos rodando da IDE
            Debugging = True
        Else
            ' Assumir que não estamos rodando da IDE
            Dim currentDomain As AppDomain = AppDomain.CurrentDomain
            AddHandler currentDomain.UnhandledException, AddressOf ErrorHandler
        End If

        LoadSettings()

        Console.Title = "Elysium.NET v1.0 - Servidor"
        Console.SetWindowSize(120, 20)

        handler = New ConsoleEventDelegate(AddressOf ConsoleEventCallback)
        SetConsoleCtrlHandler(handler, True)

        time1 = GetTimeMs()

        ' Inicializar o gerador de números aleatórios
        Randomize()

        ' Carregar Encriptação
        Dim fi = Application.StartupPath & "\AsyncKeys.xml"
        If Not File.Exists(fi) Then
            EKeyPair.GenerateKeys()
            EKeyPair.ExportKey(fi, True) ' Verdadeiro exporta chave privada também.
            ' Lembrar de nunca passar a chave privada para o cliente!
            ' Exportar a chave salva como arquivo para uso posterior.
        Else
            EKeyPair.ImportKey(fi)
        End If
        ' FIM DA ENCRIPTACAO

        ReDim Map(MAX_CACHED_MAPS)

        ReDim MapNpc(MAX_CACHED_MAPS)
        For i = 0 To MAX_CACHED_MAPS
            ReDim MapNpc(i).Npc(MAX_MAP_NPCS)
            ReDim Map(i).Npc(MAX_MAP_NPCS)
        Next

        'quests
        ReDim Quest(MAX_QUESTS)
        ClearQuests()

        'eventos
        ReDim Switches(MAX_SWITCHES)
        ReDim Variables(MAX_VARIABLES)
        ReDim TempEventMap(MAX_CACHED_MAPS)

        'Moradias
        ReDim HouseConfig(MAX_HOUSES)

        For i = 0 To MAX_CACHED_MAPS
            For x = 0 To MAX_MAP_NPCS
                ReDim MapNpc(i).Npc(x).Vital(VitalType.Count)
            Next
        Next

        ReDim Bank(MAX_PLAYERS)
        ReDim Classes(MAX_CLASSES)

        For i = 1 To MAX_PLAYERS
            ReDim Bank(i).Item(MAX_BANK)
            ReDim Bank(i).ItemRand(MAX_BANK)
            For x = 1 To MAX_BANK
                ReDim Bank(i).ItemRand(x).Stat(StatType.Count - 1)
            Next
        Next

        ReDim Player(MAX_PLAYERS)

        For i = 1 To MAX_PLAYERS
            'multi personagens
            ReDim Player(i).Character(MAX_CHARS)
            For x = 1 To MAX_CHARS
                ReDim Player(i).Character(x).Switches(MAX_SWITCHES)
                ReDim Player(i).Character(x).Variables(MAX_VARIABLES)
                ReDim Player(i).Character(x).Vital(VitalType.Count - 1)
                ReDim Player(i).Character(x).Stat(StatType.Count - 1)
                ReDim Player(i).Character(x).Equipment(EquipmentType.Count - 1)
                ReDim Player(i).Character(x).Inv(MAX_INV)
                ReDim Player(i).Character(x).Skill(MAX_PLAYER_SKILLS)
                ReDim Player(i).Character(x).PlayerQuest(MAX_QUESTS)

                ReDim Player(i).Character(x).RandEquip(EquipmentType.Count - 1)
                ReDim Player(i).Character(x).RandInv(MAX_INV)
                For y = 1 To EquipmentType.Count - 1
                    ReDim Player(i).Character(x).RandEquip(y).Stat(StatType.Count - 1)
                Next
                For y = 1 To MAX_INV
                    ReDim Player(i).Character(x).RandInv(y).Stat(StatType.Count - 1)
                Next
            Next
        Next

        ReDim TempPlayer(MAX_PLAYERS)

        For i = 1 To MAX_PLAYERS
            ReDim TempPlayer(i).SkillCd(MAX_PLAYER_SKILLS)
            ReDim TempPlayer(i).PetSkillCd(4)
        Next

        For i = 1 To MAX_PLAYERS
            ReDim TempPlayer(i).TradeOffer(MAX_INV)
        Next

        LoadTilePrefab()

        ReDim Classes(Max_Classes)
        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(StatType.Count - 1)
            ReDim Classes(i).StartItem(5)
            ReDim Classes(i).StartValue(5)
        Next

        For i = 0 To MAX_ITEMS
            ReDim Item(i).Add_Stat(StatType.Count - 1)
            ReDim Item(i).Stat_Req(StatType.Count - 1)
            ReDim Item(i).FurnitureBlocks(3, 3)
            ReDim Item(i).FurnitureFringe(3, 3)
        Next
        ReDim Npc(MAX_NPCS).Stat(StatType.Count - 1)

        ReDim Shop(MAX_SHOPS).TradeItem(MAX_TRADES)

        ReDim Animation(MAX_ANIMATIONS).Sprite(1)
        ReDim Animation(MAX_ANIMATIONS).Frames(1)
        ReDim Animation(MAX_ANIMATIONS).LoopCount(1)
        ReDim Animation(MAX_ANIMATIONS).LoopTime(1)

        ReDim MapProjectiles(MAX_CACHED_MAPS, MAX_PROJECTILES)
        ReDim Projectiles(MAX_PROJECTILES)

        'equipes
        ClearParties()

        'pets
        ReDim Pet(MAX_PETS)
        ClearPets()

        ' Verificar se o diretório existe; caso contrário, fazer
        CheckDir(Path.Database)
        CheckDir(Path.Items)
        CheckDir(Path.Maps)
        CheckDir(Path.Npcs)
        CheckDir(Path.Shops)
        CheckDir(Path.Skills)
        CheckDir(Path.accounts)
        CheckDir(Path.resources)
        CheckDir(Path.Animations)
        CheckDir(Path.logs)
        CheckDir(Path.Quests)
        CheckDir(Path.Recipes)
        CheckDir(Path.Pets)
        CheckDir(Path.Projectiles)
        CheckDir(Path.Quests)

        ' Inicializar rede
        InitNetwork()

        ' Inicializar todas as sockets dos jogadores
        Console.WriteLine("Inicializando vetor de jogadores...")

        For x = 1 To MAX_PLAYERS
            ClearPlayer(x)
        Next

        ' Serve como construtor
        ClearGameData()
        LoadGameData()
        Console.WriteLine("Gerando itens dos mapas...")
        SpawnAllMapsItems()
        Console.WriteLine("Gerando NPCs dos mapas...")
        SpawnAllMapNpcs()

        ' Verificar se a lista com nomes de personagens existe para evitar duplicatas; caso contrário, fazer.
        If Not File.Exists("Dados\Contas\charlist.txt") Then
            F = FreeFile()
        End If

        'Sistema de Recursos
        LoadSkillExp()

        InitTime()

        UpdateCaption()
        time2 = GetTimeMs()

        Console.Clear()
        Console.WriteLine(" _____ _           _                   _   _  _____ _____ ")
        Console.WriteLine("|  ___| |         (_)                 | \ | ||  ___|_   _|")
        Console.WriteLine("| |__ | |_   _ ___ _ _   _ _ __ ___   |  \| || |__   | |  ")
        Console.WriteLine("|  __|| | | | / __| | | | | '_ ` _ \  | . ` ||  __|  | |  ")
        Console.WriteLine("| |___| | |_| \__ \ | |_| | | | | | |_| |\  || |___  | |  ")
        Console.WriteLine("\____/|_|\__, |___/_|\__,_|_| |_| |_(_)_| \_/\____/  \_/  ")
        Console.WriteLine("          __/ |                                           ")
        Console.WriteLine("         |___/                                            ")

        Console.WriteLine("")

        Console.WriteLine("Inicialização completa. Servidor iniciado em " & time2 - time1 & "ms.")
        Console.WriteLine("")
        Console.WriteLine("Use /ajuda para os comandos disponíveis.")

        MyIPAddress = GetIP()

        UpdateCaption()

        ' Resetar valor de desligamento
        isShuttingDown = False

        ' Ativar o listener agora que tudo está carregado
        Socket.StartListening(Settings.Port, 5)

        ' Inicia o loop do servidor
        ServerLoop()

    End Sub

    Private Function ConsoleEventCallback(eventType As Integer) As Boolean
        If eventType = 2 Then
            Console.WriteLine("Janela do console fechando, morte iminente")
            'Limpar e fechar
            DestroyServer()
        End If
        Return False
    End Function

    Private handler As ConsoleEventDelegate

    ' Evita que isso tenha garbage collected

    Private Delegate Function ConsoleEventDelegate(eventType As Integer) As Boolean

    <Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True)>
    Private Function SetConsoleCtrlHandler(callback As ConsoleEventDelegate, add As Boolean) As Boolean
    End Function

    Sub UpdateCaption()
        Console.Title = String.Format("{0} <IP {1}:{2}> ({3} Jogadores Online) - Erros Atuais: {4} - Hora: {5}", Settings.GameName, MyIPAddress, Settings.Port, GetPlayersOnline(), ErrorCount, Time.Instance.ToString())
    End Sub

    Sub DestroyServer()
        Socket.StopListening()

        Console.WriteLine("Salvando jogadores Online...")
        SaveAllPlayersOnline()

        Console.WriteLine("Descarregando jogadores...")
        For i As Integer = 1 To MAX_PLAYERS
            SendLeftGame(i)
            LeftGame(i)
        Next

        DestroyNetwork()
        ClearGameData()

#If DEBUG Then
        Application.Exit()
        Application.ExitThread()
        Process.GetCurrentProcess.Kill()
#Else
        Environment.Exit(0)
#End If
    End Sub

    Friend Sub ClearGameData()
        Console.WriteLine("Limpando campos de tiles temporários...") : ClearTempTiles()
        Console.WriteLine("Limpando Mapas...") : ClearMaps()
        Console.WriteLine("Limpando Itens dos Mapas...") : ClearMapItems()
        Console.WriteLine("Limpando NPCs dos Mapas...") : ClearAllMapNpcs()
        Console.WriteLine("Limpando NPCs...") : ClearNpcs()
        Console.WriteLine("Limpando Recursos...") : ClearResources()
        Console.WriteLine("Limpando Itens...") : ClearItems()
        Console.WriteLine("Limpando Lojas...") : ClearShops()
        Console.WriteLine("Limpando Habilidades...") : ClearSkills()
        Console.WriteLine("Limpando Animações...") : ClearAnimations()
        Console.WriteLine("Limpando Quests...") : ClearQuests()
        Console.WriteLine("Limpando Projéteis do Mapa...") : ClearMapProjectiles()
        Console.WriteLine("Limpando Projéteis...") : ClearProjectiles()
        Console.WriteLine("Limpando Receitas...") : ClearRecipes()
        Console.WriteLine("Limpando Pets...") : ClearPets()
    End Sub

    Private Sub LoadGameData()
        Console.WriteLine("Carregando Classes...") : LoadClasses()
        Console.WriteLine("Carregando Mapas...") : LoadMaps()
        Console.WriteLine("Carregando Itens...") : LoadItems()
        Console.WriteLine("Carregando NPCs...") : LoadNpcs()
        Console.WriteLine("Carregando Recursos...") : LoadResources()
        Console.WriteLine("Carregando Lojas...") : LoadShops()
        Console.WriteLine("Carregando Habilidades...") : LoadSkills()
        Console.WriteLine("Carregando Animações...") : LoadAnimations()
        Console.WriteLine("Carregando Quests...") : LoadQuests()
        Console.WriteLine("Carregando Configuração de Casas...") : LoadHouses()
        Console.WriteLine("Carregando Switches...") : LoadSwitches()
        Console.WriteLine("Carregando Variáveis...") : LoadVariables()
        Console.WriteLine("Gerando eventos globais...") : SpawnAllMapGlobalEvents()
        Console.WriteLine("Carregando Projéteis...") : LoadProjectiles()
        Console.WriteLine("Carregando Receitas...") : LoadRecipes()
        Console.WriteLine("Carregando Pets...") : LoadPets()
    End Sub

    ' Usado para verificar a validade dos nomes
    Function IsNameLegal(sInput As Integer) As Boolean

        If (sInput >= 65 AndAlso sInput <= 90) OrElse (sInput >= 97 AndAlso sInput <= 122) OrElse (sInput = 95) OrElse (sInput = 32) OrElse (sInput >= 48 AndAlso sInput <= 57) Then
            Return True
        Else
            Return False
        End If

    End Function

    Friend Sub CheckDir(path As String)
        If Not Directory.Exists(path) Then Directory.CreateDirectory(path)
    End Sub

    Sub ErrorHandler(sender As Object, args As UnhandledExceptionEventArgs)
        Dim e As Exception = DirectCast(args.ExceptionObject, Exception)
        Dim myFilePath As String = Path.Logs & "ErrorLog.log"

        Using sw As New StreamWriter(File.Open(myFilePath, FileMode.Append))
            sw.WriteLine(DateTime.Now)
            sw.WriteLine(GetExceptionInfo(e))
        End Using

        ErrorCount = ErrorCount + 1

        UpdateCaption()
    End Sub

    Friend Function GetExceptionInfo(ex As Exception) As String
        Dim Result As String
        Dim hr As Integer = Runtime.InteropServices.Marshal.GetHRForException(ex)
        Result = ex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine
        Dim st As New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                Result &= "Linha:" & sf.GetFileLineNumber() & " Arquivo: " & System.IO.Path.GetFileName(sf.GetFileName) & Environment.NewLine
            End If
        Next
        Return Result
    End Function
#If DEBUG Then
    Friend Sub AddDebug(Msg As String)
        If DebugTxt = True Then
            Addlog(Msg, PACKET_LOG)
            Console.WriteLine(Msg)
        End If

    End Sub
#End If
End Module