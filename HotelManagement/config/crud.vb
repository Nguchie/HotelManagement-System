Imports MySql.Data.MySqlClient
Module crud  
    Public con As MySqlConnection = mysqldb()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public dt1 As New DataTable
    Public dt2 As New DataTable
    Public ds As New DataSet
    Public sql As String
    Public result As String
    Public add As String
    Public edit As String
#Region "old crud"
    Public Sub save_or_updates(ByVal sql As String, ByVal add As String, ByVal edit As String)
        con.Open()
        With cmd
            .Connection = con
            .CommandText = sql
        End With
        dt = New DataTable
        da = New MySqlDataAdapter(sql, con)
        da.Fill(dt)
        con.Close()
        If dt.Rows.Count > 0 Then

            con.Open()
            With cmd
                .Connection = con
                .CommandText = edit
                result = cmd.ExecuteNonQuery

            End With
            con.Close()
        Else
            con.Open()
            With cmd
                .Connection = con
                .CommandText = add
                result = cmd.ExecuteNonQuery

            End With
        End If
        con.Close()
    End Sub

    Public Sub createNoMsg(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                cmd.ExecuteNonQuery()
               
            End With
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message & "createNoMsg")
        End Try

    End Sub
    Public Sub create(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(msgerror & " is failed to save in the database ", MsgBoxStyle.Information)
                Else
                    MsgBox(msgsuccess & " has been save to the database")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message & " create")
        End Try
        con.Close()
    End Sub
    Public Sub reloadDtg(ByVal sql As String, ByVal dtg As DataGridView)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            dt = New DataTable
            da = New MySqlDataAdapter(sql, con)
            da.Fill(dt)
            dtg.DataSource = dt
            With dtg
               
                .Columns(0).Visible = False
                
            End With
        Catch ex As Exception
            MsgBox(ex.Message & "reloadDtg")
        End Try

        con.Close()
        da.Dispose()
    End Sub
    Public Sub reloadtxt(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            dt = New DataTable
            da = New MySqlDataAdapter(sql, con)
            da.Fill(dt)

        Catch ex As Exception
            'MsgBox(ex.Message & "reloadtxt")
        End Try

        con.Close()
        da.Dispose()
    End Sub
    Public Sub updates(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String)
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(msgerror & " is failed to updated in the database.", MsgBoxStyle.Information)
                Else
                    MsgBox(msgsuccess & " has been updated in the database.")
                End If
            End With
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message & "updates")
        End Try

    End Sub
    Public Sub deletes(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            'If MessageBox.Show("Do you want to delete this rocord?", "Delete" _
            '                     , MessageBoxButtons.YesNo, MessageBoxIcon.Information) _
            '                     = Windows.Forms.DialogResult.Yes Then
            result = cmd.ExecuteNonQuery
            If result = 0 Then
                MsgBox(msgerror & " is failed to delete in the database.")
            Else
                MsgBox(msgsuccess & " has been deleted in the database.")
            End If
            'End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region



#Region "NEW CRUD"
    Public Function save_or_update(ByVal sql As String, ByVal add As String, ByVal edit As String) As Boolean

        Try
            con.Open()
            result = RETRIEVESINGLE(sql)
            If result = True Then
                result = CUD(edit)
                If result = True Then
                    MsgBox("The record has been updated in the datatbase.")
                Else
                    MsgBox("Update query cannot be process. Please contact admiitrator.", MsgBoxStyle.Exclamation)
                End If
            Else
                result = CUD(add)
                If result = True Then
                    MsgBox("New record has been save in the database.")
                Else
                    MsgBox("Add query cannot be process. Please contact admiitrator.", MsgBoxStyle.Exclamation)
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message & " SAVE OR UPDATE FUNCTION")

        Finally
            con.Close()
            da.Dispose() 
        End Try
       

    End Function
    Public Function RETRIEVEPRO(ByVal DTG As DataGridView, ByVal SQL As String) As Boolean
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = SQL
            End With
            da = New MySqlDataAdapter
            da.SelectCommand = cmd
            dt = New DataTable
            da.Fill(dt)


            With DTG
                .Columns.Clear()
                .DataSource = dt


                If .Rows.Count >= 0 Then

                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .EditMode = DataGridViewEditMode.EditProgrammatically
                    .AllowUserToAddRows = False
                    .AllowUserToDeleteRows = False
                    .AllowUserToResizeColumns = False
                    .AllowUserToOrderColumns = False
                    .AllowUserToResizeRows = False
                    .RowHeadersVisible = False
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                    Return True

                Else

                    Return False
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function RETRIEVEDTGBROCHURE(ByVal DTG As DataGridView, ByVal SQL As String) As Boolean
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = SQL
            End With
            da = New MySqlDataAdapter
            da.SelectCommand = cmd
            dt = New DataTable
            da.Fill(dt)


            Dim btnCash As New DataGridViewButtonColumn
            Dim btnInstalment As New DataGridViewButtonColumn
            With btnCash
                '.Name = "bntCash"
                .Text = "Cash"
                .UseColumnTextForButtonValue = True
                .Width = 5

            End With
            With btnInstalment
                '.Name = "btnInstalment"
                .Text = "Instalment"
                .UseColumnTextForButtonValue = True
                .Width = 5

            End With
            With DTG
                .Columns.Clear()
                .DataSource = dt


                If .Rows.Count >= 0 Then
                    .Columns.Add(btnCash)
                    .Columns.Add(btnInstalment)
                    .SelectionMode = DataGridViewSelectionMode.CellSelect
                    .EditMode = DataGridViewEditMode.EditProgrammatically
                    .AllowUserToAddRows = False
                    .AllowUserToDeleteRows = False
                    .AllowUserToResizeColumns = False
                    .AllowUserToOrderColumns = False
                    .AllowUserToResizeRows = False
                    .RowHeadersVisible = False
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    .Columns(0).Visible = False
                    Return True

                Else

                    Return False
                End If
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function RETRIEVEtablePanel(ByVal DTG As TableLayoutPanel, ByVal SQL As String) As Boolean
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = SQL
            End With
            da = New MySqlDataAdapter
            da.SelectCommand = cmd
            ds = New DataSet
            da.Fill(dt)

            Dim lbl As New Label
          
            With DTG

                For i = 0 To dt.Rows.Count - 1

                    lbl = New Label
                    .GrowStyle = TableLayoutPanelGrowStyle.AddRows
                    lbl.Text = dt.Rows(i).Item(1)
                    .Controls.Add(lbl, 0, i)
                Next


       
                For i = 0 To dt.Rows.Count - 1

                    lbl = New Label
                    .GrowStyle = TableLayoutPanelGrowStyle.AddRows
                    lbl.Text = dt.Rows(i).Item(2)
                    .Controls.Add(lbl, 1, i)
                Next

 



                '   .DataBindings(dt.Rows(0).Item(1)).DataSource() = dt
                '.Columns.Clear()
                '.DataSource = dt
                '  .DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                '  .DataBindings.Item("CUSNAME").DataSource =

                'DataSource = ds

                '   ds = .DataBindings.Item(1).DataSource



                'If .Rows.Count >= 0 Then

                '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '    .EditMode = DataGridViewEditMode.EditProgrammatically
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToResizeColumns = False
                '    .AllowUserToOrderColumns = False
                '    .AllowUserToResizeRows = False
                '    .RowHeadersVisible = False
                '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                '    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                Return True

                'Else

                'Return False
                'End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function RETRIEVEDTG(ByVal DTG As DataGridView, ByVal SQL As String) As Boolean
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = SQL
            End With
            da = New MySqlDataAdapter
            da.SelectCommand = cmd
            dt = New DataTable
            da.Fill(dt)


            With DTG
                .Columns.Clear()
                .DataSource = dt


                If .Rows.Count >= 0 Then

                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .EditMode = DataGridViewEditMode.EditProgrammatically
                    .AllowUserToAddRows = False
                    .AllowUserToDeleteRows = False
                    .AllowUserToResizeColumns = False
                    .AllowUserToOrderColumns = False
                    .AllowUserToResizeRows = False
                    .RowHeadersVisible = False
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                    Return True

                Else

                    Return False
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function
    Public Function RETRIEVESINGLE(ByVal SQL As String) As Boolean
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = SQL
            End With
            da = New MySqlDataAdapter
            da.SelectCommand = cmd
            dt = New DataTable
            da.Fill(dt)
 
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function

    Public Function RETRIEVESINGLE_DIS_MSG(ByVal SQL As String) As Boolean
        Try
            con.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = SQL
            End With
            da = New MySqlDataAdapter
            da.SelectCommand = cmd
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()
        End Try
    End Function


    'Public Function CUD_MSG(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String) As Boolean
    '    Try
    '        con.Open()
    '        With cmd
    '            .Connection = con
    '            .CommandText = sql
    '            result = cmd.ExecuteNonQuery
    '            If result = 0 Then
    '                MsgBox(msgerror, MsgBoxStyle.Information)
    '            Else
    '                MsgBox(msgsuccess)
    '            End If
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.Message & " CUD")
    '    Finally
    '        con.Close()
    '        da.Dispose()
    '    End Try

    'End Function

    Public Function CUD_DISABLED_MSG(ByVal sql As String) As Boolean
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
            End With
            If result > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message & " CUD")
        Finally
            con.Close()
            da.Dispose()
        End Try

    End Function

    Public Function CUD(ByVal sql As String) As Boolean
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
            End With
            If result > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " CUD")
        Finally
            con.Close()
            da.Dispose()
        End Try

    End Function

#End Region
End Module


