Public Class Dosen
    Dim strsql As String
    Dim info As String
    Private _iddsn As Integer
    Private _nidn As String
    Private _nama_lengkap As String
    Private _jk As String
    Private _email As String
    Private _telpon As String
    Private _kode_fakultas As String
    Private _kode_prodi As String
    Private _passwd As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nidn()
        Get
            Return _nidn
        End Get
        Set(ByVal value)
            _nidn = value
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
    Public Property email()
        Get
            Return _email
        End Get
        Set(ByVal value)
            _email = value
        End Set
    End Property
    Public Property telpon()
        Get
            Return _telpon
        End Get
        Set(ByVal value)
            _telpon = value
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
        If (dosen_baru = True) Then
            strsql = "Insert into dosen(nidn,nama_lengkap,jk,email,telpon,kode_fakultas,kode_prodi,passwd) values ('" & _nidn & "','" & _nama_lengkap & "','" & _jk & "','" & _email & "','" & _telpon & "','" & _kode_fakultas & "','" & _kode_prodi & "','" & _passwd & "')"
            info = "INSERT"
        Else
            strsql = "update dosen set nidn='" & _nidn & "', nama_lengkap='" & _nama_lengkap & "', jk='" & _jk & "', email='" & _email & "', telpon='" & _telpon & "', kode_fakultas='" & _kode_fakultas & "', kode_prodi='" & _kode_prodi & "', passwd='" & _passwd & "' where nidn='" & _nidn & "'"
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
    Public Sub Caridosen(ByVal snidn As String)
        DBConnect()
        strsql = "SELECT * FROM dosen WHERE nidn='" & snidn & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            dosen_baru = False
            DR.Read()
            nidn = Convert.ToString((DR("nidn")))
            nama_lengkap = Convert.ToString((DR("nama_lengkap")))
            jk = Convert.ToString((DR("jk")))
            email = Convert.ToString((DR("email")))
            telpon = Convert.ToString((DR("telpon")))
            kode_fakultas = Convert.ToString((DR("kode_fakultas")))
            kode_prodi = Convert.ToString((DR("kode_prodi")))
            passwd = Convert.ToString((DR("passwd")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            dosen_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal snidn As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM dosen WHERE nidn='" & snidn & "'"
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
            strsql = "SELECT * FROM dosen"
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
