Public Class frmViewBookRooms

    Private Sub frmViewBookRooms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim totadons As Double
            Dim subtot As Double
            sql = "SELECT * FROM `tblguest` g, `tblpayment` p WHERE g.`GUESTID`=p.`GUESTID` and p.`TRANSNUM`=" & txtTransno.Text
            result = RETRIEVESINGLE(sql)
            If result = True Then
                With dt.Rows(0)
                    txtFname.Text = .Item("G_FNAME")
                    txtLname.Text = .Item("G_LNAME")
                    txtAdd.Text = .Item("G_ADDRESS")
                    txtContact.Text = .Item("G_PHONE")
                    txtTotal.Text = .Item("SPRICE")

                End With

                sql = "SELECT `ROOMTYPE` AS 'Type',`ROOMNUM` as 'RoomNo.', `ROOM` as 'Room', `PRICE` as 'Price',`ARRIVAL` as 'Checked-in', `DEPARTURE` as 'Checked-out' , `RPRICE` as 'Total', `STATUS` as 'Status' FROM  `tblroomtype` rt, `tblroom` rm, `tblreservation` r   WHERE  rm.`ROOMTYPEID`=rt.`ROOMTYPEID`  and  rm.`ROOMID`=r.`ROOMID`  AND r.TRANSNUM=" & txtTransno.Text
                result = RETRIEVEDTG(dtgListRoom, sql)
                sql = "SELECT  e.`ADONSID` as 'ID',`ADONS` as 'Add-ons', `APRICE` as 'Price', `EXQTY` as 'Quantity', `EXTOTPRICE` as 'Subtotal' FROM `tblextra` e, `tbladdons` a WHERE e.`ADONSID`=a.`ADONSID` and TRANSNUM=" & txtTransno.Text
                result = RETRIEVEDTG(dtgListAddons, sql)
                dtgListAddons.Columns(0).Visible = False
                '  dtgAddons.Columns(5).Visible = False

                For Each r As DataGridViewRow In dtgListAddons.Rows
                    totadons += r.Cells(4).Value
                Next
                subtot = totadons + dtgListRoom.Rows(0).Cells(6).Value
                txtSubtot.Text = subtot.ToString("n2")

                For Each r As DataGridViewRow In dtgAddons.Rows

                    txtaddons.Text += r.Cells(4).Value
                Next
                '    txtSubtot.Text = dtgListRoom.Rows(0).Cells(6).Value

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddons.Click
        frmShow(frmPopAdons)
        frmPopAdons.lblCheck.Text = "ViewBookedRooms"

    End Sub

    Private Sub txtaddons_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaddons.TextChanged
        Try
            Dim tot As Double

            tot = Double.Parse(txtaddons.Text) + Double.Parse(txtSubtot.Text)
            txtTotal.Text = tot.ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgAddons_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAddons.CellEndEdit
        Try
            Dim adons As Double
            For Each r As DataGridViewRow In dtgAddons.Rows
                adons += r.Cells(2).Value * r.Cells(3).Value
            Next
            txtaddons.Text = adons.ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            dtgAddons.Rows.Remove(dtgAddons.CurrentRow)
            Try
                Dim adons As Double
                For Each r As DataGridViewRow In dtgAddons.Rows
                    adons += r.Cells(2).Value * r.Cells(3).Value
                Next
                txtaddons.Text = adons.ToString("n2")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim max As Integer = dtgAddons.Rows.Count


            If max > 0 Then
                sql = "update `tblpayment` set `SPRICE` =" & Double.Parse(txtTotal.Text) & " WHERE `TRANSNUM`=" & txtTransno.Text
                CUD(sql)
                For Each r As DataGridViewRow In dtgAddons.Rows
                    r.Cells(4).Value += r.Cells(3).Value * r.Cells(2).Value
                    sql = "INSERT INTO  `tblextra` (`ADONSID`, `TRANSNUM`, `EXQTY`, `EXTOTPRICE`) " & _
                             " VALUES (" & r.Cells(0).Value & "," & txtTransno.Text & "," & r.Cells(3).Value & ",'" & r.Cells(4).Value & "')"
                    result = CUD(sql)
                Next
                If result = False Then
                    MsgBox("Error query insert tblextra", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Booking has been updated.")
                    Call frmViewBookRooms_Load(sender, e)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChecked.Click
        Try
            'sql = "UPDATE `tblreservation` SET `STATUS` = 'CHECKED-OUT' WHERE `TRANSNUM`=" & txtTransno.Text
            'result = CUD(sql)
            'If result = False Then
            '    MsgBox("ERROR TO UPDATE tblreservation", MsgBoxStyle.Exclamation)
            'End If

            sql = "UPDATE `tblpayment` SET `STATUS` = 'CHECKED-OUT' WHERE `TRANSNUM`=" & txtTransno.Text
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class