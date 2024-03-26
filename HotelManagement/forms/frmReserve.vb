Public Class frmReserve

    Private Sub frmReserve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Disable_previous_date(dtpCheckin, dtpCheckout)
        Load_Room_Type_reserve()
        Call btnAvailSeach_Click(sender, e)

    End Sub

    Private Sub btnAvailSeach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailSeach.Click
        Availability_Search_reserve()
        lblMessage.Text = "Available Room(s) from " & dtpCheckin.Text & " to " & dtpCheckout.Text
    End Sub

    Private Sub lstRoomType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRoomType.Click
        Try
            Availability_Search_Type_Reserve()
            '  lblMessage.Text = lstRoomType.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReserve.Click
        Try
            With frmBookingDetails
                Dim tot As Double
                sql = bookingDetails(dtpCheckin, dtpCheckout) & " AND ROOMID =" & dtgList.CurrentRow.Cells(0).Value
                reloadDtg(sql, .dtgList)
                For Each r As DataGridViewRow In .dtgList.Rows
                    tot += r.Cells(9).Value * r.Cells(3).Value
                Next
                .txtSubtotal.Text = tot.ToString("n2")
                .txtTotal.Text = .txtSubtotal.Text
                .lblTitle.Text = "Reservation Details"
                .btnSave.Text = "Reserve"
            End With
            frmShow(frmBookingDetails)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class