Public Class frmPopRPayment
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtChange.Text >= 0 Then
                Call frmReservedRoom.save()
                sql = " SELECT `ROOMTYPE`  as 'RoomType',`ROOMNUM`, `ROOM`, `NUMPERSON`, `PRICE`,`G_FNAME`, `G_LNAME`, `G_ADDRESS`, `G_PHONE`,`ARRIVAL`, `DEPARTURE`, `RPRICE`, r.`STATUS`,r.`TRANSDATE`, r.`TRANSNUM`, `SPRICE`, `TENDERED`, `CHANGED` FROM  `tblroomtype` rt, `tblroom` rm,  `tblreservation` r, `tblpayment` p, `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID`=r.`ROOMID` and  r.`TRANSNUM`=p.`TRANSNUM`  AND p.`GUESTID`=g.`GUESTID`   AND r.TRANSNUM=" & txtTransNo.Text
                reports(sql, "receipt", frmReciept.CrystalReportViewer1)
                frmShow(frmReciept)
                frmReciept.lbltitle.Text = "Booking"
                ReservedRooms()
            Else
                MsgBox("Unable to save. Tender the right amount.", MsgBoxStyle.Exclamation)

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

End Class