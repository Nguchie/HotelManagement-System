Public Class frmAutonumber

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            sql = "INSERT INTO `tblautonumber` (`AUTOSTART`, `AUTOINC`, `AUTOEND`, `AUTOKEY`, `AUTONUM`) " & _
            " VALUES ('" & txtStart.Text & "','" & txtINC.Text & "','" & txtEND.Text & "','" & txtKEY.Text & "','" & txtAUTONUM.Text & "')"
            CUD(sql)
            MsgBox("Record has been save.")
            Call btnReload_Click(sender, e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        Try
            sql = "SELECT * FROM `tblautonumber`  "
            RETRIEVEDTG(dtgList, sql)
            txtStart.Clear()
            txtINC.Clear()
            txtEND.Clear()
            txtKEY.Clear()
            txtAUTONUM.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            sql = "UPDATE `tblautonumber` SET `AUTOSTART`='" & txtStart.Text & _
            "', `AUTOINC`='" & txtINC.Text & "', `AUTOEND`='" & txtEND.Text & _
            "', `AUTOKEY`='" & txtKEY.Text & "', `AUTONUM`='" & txtAUTONUM.Text & "' WHERE `ID`=" & dtgList.CurrentRow.Cells(0).Value
            CUD(sql)
            MsgBox("Record has been updated.")

            Call btnReload_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            sql = "DELETE  FROM `tblautonumber` WHERE `ID`=" & dtgList.CurrentRow.Cells(0).Value
            CUD(sql)
            MsgBox("Record has been deleted.")

            Call btnReload_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgList.DoubleClick
        Try
            With dtgList.CurrentRow
                txtStart.Text = .Cells(1).Value
                txtINC.Text = .Cells(2).Value
                txtEND.Text = .Cells(3).Value
                txtAUTONUM.Text = .Cells(5).Value
                txtKEY.Text = .Cells(4).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtEND_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEND.TextChanged
        Try
            txtAUTONUM.Text = txtStart.Text & txtEND.Text
        Catch ex As Exception

        End Try
    End Sub
End Class