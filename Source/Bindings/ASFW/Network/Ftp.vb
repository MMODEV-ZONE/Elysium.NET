Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Reflection

Namespace ASFW.Network
    Public NotInheritable Class Ftp
        Implements IDisposable

        Private ReadOnly _credential As NetworkCredential
        Public BufferSize As Integer = 8192

        Public Sub New(ByVal credentials As NetworkCredential)
            _credential = credentials
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub

        Public Sub DeleteFile(ByVal url As String)
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "DELE"
            request.GetResponse().Close()
        End Sub

        Public Sub DownloadFile(ByVal url As String, ByVal localFile As String)
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "RETR"

            Using response = CType(request.GetResponse(), FtpWebResponse)

                Using rs = response.GetResponseStream()

                    Using fs = New FileStream(localFile, FileMode.Create)
                        If rs Is Nothing Then Throw New Exception("Stream was empty.")
                        Dim buffer = New Byte(BufferSize - 1) {}
                        Dim len = rs.Read(buffer, 0, BufferSize)

                        While len > 0
                            fs.Write(buffer, 0, len)
                            len = rs.Read(buffer, 0, BufferSize)
                        End While
                    End Using
                End Using
            End Using
        End Sub

        Public Function GetDateTimestamp(ByVal url As String) As String
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "MDTM"

            Using response = CType(request.GetResponse(), FtpWebResponse)

                Using rs = response.GetResponseStream()
                    If rs Is Nothing Then Throw New Exception("Stream was empty.")

                    Using sr = New StreamReader(rs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Function

        Public Function GetFileSize(ByVal url As String) As Long
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "SIZE"

            Using response = CType(request.GetResponse(), FtpWebResponse)
                Return response.ContentLength
            End Using
        End Function

        Public Function ListDirectory(ByVal url As String) As String()
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "NLST"

            Using response = CType(request.GetResponse(), FtpWebResponse)

                Using rs = response.GetResponseStream()
                    If rs Is Nothing Then Throw New Exception("Stream was empty.")

                    Using sr = New StreamReader(rs)
                        Dim list = New List(Of String)()

                        While sr.Peek() <> -1
                            list.Add(sr.ReadLine())
                        End While

                        Return list.ToArray()
                    End Using
                End Using
            End Using
        End Function

        Public Function ListDirectoryDetails(ByVal url As String) As String()
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "LIST"

            Using response = CType(request.GetResponse(), FtpWebResponse)

                Using rs = response.GetResponseStream()
                    If rs Is Nothing Then Throw New Exception("Stream was empty.")

                    Using sr = New StreamReader(rs)
                        Dim list = New List(Of String)()

                        While sr.Peek() <> -1
                            list.Add(sr.ReadLine())
                        End While

                        Return list.ToArray()
                    End Using
                End Using
            End Using
        End Function

        Public Sub MakeDirectory(ByVal url As String)
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "MKD"
            request.GetResponse().Close()
        End Sub

        Public Sub Rename(ByVal url As String, ByVal name As String)
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "RENAME"
            request.RenameTo = name
            request.GetResponse().Close()
        End Sub

        Public Sub UploadFile(ByVal url As String, ByVal localFile As String)
            Dim request = CType(WebRequest.Create(url), FtpWebRequest)
            request.Credentials = _credential
            request.KeepAlive = True
            request.UseBinary = True
            request.UsePassive = True
            request.Method = "STOR"

            Using rs = request.GetRequestStream()

                Using fs = New FileStream(localFile, FileMode.Create)
                    Dim buffer As Byte() = New Byte(BufferSize - 1) {}
                    Dim count As Integer = fs.Read(buffer, 0, BufferSize)

                    While CUInt(count) > 0UI
                        rs.Write(buffer, 0, count)
                        count = fs.Read(buffer, 0, BufferSize)
                    End While
                End Using
            End Using
        End Sub
    End Class
End Namespace
