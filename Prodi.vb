Public Class Prodi
    Dim strsql As String
    Dim info As String
    Private _idprodi As Integer
    Private _kode_prodi As String
    Private _nama_prodi As String
    Private _kode_fakultas As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_prodi()
        Get
            Return _kode_prodi
        End Get
        Set(ByVal value)
            _kode_prodi = value
        End Set
    End Property
    Public Property nama_prodi()
        Get
            Return _nama_prodi
        End Get
        Set(ByVal value)
            _nama_prodi = value
        End Set
    End Property
    Public Property kode_fakultas()
        Get
            Return _kode_fakultas
        End Get
        Set(ByVal value)
            _kode_fakultas = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (prodi_baru = True) Then
            strsql = "Insert into prodi(kode_prodi,nama_prodi,kode_fakultas) values ('" & _kode_prodi & "','" & _nama_prodi & "','" & _kode_fakultas & "')"
            info = "INSERT"
        Else
            strsql = "update prodi set kode_prodi='" & _kode_prodi & "', nama_prodi='" & _nama_prodi & "', kode_fakultas='" & _kode_fakultas & "' where kode_prodi='" & _kode_prodi & "'"
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
    Public Sub Cariprodi(ByVal skode_prodi As String)
        DBConnect()
        strsql = "SELECT * FROM prodi WHERE kode_prodi='" & skode_prodi & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            prodi_baru = False
            DR.Read()
            kode_prodi = Convert.ToString((DR("kode_prodi")))
            nama_prodi = Convert.ToString((DR("nama_prodi")))
            kode_fakultas = Convert.ToString((DR("kode_fakultas")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            prodi_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skode_prodi As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM prodi WHERE kode_prodi='" & skode_prodi & "'"
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
            strsql = "SELECT * FROM prodi"
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
