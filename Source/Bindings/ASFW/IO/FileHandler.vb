Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace ASFW.IO.FileIO
    ''' <summary>
    ''' Salva e carrega arquivos binários usando um ByteStream.
    ''' </summary>
    Public Module BinaryFile
        Public Sub Load(ByVal src As String, ByRef stream As ByteStream)
            If Not File.Exists(src) Then Return
            Dim br = New BinaryReader(File.Open(src, FileMode.Open))
            stream.Data = br.ReadBytes(br.ReadInt32())
            stream.Head = 0
            br.Close()
        End Sub

        Public Sub Save(ByVal dest As String, ByRef stream As ByteStream)
            Dim bw = New BinaryWriter(File.Open(dest, FileMode.Create))
            bw.Write(stream.Head)
            bw.Write(stream.ToArray())
            bw.Close()
        End Sub

        Public Function Load(ByVal src As String) As Byte()
            If Not File.Exists(src) Then Return New Byte(-1) {}
            Dim br = New BinaryReader(File.Open(src, FileMode.Open))
            Dim data = br.ReadBytes(br.ReadInt32())
            br.Close()
            Return data
        End Function

        Public Sub Save(ByVal dest As String, ByRef stream As Byte())
            Dim bw = New BinaryWriter(File.Open(dest, FileMode.Create))
            bw.Write(stream.Length)
            bw.Write(stream)
            bw.Close()
        End Sub
    End Module

    Public Module TextFile
        ''' <summary>
        ''' Adds the input on a new line at the end of the text file.
        ''' </summary>
        Public Sub AddLine(ByVal path As String, ByVal input As String)
            Dim fContents = File.ReadAllText(path)
            fContents += Environment.NewLine & input
            File.WriteAllText(path, fContents)
        End Sub


        ''' <summary>
        ''' Retorna verdade se a variável lida é igual ao input.
        ''' </summary>
        Public Function CompareVar(ByVal path As String, ByVal header As String, ByVal name As String, ByVal input As String) As Boolean
            Return Equals(Read(path, header, name), input)
        End Function


        ''' <summary>
        ''' Retorna verdade se o input existe em sua própria linha do arquivo.
        ''' </summary>
        Public Function StringExists(ByVal path As String, ByVal input As String) As Boolean
            Dim fContents = File.ReadAllLines(path)

            For i = 0 To fContents.Length - 1
                If fContents(i) Is input Then Return True
            Next

            Return False
        End Function


        ''' <summary>
        ''' Remove a linha que du match no input se existir. A linha deve ser igual 100%.
        ''' </summary>
        Public Sub RemoveString(ByVal path As String, ByVal input As String)
            Dim fContents = File.ReadAllLines(path)
            If fContents.Length < 1 Then Return
            Dim fBlock = fContents(0)

            If fContents.Length > 1 Then

                For i = 1 To fContents.Length - 1
                    If fContents(i) IsNot input Then fBlock += Environment.NewLine & fContents(i)
                Next
            End If

            File.WriteAllText(path, fBlock)
        End Sub


        ''' <summary>
        ''' Apaga completamente o conteúdo do arquivo.
        ''' </summary>
        Public Sub ClearFile(ByVal path As String)
            If Not File.Exists(path) Then Return
            File.Delete(path)
            File.Create(path).Dispose()
        End Sub


        ''' <summary>
        ''' Retorna o dado da variável se for encontrada. Caso contrário, retorna string vazia.
        ''' </summary>
        Public Function Read(ByVal path As String, ByVal header As String, ByVal name As String) As String
            Dim fContents = File.ReadAllLines(path)
            Dim i = 0
            Dim inHeader = False

            For i = 0 To fContents.Length - 1

                If inHeader Then
                    If fContents(i).StartsWith(name & "=", StringComparison.Ordinal) Then Return fContents(i).Substring(name.Length + 1)
                    If fContents(i).StartsWith("[", StringComparison.Ordinal) AndAlso fContents(i).EndsWith("]", StringComparison.Ordinal) Then Return ""
                Else
                    inHeader = inHeader Or fContents(i).StartsWith("[" & header & "]", StringComparison.Ordinal)
                End If
            Next

            Return ""
        End Function


        ''' <summary>
        ''' Sobrescrever dado de variável se for encontrado. Caso contrário, fazer nada.
        ''' </summary>
        Public Sub Write(ByVal path As String, ByVal header As String, ByVal name As String, ByVal value As String)
            Dim fContents = File.ReadAllLines(path)
            Dim i = 0
            Dim inHeader As Boolean = False

            For i = 0 To fContents.Length - 1

                If inHeader Then

                    If fContents(i).StartsWith(name & "=", StringComparison.Ordinal) Then
                        fContents(i) = name & "=" & value
                        File.WriteAllLines(path, fContents)
                        Return
                    End If
                Else
                    inHeader = inHeader Or fContents(i).StartsWith("[" & header & "]", StringComparison.Ordinal)
                End If
            Next
        End Sub


        ''' <summary>
        ''' Retorna dado de variável se encontrado, caso contrário volta uma string vazia.
        ''' Esta é uma réplica da funcão da INI e cria a variável se não existir, mas vem com um custo de desempenho.
        ''' </summary>
        Public Function GetVar(ByVal path As String, ByVal header As String, ByVal name As String) As String
            Dim fContents = File.ReadAllLines(path)
            Dim i = 0
            Dim inHeader = False

            For i = 0 To fContents.Length - 1

                If inHeader Then
                    If fContents(i).StartsWith(name & "=", StringComparison.Ordinal) Then Return fContents(i).Substring(name.Length + 1)

                    If fContents(i).StartsWith("[", StringComparison.Ordinal) AndAlso fContents(i).EndsWith("]", StringComparison.Ordinal) Then
                        Dim fBlock = fContents(0)
                        Dim cutIndex = i - 1

                        For index = 1 To fContents.Length - 1
                            fBlock += Environment.NewLine & fContents(i)
                            If index = cutIndex Then fBlock += Environment.NewLine & "[" & header & "]" & Environment.NewLine & name & "="
                        Next

                        File.WriteAllText(path, fBlock)
                        Return ""
                    End If
                Else
                    inHeader = inHeader Or fContents(i).StartsWith("[" & header & "]", StringComparison.Ordinal)
                End If
            Next

            If Not inHeader Then
                Dim fBlock = ""

                If fContents.Length > 0 Then
                    fBlock = fContents(0)

                    If fContents.Length > 1 Then

                        For i = 1 To fContents.Length - 1
                            fBlock += Environment.NewLine & fContents(i)
                        Next
                    End If
                End If

                fBlock += Environment.NewLine & "[" & header & "]" & Environment.NewLine & name & "="
                File.WriteAllText(path, fBlock)
            End If

            Return ""
        End Function


        ''' <summary>
        ''' Sobrescreve dado se encontrado
        ''' Esta é uma réplica da funcão da INI e cria a variável se não existir, mas vem com um custo de desempenho.
        ''' </summary>
        Public Sub PutVar(ByVal path As String, ByVal header As String, ByVal name As String, ByVal value As String)
            Dim fContents = File.ReadAllLines(path)
            Dim i = 0
            Dim inHeader As Boolean = False

            For i = 0 To fContents.Length - 1

                If inHeader Then

                    If fContents(i).StartsWith(name & "=", StringComparison.Ordinal) Then
                        fContents(i) = name & "=" & value
                        File.WriteAllLines(path, fContents)
                        Return
                    End If

                    If fContents(i).StartsWith("[", StringComparison.Ordinal) AndAlso fContents(i).EndsWith("]", StringComparison.Ordinal) Then
                        Dim fBlock = fContents(0)
                        Dim cutIndex = i - 1

                        For index = 1 To fContents.Length - 1
                            fBlock += Environment.NewLine & fContents(i)
                            If index = cutIndex Then fBlock += Environment.NewLine & "[" & header & "]" & Environment.NewLine & name & "=" & value
                        Next

                        File.WriteAllText(path, fBlock)
                        Return
                    End If
                Else
                    inHeader = inHeader Or fContents(i).StartsWith("[" & header & "]", StringComparison.Ordinal)
                End If
            Next

            If Not inHeader Then
                Dim fBlock = ""

                If fContents.Length > 0 Then
                    fBlock = fContents(0)

                    If fContents.Length > 1 Then

                        For i = 1 To fContents.Length - 1
                            fBlock += Environment.NewLine & fContents(i)
                        Next
                    End If
                End If

                fBlock += Environment.NewLine & "[" & header & "]" & Environment.NewLine & name & "=" & value
                File.WriteAllText(path, fBlock)
            End If
        End Sub

        <DllImport("kernel32")>
        Private Function WritePrivateProfileString(ByVal lpSectionName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Long
        End Function

        Public Function WriteOrCreate(filename As String, section As String, key As String, Optional defaultValue As String = "") As String
            Dim sb As New StringBuilder(500)
            If WritePrivateProfileString(section, key, defaultValue, filename) > 0 Then
                Return sb.ToString
            Else
                Return defaultValue
            End If
        End Function
    End Module
End Namespace