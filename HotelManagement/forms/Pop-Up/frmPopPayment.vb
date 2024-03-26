Public Class frmPopPayment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If frmBookingDetails.btnSave.Text = "Reserve" Then
                If txttender.Text = "0.00" Or txttender.Text = "" Or txttender.Text = "0" Then
                    MsgBox("Unable to save. Tender the right amount.", MsgBoxStyle.Exclamation)
                Else
                    Call frmBookingDetails.Book_now()
                    frmReciept.lbltitle.Text = "Booking"
                End If
            Else
                If txttender.Text = "0.00" Or txttender.Text = "" Or txttender.Text = "0" Or txtChange.Text < 0 Then
                    MsgBox("Unable to save. Tender the right amount.", MsgBoxStyle.Exclamation)
                Else 
                    Call frmBookingDetails.Book_now()
                    frmReciept.lbltitle.Text = "Booking"
                End If
            End If
           
        Catch ex As Exception
            MsgBox("Unable to save. Tender the right amount.", MsgBoxStyle.Exclamation)

        End Try

      End Sub

    Private Sub txttender_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttender.TextChanged
        Try
            Dim change As Double
            Dim tender As Double = txttender.Text
            Dim total As Double = txtTotalAmount.Text
            change = tender - total
            txtChange.Text = change.ToString("n2")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txttender_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttender.KeyPress
        CURENCY_ONLY(e, txtChange)
    End Sub

    Private Sub frmPopPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class