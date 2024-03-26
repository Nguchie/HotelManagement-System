Public Class frmReciept
    Dim title As String = ""
    Private Sub frmReciept_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmBookingDetails.Close()
        frmPopPayment.Close()
        frmPopPaymentsReserve.Close()
        frmPopRPayment.Close()
        If lbltitle.Text = "Reserve" Then
            frmShow(frmReservedRoom)
        Else
            frmShow(frmBookingList)
        End If
    End Sub

   
    Private Sub frmReciept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class