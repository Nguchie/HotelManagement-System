Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        invisible()
    End Sub

    Private Sub BTN_BOOKAROOM_Click(sender As Object, e As EventArgs) Handles BTN_BOOKAROOM.Click
        frmShow(frmBooking)
    End Sub

    Private Sub BTN_RESERVEAROOM_Click(sender As Object, e As EventArgs) Handles BTN_RESERVEAROOM.Click
        frmShow(frmReserve)
    End Sub

    Private Sub BTN_RESERVATION_Click(sender As Object, e As EventArgs) Handles BTN_RESERVATION.Click
        frmShow(frmReservedRoom)
    End Sub

    Private Sub BTN_BOOKINGS_Click(sender As Object, e As EventArgs) Handles BTN_BOOKINGS.Click
        frmShow(frmBookingList)
    End Sub

    Private Sub BTN_MANAGEROOMS_Click(sender As Object, e As EventArgs) Handles BTN_MANAGEROOMS.Click
        Edit_or_New("New")
        frmShow(frmRooms)
    End Sub

    Private Sub BTN_MANAGEGUEST_Click(sender As Object, e As EventArgs) Handles BTN_MANAGEGUEST.Click
        frmShow(frmGuest)
    End Sub

    Private Sub BTN_MANAGEROOMTYPES_Click(sender As Object, e As EventArgs) Handles BTN_MANAGEROOMTYPES.Click
        frmShow(frmRoomType)
    End Sub

    Private Sub BTN_MANAGEADDONS_Click(sender As Object, e As EventArgs) Handles BTN_MANAGEADDONS.Click
        frmShow(frmAddons)
    End Sub

    Private Sub BTN_MANAGEUSERS_Click(sender As Object, e As EventArgs) Handles BTN_MANAGEUSERS.Click
        frmShow(frm_adduser)
    End Sub

    Private Sub tsLogin_Click(sender As Object, e As EventArgs) Handles tsLogin.Click
        If tsLogin.Text = "Login" Then
            frmShow(FRMlOGIN)

        Else
            tsLogin.Text = "Login"
            tsLogin.Image = My.Resources.loginCLIP
            invisible()
        End If

    End Sub

    Private Sub BTN_DAILY_Click(sender As Object, e As EventArgs) Handles BTN_DAILY.Click
        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`  AND DAY(r.`TRANSDATE`) = DAY(Now())"
        reports(sql, "DailyReport", frmReporting.CrystalReportViewer1)
        frmShow(frmReporting)
    End Sub

    Private Sub BTN_WEEKLY_Click(sender As Object, e As EventArgs) Handles BTN_WEEKLY.Click
        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`  AND WEEK(r.`TRANSDATE`) = WEEK(Now())"
        reports(sql, "WeeklyReport", frmReporting.CrystalReportViewer1)
        frmShow(frmReporting)
    End Sub

    Private Sub BTN_MONTHLY_Click(sender As Object, e As EventArgs) Handles BTN_MONTHLY.Click
        sql = "SELECT p.`TRANSNUM` as 'TrasactionNo.',concat(`G_FNAME`,' ', `G_LNAME`) as 'Name', `ROOMNUM` AS 'RoomNo.', `ROOM` as 'Room', date(`ARRIVAL`) as 'Checked-in', date(`DEPARTURE`)  as 'Checked-out', `SPRICE` AS 'TotalPrice', p.`STATUS` as 'Status'  FROM  `tblroom` rm,`tblreservation` r, `tblpayment` p , `tblguest` g WHERE rm.`ROOMID` = r.`ROOMID` and r.`TRANSNUM`=p.`TRANSNUM` AND p.`GUESTID`=g.`GUESTID`  AND MONTH(r.`TRANSDATE`) = MONTH(Now())"
        reports(sql, "MonthlyReport", frmReporting.CrystalReportViewer1)
        frmShow(frmReporting)
    End Sub

    Private Sub BTN_INCLUSIVEDATES_Click(sender As Object, e As EventArgs) Handles BTN_INCLUSIVEDATES.Click
        frmDates.ShowDialog()

    End Sub
End Class
