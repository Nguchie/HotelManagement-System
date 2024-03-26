Public Class frmRoomList

    Private Sub frmRoomList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Availability_Room()

        fillcbo("SELECT * FROM `tblroomtype`  ", cboType, "ROOMTYPE", "ROOMTYPEID", "Select")

    End Sub
 

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Edit_or_New("Edit")
            frmShow(frmRooms)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        delete_Rooms(dtgList.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        Try
            Availability_Search_Room()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Availability_Search_Room()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Edit_or_New("New")
        frmShow(frmRooms)
        Me.Close()
    End Sub
End Class