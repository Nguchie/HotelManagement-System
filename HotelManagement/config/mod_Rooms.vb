Imports MySql.Data.MySqlClient

Module mod_Rooms 
    Public con As MySqlConnection = mysqldb()
    Public Function edit_Rooms(ByVal roomid As Integer) As Boolean
        Try
            With frmRooms
                fillcbo("SELECT * FROM `tblroomtype`  ", frmRooms.cboroomType, "ROOMTYPE", "ROOMTYPEID", "Select")
                sql = "SELECT * FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND `ROOMID`=" & roomid
                result = RETRIEVESINGLE(sql)
                If result = True Then
                    .txtRoomid.Text = dt.Rows(0).Item("ROOMID")
                    .cboroomType.Text = dt.Rows(0).Item("ROOMTYPE")
                    .txtRoomNum.Text = dt.Rows(0).Item("ROOMNUM")
                    .txtRoomName.Text = dt.Rows(0).Item("ROOM")
                    .txtRoomPrice.Text = dt.Rows(0).Item("PRICE")
                    .txtPerson.Text = dt.Rows(0).Item("NUMPERSON")
                End If
            End With
        Catch ex As Exception

        End Try

    End Function
    Public Function delete_Rooms(ByVal roomid As Integer) As Boolean
        Try
            sql = "DELETE FROM tblroom WHERE ROOMID=" & roomid
            result = CUD(sql)
            If result = True Then
                MsgBox("Room has been deleted.")
                load_Rooms()
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Function load_Rooms()
        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price' FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID`"
        reloadDtg(sql, frmRoomList.dtgList)
        With frmRoomList
            .dtgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .dtgList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        End With
        Return sql
    End Function
    Public Function Edit_or_New(ByVal action As String) As Boolean
        Try
            Select Case action
                Case "Edit"
                    edit_Rooms(frmRoomList.dtgList.CurrentRow.Cells(0).Value)

                Case "New"
                    frmRooms.txtRoomid.Text = loadautonumberWithKey("ROOMID")
                    fillcbo("SELECT * FROM `tblroomtype`  ", frmRooms.cboroomType, "ROOMTYPE", "ROOMTYPEID", "Select")
            End Select
        Catch ex As Exception

        End Try
    End Function
    Public Function Save_OR_Update_Rooms(ByVal roomid As Integer) As Boolean
        Try
            With frmRooms
                sql = "SELECT * FROM `tblroom` WHERE ROOMID= " & roomid
                result = RETRIEVESINGLE(sql)
                If result = True Then
                    sql = "UPDATE `tblroom` SET `ROOMNUM`=" & .txtRoomNum.Text & ", `ROOMTYPEID`=" & .cboroomType.SelectedValue & _
                    ", `ROOM`='" & .txtRoomName.Text & "',`NUMPERSON`=" & .txtPerson.Text & ", `PRICE`=" & .txtRoomPrice.Text & _
                    " WHERE ROOMID= " & roomid
                    result = CUD(sql)
                    If result = True Then
                        MsgBox("Room has been updated.")
                    End If
                    cleartext(frmRooms)
                    Edit_or_New("New")
                Else
                    sql = "INSERT INTO `tblroom` (ROOMID,`ROOMNUM`, `ROOMTYPEID`, `ROOM`,`NUMPERSON`, `PRICE`)  " & _
                             " VALUES (" & .txtRoomid.Text & " ," & .txtRoomNum.Text & "," & .cboroomType.SelectedValue & ",'" & .txtRoomName.Text & _
                             "'," & .txtPerson.Text & "," & .txtRoomPrice.Text & ")"
                    result = CUD(sql)
                    If result = True Then
                        MsgBox("New room has been saved.")
                    End If

                    updateautonumberWithKey("ROOMID")
                    cleartext(frmRooms)
                    Edit_or_New("New")
                End If
            End With

        Catch ex As Exception
        End Try

    End Function
    Public Function Search_Room() As Boolean
        With frmRoomList
            sql = load_Rooms() & " AND t.ROOMTYPEID =" & .cboType.SelectedValue & " AND ROOM LIKE '%" & .txtsearch.Text & "%'"
        End With

        'sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price' FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` " & condition
        reloadDtg(sql, frmRoomList.dtgList)
    End Function
    Public Function Load_Room_Type() As Boolean
        Try
            sql = "SELECT * FROM tblroomtype"
            Fill_lstBox(sql, frmBooking.lstRoomType, "ROOMTYPE", "ROOMTYPEID")
        Catch ex As Exception

        End Try
    End Function
    Public Function Load_Room_Type_reserve() As Boolean
        Try
            sql = "SELECT * FROM tblroomtype"
            Fill_lstBox(sql, frmReserve.lstRoomType, "ROOMTYPE", "ROOMTYPEID")
        Catch ex As Exception

        End Try
    End Function
    Public Function Availability_Search_reserve() As Boolean
        Try
            con.Open()

            With frmReserve
                sql = "SELECT GROUP_CONCAT(  `ROOMID` ,  '' )  FROM `tblreservation` r,`tblpayment` p " & _
                        " WHERE  r.`TRANSNUM`=p.`TRANSNUM` AND (('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                         "'>= DATE(`ARRIVAL`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                         "' <= DATE(`DEPARTURE`)) OR ('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                         "' >= DATE(`DEPARTURE`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                         "' <= DATE(`DEPARTURE`) )   OR (DATE(`ARRIVAL`) >='" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                         "' AND DATE(`ARRIVAL`) <='" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                         "'))  AND NOT p.STATUS='CHECKED-OUT'"

                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                Dim max As Integer = dt.Rows.Count

                If max > 0 Then
                    If dt.Rows(0).Item(0).ToString = "" Then
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                           " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` "
                        reloadDtg(sql, .dtgList)
                    Else
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                              " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND ROOMID NOT IN  (" & dt.Rows(0).Item(0) & ")"
                        reloadDtg(sql, .dtgList)
                    End If
                    ' MsgBox(dt.Rows(0).Item(0).ToString)
                   

                Else
                    sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                             " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` "
                    reloadDtg(sql, .dtgList)
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function Availability_Search_Type_Reserve() As Boolean
        Try
            con.Open()

            With frmReserve
                sql = "SELECT GROUP_CONCAT(  `ROOMID` ,  '' )  FROM `tblreservation` r,`tblpayment` p " & _
                        " WHERE  r.`TRANSNUM`=p.`TRANSNUM` AND (('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                         "'>= DATE(`ARRIVAL`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                         "' <= DATE(`DEPARTURE`)) OR ('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                         "' >= DATE(`DEPARTURE`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                         "' <= DATE(`DEPARTURE`) )   OR (DATE(`ARRIVAL`) >='" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                         "' AND DATE(`ARRIVAL`) <='" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                         "')) AND NOT p.STATUS='CHECKED-OUT'"

                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                Dim max As Integer = dt.Rows.Count

                If max > 0 Then
                    If dt.Rows(0).Item(0).ToString = "" Then
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                           " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND r.`ROOMTYPEID`= " & frmReserve.lstRoomType.SelectedValue
                        reloadDtg(sql, .dtgList)
                    Else
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                              " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND r.`ROOMTYPEID`= " & frmReserve.lstRoomType.SelectedValue & " AND ROOMID NOT IN  (" & dt.Rows(0).Item(0) & ")"
                        reloadDtg(sql, .dtgList)
                    End If
                    ' MsgBox(dt.Rows(0).Item(0).ToString)


                Else
                    sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                             " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND r.`ROOMTYPEID`= " & frmReserve.lstRoomType.SelectedValue & ""
                    reloadDtg(sql, .dtgList)
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function Availability_Search() As Boolean
        Try
            con.Open()

            With frmBooking 
                sql = "SELECT GROUP_CONCAT(  `ROOMID` ,  '' )  FROM `tblreservation`r,`tblpayment` p " & _
                        " WHERE  r.`TRANSNUM`=p.`TRANSNUM` AND (('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                        "'>= DATE(`ARRIVAL`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                        "' <= DATE(`DEPARTURE`)) OR ('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                        "' >= DATE(`DEPARTURE`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                        "' <= DATE(`DEPARTURE`) )   OR (DATE(`ARRIVAL`) >='" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                        "' AND DATE(`ARRIVAL`) <='" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                        "'))  AND NOT p.STATUS='CHECKED-OUT'"


                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                Dim max As Integer = dt.Rows.Count

                If max > 0 Then
                    If dt.Rows(0).Item(0).ToString = "" Then
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                           " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` "
                        reloadDtg(sql, .dtgList)
                    Else
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                              " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND ROOMID NOT IN  (" & dt.Rows(0).Item(0) & ")"
                        reloadDtg(sql, .dtgList)
                    End If
                    ' MsgBox(dt.Rows(0).Item(0).ToString)


                Else
                    sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                             " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` "
                    reloadDtg(sql, .dtgList)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function Availability_Search_Type() As Boolean
        Try
            con.Open()

            With frmBooking
                sql = "SELECT GROUP_CONCAT(  `ROOMID` ,  '' )  FROM `tblreservation` r,`tblpayment` p " & _
                        " WHERE  r.`TRANSNUM`=p.`TRANSNUM` AND (('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                        "'>= DATE(`ARRIVAL`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                        "' <= DATE(`DEPARTURE`)) OR ('" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                        "' >= DATE(`DEPARTURE`) AND '" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                        "' <= DATE(`DEPARTURE`) )   OR (DATE(`ARRIVAL`) >='" & INSERTMYSQLDATE(.dtpCheckin, "yyyy-MM-dd") & _
                        "' AND DATE(`ARRIVAL`) <='" & INSERTMYSQLDATE(.dtpCheckout, "yyyy-MM-dd") & _
                        "'))  AND NOT p.STATUS='CHECKED-OUT' "

                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                Dim max As Integer = dt.Rows.Count

                If max > 0 Then
                    If dt.Rows(0).Item(0).ToString = "" Then
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                           " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID`  AND r.`ROOMTYPEID`= " & frmBooking.lstRoomType.SelectedValue
                        reloadDtg(sql, .dtgList)
                    Else
                        sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                              " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND r.`ROOMTYPEID`= " & frmBooking.lstRoomType.SelectedValue & " AND ROOMID NOT IN  (" & dt.Rows(0).Item(0) & ")"
                        reloadDtg(sql, .dtgList)
                    End If
                    ' MsgBox(dt.Rows(0).Item(0).ToString)


                Else
                    sql = "SELECT  `ROOMID`,`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price'  " & _
                             " FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID` AND r.`ROOMTYPEID`= " & frmBooking.lstRoomType.SelectedValue
                    reloadDtg(sql, .dtgList)
                End If
 

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function bookingDetails(ByVal ARRIVAL As DateTimePicker, ByVal DEPARTURE As DateTimePicker)

        Dim night As Integer
        night = DateDiff(DateInterval.Day, ARRIVAL.Value, DEPARTURE.Value)
        If night = 0 Then
            night = 1 
        End If
        sql = "SELECT  `ROOMID`, '" & INSERTMYSQLDATE(ARRIVAL, "yyyy-MM-dd") & "'   AS 'Arrival'" & _
        ",'" & INSERTMYSQLDATE(DEPARTURE, "yyyy-MM-dd") & "'   AS 'Departure'," & night & " as 'Nights',`ROOMTYPE` as 'Type', `ROOMNUM` as 'Room No.', `ROOM` as 'Room', `NUMPERSON` as 'Person', `PRICE` as 'Price',(PRICE*" & night & ") as 'Subtotal' FROM `tblroom` r, `tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID`"
        Return sql

    End Function
    Public Function BookedRooms()
        sql = "SELECT p.`TRANSNUM` as 'TransactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', `DEPARTURE` as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID` AND  p.STATUS='BOOKED' "
        RETRIEVEDTG(frmBookingList.dtgList, sql)
        Return sql
    End Function
    Public Function ReservedRooms()
        sql = "SELECT p.`TRANSNUM` as 'TransactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', DATE(`DEPARTURE`) as 'Checked-out', `SPRICE` AS 'TotalPrice',`TENDERED` as 'PayedAmount', `CHANGED` as 'Balanced', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID` AND p.STATUS='RESERVED' "
        RETRIEVEDTG(frmReservedRoom.dtgList, sql)
        Return sql
    End Function
    Public Function Availability_Room() As Boolean
        Try
            con.Open()

            With frmRoomList
                '=========================================[Displaying to Gridview]======================================================================================='
                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = "SELECT rm.`ROOMID` ,  `ROOMTYPE` AS  'Type',  `ROOMNUM` AS  'Room No.',  `ROOM` AS  'Room',  `NUMPERSON` AS  'Person',  `PRICE` AS  'Price', p.STATUS AS  'Status' " & _
                                    " FROM  `tblroomtype` rt,  `tblroom` rm,  `tblreservation` r,  `tblpayment` p " & _
                                    " WHERE rt.`ROOMTYPEID` = rm.`ROOMTYPEID`  " & _
                                    " AND rm.`ROOMID` = r.`ROOMID`  " & _
                                    " AND r.`TRANSNUM` = p.`TRANSNUM`  " & _
                                    " AND DATE( p.`TRANSDATE` ) = DATE( NOW( ) ) AND  NOT p.STATUS='CHECKED-OUT'"
                End With
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt2 = New DataTable
                da.Fill(dt2)

                '==============================================[Adding to Gridview]=================================================================================='

                sql = " SELECT GROUP_CONCAT(`ROOMID` ,  '' )  " & _
                        " FROM  `tblreservation` r,  `tblpayment` p " & _
                        " WHERE r.`TRANSNUM` = p.`TRANSNUM`  " & _
                        " AND DATE( p.`TRANSDATE` ) = CURDATE( )  " & _
                        " AND NOT p.STATUS =  'CHECKED-OUT' "

                RETRIEVESINGLE(sql)
                If dt.Rows(0).Item(0).ToString <> "" Then
                    cmd = New MySqlCommand
                    With cmd
                        .Connection = con
                        .CommandText = "SELECT  `ROOMID` ,  `ROOMTYPE` ,  `ROOMNUM` ,  `ROOM` ,  `NUMPERSON` AS  'Person' ,  `PRICE` ,  'Available' " & _
                                        "FROM  `tblroomtype` rt,  `tblroom` rm  " & _
                                        " WHERE rt.`ROOMTYPEID` = rm.`ROOMTYPEID`  " & _
                                        " AND  ROOMID NOT IN  " & _
                                        " (  " & dt.Rows(0).Item(0) & " )"
                    End With
                    da = New MySqlDataAdapter
                    da.SelectCommand = cmd
                    dt1 = New DataTable
                    da.Fill(dt1)
                    Dim max As Integer = dt1.Rows.Count
                    If max > 0 Then
                        '==========================================================================================================================================='
                        For Each r As DataRow In dt1.Rows
                            Dim row As String() = New String() {r.Item(0).ToString, _
                                                                 r.Item(1).ToString, _
                                                                 r.Item(2).ToString, _
                                                                 r.Item(3).ToString, _
                                                                 r.Item(4).ToString, _
                                                                 r.Item(5).ToString, _
                                                                 r.Item(6).ToString}


                            With dt2.Rows
                                .Add(row)
                            End With

                        Next

                    End If
                    .dtgList.DataSource = dt2
                Else
                    sql = "SELECT  `ROOMID` ,  `ROOMTYPE` AS  'Type',  `ROOMNUM` AS  'Room No.',  `ROOM` AS  'Room',  `NUMPERSON` AS  'Person',  `PRICE` AS  'Price', ('Available') AS  'Status'  " & _
                                        "FROM  `tblroomtype` rt,  `tblroom` rm  " & _
                                        " WHERE rt.`ROOMTYPEID` = rm.`ROOMTYPEID`  "
                    reloadDtg(sql, .dtgList)
                End If

                .dtgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .dtgList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function Availability_Search_Room() As Boolean
        Try
            con.Open()

            With frmRoomList
                '=========================================[Displaying to Gridview]======================================================================================='
                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = "SELECT rm.`ROOMID` ,  `ROOMTYPE` AS  'Type',  `ROOMNUM` AS  'Room No.',  `ROOM` AS  'Room',  `NUMPERSON` AS  'Person',  `PRICE` AS  'Price', p.STATUS AS  'Status' " & _
                                    " FROM  `tblroomtype` rt,  `tblroom` rm,  `tblreservation` r,  `tblpayment` p " & _
                                    " WHERE rt.`ROOMTYPEID` = rm.`ROOMTYPEID`  " & _
                                    " AND rm.`ROOMID` = r.`ROOMID`  " & _
                                    " AND r.`TRANSNUM` = p.`TRANSNUM`  " & _
                                    " AND DATE( p.`TRANSDATE` ) = DATE( NOW( ) ) AND  NOT p.STATUS='CHECKED-OUT' AND rt.ROOMTYPEID =" & frmRoomList.cboType.SelectedValue & " AND ROOM LIKE '%" & frmRoomList.txtsearch.Text & "%'"
                End With
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt2 = New DataTable
                da.Fill(dt2)

                '==============================================[Adding to Gridview]=================================================================================='

                sql = " SELECT GROUP_CONCAT(`ROOMID` ,  '' )  " & _
                        " FROM  `tblreservation` r,  `tblpayment` p " & _
                        " WHERE r.`TRANSNUM` = p.`TRANSNUM`  " & _
                        " AND DATE( p.`TRANSDATE` ) = CURDATE( )  " & _
                        " AND NOT p.STATUS =  'CHECKED-OUT' "

                RETRIEVESINGLE(sql)
                If dt.Rows(0).Item(0).ToString <> "" Then
                    cmd = New MySqlCommand
                    With cmd
                        .Connection = con
                        .CommandText = "SELECT  `ROOMID` ,  `ROOMTYPE` ,  `ROOMNUM` ,  `ROOM` ,  `NUMPERSON` ,  `PRICE` ,  'Available' " & _
                                        "FROM  `tblroomtype` rt,  `tblroom` rm  " & _
                                        " WHERE rt.`ROOMTYPEID` = rm.`ROOMTYPEID`  " & _
                                        " AND rt.ROOMTYPEID =" & frmRoomList.cboType.SelectedValue & "  AND   ROOMID NOT IN  " & _
                                        " (  " & dt.Rows(0).Item(0) & " ) "
                    End With
                    da = New MySqlDataAdapter
                    da.SelectCommand = cmd
                    dt1 = New DataTable
                    da.Fill(dt1)
                    Dim max As Integer = dt1.Rows.Count
                    If max > 0 Then
                        '==========================================================================================================================================='
                        For Each r As DataRow In dt1.Rows
                            Dim row As String() = New String() {r.Item(0).ToString, _
                                                                 r.Item(1).ToString, _
                                                                 r.Item(2).ToString, _
                                                                 r.Item(3).ToString, _
                                                                 r.Item(4).ToString, _
                                                                 r.Item(5).ToString, _
                                                                 r.Item(6).ToString}


                            With dt2.Rows
                                .Add(row)
                            End With

                        Next

                    End If
                    .dtgList.DataSource = dt2
                Else
                    sql = "SELECT  `ROOMID` ,  `ROOMTYPE` AS  'Type',  `ROOMNUM` AS  'Room No.',  `ROOM` AS  'Room',  `NUMPERSON` AS  'Person',  `PRICE` AS  'Price', ('Available') AS  'Status' " & _
                                        "FROM  `tblroomtype` rt,  `tblroom` rm  " & _
                                        " WHERE rt.`ROOMTYPEID` = rm.`ROOMTYPEID`  AND rt.ROOMTYPEID =" & .cboType.SelectedValue & " AND ROOM LIKE '%" & .txtsearch.Text & "%'"
                    reloadDtg(sql, .dtgList)
                End If

                .dtgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .dtgList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            End With
        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
End Module
