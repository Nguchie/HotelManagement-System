Imports MySql.Data.MySqlClient
Module selects
    Public con As MySqlConnection = mysqldb()
    'procedure of your autoappend and autosugest
    Public Sub autocompletetxt(ByVal sql As String, ByVal txt As TextBox)
        Try
            dt = New DataTable
            'OPENING THE CONNECTION
            con.Open()
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            'FILLING THE DATA IN THE DATATABLE
            da.SelectCommand = cmd
            da.Fill(dt)
            'SET A VARIABLE AS A ROW OF DATA IN THE DATATABLE
            Dim r As DataRow
            'CLEARING THE AUTOCOMPLETE SOURCE OF THE TEXTBOX

            With txt
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource.Clear()
            End With
            'LOOPING THE ROW OF DATA IN THE DATATABLE
            For Each r In dt.Rows
                'ADDING THE DATA IN THE AUTO COMPLETE SOURCE OF THE TEXTBOX
                txt.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
            ''''''''''''''''''''''''
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'CLOSING THE CONNECTION
        con.Close()
        da.Dispose()
    End Sub
    Public Sub auto_sugestAll(ByVal sql As String, ByVal txt As TextBox)
        With cmd
            .Connection = con
            .CommandText = sql
        End With
        dt = New DataTable
        da = New MySqlDataAdapter(sql, con)
        da.Fill(dt)
        Dim r As DataRow
        txt.AutoCompleteCustomSource.Clear()
        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt.AutoCompleteSource = AutoCompleteSource.CustomSource
        For Each r In dt.Rows
            For i = 0 To dt.Columns.Count - 1
                With txt
                    .AutoCompleteCustomSource.Add(r.Item(i).ToString)
                End With
            Next
        
        Next
    End Sub
    Public Function fillcboD(ByVal sql As String, ByVal cbo As ComboBox, ByVal display As String, ByVal ID As String) As Boolean
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            Else
                con.Open()
                'OPENING THE CONNECTION
                cmd = New MySqlCommand
                'HOLDS THE DATA TO BE EXECUTED
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                'FILLING THE DATA IN THE DATATABLE
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    With cbo
                        .Refresh()
                        .DataSource = dt
                        .DisplayMember = display
                        .ValueMember = ID
                        .SelectedIndex = 0
                        .Text = ""
                    End With

                    Return True
                Else

                    Return False
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'CLOSING THE CONNECTION
            con.Close()
            da.Dispose()
        End Try

    End Function
    Public Function fillcbo(ByVal sql As String, ByVal cbo As ComboBox, ByVal display As String, ByVal ID As String, ByVal TXT As String) As Boolean
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            Else
                con.Open()
                'OPENING THE CONNECTION
                cmd = New MySqlCommand
                'HOLDS THE DATA TO BE EXECUTED
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                'FILLING THE DATA IN THE DATATABLE
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    With cbo
                        .Refresh()
                        .DataSource = dt
                        .DisplayMember = display
                        .ValueMember = ID
                        '.SelectedValue = "0"
                        .SelectedIndex = 0
                        .Text = TXT

                    End With

                    Return True
                Else

                    Return False
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            'CLOSING THE CONNECTION
            con.Close()
            da.Dispose()
        End Try

    End Function
    Public Sub autoreceipt(ByVal desc As String, ByVal txt As Object)
        Try
            sql = "SELECT concat(`STRT`, `END`) FROM `tblautonumber` WHERE `DESCRIPTION`= '" & desc & "'"
            reloadtxt(sql)
            txt.text = dt.Rows(0).Item(0)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub autoreceiptupdate(ByVal desc As String)
        Try
            sql = "UPDATE `tblautonumber` SET `END`=`END`+`INCREMENT` WHERE `DESCRIPTION`='" & desc & "'"
            createNoMsg(sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub loadautonumbers(ByVal txt As TextBox)
        Try
            sql = "SELECT CONCAT(`STRT`, `END`) FROM `tblautonumber` WHERE  `ID`=2"
            reloadtxt(sql)
            txt.Text = dt.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub loadautonumber(ByVal id As Integer, ByVal txt As TextBox)
        Try
            sql = "SELECT CONCAT(`STRT`, `END`) FROM `tblautonumber` WHERE  `ID`= " & id
            reloadtxt(sql)
            txt.Text = dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
  
    Public Function loadautonumberWithKey(ByVal KEY As String)
        Dim AUTOID As Integer

        Try
            sql = "SELECT concat(AUTOSTART,AUTOEND) FROM `tblautonumber` WHERE `AUTOKEY`= '" & KEY & "'"
            reloadtxt(sql)
            AUTOID = dt.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return AUTOID
    End Function
    Public Sub updateautonumberWithKey(ByVal KEY As String)
        Try
            sql = "UPDATE `tblautonumber` SET `AUTOEND`=`AUTOEND`+`AUTOINC` WHERE `AUTOKEY`='" & KEY & "'"
            createNoMsg(sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
  
 
#Region "Report"
    Public Sub reports(ByVal sql As String, ByVal rptname As String, ByVal crystalRpt As Object)
        Try
            con.Open()

            Dim reportname As String
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            ds = New DataSet
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds)
            reportname = rptname
            Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim strReportPath As String
            strReportPath = Application.StartupPath & "\report\" & reportname & ".rpt"
            With reportdoc
                .Load(strReportPath)
                .SetDataSource(ds.Tables(0))
            End With
            With crystalRpt
                .Displaytoolbar = True
                .DisplayStatusbar = True
                .ShowRefreshButton = False
                .ShowCloseButton = False
                .ShowGroupTreeButton = False
                .ReportSource = reportdoc
            End With
        Catch ex As Exception
            MsgBox(ex.Message & "No Crystal Reports have been Installed")
        End Try
        con.Close()
        da.Dispose()
    End Sub
#End Region
    Public Function Fill_lstBox(ByVal sql As String, ByVal lstBox As ListBox, ByVal display As String, ByVal valueid As String) As Boolean
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            Else
                con.Open()
                'OPENING THE CONNECTION
                cmd = New MySqlCommand
                'HOLDS THE DATA TO BE EXECUTED
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                'FILLING THE DATA IN THE DATATABLE
                da = New MySqlDataAdapter
                da.SelectCommand = cmd
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    With lstBox
                        .Refresh()
                        .DataSource = dt
                        .DisplayMember = display
                        .ValueMember = valueid

                    End With

                    Return True
                Else

                    Return False
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            'CLOSING THE CONNECTION
            con.Close()
            da.Dispose()
        End Try

    End Function
End Module
