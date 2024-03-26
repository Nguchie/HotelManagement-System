Public Class frmDates
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If cboCategory.Text = "CANCELLED" Or cboCategory.Text = "CHECKED-OUT" Then
            sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " &
               " AND p.STATUS = '" & cboCategory.Text &
               "'  AND DATE(p.`TRANSDATE`) BETWEEN '" & INSERTMYSQLDATE(dtpFrom, "yyyy-MM-dd") & "' AND '" & INSERTMYSQLDATE(dtpTo, "yyyy-MM-dd") & "'"
        Else
            sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMTYPE` as 'RoomType' ,`ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', r.`STATUS` as 'Status'  FROM `tblroomtype` rt, `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rt.`ROOMTYPEID`=rm.`ROOMTYPEID` and rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`    " &
             " AND  r.STATUS = '" & cboCategory.Text &
             "' AND DATE(r.`TRANSDATE`) BETWEEN '" & INSERTMYSQLDATE(dtpFrom, "yyyy-MM-dd") & "' AND  '" & INSERTMYSQLDATE(dtpTo, "yyyy-MM-dd") & "'"
        End If
        reports(sql, "CategorizedReport", frmReporting.CrystalReportViewer1)
        frmShow(frmReporting)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class