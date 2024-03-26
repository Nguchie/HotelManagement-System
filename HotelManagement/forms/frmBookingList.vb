Public Class frmBookingList

    Private Sub frmBookingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BookedRooms()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = BookedRooms() & "  and  concat (`ROOMNUM`,' ', `ROOM`,' ',`G_FNAME` , ' ' , `G_LNAME`) LIKE '%" & txtSearch.Text & "%'"
        RETRIEVEDTG(dtgList, sql)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCheckedout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckedout.Click
        Try
            'sql = "UPDATE `tblreservation` SET `STATUS` = 'CHECKED-OUT' WHERE `TRANSNUM`=" & dtgList.CurrentRow.Cells(0).Value
            'result = CUD(sql)
            'If result = False Then
            '    MsgBox("ERROR TO UPDATE tblreservation", MsgBoxStyle.Exclamation)
            'End If

            sql = "UPDATE `tblpayment` SET `STATUS` = 'CHECKED-OUT' WHERE `TRANSNUM`=" & dtgList.CurrentRow.Cells(0).Value
            result = CUD(sql)
            If result = False Then
                MsgBox("ERROR TO UPDATE tblpayment", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Guest has been checked-out.")
            End If

            BookedRooms()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            frmViewBookRooms.txtTransno.Text = dtgList.CurrentRow.Cells(0).Value
            frmShow(frmViewBookRooms)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        frmShow(frmBooking)
        Me.Close()
    End Sub
End Class