Module usable_function
    Public Function pnlRetrieve(ByVal pnlback As Panel, ByVal pnlfront As Panel) As Boolean
        Try
            With pnlback
                .Visible = False
                .SendToBack()
                .Dock = DockStyle.None

            End With

            With pnlfront 
                .BringToFront()
                .Dock = DockStyle.Fill
                .Visible = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function frmShow(ByVal frm As Form) As Boolean
     
        Try
            With frm
                .Show()
                .Focus()
                .BringToFront()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Disable_previous_date(ByVal dtpCheckin As DateTimePicker, ByVal dtpCheckout As DateTimePicker)
        dtpCheckout.MinDate = DateAdd(DateInterval.Day, 1, Now) 
        dtpCheckin.MinDate = Now
        Return True
    End Function
End Module
