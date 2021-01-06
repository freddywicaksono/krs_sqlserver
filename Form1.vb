Public Class Form1
    Private Sub TampilKrs()
        txtnomor_bukti.Text = okrs.nomor_bukti
        txttanggal.Text = okrs.tanggal
        txtNIM.Text = oKrs.nim

        If (oKrs.jenis_semester = "GANJIL") Then
            txtGanjil.Checked = True
        ElseIf (oKrs.jenis_semester = "GENAP") Then
            txtGenap.Checked = True
        Else
            txtGanjil.Checked = False
            txtGenap.Checked = False
        End If
        txttahun_akademik.Text = okrs.tahun_akademik
        cboSemester.Text = oKrs.semester
        oMahasiswa.Carimahasiswa(txtNIM.Text)
        If (mahasiswa_baru = False) Then
            TampilMahasiswa()
        End If
    End Sub

    Private Sub IsiCombo()
        Dim i As Integer
        cboSemester.Items.Clear()

        If (txtGanjil.Checked = True) Then
            For i = 1 To 12 Step 2
                cboSemester.Items.Add(i.ToString)
            Next
        End If

        If (txtGenap.Checked = True) Then
            For i = 2 To 12 Step 2
                cboSemester.Items.Add(i.ToString)
            Next
        End If
    End Sub

    Private Sub reload()

        nobukti = getNomorBukti()
        txtNomor_Bukti.Text = nobukti

    End Sub

    Private Sub SimpanKRS()
        krs_baru = True
        oKrs.nomor_bukti = txtNomor_Bukti.Text
        oKrs.tanggal = txtTanggal.Text
        oKrs.nim = txtNIM.Text
        If (txtGanjil.Checked = True) Then
            oKrs.jenis_semester = "GANJIL"
        End If
        If (txtGenap.Checked) Then
            oKrs.jenis_semester = "GENAP"
        End If
        oKrs.tahun_akademik = txtTahun_Akademik.Text
        oKrs.semester = cboSemester.Text
        oKrs.nidn = oMahasiswa.nidn_dosenwali

        oKrs.Simpan()

    End Sub

    Private Sub TampilMahasiswa()
        Dim nidn As String
        txtNama.Text = oMahasiswa.nama_lengkap
        oFakultas.Carifakultas(oMahasiswa.kode_fakultas)
        oProdi.Cariprodi(oMahasiswa.kode_prodi)
        txtFakultasProdi.Text = oFakultas.nama_fakultas & " / " & oProdi.nama_prodi
        nidn = oMahasiswa.nidn_dosenwali
        oDosen.Caridosen(nidn)
        txtDosenWali.Text = oDosen.nama_lengkap
    End Sub

    Private Sub ClearEntry()
        txtNIM.Text = ""
        txtNama.Text = ""
        txtDosenWali.Text = ""
        txtFakultasProdi.Text = ""
        txtTahun_Akademik.Text = ""
        txtGanjil.Checked = False
        txtGenap.Checked = False
        cboSemester.Items.Clear()
        cboSemester.Text = ""
        DataGridView1.DataSource = ""
        reload()
    End Sub

    Private Sub GetData()
        oKrs.getAllDataDetail(DataGridView1, txtNomor_Bukti.Text)
    End Sub

    Private Sub txtNomor_Bukti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomor_Bukti.KeyDown
        If (e.KeyCode = Keys.Enter And txtNomor_Bukti.Text <> "") Then
            oKrs.Carikrs(txtNomor_Bukti.Text)
            If (krs_baru = True) Then
                txtNIM.Focus()
            Else
                TampilKrs()
            End If
        End If
    End Sub

    Private Sub txtNIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIM.KeyDown
        If (e.KeyCode = Keys.Enter And txtNIM.Text <> "") Then
            omahasiswa.Carimahasiswa(txtNIM.Text)
            If (mahasiswa_baru = False) Then
                TampilMahasiswa()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub txtGanjil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGanjil.CheckedChanged
        IsiCombo()
    End Sub

    Private Sub txtGenap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGenap.CheckedChanged
        IsiCombo()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        GetData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanKRS()
        detail.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reload()
    End Sub
End Class
