Public Class frmRooms

    Private Sub cboroomType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboroomType.KeyPress
        e.Handled = True
    End Sub

    Private Sub frmRooms_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Availability_Room()
    End Sub
 
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save_OR_Update_Rooms(txtRoomid.Text) 
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        cleartext(Me)
        txtRoomid.Text = loadautonumberWithKey("ROOMID")
        fillcbo("SELECT * FROM `tblroomtype`  ", cboroomType, "ROOMTYPE", "ROOMTYPEID", "Select")
    End Sub

    Private Sub txtRoomNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoomNum.KeyPress, txtPerson.KeyPress
        Numbers_Only(e)
    End Sub

    Private Sub txtRoomPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoomPrice.KeyPress
        CURENCY_ONLY(e, txtRoomPrice)
    End Sub

    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        frmShow(frmRoomList)
        Me.Close()
    End Sub
End Class