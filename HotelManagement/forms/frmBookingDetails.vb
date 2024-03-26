Public Class frmBookingDetails
    Dim rand As New Random()
    Dim min As Integer = 1
    Dim max As Integer = 100

    Private Sub frmBookingDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   Fill_lstBox("SELECT * FROM `tbladdons`", chkLstBox_AddOns, "ADONS", "APRICE")
        DTGCOLUMNID.Visible = False
        Column4.Visible = False
        txtGuestid.Text = loadautonumberWithKey("GUESTID")
    End Sub

    Private Sub txtage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtage.KeyPress
        Numbers_Only(e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub txtAddons_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddons.TextChanged
        Try
            Dim tot As Double

            tot = Double.Parse(txtAddons.Text) + Double.Parse(txtSubtotal.Text)
            txtTotal.Text = tot.ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmShow(frmPopAdons)
        frmPopAdons.lblCheck.Text = "BookigDetails"
    End Sub

    Private Sub dtgAddons_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAddons.CellEndEdit
        Try
            Dim adons As Double
            For Each r As DataGridViewRow In dtgAddons.Rows
                adons += r.Cells(2).Value * r.Cells(3).Value
            Next
            txtAddons.Text = adons.ToString("n2")
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
                txtAddons.Text = adons.ToString("n2")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Dim transnum As Integer
    Public Sub Book_now()
        Try
            If txtage.Text = "" Then
                MsgBox("All fields are required.", MsgBoxStyle.Exclamation)
            Else
                Dim MAX As Integer = dtgList.Rows.Count
                transnum = loadautonumberWithKey("TRANSNUM")

                sql = "SELECT * FROM `tblguest` WHERE `GUESTID`=" & txtGuestid.Text
                result = RETRIEVESINGLE(sql)
                If result = False Then
                    sql = "INSERT INTO  `tblguest`  " &
                     "  (`GUESTID`, `G_FNAME`, `G_LNAME`, `G_ADDRESS`, `AGE`, `G_SEX`, `G_PHONE`) " &
                     " VALUES (" & txtGuestid.Text & ",'" & txtfname.Text & "','" & txtlname.Text &
                     "','" & txtAddress.Text & "'," & txtage.Text & ",'" & INSERTGENDER(rdoFemale, rdoMale) &
                     "', '" & txtContact.Text & "')"
                    result = CUD(sql)
                    If result = False Then
                        MsgBox("Error query insert tblpayment", MsgBoxStyle.Exclamation)
                    Else
                        updateautonumberWithKey("GUESTID")
                    End If
                End If

                If btnSave.Text = "Reserve" Then
                    For Each r As DataGridViewRow In dtgList.Rows
                        sql = "INSERT INTO  `tblreservation`  " &
                                   " (`TRANSNUM`, `TRANSDATE`, `ROOMID`, `ARRIVAL`, `DEPARTURE`, `RPRICE`, `GUESTID`, `STATUS`, `BOOKDATED`, `USERID`) " &
                                   " VALUES (" & transnum & ",'" & DISPLAYMYSQLDATE(Now, "yyyy-MM-dd") &
                                   "'," & r.Cells(0).Value & ",'" & r.Cells(1).FormattedValue &
                                   "','" & r.Cells(2).FormattedValue &
                                   "'," & r.Cells(9).Value & "," & txtGuestid.Text & ",'RESERVED','" & DISPLAYMYSQLDATE(Now, "yyyy-MM-dd") &
                                   "'," & LBLUSERID.Text & ")"
                        result = CUD(sql)
                    Next
                    If result = False Then
                        MsgBox("Error query insert tblreservation", MsgBoxStyle.Exclamation)
                    End If
                Else

                    For Each r As DataGridViewRow In dtgList.Rows
                        sql = "INSERT INTO  `tblreservation`  " &
                                   " (`TRANSNUM`, `TRANSDATE`, `ROOMID`, `ARRIVAL`, `DEPARTURE`, `RPRICE`, `GUESTID`, `STATUS`, `BOOKDATED`, `USERID`) " &
                                   " VALUES (" & transnum & ",'" & DISPLAYMYSQLDATE(Now, "yyyy-MM-dd") &
                                   "'," & r.Cells(0).Value & ",'" & r.Cells(1).FormattedValue &
                                   "','" & r.Cells(2).FormattedValue &
                                   "'," & r.Cells(9).Value & "," & txtGuestid.Text & ",'BOOKED','" & DISPLAYMYSQLDATE(Now, "yyyy-MM-dd") &
                                   "'," & LBLUSERID.Text & ")"
                        result = CUD(sql)
                    Next
                    If result = False Then
                        MsgBox("Error query insert tblreservation", MsgBoxStyle.Exclamation)
                    End If
                End If



                If btnSave.Text = "Reserve" Then
                    sql = "INSERT INTO `tblpayment` " &
                        " (`TRANSDATE`, `TRANSNUM`, `PQTY`, `GUESTID`, `SPRICE`, `STATUS`,`TENDERED`,`CHANGED`) " &
                        " VALUES ('" & DISPLAYMYSQLDATE(Now, "yyyy-MM-dd") &
                        "'," & transnum & "," & MAX & "," & txtGuestid.Text & "," & Double.Parse(txtTotal.Text) &
                        ",'RESERVED'," & Double.Parse(frmPopPaymentsReserve.txttender.Text) & "," & Double.Parse(frmPopPaymentsReserve.txtChange.Text) & ")"
                    result = CUD(sql)
                    If result = False Then
                        MsgBox("Error query insert tblpayment", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Room is already reserved.")

                    End If
                Else
                    sql = "INSERT INTO `tblpayment` " &
                        " (`TRANSDATE`, `TRANSNUM`, `PQTY`, `GUESTID`, `SPRICE`, `STATUS`,`TENDERED`,`CHANGED`) " &
                        " VALUES ('" & DISPLAYMYSQLDATE(Now, "yyyy-MM-dd") &
                        "'," & transnum & "," & MAX & "," & txtGuestid.Text & "," & Double.Parse(txtTotal.Text) &
                        ",'BOOKED'," & Double.Parse(frmPopPayment.txttender.Text) & "," & Double.Parse(frmPopPayment.txtChange.Text) & ")"
                    result = CUD(sql)
                    If result = False Then
                        MsgBox("Error query insert tblpayment", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Customer is already booked.")

                    End If
                End If



                For Each r As DataGridViewRow In dtgAddons.Rows
                    r.Cells(4).Value += r.Cells(3).Value * r.Cells(2).Value
                    sql = "INSERT INTO  `tblextra` (`ADONSID`, `TRANSNUM`, `EXQTY`, `EXTOTPRICE`) " &
                             " VALUES (" & r.Cells(0).Value & ",'" & transnum & "'," & r.Cells(3).Value & ",'" & r.Cells(4).Value & "')"
                    result = CUD(sql)
                Next
                If result = False Then
                    MsgBox("Error query insert tblextra", MsgBoxStyle.Exclamation)
                End If


            End If
            If btnSave.Text = "Reserve" Then
                sql = " SELECT `ROOMTYPE`  as 'RoomType',`ROOMNUM`, `ROOM`, `NUMPERSON`, `PRICE`,`G_FNAME`, `G_LNAME`, `G_ADDRESS`, `G_PHONE`,`ARRIVAL`, `DEPARTURE`, `RPRICE`, r.`STATUS`,r.`TRANSDATE`, r.`TRANSNUM`, `SPRICE`, `TENDERED`, `CHANGED` FROM  `tblroomtype` rt, `tblroom` rm,  `tblreservation` r, `tblpayment` p, `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID`=r.`ROOMID` and  r.`TRANSNUM`=p.`TRANSNUM`  AND p.`GUESTID`=g.`GUESTID`   AND r.TRANSNUM=" & frmPopPaymentsReserve.txtTransNo.Text
                reports(sql, "receipt", frmReciept.CrystalReportViewer1)
                frmReciept.lbltitle.Text = "Reserve"

            Else
                sql = " SELECT `ROOMTYPE`  as 'RoomType',`ROOMNUM`, `ROOM`, `NUMPERSON`, `PRICE`,`G_FNAME`, `G_LNAME`, `G_ADDRESS`, `G_PHONE`,`ARRIVAL`, `DEPARTURE`, `RPRICE`, r.`STATUS`,r.`TRANSDATE`, r.`TRANSNUM`, `SPRICE`, `TENDERED`, `CHANGED` FROM  `tblroomtype` rt, `tblroom` rm,  `tblreservation` r, `tblpayment` p, `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID`=r.`ROOMID` and  r.`TRANSNUM`=p.`TRANSNUM`  AND p.`GUESTID`=g.`GUESTID`   AND r.TRANSNUM=" & frmPopPayment.txtTransNo.Text
                reports(sql, "receip_BOOKt", frmReciept.CrystalReportViewer1)
                frmReciept.lbltitle.Text = "Booking"
            End If


            frmShow(frmReciept)
            txtGuestid.Text = loadautonumberWithKey("GUESTID")
            updateautonumberWithKey("TRANSNUM")
        Catch ex As Exception

        End Try



    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "Reserve" Then
                frmPopPaymentsReserve.txtTransNo.Text = CInt(rand.Next(min, max + 1))
                frmPopPaymentsReserve.txtTotalAmount.Text = txtTotal.Text
                MsgBox("Saved Sucessfully")
            Else
                frmPopPayment.txtTransNo.Text = CInt(rand.Next(min, max + 1))
                frmPopPayment.txtTotalAmount.Text = txtTotal.Text
                MsgBox("Saved Sucessfully")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        frmShow(frmPopGuest)
        frmPopGuest.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub txtGuestid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestid.TextChanged
        Try
            sql = "SELECT * FROM `tblguest` WHERE `GUESTID`=" & txtGuestid.Text
            result = RETRIEVESINGLE(sql)
            If result = True Then
                With dt.Rows(0)
                    If .Item("G_SEX") = "Male" Then
                        rdoMale.Checked = True
                    Else
                        rdoFemale.Checked = True
                    End If
                    txtfname.Text = .Item("G_FNAME")
                    txtlname.Text = .Item("G_LNAME")
                    txtAddress.Text = .Item("G_ADDRESS")
                    txtage.Text = .Item("AGE")
                    txtContact.Text = .Item("G_PHONE")
                End With
            Else
                txtfname.Clear()
                txtlname.Clear()
                txtAddress.Clear()
                txtage.Clear()
                txtContact.Clear()
                txtGuestid.Text = loadautonumberWithKey("GUESTID")

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            txtfname.Clear()
            txtlname.Clear()
            txtAddress.Clear()
            txtage.Clear()
            txtContact.Clear()
            txtGuestid.Text = loadautonumberWithKey("GUESTID")

        Catch ex As Exception

        End Try
    End Sub
End Class