Imports System.Data.SqlClient
Imports System.Security.Cryptography

Module MyMod
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.SqlClient.SqlDataReader
    Public SQL As String
    Public conn As New SqlConnection
    Public cn As New Connection

    'Tabel Fakultas
    '-------------------------------
    Public fakultas_baru As Boolean
    Public ofakultas As New Fakultas
    '--------------------------------

    'Tabel Prodi
    '-------------------------------
    Public prodi_baru As Boolean
    Public oprodi As New Prodi
    '--------------------------------

    'Tabel Dosen
    '-------------------------------
    Public dosen_baru As Boolean
    Public odosen As New Dosen
    '--------------------------------

    'Tabel Mahasiswa
    '-------------------------------
    Public mahasiswa_baru As Boolean
    Public omahasiswa As New Mahasiswa
    '--------------------------------

    'Tabel Matakuliah
    '-------------------------------
    Public matakuliah_baru As Boolean
    Public omatakuliah As New Matakuliah
    '--------------------------------

    'Tabel Krs
    '-------------------------------
    Public krs_baru As Boolean
    Public krsdetail_baru As Boolean
    Public oKrs As New Krs
    '--------------------------------

    Public nobukti As Double
    Public R As Random = New Random

    Public Sub DBConnect()
        cn.DataSource = "DESKTOP-QJ51NG5\SQLEXPRESS"   'sesuaikan dengan login SQL Server milik anda
        cn.DatabaseName = "akademik"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getNomorBukti()
        Dim res As Double
        res = R.Next(1000000, 9999999)
        Return res
    End Function
End Module
