Friend Module modEnumerators

    ''' <Summary> Constantes de Cores de Textos  </Summary>
    Enum ColorType As Byte
        Black
        Blue
        Green
        Cyan
        Red
        Magenta
        Brown
        Gray
        DarkGray
        BrightBlue
        BrightGreen
        BrightCyan
        BrightRed
        Pink
        Yellow
        White
    End Enum

    ''' <Summary> Acesso Rápido/Referencias de Cor  </Summary>
    Enum QColorType As Byte
        SayColor = ColorType.White
        GlobalColor = ColorType.BrightBlue
        BroadcastColor = ColorType.White
        TellColor = ColorType.BrightGreen
        EmoteColor = ColorType.BrightCyan
        AdminColor = ColorType.BrightCyan
        HelpColor = ColorType.BrightBlue
        WhoColor = ColorType.BrightBlue
        JoinLeftColor = ColorType.Gray
        NpcColor = ColorType.Brown
        AlertColor = ColorType.BrightRed
        NewMapColor = ColorType.BrightBlue
    End Enum

    ''' <Summary> Constantes Sexuais </Summary>
    Enum SexType As Byte
        Male
        Female
    End Enum

    ''' <Summary> Consntantes de Moral do Mapa </Summary>
    Enum MapMoralType As Byte
        None
        Safe
        Indoors
    End Enum

    ''' <Summary> Constantes de Tile </Summary>
    Enum TileType As Byte
        None
        Blocked
        Warp
        Item
        NpcAvoid
        Key
        KeyOpen
        Resource
        Door
        NpcSpawn
        Shop
        Bank
        Heal
        Trap
        House
        Craft
        Light

        Count
    End Enum

    ''' <Summary> Constante de Item </Summary>
    Enum ItemType As Byte
        None
        Equipment
        Consumable
        Key
        Currency
        Skill
        Furniture
        Recipe
        Pet

        Count
    End Enum

    ''' <Summary> Constantes de Consumíveis </Summary>
    Enum ConsumableType As Byte
        Hp
        Mp
        Sp
        Exp
    End Enum

    ''' <Summary> Constantes de Direção </Summary>
    Enum DirectionType As Byte
        Up
        Down
        Left
        Right
    End Enum

    ''' <Summary> Constantes de Movimento </Summary>
    Enum MovementType As Byte
        Standing
        Walking
        Running
    End Enum

    ''' <Summary> Constantes de Admin </Summary>
    Enum AdminType As Byte
        Player
        Monitor
        Mapper
        Developer
        Creator
    End Enum

    ''' <Summary> Constantes de Comportamento de NPC </Summary>
    Enum NpcBehavior As Byte
        AttackOnSight
        AttackWhenAttacked
        Friendly
        ShopKeeper
        Guard
        Quest
    End Enum

    ''' <Summary> Constantes de Habilidades </Summary>
    Enum SkillType As Byte
        DamageHp
        DamageMp
        HealHp
        HealMp
        Warp
        Pet
    End Enum

    ''' <Summary> Constantes de Alvos </Summary>
    Enum TargetType As Byte
        None
        Player
        Npc
        [Event]
        Pet
    End Enum

    ''' <Summary> Constantes de Mensagem de Ação </Summary>
    Enum ActionMsgType As Byte
        [Static]
        Scroll
        Screen
    End Enum

    ''' <Summary> Atributos usados por Jogadores, Classes e NPCs </Summary>
    Friend Enum StatType As Byte
        Strength = 1
        Endurance
        Vitality
        Luck
        Intelligence
        Spirit

        Count
    End Enum

    ''' <Summary> Vitais usados por Jogadores, Classes e NPCs </Summary>
    Friend Enum VitalType As Byte
        HP = 1
        MP
        SP

        Count
    End Enum

    ''' <Summary> Equipamentos usados por jogadores </Summary>
    Friend Enum EquipmentType As Byte
        Weapon = 1
        Armor
        Helmet
        Shield
        Shoes
        Gloves

        Count
    End Enum

    ''' <Summary> Camadas em um mapa </Summary>
    Friend Enum LayerType As Byte
        Ground = 1
        Mask
        Mask2
        Fringe
        Fringe2

        Count
    End Enum

    ''' <Summary> Habilidades de Recursos </Summary>
    Friend Enum ResourceSkills As Byte
        Herbalist = 1
        WoodCutter
        Miner
        Fisherman

        Count
    End Enum

    Friend Enum RandomBonusType
        RANDOM_SPEED = 1            ' Reduz tempo entre ataques em 20%
        RANDOM_DAMAGE        ' Aumenta dano base em 25%
        RANDOM_WARRIOR         ' Adiciona força e resistencia
        RANDOM_ARCHER        ' Adiciona Arquearia e Resistencia
        RANDOM_MAGE          ' Adiciona Magia e Resistencia
        RANDOM_JESTER         ' Adiciona Magia e Arquearia
        RANDOM_BATTLEMAGE     ' Adiciona Ataque e Magia
        RANDOM_ROGUE         ' Adiciona Ataque e Arquearia
        RANDOM_TOWER           ' Adiciona Resistencia e Defesa
        RANDOM_SURVIVALIST     ' Adiciona Cozinha e Pescaria
        RANDOM_PERFECTIONIST   ' Adiciona Mineração e Joalheria
        RANDOM_COALMEN         ' Adiciona Mineração e Forja
        RANDOM_BOWYER          ' Adiciona Lenhadoria e Fazedor-de-Flecharia
        RANDOM_BROKEN          ' Reduz dano e aumenta velocidade em 10% 
        RANDOM_PRISM           ' Quatro atributos aleatorios
        RANDOM_CANNON          ' Dá ataque, alcance e magia
    End Enum

    Friend Enum RarityType
        RARITY_BROKEN = 1
        RARITY_COMMON
        RARITY_UNCOMMON
        RARITY_RARE
        RARITY_EPIC
    End Enum

    Friend Enum WeatherType
        None
        Rain
        Snow
        Hail
        Sandstorm
        Storm
        Fog
    End Enum

    Friend Enum QuestType
        Slay = 1
        Collect
        Talk
        Reach
        Give
        Kill
        Gather
        Fetch
        TalkEvent
    End Enum

    Friend Enum QuestStatusType
        NotStarted
        Started
        Completed
        Repeatable
    End Enum

End Module