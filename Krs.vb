Public Class Krs
    Dim strsql As String
    Dim info As String
    Private _idkrs As Integer
    Private _nomor_bukti As String
    Private _tanggal As String
    Private _nim As String
    Private _jenis_semester As String
    Private _tahun_akademik As String
    Private _semester As String
    Private _nidn As String
    Private _indeks_prestasi As System.Single = 0
    Private _catatan As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Private _iddetail As Integer
    Private _kodemk As String
    Private _sks As Integer
    Private _keterangan As String
    Private _nilai_khd As System.Single = 0
    Private _nilai_tgs As System.Single = 0
    Private _nilai_uts As System.Decimal = 0
    Private _nilai_uas As System.Single = 0
    Private _nilai_akhir As System.Single = 0
    Private _nilai_mutu As String = vbNull
    Public Property nomor_bukti()
        Get
            Return _nomor_bukti
        End Get
        Set(ByVal value)
            _nomor_bukti = value
        End Set
    End Property
    Public Property tanggal()
        Get
            Return _tanggal
        End Get
        Set(ByVal value)
            _tanggal = value
        End Set
    End Property
    Public Property nim()
        Get
            Return _nim
        End Get
        Set(ByVal value)
            _nim = value
        End Set
    End Property
    Public Property jenis_semester()
        Get
            Return _jenis_semester
        End Get
        Set(ByVal value)
            _jenis_semester = value
        End Set
    End Property
    Public Property tahun_akademik()
        Get
            Return _tahun_akademik
        End Get
        Set(ByVal value)
            _tahun_akademik = value
        End Set
    End Property
    Public Property semester()
        Get
            Return _semester
        End Get
        Set(ByVal value)
            _semester = value
        End Set
    End Property
    Public Property nidn()
        Get
            Return _nidn
        End Get
        Set(ByVal value)
            _nidn = value
        End Set
    End Property
    Public Property indeks_prestasi()
        Get
            Return _indeks_prestasi
        End Get
        Set(ByVal value)
            _indeks_prestasi = value
        End Set
    End Property
    Public Property catatan()
        Get
            Return _catatan
        End Get
        Set(ByVal value)
            _catatan = value
        End Set
    End Property
    Public Property iddetail()
        Get
            Return _iddetail
        End Get
        Set(ByVal value)
            _iddetail = value
        End Set
    End Property
    Public Property kodemk()
        Get
            Return _kodemk
        End Get
        Set(ByVal value)
            _kodemk = value
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
    Public Property keterangan()
        Get
            Return _keterangan
        End Get
        Set(ByVal value)
            _keterangan = value
        End Set
    End Property
    Public Property nilai_khd()
        Get
            Return _nilai_khd
        End Get
        Set(ByVal value)
            _nilai_khd = value
        End Set
    End Property
    Public Property nilai_tgs()
        Get
            Return _nilai_tgs
        End Get
        Set(ByVal value)
            _nilai_tgs = value
        End Set
    End Property
    Public Property nilai_uts()
        Get
            Return _nilai_uts
        End Get
        Set(ByVal value)
            _nilai_uts = value
        End Set
    End Property
    Public Property nilai_uas()
        Get
            Return _nilai_uas
        End Get
        Set(ByVal value)
            _nilai_uas = value
        End Set
    End Property
    Public Property nilai_akhir()
        Get
            Return _nilai_akhir
        End Get
        Set(ByVal value)
            _nilai_akhir = value
        End Set
    End Property
    Public Property nilai_mutu()
        Get
            Return _nilai_mutu
        End Get
        Set(ByVal value)
            _nilai_mutu = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (krs_baru = True) Then
            strsql = "Insert into krs(nomor_bukti,tanggal,nim,jenis_semester,tahun_akademik,semester,nidn,indeks_prestasi,catatan) values ('" & _nomor_bukti & "','" & _tanggal & "','" & _nim & "','" & _jenis_semester & "','" & _tahun_akademik & "','" & _semester & "','" & _nidn & "','" & _indeks_prestasi & "','" & _catatan & "')"
            info = "INSERT"
        Else
            strsql = "update krs set nomor_bukti='" & _nomor_bukti & "', tanggal='" & _tanggal & "', nim='" & _nim & "', jenis_semester='" & _jenis_semester & "', tahun_akademik='" & _tahun_akademik & "', semester='" & _semester & "', nidn='" & _nidn & "', indeks_prestasi='" & _indeks_prestasi & "', catatan='" & _catatan & "' where nomor_bukti='" & _nomor_bukti & "'"
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
    Public Sub SimpanDetail()
        Dim info As String
        DBConnect()
        If (krsdetail_baru = True) Then
            strsql = "Insert into krsdetail(nomor_bukti,kodemk,sks) values ('" & _nomor_bukti & "','" & _kodemk & "','" & _sks & "')"
            info = "Data berhasil disimpan"
        Else
            strsql = "update krsdetail set nomor_bukti='" & _nomor_bukti & "', kodemk='" & _kodemk & "', sks='" & _sks & "', keterangan='" & _keterangan & "', nilai_khd='" & _nilai_khd & "', nilai_tgs='" & _nilai_tgs & "', nilai_uts='" & _nilai_uts & "', nilai_uas='" & _nilai_uas & "', nilai_akhir='" & _nilai_akhir & "', nilai_mutu='" & _nilai_mutu & "' where iddetail='" & _iddetail & "'"
            info = "Data berhasil diperbarui"
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
    Public Sub Carikrs(ByVal snomor_bukti As String)
        DBConnect()
        strsql = "SELECT * FROM krs WHERE nomor_bukti='" & snomor_bukti & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            krs_baru = False
            DR.Read()
            nomor_bukti = Convert.ToString((DR("nomor_bukti")))
            tanggal = Convert.ToString((DR("tanggal")))
            nim = Convert.ToString((DR("nim")))
            jenis_semester = Convert.ToString((DR("jenis_semester")))
            tahun_akademik = Convert.ToString((DR("tahun_akademik")))
            semester = Convert.ToString((DR("semester")))
            nidn = Convert.ToString((DR("nidn")))
            indeks_prestasi = Convert.ToString((DR("indeks_prestasi")))
            catatan = Convert.ToString((DR("catatan")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            krs_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal snomor_bukti As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM krs WHERE nomor_bukti='" & snomor_bukti & "'"
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
    Public Sub HapusDetail(ByVal siddetail As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM krsdetail WHERE iddetail='" & siddetail & "'"
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
    Public Sub getAllDataDetail(ByVal dg As DataGridView, ByVal snomor_bukti As String)
        Try
            DBConnect()
            strsql = "SELECT A.kodemk,B.namamk,A.sks FROM krsdetail A left join matakuliah B on(A.kodemk=B.kodemk) WHERE A.nomor_bukti='" & snomor_bukti & "'"
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
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM krs"
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
