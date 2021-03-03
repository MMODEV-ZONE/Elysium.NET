Imports System.IO
Imports ASFW
Imports ASFW.IO.FileIO

Friend Module modCrafting

#Region "Globals"
    Friend Recipe(MAX_RECIPE) As RecipeRec

    Friend Const RecipeType_Herb As Byte = 0
    Friend Const RecipeType_Wood As Byte = 1
    Friend Const RecipeType_Metal As Byte = 2
#End Region

#Region "Database"

    Sub CheckRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            If Not File.Exists(Path.Recipe(i)) Then
                SaveRecipe(i)
                Application.DoEvents()
            End If
        Next

    End Sub

    Sub SaveRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            SaveRecipe(i)
            Application.DoEvents()
        Next

    End Sub

    Sub SaveRecipe(RecipeNum As Integer)
        Dim filename As String
        'Dim i As Integer

        filename = Path.Recipe(RecipeNum)

        SaveObject(Recipe(RecipeNum), filename)
    End Sub

    Sub LoadRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            LoadRecipe(i)
            Application.DoEvents()
        Next

    End Sub

    Sub LoadRecipe(RecipeNum As Integer)
        Dim filename As String

        CheckRecipes()

        filename = Path.Recipe(RecipeNum)

        LoadObject(Recipe(RecipeNum), filename)
    End Sub

    Sub ClearRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            ClearRecipe(i)
            Application.DoEvents()
        Next

    End Sub

    Sub ClearRecipe(Num As Integer)
        Recipe(Num).Name = ""
        Recipe(Num).RecipeType = 0
        Recipe(Num).MakeItemNum = 0
        Recipe(Num).MakeItemAmount = 0
        Recipe(Num).CreateTime = 0
        ReDim Recipe(Num).Ingredients(MAX_INGREDIENT)
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_RequestRecipes(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CRequestRecipes")
#End If

        SendRecipes(index)
    End Sub

    Sub Packet_RequestEditRecipes(index As Integer, ByRef data() As Byte)
        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        Dim Buffer = New ByteStream(4)
        Buffer.WriteInt32(ServerPackets.SRecipeEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)
#If DEBUG Then
        AddDebug("Enviada SMSG: SRecipeEditor")
#End If
        Buffer.Dispose()

    End Sub

    Sub Packet_SaveRecipe(index As Integer, ByRef data() As Byte)
        Dim n As Integer

        ' Prevenir hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida EMSG: SaveRecipe")
#End If
        'Índice da receita
        n = buffer.ReadInt32

        ' Update the Recipe
        Recipe(n) = DeserializeData(buffer)

        'Salvar
        SaveRecipe(n)

        'Enviar a todos
        SendUpdateRecipeToAll(n)

        buffer.Dispose()

    End Sub

    Sub Packet_CloseCraft(index As Integer, ByRef data() As Byte)
#If DEBUG Then
        AddDebug("Recebida CMSG: CCloseCraft")
#End If
        TempPlayer(index).IsCrafting = False
    End Sub

    Sub Packet_StartCraft(index As Integer, ByRef data() As Byte)
        Dim recipeindex As Integer, amount As Integer
        Dim buffer As New ByteStream(data)
#If DEBUG Then
        AddDebug("Recebida CMSG: CStartCraft")
#End If
        recipeindex = buffer.ReadInt32
        amount = buffer.ReadInt32

        If TempPlayer(index).IsCrafting = False Then Exit Sub

        If recipeindex = 0 OrElse amount = 0 Then Exit Sub

        If Not CheckLearnedRecipe(index, recipeindex) Then Exit Sub

        StartCraft(index, recipeindex, amount)

        buffer.Dispose()

    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendRecipes(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_RECIPE

            If Len(Trim$(Recipe(i).Name)) > 0 Then
                SendUpdateRecipeTo(index, i)
            End If

        Next

    End Sub

    Sub SendUpdateRecipeTo(index As Integer, RecipeNum As Integer)
        Dim buffer As ByteStream ', i As Integer
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateRecipe)
        buffer.WriteInt32(RecipeNum)
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateRecipe")
#End If
        buffer.WriteBlock(SerializeData(Recipe(RecipeNum)))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendUpdateRecipeToAll(RecipeNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateRecipe)
        buffer.WriteInt32(RecipeNum)
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateRecipe Para Todos")
#End If

        buffer.WriteBlock(SerializeData(Recipe(RecipeNum)))

        SendDataToAll(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendPlayerRecipes(index As Integer)
        Dim i As Integer
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SSendPlayerRecipe)
#If DEBUG Then
        AddDebug("Enviada SMSG: SSendPlayerRecipe")
#End If
        For i = 1 To MAX_RECIPE
            buffer.WriteInt32(Player(index).Character(TempPlayer(index).CurChar).RecipeLearned(i))
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendOpenCraft(index As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SOpenCraft)
#If DEBUG Then
        AddDebug("Enviada SMSG: SOpenCraft")
#End If
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendCraftUpdate(index As Integer, done As Byte)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateCraft)
#If DEBUG Then
        AddDebug("Enviada SMSG: SUpdateCraft")
#End If
        buffer.WriteInt32(done)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

#End Region

#Region "Functions"

    Friend Function CheckLearnedRecipe(index As Integer, RecipeNum As Integer) As Boolean
        CheckLearnedRecipe = False

        If Player(index).Character(TempPlayer(index).CurChar).RecipeLearned(RecipeNum) = 1 Then
            CheckLearnedRecipe = True
        End If
    End Function

    Friend Sub LearnRecipe(index As Integer, RecipeNum As Integer, InvNum As Integer)
        If CheckLearnedRecipe(index, RecipeNum) Then ' já conhecemos esta
            PlayerMsg(index, "Você já conhece esta receita!", ColorType.BrightRed)
        Else ' caso contrário, vamos aprender
            Player(index).Character(TempPlayer(index).CurChar).RecipeLearned(RecipeNum) = 1

            PlayerMsg(index, "Você aprendeu a receita " & Recipe(RecipeNum).Name & "!", ColorType.BrightGreen)

            TakeInvItem(index, GetPlayerInvItemNum(index, InvNum), 0)

            SavePlayer(index)
            SendPlayerData(index)
        End If
    End Sub

    Friend Sub StartCraft(index As Integer, RecipeNum As Integer, Amount As Integer)

        If TempPlayer?(index).IsCrafting Then
            TempPlayer(index).CraftRecipe = RecipeNum
            TempPlayer(index).CraftAmount = Amount

            TempPlayer(index).CraftTimer = GetTimeMs()
            TempPlayer(index).CraftTimeNeeded = Recipe(RecipeNum).CreateTime

            TempPlayer(index).CraftIt = 1
        End If

    End Sub

    Friend Sub UpdateCraft(index As Integer)
        Dim i As Integer

        'certo, fizemos o item, dar o item e tomar os ingredientes
        If GiveInvItem(index, Recipe(TempPlayer(index).CraftRecipe).MakeItemNum, Recipe(TempPlayer(index).CraftRecipe).MakeItemAmount, True) Then
            For i = 1 To MAX_INGREDIENT
                TakeInvItem(index, Recipe(TempPlayer(index).CraftRecipe).Ingredients(i).ItemNum, Recipe(TempPlayer(index).CraftRecipe).Ingredients(i).Value)
            Next
            PlayerMsg(index, "Você criou " & Trim(Item(Recipe(TempPlayer(index).CraftRecipe).MakeItemNum).Name) & " X " & Recipe(TempPlayer(index).CraftRecipe).MakeItemAmount, ColorType.BrightGreen)
        End If

        If TempPlayer?(index).IsCrafting Then
            TempPlayer(index).CraftAmount = TempPlayer(index).CraftAmount - 1

            If TempPlayer(index).CraftAmount > 0 Then
                TempPlayer(index).CraftTimer = GetTimeMs()
                TempPlayer(index).CraftTimeNeeded = Recipe(TempPlayer(index).CraftRecipe).CreateTime

                TempPlayer(index).CraftIt = 1

                SendCraftUpdate(index, 0)
            End If

            SendCraftUpdate(index, 1)
        End If

    End Sub

#End Region

End Module