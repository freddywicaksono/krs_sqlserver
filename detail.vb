Public Class detail
    Private Sub ClearEntry()
        txtkodemk.Text = ""
        txtNamaMK.Text = ""
        txtSKS.Text = ""
    End Sub
    Private Sub Reload()
        oKrs.getAllDataDetail(DataGridView1, txtnomor_bukti.Text)
    End Sub

    Private Sub SimpanKRSDetail()
        oKrs.nomor_bukti = txtnomor_bukti.Text
        oKrs.kodemk = txtkodemk.Text
        oKrs.sks = txtSKS.Text
        krsdetail_baru = True
        oKrs.SimpanDetail()
        ClearEntry()
        Reload()
    End Sub
    Private Sub txtkodemk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkodemk.KeyDown
        If (e.KeyCode = Keys.Enter And txtkodemk.Text <> "") Then
            omatakuliah.Carimatakuliah(txtkodemk.Text)
            txtNamaMK.Text = omatakuliah.namamk
            txtSKS.Text = omatakuliah.sks
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        SimpanKRSDetail()
        txtkodemk.Focus()
    End Sub

    Private Sub detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnomor_bukti.Text = nobukti
        Reload()
    End Sub
End Class