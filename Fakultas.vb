Public Class Fakultas
    Dim strsql As String
    Dim info As String
    Private _idfk As Integer
    Private _kode_fakultas As String
    Private _nama_fakultas As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_fakultas()
        Get
            Return _kode_fakultas
        End Get
        Set(ByVal value)
            _kode_fakultas = value
        End Set
    End Property
    Public Property nama_fakultas()
        Get
            Return _nama_fakultas
        End Get
        Set(ByVal value)
            _nama_fakultas = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (fakultas_baru = True) Then
            strsql = "Insert into fakultas(kode_fakultas,nama_fakultas) values ('" & _kode_fakultas & "','" & _nama_fakultas & "')"
            info = "INSERT"
        Else
            strsql = "update fakultas set kode_fakultas='" & _kode_fakultas & "', nama_fakultas='" & _nama_fakultas & "' where kode_fakultas='" & _kode_fakultas & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Carifakultas(ByVal skode_fakultas As String)
        DBConnect()
        strsql = "SELECT * FROM fakultas WHERE kode_fakultas='" & skode_fakultas & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            fakultas_baru = False
            DR.Read()
            kode_fakultas = Convert.ToString((DR("kode_fakultas")))
            nama_fakultas = Convert.ToString((DR("nama_fakultas")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            fakultas_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_fakultas As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM fakultas WHERE kode_fakultas='" & skode_fakultas & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM fakultas"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
