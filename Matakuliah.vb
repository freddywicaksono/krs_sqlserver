Public Class Matakuliah
    Dim strsql As String
    Dim info As String
    Private _idmk As Integer
    Private _kodemk As String
    Private _namamk As String
    Private _sks As Integer
    Private _kode_prodi As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kodemk()
        Get
            Return _kodemk
        End Get
        Set(ByVal value)
            _kodemk = value
        End Set
    End Property
    Public Property namamk()
        Get
            Return _namamk
        End Get
        Set(ByVal value)
            _namamk = value
        End Set
    End Property
    Public Property sks()
        Get
            Return _sks
        End Get
        Set(ByVal value)
            _sks = value
        End Set
    End Property
    Public Property kode_prodi()
        Get
            Return _kode_prodi
        End Get
        Set(ByVal value)
            _kode_prodi = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (matakuliah_baru = True) Then
            strsql = "Insert into matakuliah(kodemk,namamk,sks,kode_prodi) values ('" & _kodemk & "','" & _namamk & "','" & _sks & "','" & _kode_prodi & "')"
            info = "INSERT"
        Else
            strsql = "update matakuliah set kodemk='" & _kodemk & "', namamk='" & _namamk & "', sks='" & _sks & "', kode_prodi='" & _kode_prodi & "' where kodemk='" & _kodemk & "'"
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
    Public Sub Carimatakuliah(ByVal skodemk As String)
        DBConnect()
        strsql = "SELECT * FROM matakuliah WHERE kodemk='" & skodemk & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            matakuliah_baru = False
            DR.Read()
            kodemk = Convert.ToString((DR("kodemk")))
            namamk = Convert.ToString((DR("namamk")))
            sks = Convert.ToString((DR("sks")))
            kode_prodi = Convert.ToString((DR("kode_prodi")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            matakuliah_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal skodemk As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM matakuliah WHERE kodemk='" & skodemk & "'"
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
            strsql = "SELECT * FROM matakuliah"
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
