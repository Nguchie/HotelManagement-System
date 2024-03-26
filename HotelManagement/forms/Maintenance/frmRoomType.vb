Public Class frmRoomType




    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        frmShow(Form1)
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If lblid.Text = "Select" Then
                sql = "INSERT INTO tblroomtype (ROOMTYPE,DESCRIPTION) VALUES ('" & txtType.Text & "','" & txtDesc.Text & "')"
                result = CUD(sql)
                If result = True Then
                    MsgBox("New room type has been saved.")
                    txtType.Clear()
                    txtDesc.Clear()
                    lblid.Text = "Select"

                Else
                    MsgBox("Error query")
                End If
            Else
                sql = "UPDATE tblroomtype SET  ROOMTYPE='" & txtType.Text & "',DESCRIPTION='" & txtDesc.Text & "' WHERE ROOMTYPEID=" & lblid.Text
                result = CUD(sql)
                If result = True Then
                    MsgBox("Room type has been updated.")
                    txtType.Clear()
                    txtDesc.Clear()
                    lblid.Text = "Select"

                Else
                    MsgBox("Error query")
                End If
            End If

            sql = "SELECT `ROOMTYPEID`, `ROOMTYPE` as 'Room Type', `DESCRIPTION` as 'Description' FROM `tblroomtype` "
            reloadDtg(sql, dtglist)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            sql = "SELECT `ROOMTYPEID`, `ROOMTYPE` as 'Room Type', `DESCRIPTION` as 'Description' FROM `tblroomtype` WHERE ROOMTYPE like '%" & txtsearch.Text & "%'"
            RETRIEVEDTG(dtglist, sql)
            dtglist.Columns(0).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            lblid.Text = dtglist.CurrentRow.Cells(0).Value
            txtType.Text = dtglist.CurrentRow.Cells(1).Value
            txtDesc.Text = dtglist.CurrentRow.Cells(2).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmBrand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblid.Text = "Select"
        lblid.Visible = False
        sql = "SELECT `ROOMTYPEID`, `ROOMTYPE` as 'Room Type', `DESCRIPTION` as 'Description' FROM `tblroomtype` "
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            sql = "DELETE  FROM `tblroomtype` WHERE `ROOMTYPEID`=" & dtglist.CurrentRow.Cells(0).Value
            CUD(sql)
            sql = "SELECT `ROOMTYPEID`, `ROOMTYPE` as 'Room Type', `DESCRIPTION` as 'Description' FROM `tblroomtype` "
            reloadDtg(sql, dtglist)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        sql = "SELECT `ROOMTYPEID`, `ROOMTYPE` as 'Room Type', `DESCRIPTION` as 'Description' FROM `tblroomtype` "
        reloadDtg(sql, dtglist)
        txtType.Clear()
        txtDesc.Clear()
        lblid.Text = "Select"
    End Sub

 
End Class