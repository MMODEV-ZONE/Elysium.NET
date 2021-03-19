Module S_RandomItems

    Friend Sub ClearRandBank(index As Integer, BankNum As Integer)
        Dim i As Integer

        Bank(index).Item(BankNum).Prefix = ""
        Bank(index).Item(BankNum).Suffix = ""
        Bank(index).Item(BankNum).Damage = 0
        Bank(index).Item(BankNum).Speed = 0
        Bank(index).Item(BankNum).Rarity = 0

        For i = 1 To StatType.Count - 1
            Bank(index).Item(BankNum).Stat(i) = 0
        Next i
    End Sub

    Friend Sub ClearRandInv(index As Integer, InvNum As Integer)
        Dim i As Integer

        Player(index).Character(TempPlayer(index).CurChar).Inv(InvNum).Prefix = ""
        Player(index).Character(TempPlayer(index).CurChar).Inv(InvNum).Suffix = ""
        Player(index).Character(TempPlayer(index).CurChar).Inv(InvNum).Damage = 0
        Player(index).Character(TempPlayer(index).CurChar).Inv(InvNum).Speed = 0
        Player(index).Character(TempPlayer(index).CurChar).Inv(InvNum).Rarity = 0

        For i = 1 To StatType.Count - 1
            Player(index).Character(TempPlayer(index).CurChar).Inv(InvNum).Stat(i) = 0
        Next i
    End Sub

    Friend Sub ClearRandEq(index As Integer, Equipment As EquipmentType)
        Dim i As Integer

        Player(index).Character(TempPlayer(index).CurChar).Equipment(Equipment).Prefix = ""
        Player(index).Character(TempPlayer(index).CurChar).Equipment(Equipment).Suffix = ""
        Player(index).Character(TempPlayer(index).CurChar).Equipment(Equipment).Damage = 0
        Player(index).Character(TempPlayer(index).CurChar).Equipment(Equipment).Speed = 0
        Player(index).Character(TempPlayer(index).CurChar).Equipment(Equipment).Rarity = 0

        For i = 1 To StatType.Count - 1
            Player(index).Character(TempPlayer(index).CurChar).Equipment(Equipment).Stat(i) = 0
        Next i
    End Sub

    Friend Sub GivePlayerRandomItem(index As Integer, itemnum As Integer, invslot As Integer)
        Dim RandomType As Integer, StatAmount As Integer, Rarity As Integer, TempNum As Integer, TempAmount As Double, i As Integer, ItemLevel As Integer
        Dim Prefix As String = ""
        'Verificar se estamos fora de alcance ou se o item não é aleatório
        If itemnum < 1 OrElse itemnum > MAX_ITEMS Then Exit Sub
        If index < 1 OrElse index > MAX_PLAYERS Then Exit Sub
        If Item(itemnum).Randomize = 0 Then Exit Sub

        ' See what rarity we get
        TempNum = Random(1, 100)
        If TempNum >= 95 Then
            Rarity = RarityType.RARITY_EPIC
            TempAmount = 0.5
            Prefix = "Épico "
        ElseIf TempNum >= 80 AndAlso TempNum < 95 Then
            Rarity = RarityType.RARITY_RARE
            TempAmount = 0.35
            Prefix = "Raro "
        ElseIf TempNum >= 60 AndAlso TempNum < 80 Then
            Rarity = RarityType.RARITY_UNCOMMON
            TempAmount = 0.2
            Prefix = "Comum "
        ElseIf TempNum >= 20 AndAlso TempNum < 60 Then
            Rarity = RarityType.RARITY_COMMON
            TempAmount = 0
        Else
            Rarity = RarityType.RARITY_BROKEN
            RandomType = RandomBonusType.RANDOM_BROKEN
            Prefix = "Quebrado "
        End If

        'Temos raridade! Determinar o tipo do encanto
        If Rarity <> RarityType.RARITY_BROKEN Then
            RandomType = Random(1, MAX_RANDOM_TYPES)
        End If

        ' Setar o nível do item para referencia mais fácil 
        ItemLevel = Item(itemnum).ItemLevel

        ' Setar o StatAmount bônus
        StatAmount = ItemLevel * TempAmount
        If StatAmount < 4 AndAlso Rarity = RarityType.RARITY_EPIC Then StatAmount = 4
        If StatAmount < 3 AndAlso Rarity = RarityType.RARITY_RARE Then StatAmount = 3
        If StatAmount < 2 AndAlso Rarity = RarityType.RARITY_UNCOMMON Then StatAmount = 2

        ' Dar item baseado no tipo
        Select Case RandomType
            Case RandomBonusType.RANDOM_SPEED
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " da Velocidade"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed - (Item(itemnum).Speed * TempAmount)
            Case RandomBonusType.RANDOM_DAMAGE
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Dano"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                If TempAmount < 1 Then TempAmount = 1
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2 + (Item(itemnum).Data2 * TempAmount)
            Case RandomBonusType.RANDOM_WARRIOR
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Guerreiro"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Strength) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Endurance) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_ARCHER
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Arqueiro"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Spirit) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Endurance) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_MAGE
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Mago"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Intelligence) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Endurance) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_JESTER
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Bobo-da-corte"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Intelligence) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Spirit) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_BATTLEMAGE
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Mago de Batalha"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Strength) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Intelligence) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_ROGUE
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Vampiro"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Strength) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Spirit) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_TOWER
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " da Torre"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Endurance) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_SURVIVALIST
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " da Sobrevivência"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(ResourceSkills.Fisherman) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_PERFECTIONIST
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " da Perfeição"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(ResourceSkills.Miner) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_COALMEN
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Mineiro"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(ResourceSkills.Miner) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(ResourceSkills.WoodCutter) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_BOWYER
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Arqueador"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(ResourceSkills.WoodCutter) = ItemLevel + StatAmount
            Case RandomBonusType.RANDOM_BROKEN
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = "Quebrado "
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = ""
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = RarityType.RARITY_BROKEN
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2 - (Item(itemnum).Data2 / 10)
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed + (Item(itemnum).Speed / 10)
            Case RandomBonusType.RANDOM_PRISM
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Prisma"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                For i = 1 To 4
                    Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(Random(1, StatType.Count - 1)) = ItemLevel + StatAmount
                Next
            Case RandomBonusType.RANDOM_CANNON
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Prefix = Prefix
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Suffix = " do Canhão"
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Rarity = Rarity
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Damage = Item(itemnum).Data2
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Speed = Item(itemnum).Speed
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Strength) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Intelligence) = ItemLevel + StatAmount
                Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Stat(StatType.Spirit) = ItemLevel + StatAmount
        End Select
    End Sub

End Module