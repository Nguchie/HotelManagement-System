Public Class frmGuest

 
    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sql = "SELECT `GUESTID` AS 'ID', `G_FNAME` AS 'FIRSTNAME', `G_LNAME` AS 'LASTNAME', `G_ADDRESS` AS 'ADDRESS', `AGE`, `G_SEX` AS 'SEX', `G_PHONE` AS 'PHONE NO.' FROM `tblguest` "
            RETRIEVEDTG(dtgList, sql)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged

        Try
            sql = "SELECT `GUESTID` AS 'ID', `G_FNAME` AS 'FIRSTNAME', `G_LNAME` AS 'LASTNAME', `G_ADDRESS` AS 'ADDRESS', `AGE`, `G_SEX` AS 'SEX', `G_PHONE` AS 'PHONE NO.' FROM `tblguest` WHERE CONCAT(`GUESTID`, ' ' , `G_FNAME`, ' ' ,`G_LNAME`,' ' , `G_ADDRESS` ) LIKE '%" & txtsearch.Text & "%'"
            RETRIEVEDTG(dtgList, sql)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            sql = "DELETE FROM `tblguest` WHERE `GUESTID`=" & dtgList.CurrentRow.Cells(0).Value
            result = CUD(sql)
            If result = True Then
                MsgBox("Guest has been removed.")
                Call frmGuest_Load(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class