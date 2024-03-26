Public Class frmPopAdons

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim adons As Double
            Dim max As Integer
            If lblCheck.Text = "BookigDetails" Then 
                With frmBookingDetails
                    .dtgAddons.Rows.Add(DataGridView1.CurrentRow.Cells(0).Value, DataGridView1.CurrentRow.Cells(1).Value, DataGridView1.CurrentRow.Cells(2).Value, 1)
                    For Each r As DataGridViewRow In .dtgAddons.Rows
                        adons += r.Cells(2).Value * r.Cells(3).Value
                    Next
                    .txtAddons.Text = adons.ToString("n2")
                    Me.Close()
                End With
            ElseIf lblCheck.Text = "ViewBookedRooms" Then
                With frmViewBookRooms
                    max = .dtgAddons.Rows.Count - 1
                    .dtgAddons.Rows.Add(DataGridView1.CurrentRow.Cells(0).Value, _
                                        DataGridView1.CurrentRow.Cells(1).Value, _
                                        DataGridView1.CurrentRow.Cells(2).Value, 1)
                    For Each r As DataGridViewRow In .dtgAddons.Rows
                        adons += r.Cells(2).Value * r.Cells(3).Value
                    Next
                    .txtaddons.Text = adons.ToString("n2")
                    Me.Close()
                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPopAdons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT ADONSID, `ADONS` as 'Add-ons', `APRICE` as 'Price' FROM `tbladdons` "
        RETRIEVEDTG(DataGridView1, sql)

    End Sub
End Class