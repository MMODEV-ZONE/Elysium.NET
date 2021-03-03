Namespace Path
    Friend Module modPaths

        ''' <summary> Retorna o diretório do aplicativo </summary>
        Friend ReadOnly Property Local As String
            Get
                Return Application.StartupPath() & "/"
            End Get
        End Property

        ''' <summary> Retorna o diretório de conteúdos </summary>
        Friend ReadOnly Property Contents As String
            Get
                Return Application.StartupPath() & "\Dados\"
            End Get
        End Property

        ''' <summary> Retorna o diretório do banco de dados </summary>
        Friend ReadOnly Property Database As String
            Get
                Return Application.StartupPath() & "\Dados\"
            End Get
        End Property

        ''' <summary> Retorna o diretório de configuração </summary>
        Friend ReadOnly Property Config As String
            Get
                Return Application.StartupPath() & "/Dados/"
            End Get
        End Property


        '############################
        '###  Diretórios exclusivos  ###
        '############################

#If CLIENT Then

        ''' <summary> Retorna o diretório gráfico </summary>
        Friend ReadOnly Property Graphics As String
            Get
                Return Contents & "\Graficos\"
            End Get
        End Property

        ''' <summary> Retorna o diretório gui </summary>
        Friend ReadOnly Property Gui As String
            Get
                Return Contents & "\Interface\"
            End Get
        End Property

        ''' <summary> Retorna o diretório de músicas </summary>
        Friend ReadOnly Property Music As String
            Get
                Return Contents & "\Audio\Musicas\"
            End Get
        End Property

        ''' <summary> Retorna o diretório de sons </summary>
        Friend ReadOnly Property Sounds As String
            Get
                Return Contents & "\Audio\Efeitos\"
            End Get
        End Property

#ElseIf SERVER Then

        ''' <summary> Retorna diretório de contas </summary>
        Friend ReadOnly Property Accounts As String
            Get
                Return Application.StartupPath() & "/Dados/Contas/"
            End Get
        End Property

        ''' <summary> Retorna arquivo de contas </summary>
        Friend Function Account(index As Integer) As String
            Return Accounts & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de animações </summary>
        Friend ReadOnly Property Animations As String
            Get
                Return Application.StartupPath() & "/Dados/Animados/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de animações </summary>
        Friend Function Animation(index As Integer) As String
            Return Animations & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de itens </summary>
        Friend ReadOnly Property Items As String
            Get
                Return Application.StartupPath() & "/Dados/Itens/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de itens </summary>
        Friend Function Item(index As Integer) As String
            Return Items & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de logs </summary>
        Friend ReadOnly Property Logs As String
            Get
                Return Application.StartupPath() & "/Logs/"
            End Get
        End Property

        ''' <summary> Retorna diretório de mapas </summary>
        Friend ReadOnly Property Maps As String
            Get
                Return Application.StartupPath() & "/Dados/Mapas/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de mapas </summary>
        Friend Function Map(index As Integer) As String
            Return Maps & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de npcs </summary>
        Friend ReadOnly Property Npcs As String
            Get
                Return Application.StartupPath() & "/Dados/Npcs/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de npcs </summary>
        Friend Function Npc(index As Integer) As String
            Return Npcs() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de pets </summary>
        Friend ReadOnly Property Pets As String
            Get
                Return Application.StartupPath() & "/Dados/Pets/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de pets </summary>
        Friend Function Pet(index As Integer) As String
            Return Pets() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de projeteis </summary>
        Friend ReadOnly Property Projectiles As String
            Get
                Return Application.StartupPath() & "/Dados/Projeteis/"
            End Get
        End Property

        ''' <summary> Retorna arquivo de projeteis </summary>
        Friend Function Projectile(index As Integer) As String
            Return Projectiles() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de quests </summary>
        Friend ReadOnly Property Quests As String
            Get
                Return Application.StartupPath() & "/Dados/Tarefas/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de quests </summary>
        Friend Function Quest(index As Integer) As String
            Return Quests() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de receitas </summary>
        Friend ReadOnly Property Recipes As String
            Get
                Return Application.StartupPath() & "/Dados/Receitas/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de receitas </summary>
        Friend Function Recipe(index As Integer) As String
            Return Recipes() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de recursous </summary>
        Friend ReadOnly Property Resources As String
            Get
                Return Application.StartupPath() & "/Dados/Recursos/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de recursos </summary>
        Friend Function Resource(index As Integer) As String
            Return Resources() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de lojas </summary>
        Friend ReadOnly Property Shops As String
            Get
                Return Application.StartupPath() & "/Dados/Lojas/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de lojas </summary>
        Friend Function Shop(index As Integer) As String
            Return Shops() & index & ".dat"
        End Function

        ''' <summary> Retorna diretório de habilidades </summary>
        Friend ReadOnly Property Skills As String
            Get
                Return Application.StartupPath() & "/Dados/Habilidades/"
            End Get
        End Property

        ''' <summary> Retorna arquivos de habilidades </summary>
        Friend Function Skill(index As Integer) As String
            Return Skills() & index & ".dat"
        End Function

#End If

    End Module
End Namespace