Imports System
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports System.Security.Cryptography

Namespace ASFW.IO.Encryption
    ''' <summary>
    ''' Método simples de criptografia utilizando uma senha estática.
    ''' </summary>
    Public Module Generic
        Public Function EncryptBytes(ByVal value As Byte(), ByVal password As String, ByVal iterations As Integer) As Byte()
            Dim len = value.Length
            Dim salt = New Byte(31) {}
            Dim rgbIv = New Byte(31) {}
            Dim buffer As Byte()

            Using csp = New RNGCryptoServiceProvider()
                csp.GetBytes(salt)
                csp.GetBytes(rgbIv)
            End Using

            Using bytes = New Rfc2898DeriveBytes(password, salt, iterations)
                Dim rm = New RijndaelManaged With {
                    .BlockSize = 256,
                    .Mode = CipherMode.CBC,
                    .Padding = PaddingMode.PKCS7
                }

                Using es = rm.CreateEncryptor(bytes.GetBytes(32), rgbIv)

                    Using ms = New MemoryStream()

                        Using cs = New CryptoStream(ms, es, CryptoStreamMode.Write)
                            cs.Write(value, 0, len)
                            cs.FlushFinalBlock()
                            buffer = ms.ToArray()
                        End Using
                    End Using
                End Using

                len = buffer.Length
                value = New Byte(64 + len - 1) {}
                System.Buffer.BlockCopy(salt, 0, value, 0, 32)
                System.Buffer.BlockCopy(rgbIv, 0, value, 32, 32)
                System.Buffer.BlockCopy(buffer, 0, value, 64, len)
                Return value
            End Using
        End Function

        Public Async Function EncryptBytesAsync(ByVal value As Byte(), ByVal password As String, ByVal iterations As Integer) As Task(Of Byte())
            Dim len = value.Length
            Dim salt = New Byte(31) {}
            Dim rgbIv = New Byte(31) {}
            Dim buffer As Byte()

            Using csp = New RNGCryptoServiceProvider()
                csp.GetBytes(salt)
                csp.GetBytes(rgbIv)
            End Using

            Using bytes = New Rfc2898DeriveBytes(password, salt, iterations)
                Dim rm = New RijndaelManaged With {
                    .BlockSize = 256,
                    .Mode = CipherMode.CBC,
                    .Padding = PaddingMode.PKCS7
                }

                Using es = rm.CreateEncryptor(bytes.GetBytes(32), rgbIv)

                    Using ms = New MemoryStream()

                        Using cs = New CryptoStream(ms, es, CryptoStreamMode.Write)
                            Await cs.WriteAsync(value, 0, len)
                            cs.FlushFinalBlock()
                            buffer = ms.ToArray()
                        End Using
                    End Using
                End Using

                len = buffer.Length
                value = New Byte(64 + len - 1) {}
                System.Buffer.BlockCopy(salt, 0, value, 0, 32)
                System.Buffer.BlockCopy(rgbIv, 0, value, 32, 32)
                System.Buffer.BlockCopy(buffer, 0, value, 64, len)
                Return value
            End Using
        End Function

        Public Function EncryptString(ByVal value As String, ByVal password As String, ByVal iterations As Integer) As String
            Dim buffer = EncryptBytes(Encoding.UTF8.GetBytes(value), password, iterations)
            Return Convert.ToBase64String(buffer)
        End Function

        Public Async Function EncryptStringAsync(ByVal value As String, ByVal password As String, ByVal iterations As Integer) As Task(Of String)
            Dim buffer = Await EncryptBytesAsync(Encoding.UTF8.GetBytes(value), password, iterations)
            Return Convert.ToBase64String(buffer)
        End Function

        Public Function DecryptBytes(ByVal value As Byte(), ByVal password As String, ByVal iterations As Integer) As Byte()
            Dim len = value.Length - 64
            Dim salt = New Byte(31) {}
            Dim rgbIv = New Byte(31) {}
            Dim buffer = New Byte(len - 1) {}
            System.Buffer.BlockCopy(value, 0, salt, 0, 32)
            System.Buffer.BlockCopy(value, 32, rgbIv, 0, 32)
            System.Buffer.BlockCopy(value, 64, buffer, 0, len)
            Dim rm = New RijndaelManaged With {
                .BlockSize = 256,
                .Mode = CipherMode.CBC,
                .Padding = PaddingMode.PKCS7
            }

            Using bytes = New Rfc2898DeriveBytes(password, salt, iterations)

                Using ds = rm.CreateDecryptor(bytes.GetBytes(32), rgbIv)

                    Using ms = New MemoryStream()

                        Using cs = New CryptoStream(ms, ds, CryptoStreamMode.Write)
                            cs.Write(buffer, 0, len)
                            cs.FlushFinalBlock()
                            Return ms.ToArray()
                        End Using
                    End Using
                End Using
            End Using
        End Function

        Public Async Function DecryptBytesAsync(ByVal value As Byte(), ByVal password As String, ByVal iterations As Integer) As Task(Of Byte())
            Dim len = value.Length - 64
            Dim salt = New Byte(31) {}
            Dim rgbIv = New Byte(31) {}
            Dim buffer = New Byte(len - 1) {}
            System.Buffer.BlockCopy(value, 0, salt, 0, 32)
            System.Buffer.BlockCopy(value, 32, rgbIv, 0, 32)
            System.Buffer.BlockCopy(value, 64, buffer, 0, len)
            Dim rm = New RijndaelManaged With {
                .BlockSize = 256,
                .Mode = CipherMode.CBC,
                .Padding = PaddingMode.PKCS7
            }

            Using bytes = New Rfc2898DeriveBytes(password, salt, iterations)

                Using ds = rm.CreateDecryptor(bytes.GetBytes(32), rgbIv)

                    Using ms = New MemoryStream()

                        Using cs = New CryptoStream(ms, ds, CryptoStreamMode.Write)
                            Await cs.WriteAsync(buffer, 0, len)
                            cs.FlushFinalBlock()
                            Return ms.ToArray()
                        End Using
                    End Using
                End Using
            End Using
        End Function

        Public Function DecryptString(ByVal value As String, ByVal password As String, ByVal iterations As Integer) As String
            Dim buffer = DecryptBytes(Convert.FromBase64String(value), password, iterations)
            Return Encoding.UTF8.GetString(buffer)
        End Function

        Public Async Function DecryptStrinAsync(ByVal value As String, ByVal password As String, ByVal iterations As Integer) As Task(Of String)
            Dim buffer = Await DecryptBytesAsync(Convert.FromBase64String(value), password, iterations)
            Return Encoding.UTF8.GetString(buffer)
        End Function
    End Module


    ''' <summary>
    ''' Método avançado de criptografia utilizando um par de chaves assíncrono.
    ''' </summary>
    Public NotInheritable Class KeyPair
        Implements IDisposable



        Public Enum KeyType
            Signature = 1
            Exchange = 2
        End Enum


        Property Csp As CspParameters = New CspParameters()

        Private _rsa As RSACryptoServiceProvider

        Public Sub Dispose() Implements IDisposable.Dispose
            _rsa.Dispose()
            Me.Csp = Nothing
            _rsa = Nothing
        End Sub


        ''' <summary>
        ''' Retorna se uma chave pública foi carregada.
        ''' </summary>
        Public ReadOnly Property PublicOnly As Boolean
            Get
                If _rsa Is Nothing Then Throw New Exception("Chave(s) não encontrada(s)!")
                Return _rsa.PublicOnly
            End Get
        End Property


        ''' <summary>
        ''' Gera uma nova chave pública de encriptar e privada de decriptar.
        ''' </summary>
        Public Sub GenerateKeys(ByVal Optional type As KeyType = KeyType.Signature)
            Csp.ProviderType = type
            _rsa = New RSACryptoServiceProvider(1024, Csp)
        End Sub


        ''' <summary>
        ''' Retorna o string da chave. Isto funciona para pegar a chave para que possam ser passadas sem acessar um arquivo.
        ''' </summary>
        Public Function ExportKeyString(ByVal Optional exportPrivate As Boolean = False) As String
            Return _rsa.ToXmlString(exportPrivate)
        End Function


        ''' <summary>
        ''' Salva o dado da chave em um arquivo para reuso.
        ''' </summary>
        Public Sub ExportKey(ByVal file As String, ByVal Optional exportPrivate As Boolean = True)
            Dim stream = New StreamWriter(file, False)
            stream.Write(_rsa.ToXmlString(exportPrivate))
            stream.Close()
        End Sub


        ''' <summary>
        ''' Carrega o dado de string da chave para uso.
        ''' </summary>
        Public Sub ImportKeyString(ByVal key As String)
            _rsa = New RSACryptoServiceProvider(Csp)
            _rsa.FromXmlString(key)
        End Sub


        ''' <summary>
        ''' Carrega o dado de string da chave de um arquivo para uso.
        ''' </summary>
        Public Sub ImportKey(ByVal file As String)
            Dim stream = New StreamReader(file)
            _rsa = New RSACryptoServiceProvider(Csp)
            _rsa.FromXmlString(stream.ReadToEnd())
            stream.Close()
        End Sub

        Public Function EncryptBytes(ByVal value As Byte()) As Byte()
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }

            Using ms = New MemoryStream()
                ms.Write(_rsa.Encrypt(rm.Key, False), 0, 128)
                ms.Write(rm.IV, 0, 16)

                Using es = rm.CreateEncryptor()

                    Using cs = New CryptoStream(ms, es, CryptoStreamMode.Write)
                        cs.Write(value, 0, value.Length)
                        cs.FlushFinalBlock()
                    End Using
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Async Function EncryptBytesAsync(ByVal value As Byte()) As Task(Of Byte())
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }

            Using ms = New MemoryStream()
                Await ms.WriteAsync(_rsa.Encrypt(rm.Key, False), 0, 128)
                Await ms.WriteAsync(rm.IV, 0, 16)

                Using es = rm.CreateEncryptor()

                    Using cs = New CryptoStream(ms, es, CryptoStreamMode.Write)
                        Await cs.WriteAsync(value, 0, value.Length)
                        cs.FlushFinalBlock()
                    End Using
                End Using

                Return ms.ToArray()
            End Using
        End Function

        Public Function EncryptBytes(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Byte()
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }

            Using es = rm.CreateEncryptor()

                Using ms = New MemoryStream()
                    ms.Write(_rsa.Encrypt(rm.Key, False), 0, 128)
                    ms.Write(rm.IV, 0, 16)

                    Using cs = New CryptoStream(ms, es, CryptoStreamMode.Write)
                        cs.Write(value, offset, size)
                        cs.FlushFinalBlock()
                    End Using

                    Return ms.ToArray()
                End Using
            End Using
        End Function

        Public Async Function EncryptBytesAsync(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Task(Of Byte())
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }

            Using es = rm.CreateEncryptor()

                Using ms = New MemoryStream()
                    Await ms.WriteAsync(_rsa.Encrypt(rm.Key, False), 0, 128)
                    Await ms.WriteAsync(rm.IV, 0, 16)

                    Using cs = New CryptoStream(ms, es, CryptoStreamMode.Write)
                        Await cs.WriteAsync(value, offset, size)
                        cs.FlushFinalBlock()
                    End Using

                    Return ms.ToArray()
                End Using
            End Using
        End Function

        Public Function EncryptString(ByVal value As String) As String
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            Return Convert.ToBase64String(EncryptBytes(Encoding.UTF8.GetBytes(value)))
        End Function

        Public Async Function EncryptStringAsync(ByVal value As String) As Task(Of String)
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            Return Convert.ToBase64String(Await EncryptBytesAsync(Encoding.UTF8.GetBytes(value)))
        End Function

        Public Sub EncryptFile(ByVal srcFile As String, ByVal dstFile As String)
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            File.WriteAllBytes(dstFile, EncryptBytes(File.ReadAllBytes(srcFile)))
        End Sub

        Public Async Function EncryptFileAsync(ByVal srcFile As String, ByVal dstFile As String) As Task
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            File.WriteAllBytes(dstFile, Await EncryptBytesAsync(File.ReadAllBytes(srcFile)))
        End Function

        Public Function DecryptBytes(ByVal value As Byte()) As Byte()
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return Nothing
            If value.Length < 144 Then Return Nothing
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }
            Dim rgb = New Byte(127) {}
            Dim iv = New Byte(15) {}
            Dim len = value.Length - 144
            Dim buffer = New Byte(len - 1) {}
            System.Buffer.BlockCopy(value, 0, rgb, 0, 128)
            System.Buffer.BlockCopy(value, 128, iv, 0, 16)
            System.Buffer.BlockCopy(value, 144, buffer, 0, len)

            Using ds = rm.CreateDecryptor(_rsa.Decrypt(rgb, False), iv)

                Using ms = New MemoryStream()

                    Using cs = New CryptoStream(ms, ds, CryptoStreamMode.Write)
                        cs.Write(buffer, 0, len)
                        cs.FlushFinalBlock()
                        Return ms.ToArray()
                    End Using
                End Using
            End Using
        End Function

        Public Async Function DecryptBytesAsync(ByVal value As Byte()) As Task(Of Byte())
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return Nothing
            If value.Length < 144 Then Return Nothing
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }
            Dim rgb = New Byte(127) {}
            Dim iv = New Byte(15) {}
            Dim len = value.Length - 144
            Dim buffer = New Byte(len - 1) {}
            System.Buffer.BlockCopy(value, 0, rgb, 0, 128)
            System.Buffer.BlockCopy(value, 128, iv, 0, 16)
            System.Buffer.BlockCopy(value, 144, buffer, 0, len)

            Using ds = rm.CreateDecryptor(_rsa.Decrypt(rgb, False), iv)

                Using ms = New MemoryStream()

                    Using cs = New CryptoStream(ms, ds, CryptoStreamMode.Write)
                        Await cs.WriteAsync(buffer, 0, len)
                        cs.FlushFinalBlock()
                        Return ms.ToArray()
                    End Using
                End Using
            End Using
        End Function

        Public Function DecryptBytes(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Byte()
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return Nothing
            If value.Length < 144 Then Return Nothing
            If value.Length < offset + size Then Return Nothing
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }
            Dim rgb = New Byte(127) {}
            Dim iv = New Byte(15) {}
            Dim len = size - 144
            Dim buffer = New Byte(len - 1) {}
            System.Buffer.BlockCopy(value, offset, rgb, 0, 128)
            System.Buffer.BlockCopy(value, offset + 128, iv, 0, 16)
            System.Buffer.BlockCopy(value, offset + 144, buffer, 0, len)

            Using ds = rm.CreateDecryptor(_rsa.Decrypt(rgb, False), iv)

                Using ms = New MemoryStream()

                    Using cs = New CryptoStream(ms, ds, CryptoStreamMode.Write)
                        cs.Write(buffer, 0, len)
                        cs.FlushFinalBlock()
                        Return ms.ToArray()
                    End Using
                End Using
            End Using
        End Function

        Public Async Function DecryptBytesAsync(ByVal value As Byte(), ByVal offset As Integer, ByVal size As Integer) As Task(Of Byte())
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return Nothing
            If value.Length < 160 Then Return Nothing
            If value.Length < offset + size Then Return Nothing
            Dim rm = New RijndaelManaged With {
                .KeySize = 128,
                .BlockSize = 128,
                .Mode = CipherMode.CBC
            }
            Dim rgb = New Byte(127) {}
            Dim iv = New Byte(16) {}
            Dim len = size - 160
            Dim buffer = New Byte(len - 1) {}
            System.Buffer.BlockCopy(value, offset, rgb, 0, 128)
            System.Buffer.BlockCopy(value, offset + 128, iv, 0, 16)
            System.Buffer.BlockCopy(value, offset + 144, buffer, 0, len)

            Using ds = rm.CreateDecryptor(_rsa.Decrypt(rgb, False), iv)

                Using ms = New MemoryStream()

                    Using cs = New CryptoStream(ms, ds, CryptoStreamMode.Write)
                        Await cs.WriteAsync(buffer, 0, len)
                        cs.FlushFinalBlock()
                        Return ms.ToArray()
                    End Using
                End Using
            End Using
        End Function

        Public Function DecryptString(ByVal value As String) As String
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return Nothing
            Dim buffer = Convert.FromBase64String(value)
            If buffer.Length < 144 Then Return ""
            Return Encoding.UTF8.GetString(DecryptBytes(buffer))
        End Function

        Public Async Function DecryptStringAsync(ByVal value As String) As Task(Of String)
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return Nothing
            Dim buffer = Convert.FromBase64String(value)
            If buffer.Length < 144 Then Return ""
            Return Encoding.UTF8.GetString(Await DecryptBytesAsync(buffer))
        End Function

        Public Sub DecryptFile(ByVal srcFile As String, ByVal dstFile As String)
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return
            Dim buffer = DecryptBytes(File.ReadAllBytes(srcFile))
            If buffer Is Nothing Then Throw New Exception("Conteúdo do arquivo estava vazio!")
            File.WriteAllBytes(dstFile, buffer)
        End Sub

        Public Async Function DecryptFileAsync(ByVal srcFile As String, ByVal dstFile As String) As Task
            If _rsa Is Nothing Then Throw New Exception("Chave não setada.")
            If _rsa.PublicOnly Then Return
            Dim buffer = Await DecryptBytesAsync(File.ReadAllBytes(srcFile))
            If buffer Is Nothing Then Throw New Exception("Conteúdo do arquivo estava vazio!")
            File.WriteAllBytes(dstFile, buffer)
        End Function
    End Class
End Namespace