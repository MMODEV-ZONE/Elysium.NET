Imports System.IO
Imports System.IO.Compression
Imports System.Threading.Tasks

Namespace ASFW.IO
    Public Module Compression
        Public Function CompressBytes(ByVal value As Byte()) As Byte()
            Dim len = value.Length

            Using ms = New MemoryStream()

                Using gs = New GZipStream(ms, CompressionMode.Compress)
                    gs.Write(value, 0, len)
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Async Function CompressBytesAsync(ByVal value As Byte()) As Task(Of Byte())
            Dim len = value.Length

            Using ms = New MemoryStream()

                Using gs = New GZipStream(ms, CompressionMode.Compress)
                    Await gs.WriteAsync(value, 0, len)
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Function CompressBytes(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Byte()
            Using ms = New MemoryStream()

                Using gs = New GZipStream(ms, CompressionMode.Compress)
                    gs.Write(value, offset, size)
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Async Function CompressBytesAsync(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Task(Of Byte())
            Using ms = New MemoryStream()

                Using gs = New GZipStream(ms, CompressionMode.Compress)
                    Await gs.WriteAsync(value, offset, size)
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Function CompressFile(ByVal path As String) As Byte()
            Dim buffer = File.ReadAllBytes(path)
            Dim len As Integer = buffer.Length

            Using ms = New MemoryStream()

                Using gs = New GZipStream(ms, CompressionMode.Compress)
                    gs.Write(buffer, 0, len)
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Async Function CompressFileAsync(ByVal path As String) As Task(Of Byte())
            Dim buffer = File.ReadAllBytes(path)
            Dim len As Integer = buffer.Length

            Using ms = New MemoryStream()

                Using gs = New GZipStream(ms, CompressionMode.Compress)
                    Await gs.WriteAsync(buffer, 0, len)
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Sub CompressFile(ByVal srcFile As String, ByVal dstFile As String)
            File.WriteAllBytes(dstFile, CompressFile(srcFile))
        End Sub

        Public Async Function CompressFileAsync(ByVal srcFile As String, ByVal dstFile As String) As Task
            File.WriteAllBytes(dstFile, Await CompressFileAsync(srcFile))
        End Function

        Public Function DecompressBytes(ByVal value As Byte()) As Byte()
            Dim len = BitConverter.ToInt32(value, value.Length - 4)
            Dim buffer = New Byte(len - 1) {}

            Using ms = New MemoryStream(value)

                Using gs = New GZipStream(ms, CompressionMode.Decompress)
                    gs.Read(buffer, 0, len)
                End Using
            End Using

            Return buffer
        End Function

        Public Async Function DecompressBytesAsync(ByVal value As Byte()) As Task(Of Byte())
            Dim len = BitConverter.ToInt32(value, value.Length - 4)
            Dim buffer = New Byte(len - 1) {}

            Using ms = New MemoryStream(value)

                Using gs = New GZipStream(ms, CompressionMode.Decompress)
                    Await gs.ReadAsync(buffer, 0, len)
                End Using
            End Using

            Return buffer
        End Function

        Public Function DecompressBytes(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Byte()
            Dim buffer = New Byte(size - 1) {}
            System.Buffer.BlockCopy(value, offset, buffer, 0, size)
            Return DecompressBytes(buffer)
        End Function

        Public Async Function DecompressBytesAsync(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Task(Of Byte())
            Dim buffer = New Byte(size - 1) {}
            System.Buffer.BlockCopy(value, offset, buffer, 0, size)
            Return Await DecompressBytesAsync(buffer)
        End Function

        Public Function DecompressFile(ByVal path As String) As Byte()
            Dim value = File.ReadAllBytes(path)
            Dim len = BitConverter.ToInt32(value, value.Length - 4)
            Dim buffer = New Byte(len - 1) {}

            Using ms = New MemoryStream(value)

                Using gs = New GZipStream(ms, CompressionMode.Decompress)
                    gs.Read(buffer, 0, len)
                End Using
            End Using

            Return buffer
        End Function

        Public Async Function DecompressFileAsync(ByVal path As String) As Task(Of Byte())
            Dim value = File.ReadAllBytes(path)
            Dim len = BitConverter.ToInt32(value, value.Length - 4)
            Dim buffer = New Byte(len - 1) {}

            Using ms = New MemoryStream(value)

                Using gs = New GZipStream(ms, CompressionMode.Decompress)
                    Await gs.ReadAsync(buffer, 0, len)
                End Using
            End Using

            Return buffer
        End Function

        Public Sub DecompressFile(ByVal srcFile As String, ByVal dstFile As String)
            File.WriteAllBytes(dstFile, DecompressFile(srcFile))
        End Sub

        Public Async Function DecompressFileAsync(ByVal srcFile As String, ByVal dstFile As String) As Task
            File.WriteAllBytes(dstFile, Await DecompressFileAsync(srcFile))
        End Function
    End Module
End Namespace
