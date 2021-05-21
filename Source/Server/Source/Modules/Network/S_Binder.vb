Public Class S_Binder
    Inherits Runtime.Serialization.SerializationBinder

    Overrides Function BindToType(assemblyName As String, typeName As String) As Type
        assemblyName = assemblyName.Replace("Cliente Elysium", "Servidor Elysium")
        Return Type.GetType(String.Format("{0}, {1}", typeName, assemblyName))
    End Function
End Class
