Imports System.Xml.Serialization
Imports SFML.Graphics

Public Class GUIPanel
    Inherits GUIObject

    <XmlAttribute("ControlBox")>
    Public ControlBox As Boolean
    <XmlAttribute("Caption")>
    Public Caption As String
    <XmlAttribute("Background")>
    Public Background As String = "janela"
    <XmlAttribute("Height")>
    Public Height As Integer = 168
    <XmlAttribute("Width")>
    Public Width As Integer = 168

    Private Const MinHeight As Integer = 48
    Private Const MinWidth As Integer = 48

    <XmlIgnore>
    Private GfxRectWidth As Integer
    <XmlIgnore>
    Private GfxRectHeight As Integer
    <XmlIgnore>
    Private sRECT As Rectangle
    <XmlIgnore>
    Private dRECT As Rectangle
    <XmlIgnore>
    Private CloseButton As GUIButton

    Public Children As List(Of GUIObject)

    Public Sub New()
        Children = New List(Of GUIObject)
    End Sub

    Public Overrides Sub Render(window As RenderWindow)
        If Not String.IsNullOrEmpty(Background) Then
            LoadComponentTexture(Background)

            If Height < MinHeight Then Height = MinHeight
            If Width < MinWidth Then Width = MinWidth

            GfxRectHeight = ComponentGfxInfo.Height / 3
            GfxRectWidth = ComponentGfxInfo.Width / 3

            'Desenhar corpo da janela
            DrawTopCornerLeft(window)
            DrawTopBorder(window)
            DrawTopCornerRight(window)
            DrawMidBorderLeft(window)
            DrawPanelBody(window)
            DrawMidBorderRight(window)
            DrawBottomCornerLeft(window)
            DrawBottomBorder(window)
            DrawBottomCornerRight(window)

            If Not String.IsNullOrEmpty(Me.Caption) Then
                DrawCaption(window)
            End If

            If ControlBox Then
                If CloseButton Is Nothing Then
                    CloseButton = New GUIButton With {
                        .Caption = "X",
                        .BackgroundRed = 255,
                        .BackgroundGreen = 0,
                        .BackgroundBlue = 0,
                        .Height = 14,
                        .Width = 14
                    }
                End If

                CloseButton.X = Me.X + Me.Width - GfxRectWidth * 2
                CloseButton.Y = Me.Y + GfxRectHeight
                CloseButton.Render(window)
            End If
        End If
    End Sub

    Private Sub DrawWindowPart(window As RenderWindow, dRECT As Rectangle, sRECT As Rectangle)
        RenderTextures(ComponentTexture, window, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, dRECT.Width, dRECT.Height, sRECT.Width, sRECT.Height)
    End Sub

    Private Sub DrawTopCornerLeft(window As RenderWindow)
        'Canto superior esquerdo
        With sRECT
            .Y = 0
            .Height = GfxRectHeight
            .X = 0
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y
            .Height = GfxRectHeight
            .X = Me.X
            .Width = GfxRectWidth
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawTopBorder(window As RenderWindow)
        'Borda superior
        With sRECT
            .Y = 0
            .Height = GfxRectHeight
            .X = GfxRectWidth
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y
            .Height = GfxRectHeight
            .X = Me.X + GfxRectWidth
            .Width = Me.Width - (GfxRectWidth * 2)
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawTopCornerRight(window As RenderWindow)
        'Canto superior direito
        With sRECT
            .Y = 0
            .Height = GfxRectHeight
            .X = GfxRectWidth * 2
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y
            .Height = GfxRectHeight
            .X = Me.X + Me.Width - GfxRectWidth
            .Width = GfxRectWidth
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawMidBorderLeft(window As RenderWindow)
        'Borda esquerda
        With sRECT
            .Y = GfxRectHeight
            .Height = GfxRectHeight
            .X = 0
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y + GfxRectHeight
            .Height = Me.Height - (GfxRectHeight * 2)
            .X = Me.X
            .Width = GfxRectWidth
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawPanelBody(window As RenderWindow)
        'Corpo da janela
        With sRECT
            .Y = GfxRectHeight
            .Height = GfxRectHeight
            .X = GfxRectWidth
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y + GfxRectHeight
            .Height = Me.Height - (GfxRectHeight * 2)
            .X = Me.X + GfxRectWidth
            .Width = Me.Width - (GfxRectWidth * 2)
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawMidBorderRight(window As RenderWindow)
        'Borda direita
        With sRECT
            .Y = GfxRectHeight
            .Height = GfxRectHeight
            .X = GfxRectWidth * 2
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y + GfxRectHeight
            .Height = Me.Height - (GfxRectHeight * 2)
            .X = Me.X + Me.Width - GfxRectWidth
            .Width = GfxRectWidth
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawBottomCornerLeft(window As RenderWindow)
        'Canto inferior esquerdo
        With sRECT
            .Y = GfxRectHeight * 2
            .Height = GfxRectHeight
            .X = 0
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y + Me.Height - GfxRectHeight
            .Height = GfxRectHeight
            .X = Me.X
            .Width = GfxRectWidth
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawBottomBorder(window As RenderWindow)
        'Borda inferior
        With sRECT
            .Y = GfxRectHeight * 2
            .Height = GfxRectHeight
            .X = GfxRectWidth
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y + Me.Height - GfxRectHeight
            .Height = GfxRectHeight
            .X = Me.X + GfxRectWidth
            .Width = Me.Width - (GfxRectWidth * 2)
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawBottomCornerRight(window As RenderWindow)
        'Canto inferior esquerdo
        With sRECT
            .Y = GfxRectHeight * 2
            .Height = GfxRectHeight
            .X = GfxRectWidth * 2
            .Width = GfxRectWidth
        End With

        With dRECT
            .Y = Me.Y + Me.Height - GfxRectHeight
            .Height = GfxRectHeight
            .X = Me.X + Me.Width - GfxRectWidth
            .Width = GfxRectWidth
        End With

        DrawWindowPart(window, dRECT, sRECT)
    End Sub

    Private Sub DrawCaption(window As RenderWindow)
        DrawText(GfxRectWidth, GfxRectHeight, Me.Caption, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, window)
    End Sub
End Class
