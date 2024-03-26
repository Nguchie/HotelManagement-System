Public Class frmReservedRoom

    Private Sub frmReservedRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReservedRooms()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = ReservedRooms() & "  and  concat (`ROOMNUM`,' ', `ROOM`,' ',`G_FNAME` , ' ' , `G_LNAME`) LIKE '%" & txtSearch.Text & "%'"
        RETRIEVEDTG(dtgList, sql)
    End Sub
    Public Sub save()
        'sql = "UPDATE `tblreservation` SET `STATUS` = 'BOOKED' WHERE `TRANSNUM`=" & dtgList.CurrentRow.Cells(0).Value
        'result = CUD(sql)
        'If result = False Then
        '    MsgBox("ERROR TO UPDATE tblreservation", MsgBoxStyle.Exclamation)
        'End If

        sql = "UPDATE `tblpayment` SET `STATUS` = 'BOOKED' ,`TENDERED`=`TENDERED`+ " & frmPopRPayment.txttender.Text & ", `CHANGED`=" & Double.Parse(frmPopRPayment.txtChange.Text) & " WHERE `TRANSNUM`=" & dtgList.CurrentRow.Cells(0).Value
        result = CUD(sql)
        If result = False Then
            MsgBox("ERROR TO UPDATE tblpayment", MsgBoxStyle.Exclamation)
        Else
            MsgBox("Guest has been checked-in.")
        End If
       
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCheckedout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckedout.Click
        Try
            If dtgList.CurrentRow.Cells(8).Value = 0 Then
                save()
            Else

                frmShow(frmPopRPayment)
                With frmPopRPayment
                    .txtTransNo.Text = dtgList.CurrentRow.Cells(0).Value
                    .txtTotalAmount.Text = dtgList.CurrentRow.Cells(8).Value
                End With

            End If
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            sql = "UPDATE `tblreservation` SET `STATUS` = 'CANCELLED' WHERE `TRANSNUM`=" & dtgList.CurrentRow.Cells(0).Value
            result = CUD(sql)
            If result = False Then
                MsgBox("ERROR TO UPDATE tblreservation", MsgBoxStyle.Exclamation)
            End If

            sql = "UPDATE `tblpayment` SET `STATUS` = 'CANCELLED' ,`TENDERED`=0, `CHANGED`=0 WHERE `TRANSNUM`=" & dtgList.CurrentRow.Cells(0).Value
            result = CUD(sql)
            If result = False Then
                MsgBox("ERROR TO UPDATE tblpayment", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Reservation of room(s) has been cancelled.")
            End If
            ReservedRooms()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellContentClick

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmShow(frmReserve)
        Me.Close()
    End Sub
End Class