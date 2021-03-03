Imports System.IO
Imports ASFW.IO.Serialization

#If CLIENT Then
Public Class LanguageDef

    Public Load As New LoadDef
    Public Class LoadDef

        Public Loading As String = "Carregando..."
        Public Graphics As String = "Iniciando Graficos..."
        Public Network As String = "Conectando na rede..."
        Public Starting As String = "Jogo iniciando..."

    End Class

    Public MainMenu As New MainMenuDef
    Public Class MainMenuDef

        ' TEXTO PRINCIPAL
        Public ServerStatus As String = "Estado do servidor:"
        Public ServerOnline As String = "Online"
        Public ServerReconnect As String = "Reconectando..."
        Public ServerOffline As String = "Offline"
        Public ButtonPlay As String = "Entrar"
        Public ButtonRegister As String = "Criar Nova Conta"
        Public ButtonCredits As String = "Creditos"
        Public ButtonExit As String = "Sair"
        Public NewsHeader As String = "Últimas Noticias"
        Public News As String = "Bem-vindo ao cliente da Elysium.NET. Esse é um motor de jogos gratuito e open source. Precisa de ajuda OU suporte? Visite nosso website em http://www.mmodev.com.br/"

        ' TEXTO DE LOGIN
        Public Login As String = "Login"
        Public LoginName As String = "Usuário "
        Public LoginPass As String = "Senha "
        Public LoginCheckBox As String = "Salvar senha?"
        Public LoginButton As String = "Entrar"

        ' TEXTO DE NOVO PERSONAGEM
        Public NewCharacter As String = "Criar personagem"
        Public NewCharacterName As String = "Nome: "
        Public NewCharacterClass As String = "Classe: "
        Public NewCharacterGender As String = "Sexo: "
        Public NewCharacterMale As String = "Masculino"
        Public NewCharacterFemale As String = "Feminino"
        Public NewCharacterSprite As String = "Sprite"
        Public NewCharacterButton As String = "cRIAR"

        ' TEXTO DE SELEÇÃO DE PERSONAGENS
        Public UseCharacter As String = "Seleção de Personagem"
        Public UseCharacterNew As String = "Novo"
        Public UseCharacterUse As String = "Selecionar"
        Public UseCharacterDel As String = "Deletar"

        ' TEXTO DE REGISTRO DA CONTA
        Public RegisterName As String = "Usuário "
        Public RegisterPass As String = "Senha "
        Public RetypeRegisterPass As String = "Re-digite a senha "

        ' TEXTO DE CREDITOS
        Public Credits As String = "Créditos"

        ' TEXTOS DIVERSOS
        Public StringLegal As String = "Você não pode usar caracteres ASCII em seu nome, digite novamente."
        Public SendLogin As String = "Conectado, logando na seleção de personagem..."
        Public SendNewCharacter As String = "Conectado, selecionando personagem..."
        Public SendRegister As String = "Conectado, concluindo registro..."
        Public ConnectToServer As String = "Conectando ao servidor ({0}) ..."

    End Class

    Public Game As New GameDef
    Public Class GameDef

        Public MapName As String = "Mapa: "
        Public Time As String = "Hora: "
        Public Fps As String = "Fps: "
        Public Lps As String = "Lps: "

        Public Ping As String = "Ping: "
        Public PingSync As String = "Sync"
        Public PingLocal As String = "Local"

        Public MapReceive As String = "Carregando mapa..."
        Public DataReceive As String = "Carregando dados..."

        Public MapCurMap As String = "Mapa # {0}"
        Public MapCurLoc As String = "Localização() x: {0} y: {1}"
        Public MapLoc As String = "Localizacao Atual x: {0} y: {1}"

    End Class

    Public Chat As New ChatDef
    Public Class ChatDef

        ' Universal
        Public Emote As String = "Digite: /emote [1-11]"
        Public Info As String = "Digite: /info [jogador]"
        Public Party As String = "Digite: /equipe [jogador]"
        Public PlayerMsg As String = "Digite: ![jogador] [message]"
        Public HouseInvite As String = "Digite: /convidarmoradia [jogador]"
        Public InvalidCmd As String = "Comando inválido."
        Public Help1 As String = "Comandos sociais: "
        Public Help2 As String = "'[mensagem] = Mensagem global"
        Public Help3 As String = "-[mensagem] = Mensagem para a equipe"
        Public Help4 As String = "![jogador] [mensagem] = Mensagem direta"
        Public Help5 As String = "Comandos úteis: /ajuda, /info, 
                                  /quem, /fps, /lps, /atributos, /troca, 
                                  /equipe, /entrar, /sair, /vendermoradia, 
                                  /convidarmoradia"

        ' Apenas admin
        Public AccessAlert As String = "Você não tem permissão necessaria..."
        Public AdminGblMsg As String = "''msgaqui = Mensagem global como administrador"
        Public AdminPvtMsg As String = "= msgaqui = Mensagem privada como administrador"
        Public Admin1 As String = "Comandos sociais:"
        Public Admin2 As String = "Comandos úteis /admin, /loc, 
                                   /melevarpara, /metraga, /irpara, 
                                   /sprite, /mapreport, /chutar, 
                                   /banir, /respawn, /boasvindas, /resetartarefa"

        Public Welcome As String = "Digite: /boasvindas [mensagem]"
        Public Access As String = "Digite: /acesso [jogador] [acesso]"
        Public Sprite As String = "Digite: /sprite [index]"
        Public Kick As String = "Digite: /chutar [jogador]"
        Public Ban As String = "Digite: /banir [jogador]"

        Public WarpMeTo As String = "Digite: /melevarpara [jogador]"
        Public WarpToMe As String = "Digite: /metraga [jogador]"
        Public WarpTo As String = "Digite: /irpara [índice do mapa]"

        Public ResetQuest As String = "Digite: /resetartarefa [índice]"

        Public InvalidMap As String = "Mapa inválido..."
        Public InvalidQuest As String = "Tarefa inválida..."

    End Class

    Public ItemDescription As New ItemDescriptionDef
    Public Class ItemDescriptionDef

        Public NotAvailable As String = "Não é possível"
        Public None As String = "Zero"
        Public Seconds As String = "Segundos"

        Public Currency As String = "Moeda"
        Public Key As String = "Chave"
        Public Furniture As String = "Móveis"
        Public Potion As String = "Poção"
        Public Skill As String = "Habilidades"

        Public Weapon As String = "Equipamento"
        Public Armor As String = "Armadura"
        Public Helmet As String = "Capacete"
        Public Shield As String = "Escudo"
        Public Shoes As String = "Calçados"
        Public Gloves As String = "Luvas"

        Public Amount As String = "Quantidade: "
        Public Restore As String = "Restaurar quantidade: "
        Public Damage As String = "Dano: "
        Public Defense As String = "Defesa: "

    End Class

    Public SkillDescription As New SkillDescriptionDef
    Public Class SkillDescriptionDef

        Public No As String = "Não"
        Public None As String = "Nenhum"
        Public Warp As String = "Teletransporte"
        Public Tiles As String = "Tiles"
        Public SelfCast As String = "Uso próprio"

        Public Gain As String = "Ganho: "
        Public GainHp As String = "Ganho de PV"
        Public GainMp As String = "Ganho de PM"
        Public Lose As String = "Perdendo: "
        Public LoseHp As String = "Perda de PV"
        Public LoseMp As String = "Perda de PM"

    End Class

    Public Crafting As New CraftingDef
    Public Class CraftingDef

        Public NotEnough As String = "Materiais insuficientes!"
        Public NotSelected As String = "Nada selecionado"

    End Class

    Public Trade As New TradeDef
    Public Class TradeDef

        Public Request As String = "{0} está solicitando uma troca."
        Public Timeout As String = "Você demorou muito para decidir. Por favor, tente novamente."

        Public Value As String = "Valor total: {0}g"

        Public StatusOther As String = "Outro jogador aceitou a oferta."
        Public StatusSelf As String = "Você aceitou a oferta."

    End Class

    Public Events As New EventDef
    Public Class EventDef

        Public OptContinue = "- Continuar -"

    End Class

    Public Quest As New QuestDef
    Public Class QuestDef

        Public Cancel As String = "Cancela a tarefa iniciada"
        Public Started As String = "Inicia Tarefa"
        Public Completed As String = "Tarefa completada"

        ' Quest Types
        Public Slay As String = "Mate {0}/{1} {2}."
        Public Collect As String = "Colete {0}/{1} {2}."
        Public Talk As String = "Fale com {0}."
        Public Reach As String = "Vá para {0}."
        Public TurnIn As String = "De {0} para {1} {2}/{3}, conforme pedido."
        Public Kill As String = "Mate {0}/{1} jogadores no combate."
        Public Gather As String = "Reuna {0}/{1} {2}."
        Public Fetch As String = "Busque {0} X {1} do {2}."

    End Class

    Public Character As New CharacterDef
    Public Class CharacterDef

        Public Name As String = "Nome: "
        Public ClassType As String = "Classe: "
        Public Level As String = "Nível: "
        Public Exp As String = "Exp: "

        Public StatsLabel As String = "== Atributos =="
        Public Strength As String = "Força: "
        Public Endurance As String = "Resistência: "
        Public Vitality As String = "Vitalidade: "
        Public Intelligence As String = "Inteligência: "
        Public Luck As String = "Sorte: "
        Public Spirit As String = "Espírito: "
        Public Points As String = "Pontos Disponíveis: "

        Public SkillLabel As String = "== Nível da Habilidade =="
        Public Herbalist As String = "Herborista: "
        Public Woodcutter As String = "Lenhador: "
        Public Miner As String = "Mineiração: "
        Public Fisherman As String = "Pescaria: "

    End Class
End Class

Friend Module modLanguage
    Public Language As New LanguageDef

    Friend Sub LoadLanguage()
        Dim cf As String = Path.Config() & "\Languages\"
        If Not Directory.Exists(cf) Then
            Directory.CreateDirectory(cf)
        End If : cf = cf & Settings.Language & ".xml"

        If Not File.Exists(cf) Then
            File.Create(cf).Dispose()
            ASFW.IO.Serialization.SaveXml(Of LanguageDef)(cf, New LanguageDef)
        End If : Language = ASFW.IO.Serialization.LoadXml(Of LanguageDef)(cf)
    End Sub
End Module
#End If