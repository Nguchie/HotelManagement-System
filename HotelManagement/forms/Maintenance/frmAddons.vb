Public Class frmAddons

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        sql = "SELECT ADONSID, `ADONS` as 'Add-ons', `APRICE` as 'Price' FROM `tbladdons`"
        RETRIEVEDTG(dtgList, sql)
        dtgList.Columns(0).Visible = False
        txtName.Clear()
        txtPrice.Clear()
        lblid.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
 
            If lblid.Text = "" Then
                sql = "INSERT INTO `tbladdons` (`ADONS`, `APRICE` ) VALUES ('" & txtName.Text & "'," & txtPrice.Text & ")"
                result = CUD(sql)
                If result = True Then
                    MsgBox("New add-ons has been saved into the database.")
                    Call btnNew_Click(sender, e)
                End If
            Else
                sql = "UPDATE `tbladdons` SET `ADONS`='" & txtName.Text & "', `APRICE`=" & txtPrice.Text & " WHERE ADONSID=" & lblid.Text
                result = CUD(sql)
                If result = True Then
                    MsgBox("Add-ons has been updated into the database.")
                    Call btnNew_Click(sender, e)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            sql = "DELETE  FROM `tbladdons` WHERE  `ADONSID`=" & dtgList.CurrentRow.Cells(0).Value
            result = CUD(sql)
            If result = True Then
                MsgBox("The records has been deleted into the database.")
                Call btnNew_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAddons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call btnNew_Click(sender, e)
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        txtName.Text.ToUpper()
    End Sub

    Private Sub txtPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
        CURENCY_ONLY(e, txtPrice)
    End Sub

    Private Sub dtgList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgList.Click
        Try
            With dtgList.CurrentRow
                lblid.Text = .Cells(0).Value
                txtName.Text = .Cells(1).Value
                txtPrice.Text = .Cells(2).Value
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class