Public Class frmReports
 
 
    Private Sub rdoDaily_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoDaily.Click
        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`  AND DAY(r.`TRANSDATE`) = DAY(Now())"
        reports(sql, "DailyReport", CrystalReportViewer1)
        rdoRooms.Checked = False
    End Sub

    Private Sub rdomonthly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdomonthly.Click
        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`  AND MONTH(r.`TRANSDATE`) = MONTH(Now())"
        reports(sql, "MonthlyReport", CrystalReportViewer1)
        rdoRooms.Checked = False
    End Sub

    Private Sub rdoWeekly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoWeekly.Click
        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`  AND WEEK(r.`TRANSDATE`) = WEEK(Now())"
        reports(sql, "WeeklyReport", CrystalReportViewer1)
        rdoRooms.Checked = False
    End Sub

    
    Private Sub rdoclear()
        rdoDaily.Checked = False
        rdomonthly.Checked = False
        rdoWeekly.Checked = False
    End Sub

    Private Sub rdoRooms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoRooms.Click
        sql = "SELECT  `ROOMNUM` as 'RoomNo.' ,`ROOMTYPE` as 'RoomType', `ROOM` as 'Room', `NUMPERSON` as 'Preson', `PRICE` as 'Price' FROM `tblroom` r,`tblroomtype` t WHERE r.`ROOMTYPEID`=t.`ROOMTYPEID`"
        reports(sql, "ListofRooms", CrystalReportViewer1)
        rdoclear()
    End Sub

    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'rdoclear()
        'rdoRooms.Checked = False
        sql = "SELECT * FROM tblroomtype"
        Fill_lstBox(sql, lstBoxType, "ROOMTYPE", "ROOMTYPEID")
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cboCategory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If cboCategory.Text = "CANCELLED" Or cboCategory.Text = "CHECKED-OUT" Then
                sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " & _
                   " AND rt.ROOMTYPEID= " & lstBoxType.SelectedValue & " AND p.STATUS = '" & cboCategory.Text & _
                   "'  AND DATE(p.`TRANSDATE`)>='" & INSERTMYSQLDATE(dtpFrom, "yyyy-MM-dd") & "' AND DATE(p.`TRANSDATE`)<='" & INSERTMYSQLDATE(dtpTo, "yyyy-MM-dd") & "'"
            Else
                sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', r.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " & _
                 " AND rt.ROOMTYPEID= " & lstBoxType.SelectedValue & " AND r.STATUS = '" & cboCategory.Text & _
                 "' AND DATE(r.`TRANSDATE`)>='" & INSERTMYSQLDATE(dtpFrom, "yyyy-MM-dd") & "' AND DATE(r.`TRANSDATE`)<='" & INSERTMYSQLDATE(dtpTo, "yyyy-MM-dd") & "'"
            End If
            reports(sql, "CategorizedReport", CrystalReportViewer1)

            rdoclear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstBoxType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBoxType.Click
        Try
            sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', r.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " & _
                          " AND rt.ROOMTYPEID= " & lstBoxType.SelectedValue
            reports(sql, "RoomType", CrystalReportViewer1)
        Catch ex As Exception

        End Try
    End Sub
 

    Private Sub cboCategory_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedValueChanged
        'Try
        '    If cboCategory.Text = "CANCELLED" Or cboCategory.Text = "CHECKED-OUT" Then
        '        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " & _
        '           " AND rt.ROOMTYPEID= " & lstBoxType.SelectedValue & " AND p.STATUS = '" & cboCategory.Text & "' "
        '    Else
        '        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', r.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " & _
        '         " AND rt.ROOMTYPEID= " & lstBoxType.SelectedValue & " AND r.STATUS = '" & cboCategory.Text & "' "
        '    End If
        '    reports(sql, "CategorizedReport", CrystalReportViewer1)

        '    rdoclear()
        'Catch ex As Exception

        'End Try
    End Sub


End Class