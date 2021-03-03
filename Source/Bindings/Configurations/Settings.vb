Imports System.IO
Imports System.Xml.Serialization
Imports ASFW.IO.Serialization

Public Class SettingsDef

#If CLIENT Then

    Public Language As String = "PT-BR"

    Public Username As String = ""
    Public Password As String = ""
    Public SavePass As Boolean = False

    Public MenuMusic As String = ""
    Public Music As Boolean = True
    Public Sound As Boolean = True
    Public Volume As Single = 100.0F

    Public ScreenSize As Byte = 0
    Public HighEnd As Byte = 0
    Public ShowNpcBar As Byte = 1

    <XmlIgnore()> Public Ip As String = "127.0.0.1"
    <XmlIgnore()> Public Port As Integer = 7001

    <XmlIgnore()> Public GameName As String = "Elysium.NET"
    <XmlIgnore()> Public Website As String = "http://www.mmodev.com.br"

#ElseIf SERVER Then
    Public GameName As String = "Elysium.NET"
    Public Website As String = "http://www.mmodev.com.br"

    Public Welcome As String = "Bem vindo ao Elysium.net, aproveite sua estadia e visite nosso portal http://www.mmodev.com.br!"
    Public Port As Integer = 7001

    Public StartMap As Integer = 1
    Public StartX As Integer = 13
    Public StartY As Integer = 7
#End If

End Class

Friend Module modSettings
    Public Settings As New SettingsDef

    Friend Sub LoadSettings()
        Dim cf As String = Path.Config()
        If Not Directory.Exists(cf) Then
            Directory.CreateDirectory(cf)
        End If : cf = cf & "\Configurações.xml"

        If Not File.Exists(cf) Then
            File.Create(cf).Dispose()
            ASFW.IO.Serialization.SaveXml(Of SettingsDef)(cf, New SettingsDef)
        End If : Settings = ASFW.IO.Serialization.LoadXml(Of SettingsDef)(cf)
    End Sub

    Friend Sub SaveSettings()
        Dim cf As String = Path.Config()
        If Not Directory.Exists(cf) Then
            Directory.CreateDirectory(cf)
        End If : cf = cf & "\Configurações.xml"

        ASFW.IO.Serialization.SaveXml(Of SettingsDef)(cf, Settings)
    End Sub

End Module