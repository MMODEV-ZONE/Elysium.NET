﻿Imports System.IO
Imports ASFW
Imports ASFW.IO.FileIO
Imports Ini = ASFW.IO.FileIO.TextFile

Module modDatabase

#Region "Classes"

    Sub ClearClasses()
        Dim i As Integer

        ReDim Classes(Max_Classes)

        For i = 1 To Max_Classes
            Classes(i) = Nothing
            Classes(i).Name = ""
            Classes(i).Desc = ""
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(StatType.Count - 1)
            ReDim Classes(i).StartItem(5)
            ReDim Classes(i).StartValue(5)
        Next

    End Sub

    Sub LoadClasses()
        Dim cf = Path.Database & "Classes.ini"
        Dim i, n, x As Integer

        ClearClasses()

        For i = 1 To MAX_CLASSES
            Classes(i).Name = Ini.Read(cf, "CLASS" & i, "Name")
            Classes(i).Desc = Ini.Read(cf, "CLASS" & i, "Desc")
            Classes(i).BaseExp = Val(Ini.Read(cf, "CLASS" & i, "BaseExp"))

            n = Val(Ini.Read(cf, "CLASS" & i, "MaxMaleSprite"))
            ReDim Classes(i).MaleSprite(n)
            For x = 0 To n
                Classes(i).MaleSprite(x) = Val(Ini.Read(cf, "CLASS" & i, "Sprite_Male" & x))
            Next

            n = Val(Ini.Read(cf, "CLASS" & i, "MaxFemaleSprite"))
            ReDim Classes(i).FemaleSprite(n)
            For x = 0 To n
                Classes(i).FemaleSprite(x) = Val(Ini.Read(cf, "CLASS" & i, "Sprite_Female" & x))
            Next

            Classes(i).Stat(StatType.Strength) = Val(Ini.Read(cf, "CLASS" & i, "Str"))
            Classes(i).Stat(StatType.Endurance) = Val(Ini.Read(cf, "CLASS" & i, "End"))
            Classes(i).Stat(StatType.Vitality) = Val(Ini.Read(cf, "CLASS" & i, "Vit"))
            Classes(i).Stat(StatType.Luck) = Val(Ini.Read(cf, "CLASS" & i, "Luck"))
            Classes(i).Stat(StatType.Intelligence) = Val(Ini.Read(cf, "CLASS" & i, "Int"))
            Classes(i).Stat(StatType.Spirit) = Val(Ini.Read(cf, "CLASS" & i, "Speed"))

            Classes(i).StartMap = Val(Ini.Read(cf, "CLASS" & i, "StartMap"))
            Classes(i).StartX = Val(Ini.Read(cf, "CLASS" & i, "StartX"))
            Classes(i).StartY = Val(Ini.Read(cf, "CLASS" & i, "StartY"))

            ' loop for items & values
            For x = 1 To 5
                Classes(i).StartItem(x) = Val(Ini.Read(cf, "CLASS" & i, "StartItem" & x))
                Classes(i).StartValue(x) = Val(Ini.Read(cf, "CLASS" & i, "StartValue" & x))
            Next
        Next
    End Sub

    Sub SaveClasses()
        Dim cf = Path.Database & "Classes.ini"
        Dim i, n, x As Integer

        For i = 1 To MAX_CLASSES
            Ini.Write(cf, "CLASS" & i, "Name", Trim$(Classes(i).Name))
            Ini.Write(cf, "CLASS" & i, "Desc", Trim$(Classes(i).Desc))
            Ini.Write(cf, "CLASS" & i, "BaseExp", Classes(i).BaseExp)

            n = UBound(Classes(i).MaleSprite)
            Ini.Write(cf, "CLASS" & i, "MaxMaleSprite", n)
            For x = 0 To n
                Ini.Write(cf, "CLASS" & i, "Sprite_Male" & x, Classes(i).MaleSprite(x))
            Next

            n = UBound(Classes(i).FemaleSprite)
            Ini.Write(cf, "CLASS" & i, "MaxFemaleSprite", n)
            For x = 0 To n
                Ini.Write(cf, "CLASS" & i, "Sprite_Female" & x, Classes(i).FemaleSprite(x))
            Next

            Ini.Write(cf, "CLASS" & i, "Str", Classes(i).Stat(StatType.Strength))
            Ini.Write(cf, "CLASS" & i, "End", Classes(i).Stat(StatType.Endurance))
            Ini.Write(cf, "CLASS" & i, "Vit", Classes(i).Stat(StatType.Vitality))
            Ini.Write(cf, "CLASS" & i, "Luck", Classes(i).Stat(StatType.Luck))
            Ini.Write(cf, "CLASS" & i, "Int", Classes(i).Stat(StatType.Intelligence))
            Ini.Write(cf, "CLASS" & i, "Speed", Classes(i).Stat(StatType.Spirit))

            Ini.Write(cf, "CLASS" & i, "StartMap", Classes(i).StartMap)
            Ini.Write(cf, "CLASS" & i, "StartX", Classes(i).StartX)
            Ini.Write(cf, "CLASS" & i, "StartY", Classes(i).StartY)

            ' Fazer o loop de itens e valores
            For x = 1 To 5
                Ini.Write(cf, "CLASS" & i, "StartItem" & x, Classes(i).StartItem(x))
                Ini.Write(cf, "CLASS" & i, "StartValue" & x, Classes(i).StartValue(x))
            Next
        Next
    End Sub

    Function GetClassMaxVital(ClassNum As Integer, Vital As VitalType) As Integer
        GetClassMaxVital = 0

        Select Case Vital
            Case VitalType.HP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(StatType.Vitality) \ 2) + Classes(ClassNum).Stat(StatType.Vitality)) * 2
            Case VitalType.MP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(StatType.Intelligence) \ 2) + Classes(ClassNum).Stat(StatType.Intelligence)) * 2
            Case VitalType.SP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(StatType.Spirit) \ 2) + Classes(ClassNum).Stat(StatType.Spirit)) * 2
        End Select

    End Function

    Function GetClassName(ClassNum As Integer) As String
        GetClassName = Trim$(Classes(ClassNum).Name)
    End Function

#End Region

#Region "Maps"

    Sub CheckMaps()
        For i = 1 To MAX_MAPS
            If Not File.Exists(Path.Map(i)) Then
                SaveMap(i)
            End If
        Next

    End Sub

    Sub ClearMaps()
        For i = 1 To MAX_CACHED_MAPS
            ClearMap(i)
        Next
    End Sub

    Sub ClearMap(mapNum As Integer)
        Dim x As Integer
        Dim y As Integer
        Map(mapNum) = Nothing
        Map(mapNum).Tileset = 1
        Map(mapNum).Name = ""
        Map(mapNum).MaxX = MAX_MAPX
        Map(mapNum).MaxY = MAX_MAPY
        ReDim Map(mapNum).Npc(MAX_MAP_NPCS)
        ReDim Map(mapNum).Tile(Map(mapNum).MaxX, Map(mapNum).MaxY)

        For x = 0 To MAX_MAPX
            For y = 0 To MAX_MAPY
                ReDim Map(mapNum).Tile(x, y).Layer(LayerType.Count - 1)
            Next
        Next

        Map(mapNum).EventCount = 0
        ReDim Map(mapNum).Events(0)

        ' Resetar o valores se o jogador estiver no mapa ou não
        PlayersOnMap(mapNum) = False
        Map(mapNum).Tileset = 1
        Map(mapNum).Name = ""
        Map(mapNum).Music = ""
        Map(mapNum).MaxX = MAX_MAPX
        Map(mapNum).MaxY = MAX_MAPY

        ClearTempTile(mapNum)

    End Sub

    Sub SaveMaps()
        Dim i As Integer

        For i = 1 To MAX_MAPS
            SaveMap(i)
            SaveMapEvent(i)
        Next

    End Sub

    Sub SaveMap(mapNum As Integer)
        Dim filename As String
        'Dim x As Integer, y As Integer, l As Integer

        filename = Path.Map(mapNum)
        SaveObject(Map(mapNum), filename)

    End Sub

    Sub SaveMapEvent(mapNum As Integer)
        Dim cf = Path.Maps & mapNum & "_eventdata.ini"

        If Not File.Exists(cf) Then File.Create(cf).Dispose()

        'Isto é para salvar eventos. Está no arquivo .ini porque há valores não limitados (strings) que nao podem ser facilmente carregados da maneira normal.
        Ini.WriteOrCreate(cf, "Events", "EventCount", Val(Map(mapNum).EventCount))

        If Map(mapNum).EventCount > 0 Then
            For i = 1 To Map(mapNum).EventCount
                With Map(mapNum).Events(i)
                    Ini.WriteOrCreate(cf, "Event" & i, "Name", .Name)
                    Ini.WriteOrCreate(cf, "Event" & i, "Global", Val(.Globals))
                    Ini.WriteOrCreate(cf, "Event" & i, "x", Val(.X))
                    Ini.WriteOrCreate(cf, "Event" & i, "y", Val(.Y))
                    Ini.WriteOrCreate(cf, "Event" & i, "PageCount", Val(.PageCount))

                End With
                If Map(mapNum).Events(i).PageCount > 0 Then
                    For x = 1 To Map(mapNum).Events(i).PageCount
                        With Map(mapNum).Events(i).Pages(x)
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "chkVariable", Val(.ChkVariable))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "VariableIndex", Val(.Variableindex))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "VariableCondition", Val(.VariableCondition))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "VariableCompare", Val(.VariableCompare))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "chkSwitch", Val(.ChkSwitch))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "SwitchIndex", Val(.Switchindex))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "SwitchCompare", Val(.SwitchCompare))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "chkHasItem", Val(.ChkHasItem))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "HasItemIndex", Val(.HasItemindex))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "HasItemAmount", Val(.HasItemAmount))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "chkSelfSwitch", Val(.ChkSelfSwitch))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "SelfSwitchIndex", Val(.SelfSwitchindex))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "SelfSwitchCompare", Val(.SelfSwitchCompare))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "GraphicType", Val(.GraphicType))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "Graphic", Val(.Graphic))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "GraphicX", Val(.GraphicX))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "GraphicY", Val(.GraphicY))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "GraphicX2", Val(.GraphicX2))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "GraphicY2", Val(.GraphicY2))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveType", Val(.MoveType))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveSpeed", Val(.MoveSpeed))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveFreq", Val(.MoveFreq))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "IgnoreMoveRoute", Val(.IgnoreMoveRoute))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "RepeatMoveRoute", Val(.RepeatMoveRoute))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRouteCount", Val(.MoveRouteCount))

                            If .MoveRouteCount > 0 Then
                                For y = 1 To .MoveRouteCount
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Index", Val(.MoveRoute(y).Index))
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data1", Val(.MoveRoute(y).Data1))
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data2", Val(.MoveRoute(y).Data2))
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data3", Val(.MoveRoute(y).Data3))
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data4", Val(.MoveRoute(y).Data4))
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data5", Val(.MoveRoute(y).Data5))
                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data6", Val(.MoveRoute(y).Data6))
                                Next
                            End If

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "WalkAnim", Val(.WalkAnim))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "DirFix", Val(.DirFix))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "WalkThrough", Val(.WalkThrough))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "ShowName", Val(.ShowName))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "Trigger", Val(.Trigger))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandListCount", Val(.CommandListCount))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "Position", Val(.Position))
                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "QuestNum", Val(.QuestNum))

                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "PlayerGender", Val(.ChkPlayerGender))

                        End With

                        If Map(mapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            For y = 1 To Map(mapNum).Events(i).Pages(x).CommandListCount
                                Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "CommandCount", Val(Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount))
                                Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "ParentList", Val(Map(mapNum).Events(i).Pages(x).CommandList(y).ParentList))

                                If Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    For z = 1 To Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Index", Val(.Index))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text1", .Text1)
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text2", .Text2)
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text3", .Text3)
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text4", .Text4)
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text5", .Text5)
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data1", Val(.Data1))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data2", Val(.Data2))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data3", Val(.Data3))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data4", Val(.Data4))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data5", Val(.Data5))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data6", Val(.Data6))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchCommandList", Val(.ConditionalBranch.CommandList))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchCondition", Val(.ConditionalBranch.Condition))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchData1", Val(.ConditionalBranch.Data1))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchData2", Val(.ConditionalBranch.Data2))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchData3", Val(.ConditionalBranch.Data3))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchElseCommandList", Val(.ConditionalBranch.ElseCommandList))
                                            Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRouteCount", Val(.MoveRouteCount))

                                            If .MoveRouteCount > 0 Then
                                                For w = 1 To .MoveRouteCount
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Index", Val(.MoveRoute(w).Index))
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data1", Val(.MoveRoute(w).Data1))
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data2", Val(.MoveRoute(w).Data2))
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data3", Val(.MoveRoute(w).Data3))
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data4", Val(.MoveRoute(w).Data4))
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data5", Val(.MoveRoute(w).Data5))
                                                    Ini.WriteOrCreate(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data6", Val(.MoveRoute(w).Data6))
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Sub LoadMapEvent(mapNum As Integer)
        Dim cf = Path.Maps & mapNum & "_eventdata.ini"

        Map(mapNum).EventCount = Val(Ini.Read(cf, "Events", "EventCount"))
        If Not Map(mapNum).EventCount > 0 Then Exit Sub

        Dim i As Integer, x As Integer, y As Integer, p As Integer

        ReDim Map(mapNum).Events(Map(mapNum).EventCount)
        For i = 1 To Map(mapNum).EventCount
            If Val(Ini.Read(cf, "Event" & i, "PageCount")) > 0 Then

                With Map(mapNum).Events(i)
                    .Name = Ini.Read(cf, "Event" & i, "Name")
                    .Globals = Val(Ini.Read(cf, "Event" & i, "Global"))
                    .X = Val(Ini.Read(cf, "Event" & i, "x"))
                    .Y = Val(Ini.Read(cf, "Event" & i, "y"))
                    .PageCount = Val(Ini.Read(cf, "Event" & i, "PageCount"))
                End With
                If Map(mapNum).Events(i).PageCount > 0 Then
                    ReDim Map(mapNum).Events(i).Pages(Map(mapNum).Events(i).PageCount)
                    For x = 1 To Map(mapNum).Events(i).PageCount
                        With Map(mapNum).Events(i).Pages(x)
                            .ChkVariable = Val(Ini.Read(cf, "Event" & i & "Page" & x, "chkVariable"))
                            .Variableindex = Val(Ini.Read(cf, "Event" & i & "Page" & x, "VariableIndex"))
                            .VariableCondition = Val(Ini.Read(cf, "Event" & i & "Page" & x, "VariableCondition"))
                            .VariableCompare = Val(Ini.Read(cf, "Event" & i & "Page" & x, "VariableCompare"))

                            .ChkSwitch = Val(Ini.Read(cf, "Event" & i & "Page" & x, "chkSwitch"))
                            .Switchindex = Val(Ini.Read(cf, "Event" & i & "Page" & x, "SwitchIndex"))
                            .SwitchCompare = Val(Ini.Read(cf, "Event" & i & "Page" & x, "SwitchCompare"))

                            .ChkHasItem = Val(Ini.Read(cf, "Event" & i & "Page" & x, "chkHasItem"))
                            .HasItemindex = Val(Ini.Read(cf, "Event" & i & "Page" & x, "HasItemIndex"))
                            .HasItemAmount = Val(Ini.Read(cf, "Event" & i & "Page" & x, "HasItemAmount"))

                            .ChkSelfSwitch = Val(Ini.Read(cf, "Event" & i & "Page" & x, "chkSelfSwitch"))
                            .SelfSwitchindex = Val(Ini.Read(cf, "Event" & i & "Page" & x, "SelfSwitchIndex"))
                            .SelfSwitchCompare = Val(Ini.Read(cf, "Event" & i & "Page" & x, "SelfSwitchCompare"))

                            .GraphicType = Val(Ini.Read(cf, "Event" & i & "Page" & x, "GraphicType"))
                            .Graphic = Val(Ini.Read(cf, "Event" & i & "Page" & x, "Graphic"))
                            .GraphicX = Val(Ini.Read(cf, "Event" & i & "Page" & x, "GraphicX"))
                            .GraphicY = Val(Ini.Read(cf, "Event" & i & "Page" & x, "GraphicY"))
                            .GraphicX2 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "GraphicX2"))
                            .GraphicY2 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "GraphicY2"))

                            .MoveType = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveType"))
                            .MoveSpeed = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveSpeed"))
                            .MoveFreq = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveFreq"))

                            .IgnoreMoveRoute = Val(Ini.Read(cf, "Event" & i & "Page" & x, "IgnoreMoveRoute"))
                            .RepeatMoveRoute = Val(Ini.Read(cf, "Event" & i & "Page" & x, "RepeatMoveRoute"))

                            .MoveRouteCount = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRouteCount"))

                            If .MoveRouteCount > 0 Then
                                ReDim Map(mapNum).Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Index"))
                                    .MoveRoute(y).Data1 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data1"))
                                    .MoveRoute(y).Data2 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data2"))
                                    .MoveRoute(y).Data3 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data3"))
                                    .MoveRoute(y).Data4 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data4"))
                                    .MoveRoute(y).Data5 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data5"))
                                    .MoveRoute(y).Data6 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "MoveRoute" & y & "Data6"))
                                Next
                            End If

                            .WalkAnim = Val(Ini.Read(cf, "Event" & i & "Page" & x, "WalkAnim"))
                            .DirFix = Val(Ini.Read(cf, "Event" & i & "Page" & x, "DirFix"))
                            .WalkThrough = Val(Ini.Read(cf, "Event" & i & "Page" & x, "WalkThrough"))
                            .ShowName = Val(Ini.Read(cf, "Event" & i & "Page" & x, "ShowName"))
                            .Trigger = Val(Ini.Read(cf, "Event" & i & "Page" & x, "Trigger"))
                            .CommandListCount = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandListCount"))

                            .Position = Val(Ini.Read(cf, "Event" & i & "Page" & x, "Position"))
                            .QuestNum = Val(Ini.Read(cf, "Event" & i & "Page" & x, "QuestNum"))

                            .ChkPlayerGender = Val(Ini.Read(cf, "Event" & i & "Page" & x, "PlayerGender"))
                        End With

                        If Map(mapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map(mapNum).Events(i).Pages(x).CommandList(Map(mapNum).Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map(mapNum).Events(i).Pages(x).CommandListCount
                                Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "CommandCount"))
                                Map(mapNum).Events(i).Pages(x).CommandList(y).ParentList = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "ParentList"))
                                If Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                    For p = 1 To Map(mapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(mapNum).Events(i).Pages(x).CommandList(y).Commands(p)
                                            .Index = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Index"))
                                            .Text1 = Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text1")
                                            .Text2 = Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text2")
                                            .Text3 = Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text3")
                                            .Text4 = Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text4")
                                            .Text5 = Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text5")
                                            .Data1 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data1"))
                                            .Data2 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data2"))
                                            .Data3 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data3"))
                                            .Data4 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data4"))
                                            .Data5 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data5"))
                                            .Data6 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data6"))
                                            .ConditionalBranch.CommandList = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchCommandList"))
                                            .ConditionalBranch.Condition = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchCondition"))
                                            .ConditionalBranch.Data1 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchData1"))
                                            .ConditionalBranch.Data2 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchData2"))
                                            .ConditionalBranch.Data3 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchData3"))
                                            .ConditionalBranch.ElseCommandList = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchElseCommandList"))
                                            .MoveRouteCount = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRouteCount"))
                                            If .MoveRouteCount > 0 Then
                                                ReDim .MoveRoute(.MoveRouteCount)
                                                For w = 1 To .MoveRouteCount
                                                    .MoveRoute(w).Index = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Index"))
                                                    .MoveRoute(w).Data1 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data1"))
                                                    .MoveRoute(w).Data2 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data2"))
                                                    .MoveRoute(w).Data3 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data3"))
                                                    .MoveRoute(w).Data4 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data4"))
                                                    .MoveRoute(w).Data5 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data5"))
                                                    .MoveRoute(w).Data6 = Val(Ini.Read(cf, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data6"))
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Sub LoadMaps()
        Dim i As Integer

        CheckMaps()

        For i = 1 To MAX_MAPS
            LoadMap(i)
        Next
    End Sub

    Sub LoadMap(mapNum As Integer)
        Dim filename As String
        'Dim x As Integer
        'Dim y As Integer
        'Dim l As Integer

        filename = Path.Map(mapNum)

        LoadObject(Map(mapNum), filename)


        ClearTempTile(mapNum)
        CacheResources(mapNum)

        If Map(mapNum).Name Is Nothing Then Map(mapNum).Name = ""
        If Map(mapNum).Music Is Nothing Then Map(mapNum).Music = ""

        If File.Exists(Path.Maps & mapNum & "_eventdata.ini") Then
            LoadMapEvent(mapNum)
        End If

    End Sub

    Sub ClearTempTiles()
        ReDim TempTile(MAX_CACHED_MAPS)

        For i = 1 To MAX_CACHED_MAPS
            ClearTempTile(i)
        Next

    End Sub

    Sub ClearTempTile(mapNum As Integer)
        Dim y As Integer
        Dim x As Integer
        TempTile(mapNum).DoorTimer = 0
        ReDim TempTile(mapNum).DoorOpen(Map(mapNum).MaxX, Map(mapNum).MaxY)

        For x = 0 To Map(mapNum).MaxX
            For y = 0 To Map(mapNum).MaxY
                TempTile(mapNum).DoorOpen(x, y) = False
            Next
        Next

    End Sub

    Sub ClearMapItem(index As Integer, mapNum As Integer)
        MapItem(mapNum, index).ItemData.Clear()
        MapItem(mapNum, index) = Nothing
    End Sub

    Sub ClearMapItems()
        Dim x As Integer
        Dim y As Integer

        For y = 1 To MAX_CACHED_MAPS
            For x = 1 To MAX_MAP_ITEMS
                ClearMapItem(x, y)
            Next
        Next

    End Sub

#End Region

#Region "Npc's"

    Sub SaveNpcs()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            SaveNpc(i)
            Application.DoEvents()
        Next

    End Sub

    Sub SaveNpc(NpcNum As Integer)
        Dim filename As String
        'Dim i As Integer
        filename = Path.Npc(NpcNum)

        SaveObject(Npc(NpcNum), filename)
    End Sub

    Sub LoadNpcs()
        Dim i As Integer

        CheckNpcs()

        For i = 1 To MAX_NPCS
            LoadNpc(i)
            Application.DoEvents()
        Next
        'SaveNpcs()
    End Sub

    Sub LoadNpc(NpcNum As Integer)
        Dim filename As String
        'Dim n As Integer

        filename = Path.Npc(NpcNum)
        LoadObject(Npc(NpcNum), filename)

        If Npc(NpcNum).Name Is Nothing Then Npc(NpcNum).Name = ""
        If Npc(NpcNum).AttackSay Is Nothing Then Npc(NpcNum).AttackSay = ""
    End Sub

    Sub CheckNpcs()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            If Not File.Exists(Path.Npc(i)) Then
                SaveNpc(i)
                Application.DoEvents()
            End If

        Next

    End Sub

    Sub ClearMapNpc(index As Integer, mapNum As Integer)
        MapNpc(mapNum).Npc(index) = Nothing

        ReDim MapNpc(mapNum).Npc(index).Vital(VitalType.Count)
        ReDim MapNpc(mapNum).Npc(index).SkillCd(MAX_NPC_SKILLS)
    End Sub

    Sub ClearAllMapNpcs()
        Dim y As Integer

        For y = 1 To MAX_CACHED_MAPS
            ClearMapNpcs(y)
            Application.DoEvents()
        Next

    End Sub

    Sub ClearMapNpcs(mapNum As Integer)
        Dim x As Integer
        Dim y As Integer

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, y)
            Application.DoEvents()
        Next

    End Sub

    Sub ClearNpc(index As Integer)
        Npc(index) = Nothing
        Npc(index).Name = ""
        Npc(index).AttackSay = ""
        ReDim Npc(index).Stat(StatType.Count - 1)
        For i = 1 To 5
            ReDim Npc(index).DropChance(5)
            ReDim Npc(index).DropItem(5)
            ReDim Npc(index).DropItemValue(5)
            ReDim Npc(index).Skill(MAX_NPC_SKILLS)
        Next
    End Sub

    Sub ClearNpcs()
        For i = 1 To MAX_NPCS
            ClearNpc(i)
        Next

    End Sub

#End Region

#Region "Shops"

    Sub SaveShops()
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            SaveShop(i)
            Application.DoEvents()
        Next

    End Sub

    Sub SaveShop(shopNum As Integer)
        'Dim i As Integer
        Dim filename As String

        filename = Path.Shop(shopNum)

        SaveObject(Shop(shopNum), filename)
    End Sub

    Sub LoadShops()

        Dim i As Integer

        CheckShops()

        For i = 1 To MAX_SHOPS
            LoadShop(i)
            Application.DoEvents()
        Next

    End Sub

    Sub LoadShop(ShopNum As Integer)
        Dim filename As String
        'Dim x As Integer

        filename = Path.Shop(ShopNum)

        LoadObject(Shop(ShopNum), filename)

    End Sub

    Sub CheckShops()
        Dim i As Integer

        For i = 1 To MAX_SHOPS

            If Not File.Exists(Path.Shop(i)) Then
                SaveShop(i)
            End If

        Next

    End Sub

    Sub ClearShop(index As Integer)
        Dim i As Integer

        Shop(index) = Nothing
        Shop(index).Name = ""

        ReDim Shop(index).TradeItem(MAX_TRADES)
        For i = 0 To MAX_SHOPS
            ReDim Shop(i).TradeItem(MAX_TRADES)
        Next

    End Sub

    Sub ClearShops()
        For i = 1 To MAX_SHOPS
            Call ClearShop(i)
        Next
    End Sub

#End Region

#Region "Skills"

    Sub SaveSkills()
        Dim i As Integer
        Console.WriteLine("Salvando habilidades... ")

        For i = 1 To MAX_SKILLS
            SaveSkill(i)
            Application.DoEvents()
        Next

    End Sub

    Sub SaveSkill(skillnum As Integer)
        Dim filename As String
        filename = Path.Skill(skillnum)

        SaveObject(Skill(skillnum), filename)
    End Sub

    Sub LoadSkills()
        Dim i As Integer

        CheckSkills()

        For i = 1 To MAX_SKILLS
            LoadSkill(i)
            Application.DoEvents()
        Next

    End Sub

    Sub LoadSkill(SkillNum As Integer)
        Dim filename As String

        filename = Path.Skill(SkillNum)
        LoadObject(Skill(SkillNum), filename)

    End Sub

    Sub CheckSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS

            If Not File.Exists(Path.Skill(i)) Then
                SaveSkill(i)
                Application.DoEvents()
            End If

        Next

    End Sub

    Sub ClearSkill(index As Integer)
        Skill(index) = Nothing
        Skill(index).Name = ""
        Skill(index).LevelReq = 1 'precisa ser 1 para o editor de habilidades
    End Sub

    Sub ClearSkills()
        For i = 1 To MAX_SKILLS
            ClearSkill(i)
        Next

    End Sub

#End Region

#Region "Accounts"

    Function AccountExist(Name As String) As Boolean
        Return File.Exists(Application.StartupPath & "\Dados\Contas\" & Trim$(Name) & "\Data.bin")
    End Function

    Function PasswordOK(Name As String, Password As String) As Boolean
        If Not AccountExist(Name) Then Return False
        Dim reader As New ByteStream()
        BinaryFile.Load(Application.StartupPath & "\Dados\Contas\" & Trim$(Name) & "\Data.bin", reader)
        If reader.ReadString().Trim <> Name.Trim Then Return False
        Return reader.ReadString().Trim.ToUpper = Password.Trim.ToUpper
    End Function

    Sub AddAccount(index As Integer, Name As String, Password As String)
        ClearPlayer(index)

        Player(index).Login = Name
        Player(index).Password = Password

        SavePlayer(index)
    End Sub

    Sub DeleteName(Name As String)
        TextFile.RemoveString(Application.StartupPath & "\Dados\Contas\charlist.txt", Name.Trim.ToLower)
    End Sub

#End Region

#Region "Players"

    Sub SaveAllPlayersOnline()
        For i = 1 To GetPlayersOnline()
            If Not IsPlaying(i) Then Continue For
            SavePlayer(i)
            SaveBank(i)
        Next
    End Sub

    Sub SavePlayer(index As Integer)
        Dim playername As String = Trim$(Player(index).Login)
        Dim filename As String = Application.StartupPath & "\Dados\Contas\" & playername
        CheckDir(filename) : filename += "\Data.bin"

        Dim writer As New ByteStream(9 + Player(index).Login.Length + Player(index).Password.Length)

        writer.WriteString(Player(index).Login)
        writer.WriteString(Player(index).Password)
        writer.WriteByte(Player(index).Access)

        BinaryFile.Save(filename, writer)

        For i = 1 To MAX_CHARS
            SaveCharacter(index, i)
        Next

    End Sub

    Sub LoadPlayer(index As Integer, Name As String)
        Dim filename As String = Application.StartupPath & "\Dados\Contas\" & Name.Trim() & "\Data.bin"
        ClearPlayer(index)

        Dim reader As New ByteStream()
        BinaryFile.Load(filename, reader)

        Player(index).Login = reader.ReadString()
        Player(index).Password = reader.ReadString()
        Player(index).Access = reader.ReadByte()

        For i As Integer = 1 To MAX_CHARS
            LoadCharacter(index, i)
        Next

    End Sub

    Sub ClearPlayer(index As Integer)
        ReDim TempPlayer(index).SkillCd(MAX_PLAYER_SKILLS)
        ReDim TempPlayer(index).PetSkillCd(4)

        Player(index).Login = ""
        Player(index).Password = ""

        Player(index).Access = 0

        For i = 1 To MAX_CHARS
            ClearCharacter(index, i)
        Next

    End Sub

#End Region

#Region "Bank"

    Friend Sub LoadBank(index As Integer, Name As String)
        Dim filename As String = Application.StartupPath & "\Dados\Contas\" & Name.Trim() & "\Bank.bin"

        ClearBank(index)

        If Not File.Exists(filename) Then
            SaveBank(index)
            Exit Sub
        End If

        LoadObject(Bank(index), filename)
    End Sub

    Sub SaveBank(index As Integer)
        Dim filename = Application.StartupPath & "\Dados\Contas\" & Player(index).Login.Trim() & "\Bank.bin"

        SaveObject(Bank(index), filename)
    End Sub

    Sub ClearBank(index As Integer)
        ReDim Bank(index).Item(MAX_BANK)

        For i = 1 To MAX_BANK
            Bank(index).Item(i).Clear()
        Next
    End Sub

#End Region

#Region "Characters"

    Sub ClearCharacter(index As Integer, CharNum As Integer)
        Player(index).Character(CharNum).Classes = 0
        Player(index).Character(CharNum).Dir = 0

        For i = 0 To EquipmentType.Count - 1
            Player(index).Character(CharNum).Equipment(i).Num = 0
        Next

        For i = 0 To MAX_INV
            Player(index).Character(CharNum).Inv(i).Num = 0
            Player(index).Character(CharNum).Inv(i).Value = 0
        Next

        Player(index).Character(CharNum).Exp = 0
        Player(index).Character(CharNum).Level = 0
        Player(index).Character(CharNum).Map = 0
        Player(index).Character(CharNum).Name = ""
        Player(index).Character(CharNum).Pk = 0
        Player(index).Character(CharNum).Points = 0
        Player(index).Character(CharNum).Sex = 0

        For i = 0 To MAX_PLAYER_SKILLS
            Player(index).Character(CharNum).Skill(i) = 0
        Next

        Player(index).Character(CharNum).Sprite = 0

        For i = 0 To StatType.Count - 1
            Player(index).Character(CharNum).Stat(i) = 0
        Next

        For i = 0 To VitalType.Count - 1
            Player(index).Character(CharNum).Vital(i) = 0
        Next

        Player(index).Character(CharNum).X = 0
        Player(index).Character(CharNum).Y = 0

        ReDim Player(index).Character(CharNum).PlayerQuest(MAX_QUESTS)
        For i = 1 To MAX_QUESTS
            Player(index).Character(CharNum).PlayerQuest(i).Status = 0
            Player(index).Character(CharNum).PlayerQuest(i).ActualTask = 0
            Player(index).Character(CharNum).PlayerQuest(i).CurrentCount = 0
        Next

        'Moradia
        Player(index).Character(CharNum).House.Houseindex = 0
        Player(index).Character(CharNum).House.FurnitureCount = 0
        ReDim Player(index).Character(CharNum).House.Furniture(Player(index).Character(CharNum).House.FurnitureCount)

        For i = 0 To Player(index).Character(CharNum).House.FurnitureCount
            Player(index).Character(CharNum).House.Furniture(i).ItemNum = 0
            Player(index).Character(CharNum).House.Furniture(i).X = 0
            Player(index).Character(CharNum).House.Furniture(i).Y = 0
        Next

        Player(index).Character(CharNum).InHouse = 0
        Player(index).Character(CharNum).LastMap = 0
        Player(index).Character(CharNum).LastX = 0
        Player(index).Character(CharNum).LastY = 0

        ReDim Player(index).Character(CharNum).Hotbar(MAX_HOTBAR)
        For i = 1 To MAX_HOTBAR
            Player(index).Character(CharNum).Hotbar(i).Slot = 0
            Player(index).Character(CharNum).Hotbar(i).SlotType = 0
        Next

        ReDim Player(index).Character(CharNum).Switches(MAX_SWITCHES)
        For i = 1 To MAX_SWITCHES
            Player(index).Character(CharNum).Switches(i) = 0
        Next
        ReDim Player(index).Character(CharNum).Variables(MAX_VARIABLES)
        For i = 1 To MAX_VARIABLES
            Player(index).Character(CharNum).Variables(i) = 0
        Next

        ReDim Player(index).Character(CharNum).GatherSkills(ResourceSkills.Count - 1)
        For i = 0 To ResourceSkills.Count - 1
            Player(index).Character(CharNum).GatherSkills(i).SkillLevel = 1
            Player(index).Character(CharNum).GatherSkills(i).SkillCurExp = 0
            Player(index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 100
        Next

        ReDim Player(index).Character(CharNum).RecipeLearned(MAX_RECIPE)
        For i = 1 To MAX_RECIPE
            Player(index).Character(CharNum).RecipeLearned(i) = 0
        Next

        'Itens aleatórios
        ReDim Player(index).Character(CharNum).Inv(MAX_INV)
        For i = 1 To MAX_INV
            Player(index).Character(CharNum).Inv(i).Clear()
        Next

        ReDim Player(index).Character(CharNum).Equipment(EquipmentType.Count - 1)
        For i = 1 To EquipmentType.Count - 1
            Player(index).Character(CharNum).Equipment(i).Clear()
        Next

        'pets
        Player(index).Character(CharNum).Pet.Num = 0
        Player(index).Character(CharNum).Pet.Health = 0
        Player(index).Character(CharNum).Pet.Mana = 0
        Player(index).Character(CharNum).Pet.Level = 0

        ReDim Player(index).Character(CharNum).Pet.Stat(StatType.Count - 1)
        For i = 1 To StatType.Count - 1
            Player(index).Character(CharNum).Pet.Stat(i) = 0
        Next

        ReDim Player(index).Character(CharNum).Pet.Skill(4)
        For i = 1 To 4
            Player(index).Character(CharNum).Pet.Skill(i) = 0
        Next

        Player(index).Character(CharNum).Pet.X = 0
        Player(index).Character(CharNum).Pet.Y = 0
        Player(index).Character(CharNum).Pet.Dir = 0
        Player(index).Character(CharNum).Pet.Alive = 0
        Player(index).Character(CharNum).Pet.AttackBehaviour = 0
        Player(index).Character(CharNum).Pet.AdoptiveStats = 0
        Player(index).Character(CharNum).Pet.Points = 0
        Player(index).Character(CharNum).Pet.Exp = 0

    End Sub

    Sub LoadCharacter(index As Integer, CharNum As Integer)
        Dim filename As String = Application.StartupPath & "\Dados\Contas\" & Player(index).Login.Trim & "\" & CharNum & ".bin"

        ClearCharacter(index, CharNum)

        LoadObject(Player(index).Character(CharNum), filename)

    End Sub

    Sub SaveCharacter(index As Integer, CharNum As Integer)
        Dim filename As String = Application.StartupPath & "\Dados\Contas\" & Player(index).Login.Trim & "\" & CharNum & ".bin"
        SaveObject(Player(index).Character(CharNum), filename)
    End Sub

    Function CharExist(index As Integer, CharNum As Integer) As Boolean
        Return Player(index).Character(CharNum).Name.Trim.Length > 0
    End Function

    Sub AddChar(index As Integer, CharNum As Integer, Name As String, Sex As Byte, ClassNum As Byte, Sprite As Integer)
        Dim n As Integer, i As Integer

        If Len(Trim$(Player(index).Character(CharNum).Name)) = 0 Then
            Player(index).Character(CharNum).Name = Name
            Player(index).Character(CharNum).Sex = Sex
            Player(index).Character(CharNum).Classes = ClassNum

            If Player(index).Character(CharNum).Sex = SexType.Male Then
                Player(index).Character(CharNum).Sprite = Classes(ClassNum).MaleSprite(Sprite - 1)
            Else
                Player(index).Character(CharNum).Sprite = Classes(ClassNum).FemaleSprite(Sprite - 1)
            End If

            Player(index).Character(CharNum).Level = 1

            For n = 1 To StatType.Count - 1
                Player(index).Character(CharNum).Stat(n) = Classes(ClassNum).Stat(n)
            Next n

            Player(index).Character(CharNum).Dir = DirectionType.Down
            Player(index).Character(CharNum).Map = Classes(ClassNum).StartMap
            Player(index).Character(CharNum).X = Classes(ClassNum).StartX
            Player(index).Character(CharNum).Y = Classes(ClassNum).StartY
            Player(index).Character(CharNum).Dir = DirectionType.Down
            Player(index).Character(CharNum).Vital(VitalType.HP) = GetPlayerMaxVital(index, VitalType.HP)
            Player(index).Character(CharNum).Vital(VitalType.MP) = GetPlayerMaxVital(index, VitalType.MP)
            Player(index).Character(CharNum).Vital(VitalType.SP) = GetPlayerMaxVital(index, VitalType.SP)

            ' Setar equipamento inicial
            For n = 1 To 5
                If Classes(ClassNum).StartItem(n) > 0 Then
                    Player(index).Character(CharNum).Inv(n).Num = Classes(ClassNum).StartItem(n)
                    Player(index).Character(CharNum).Inv(n).Value = Classes(ClassNum).StartValue(n)

                    If Item(Classes(ClassNum).StartItem(n)).Randomize Then
                        Player(index).Character(TempPlayer(index).CurChar).Inv(n).Prefix = ""
                        Player(index).Character(TempPlayer(index).CurChar).Inv(n).Suffix = ""
                        Player(index).Character(TempPlayer(index).CurChar).Inv(n).Rarity = RarityType.RARITY_COMMON
                        Player(index).Character(TempPlayer(index).CurChar).Inv(n).Damage = Item(Classes(ClassNum).StartItem(n)).Data2
                        Player(index).Character(TempPlayer(index).CurChar).Inv(n).Speed = Item(Classes(ClassNum).StartItem(n)).Speed
                        For i = 1 To StatType.Count - 1
                            Player(index).Character(TempPlayer(index).CurChar).Inv(n).Stat(i) = Item(Classes(ClassNum).StartItem(n)).Add_Stat(i)
                        Next
                    End If
                End If
            Next

            'Setar habilidades
            ReDim Player(index).Character(CharNum).GatherSkills(ResourceSkills.Count - 1)
            For i = 0 To ResourceSkills.Count - 1
                Player(index).Character(CharNum).GatherSkills(i).SkillLevel = 1
                Player(index).Character(CharNum).GatherSkills(i).SkillCurExp = 0
                Player(index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 100
            Next

            ' Anexar nome ao arquivo
            AddTextToFile(Name, "Contas\charlist.txt")

            SavePlayer(index)
            Exit Sub
        End If

    End Sub

    Function FindChar(Name As String) As Boolean
        FindChar = False
        Dim characters() As String
        Dim fullpath As String
        Dim Contents As String

        fullpath = Path.Accounts & "charlist.txt"

        Contents = GetFileContents(fullpath)
        characters = Split(Contents, vbNewLine)

        For i = 0 To UBound(characters)
            If Trim$(LCase(characters(i)) = Trim$(LCase(Name))) Then
                FindChar = True
            End If
        Next

        Return FindChar
    End Function

#End Region

#Region "Logs"

    Friend Function GetFileContents(fullPath As String) As String
        Dim strContents = ""
        Dim objReader As StreamReader
        If Not File.Exists(fullPath) Then File.Create(fullPath).Dispose()
        Try
            objReader = New StreamReader(fullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
        Catch
        End Try
        Return strContents
    End Function

    Friend Function Addlog(strData As String, FN As String) As Boolean
        Dim fullpath As String
        Dim contents As String
        Dim bAns = False
        Dim objReader As StreamWriter
        fullpath = Path.Logs & FN
        contents = GetFileContents(fullpath)
        contents = contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(contents)
            objReader.Close()
            bAns = True
        Catch
        End Try
        Return bAns
    End Function

    Friend Function AddTextToFile(strData As String, fn As String) As Boolean
        Dim fullpath As String
        Dim contents As String
        Dim bAns = False
        Dim objReader As StreamWriter
        fullpath = Path.Database & fn
        contents = GetFileContents(fullpath)
        contents = contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(contents)
            objReader.Close()
            bAns = True
        Catch
        End Try
        Return bAns
    End Function

#End Region

#Region "Banning"

    Sub ServerBanIndex(BanPlayerindex As Integer)
        Dim filename As String
        Dim IP As String
        Dim F As Integer
        Dim i As Integer
        filename = Application.StartupPath & "\dados\banlist.txt"

        ' Ter certeza que o arquivo existe
        If Not File.Exists("data\banlist.txt") Then
            F = FreeFile()
        End If

        ' Cortar a última parte do IP 
        IP = Socket.ClientIp(BanPlayerindex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP, "banlist.txt")
        GlobalMsg(GetPlayerName(BanPlayerindex) & " foi banido de " & Settings.GameName & " pelo servidor!")
        Addlog("O Servidor" & " baniu " & GetPlayerName(BanPlayerindex) & ".", ADMIN_LOG)
        AlertMsg(BanPlayerindex, "Você foi banido pelo servidor!", True)
    End Sub

    Function IsBanned(IP As String) As Boolean
        Dim filename As String, line As String

        filename = Application.StartupPath & "\dados\banlist.txt"

        ' Ver se o arquivo existe
        If Not File.Exists(filename) Then
            Return False
        End If

        Dim sr As StreamReader = New StreamReader(filename)

        Do While sr.Peek() >= 0
            'Console.WriteLine(sr.ReadLine())
            ' Está banido?
            line = sr.ReadLine()
            If Trim$(LCase$(line)) = Trim$(LCase$(Mid$(IP, 1, Len(line)))) Then
                IsBanned = True
            End If
        Loop
        sr.Close()

    End Function

    Sub BanIndex(BanPlayerindex As Integer, BannedByindex As Integer)
        Dim filename As String = Application.StartupPath & "\dados\banlist.txt"
        Dim IP As String, i As Integer

        ' Ter certeza que o arquivo existe
        If Not File.Exists(filename) Then File.Create(filename).Dispose()

        ' Cortar úlimo pedaço do IP
        IP = Socket.ClientIp(BanPlayerindex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP, "banlist.txt")
        GlobalMsg(GetPlayerName(BanPlayerindex) & " foi banido de " & Settings.GameName & " por " & GetPlayerName(BannedByindex) & "!")
        Addlog(GetPlayerName(BannedByindex) & " baniu " & GetPlayerName(BanPlayerindex) & ".", ADMIN_LOG)
        AlertMsg(BanPlayerindex, "Você foi banido por " & GetPlayerName(BannedByindex) & "!", True)
    End Sub

#End Region

#Region "Data Functions"

    Function ClassData() As Byte()
        Dim i As Integer, n As Integer, q As Integer
        Dim buffer As New ByteStream(4)

        For i = 1 To MAX_CLASSES
            buffer.WriteString((GetClassName(i).Trim))
            buffer.WriteString((Classes(i).Desc.Trim))
            buffer.WriteInt32(GetClassMaxVital(i, VitalType.HP))
            buffer.WriteInt32(GetClassMaxVital(i, VitalType.MP))
            buffer.WriteInt32(GetClassMaxVital(i, VitalType.SP))

            ' Setar o tamanho do vetor da sprite
            n = UBound(Classes(i).MaleSprite)

            ' Enviar o tamanho do vetor
            buffer.WriteInt32(n)

            ' Fazer o loop enviando cada sprte 
            For q = 0 To n
                buffer.WriteInt32(Classes(i).MaleSprite(q))
            Next

            ' Setar o tamanho do vetor da sprite 
            n = UBound(Classes(i).FemaleSprite)

            ' Enviar o tamanho do vetor
            buffer.WriteInt32(n)

            ' Fazer o loop enviando cada sprte
            For q = 0 To n
                buffer.WriteInt32(Classes(i).FemaleSprite(q))
            Next

            buffer.WriteInt32(Classes(i).Stat(StatType.Strength))
            buffer.WriteInt32(Classes(i).Stat(StatType.Endurance))
            buffer.WriteInt32(Classes(i).Stat(StatType.Vitality))
            buffer.WriteInt32(Classes(i).Stat(StatType.Intelligence))
            buffer.WriteInt32(Classes(i).Stat(StatType.Luck))
            buffer.WriteInt32(Classes(i).Stat(StatType.Spirit))

            For q = 1 To 5
                buffer.WriteInt32(Classes(i).StartItem(q))
                buffer.WriteInt32(Classes(i).StartValue(q))
            Next

            buffer.WriteInt32(Classes(i).StartMap)
            buffer.WriteInt32(Classes(i).StartX)
            buffer.WriteInt32(Classes(i).StartY)

            buffer.WriteInt32(Classes(i).BaseExp)
        Next

        Return buffer.ToArray()
    End Function

    Function NpcsData() As Byte()
        Dim buffer As New ByteStream(4)
        For i = 1 To MAX_NPCS
            If Not Len(Trim$(Npc(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(NpcData(i))
        Next
        Return buffer.ToArray
    End Function

    Function NpcData(NpcNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(NpcNum)
        buffer.WriteBlock(SerializeData(Npc(NpcNum)))
        Return buffer.ToArray
    End Function

    Function ShopsData() As Byte()
        Dim buffer As New ByteStream(4)
        For i = 1 To MAX_SHOPS
            If Not Len(Trim$(Shop(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(ShopData(i))
        Next
        Return buffer.ToArray
    End Function

    Function ShopData(shopNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(shopNum)
        buffer.WriteBlock(SerializeData(Shop(shopNum)))
        Return buffer.ToArray
    End Function

    Function SkillsData() As Byte()
        Dim buffer As New ByteStream(4)
        For i = 1 To MAX_SKILLS
            If Not Len(Trim$(Skill(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(SkillData(i))
        Next
        Return buffer.ToArray
    End Function

    Function SkillData(skillnum As Integer) As Byte()
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(skillnum)
        buffer.WriteBlock(SerializeData(Skill(skillnum)))
        Return buffer.ToArray
    End Function

#End Region

#Region "Serialization"

    Sub LoadObject(ByRef Element As Object, ByVal Filename As String)
        Dim stream As FileStream
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        stream = File.OpenRead(Filename)
        Element = formatter.Deserialize(stream)
        stream.Close()
    End Sub

    Sub SaveObject(ByVal Element As Object, ByVal Filename As String)
        Dim stream As FileStream = File.Create(Filename)
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        formatter.Serialize(stream, Element)
        stream.Close()
    End Sub

#End Region

End Module