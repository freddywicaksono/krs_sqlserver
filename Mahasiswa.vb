Public Class Mahasiswa
    Dim strsql As String
    Dim info As String
    Private _idmhs As Integer
    Private _nim As String
    Private _nama_lengkap As String
    Private _jk As String
    Private _tanggal_lahir As String
    Private _kode_fakultas As String
    Private _kode_prodi As String
    Private _nidn_dosenwali As String
    Private _passwd As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nim()
        Get
            Return _nim
        End Get
        Set(ByVal value)
            _nim = value
        End Set
    End Property
    Public Property nama_lengkap()
        Get
            Return _nama_lengkap
        End Get
        Set(ByVal value)
            _nama_lengkap = value
        End Set
    End Property
    Public Property jk()
        Get
            Return _jk
        End Get
        Set(ByVal value)
            _jk = value
        End Set
    End Property
    Public Property tanggal_lahir()
        Get
            Return _tanggal_lahir
        End Get
        Set(ByVal value)
            _tanggal_lahir = value
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
    Public Property kode_prodi()
        Get
            Return _kode_prodi
        End Get
        Set(ByVal value)
            _kode_prodi = value
        End Set
    End Property
    Public Property nidn_dosenwali()
        Get
            Return _nidn_dosenwali
        End Get
        Set(ByVal value)
            _nidn_dosenwali = value
        End Set
    End Property
    Public Property passwd()
        Get
            Return _passwd
        End Get
        Set(ByVal value)
            _passwd = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (mahasiswa_baru = True) Then
            strsql = "Insert into mahasiswa(nim,nama_lengkap,jk,tanggal_lahir,kode_fakultas,kode_prodi,nidn_dosenwali,passwd) values ('" & _nim & "','" & _nama_lengkap & "','" & _jk & "','" & _tanggal_lahir & "','" & _kode_fakultas & "','" & _kode_prodi & "','" & _nidn_dosenwali & "','" & _passwd & "')"
            info = "INSERT"
        Else
            strsql = "update mahasiswa set nim='" & _nim & "', nama_lengkap='" & _nama_lengkap & "', jk='" & _jk & "', tanggal_lahir='" & _tanggal_lahir & "', kode_fakultas='" & _kode_fakultas & "', kode_prodi='" & _kode_prodi & "', nidn_dosenwali='" & _nidn_dosenwali & "', passwd='" & _passwd & "' where nim='" & _nim & "'"
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
    Public Sub Carimahasiswa(ByVal snim As String)
        DBConnect()
        strsql = "SELECT * FROM mahasiswa WHERE nim='" & snim & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            mahasiswa_baru = False
            DR.Read()
            nim = Convert.ToString((DR("nim")))
            nama_lengkap = Convert.ToString((DR("nama_lengkap")))
            jk = Convert.ToString((DR("jk")))
            tanggal_lahir = Convert.ToString((DR("tanggal_lahir")))
            kode_fakultas = Convert.ToString((DR("kode_fakultas")))
            kode_prodi = Convert.ToString((DR("kode_prodi")))
            nidn_dosenwali = Convert.ToString((DR("nidn_dosenwali")))
            passwd = Convert.ToString((DR("passwd")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            mahasiswa_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal snim As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM mahasiswa WHERE nim='" & snim & "'"
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
            strsql = "SELECT * FROM mahasiswa"
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
