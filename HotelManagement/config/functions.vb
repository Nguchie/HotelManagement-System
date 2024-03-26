Module functions
    Public Sub cleartext(ByVal obj As Object)
        For Each ctrl As Control In obj.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                ctrl.Text = Nothing
            End If
        Next
        For Each ctrl As Control In obj.Controls
            If ctrl.GetType Is GetType(RichTextBox) Then
                ctrl.Text = Nothing
            End If
        Next
        For Each ctrl As Control In obj.Controls
            If ctrl.GetType Is GetType(ComboBox) Then
                ctrl.Text = ""
            End If
        Next
    End Sub
    Public Sub numbersonly(ByVal e As Object)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Public Function DISPLAYAGE(ByVal DBIRTH As Date, ByVal TODATE As Date)
        Dim AGE As Integer
        'CALCULATING THE INTERVAL BETWEEN THE DATE OF BIRTH AND THE END OF THE DATE.
        AGE = DateDiff(DateInterval.Year, DBIRTH, TODATE) 
        Return AGE
    End Function
    Public Function DISNUMBERDAY(ByVal DBIRTH As Date, ByVal TODATE As Date)
        Dim NumDays As Integer
        'CALCULATING THE INTERVAL BETWEEN THE DATE OF BIRTH AND THE END OF THE DATE.

        NumDays = DateDiff(DateInterval.Day, DBIRTH, TODATE)

        Return NumDays
    End Function
    Public Function DISPLAYDATE(ByVal DTP As Date, ByVal dateformat As String)
        Dim mysqldate As String
        mysqldate = Format(DTP, dateformat)
        Return mysqldate
    End Function
    Public Function DISPLAYTIME(ByVal time As Date, ByVal dateformat As String)
        Dim mysqldate As String
        mysqldate = Format(time, dateformat)
        Return mysqldate
    End Function
    Public Function INSERTMYSQLDATE(ByVal DTP As DateTimePicker, ByVal dateformat As String) 
        Dim mysqldate As String
        mysqldate = Format(DTP.Value, dateformat)
        Return mysqldate
    End Function
    Public Function DISPLAYMYSQLDATE(ByVal DTP As Date, ByVal dateformat As String)
        Dim mysqldate As String
        mysqldate = Format(DTP, dateformat)
        Return mysqldate
    End Function
    Public Function INSERTGENDER(ByVal rdoF As RadioButton, ByVal rdoM As RadioButton)
        Dim rdo As String = ""

        If rdoF.Checked = True Then
            rdo = "Female"
        ElseIf rdoM.Checked = True Then
            rdo = "Male"
        End If

        Return rdo
    End Function
    Public Function DISPLAYPHIC(ByVal RDOSSS As RadioButton, ByVal RDOSSSDEP As RadioButton, ByVal RDOGSIS As RadioButton, ByVal RDOGSISDEP As RadioButton)
        Try
            Dim PHIC As String = ""
            If RDOGSIS.Checked Then
                PHIC = "GSIS"
            ElseIf RDOSSS.Checked Then
                PHIC = "SSS"
            ElseIf RDOGSISDEP.Checked Then
                PHIC = "GSIS Dependent"
            ElseIf RDOSSSDEP.Checked Then
                PHIC = "SSS Dependent"
            End If
            Return PHIC
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        Return True
    End Function
    Public Function ERRORMSGLBL(ByVal LBL As Label, ByVal CONTAINER As Object)

        For Each TXT As Control In CONTAINER.CONTROLS
            If TypeOf TXT Is TextBox Then
                If TXT.Text = "" Then
                    Return True
                End If
            End If
        Next
        For Each TXT As Control In CONTAINER.CONTROLS
            If TypeOf TXT Is ComboBox Then
                If TXT.Text = "" Then
                    Return True
                End If
            End If
        Next
        Return False

    End Function
    Public Function Numbers_Only(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Try
            If e.KeyChar <> ChrW(Keys.Back) Then
                e.Handled = True
                If IsNumeric(e.KeyChar) Then
                    e.Handled = False '
                    Return True
                End If
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CaseNumbers_Only(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txt As Object) As Boolean
        Try
            If e.KeyChar <> ChrW(Keys.Back) Then
                e.Handled = True
                If txt.Text.Contains("-") Then
                    e.Handled = False '
                    If IsNumeric(e.KeyChar) Then
                        e.Handled = False '
                        Return True
                    End If
                End If
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Character_Only(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Try
            If e.KeyChar <> ChrW(Keys.Back) Then
                e.Handled = False
                If IsNumeric(e.KeyChar) Then
                    e.Handled = True '
                    Return False
                End If
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CHECKERRORMSGLBL(ByVal LBL As Label, ByVal CONTAINER As Object) As Boolean
        Try
            'Dim maxrow As Integer = dtg.Rows.Count - 1

            If ERRORMSGLBL(LBL, CONTAINER) = True Then
                With LBL
                    .Text = "All fields are required!"
                    .Font = New Font("Arial", 11, FontStyle.Bold)
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
                Beep()
                Return True
            Else
                With LBL
                    .Text = ""
                    .BackColor = Color.Transparent
                    .ForeColor = Color.Transparent
                End With
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function CBOADDITEMS(ByVal cbo As ComboBox) As Boolean
        Try
            cbo.Items.Clear()
            Dim ITEMS() As String = {"Single", "Merried", "Widow"}
            For i = 0 To ITEMS.Length - 1
                cbo.Items.Add(ITEMS(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Function
    Public Function DISABLEOBJECT(ByVal TXT As Object, ByVal CONTAINER As Object) As Boolean
        Try

            For Each OBJ As Control In CONTAINER.CONTROLS
                If TypeOf OBJ Is TextBox Then
                    OBJ.Enabled = False
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If
            
                If TypeOf OBJ Is ComboBox Then
                    OBJ.Enabled = False
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If
            
                If TypeOf OBJ Is RichTextBox Then
                    OBJ.Enabled = False
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If
            
                If TypeOf OBJ Is DateTimePicker Then
                    OBJ.Enabled = False
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If
            
                If TypeOf OBJ Is RadioButton Then
                    OBJ.Enabled = False
                    'OBJ.BackColor = Color.Transparent 
                    'OBJ.ForeColor = Color.Black
                End If
              
            Next
            TXT.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
     
    End Function
    Public Function CURENCY_ONLY(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txt As Object) As Boolean
        Try

            If e.KeyChar <> ChrW(Keys.Back) Then
                e.Handled = True
                If e.KeyChar <> "." Then
                    If IsNumeric(e.KeyChar) Then
                        e.Handled = False '

                    End If

                ElseIf txt.Text.Contains(".") Then
                    MessageBox.Show("Only one decimal point allowed")
                Else
                    e.Handled = False
                End If
            End If

        Catch ex As Exception
            ' logs(ex.Message & " at TXTTENDERED_KeyPress")
            MsgBox(ex.Message & " at TXTTENDERED_KeyPress")
        End Try
    End Function
    Public Function ENABLEOBJECT(ByVal CONTAINER As Object) As Boolean
        Try

            For Each OBJ As Control In CONTAINER.CONTROLS
                If TypeOf OBJ Is TextBox Then
                    OBJ.Enabled = True
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If

                If TypeOf OBJ Is ComboBox Then
                    OBJ.Enabled = True
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If

                If TypeOf OBJ Is RichTextBox Then
                    OBJ.Enabled = True
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If

                If TypeOf OBJ Is DateTimePicker Then
                    OBJ.Enabled = True
                    OBJ.BackColor = Color.White
                    OBJ.ForeColor = Color.Black
                End If

                If TypeOf OBJ Is RadioButton Then
                    OBJ.Enabled = True
                    'OBJ.BackColor = Color.Transparent 
                    'OBJ.ForeColor = Color.Black
                End If

            Next
            'TXT.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Public Function HandledtgDataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) As Boolean

        'MessageBox.Show("Error happened " _
        '    & e.Context.ToString())
        MsgBox("Incorrect format", MsgBoxStyle.Exclamation)


        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            MsgBox("Incorrect format", MsgBoxStyle.Exclamation)


        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MsgBox("Incorrect format", MsgBoxStyle.Exclamation)

        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MsgBox("Incorrect format", MsgBoxStyle.Exclamation)

        End If
        If (e.Context = _
            DataGridViewDataErrorContexts.LeaveControl) Then
            MsgBox("Incorrect format", MsgBoxStyle.Exclamation)

        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If
    End Function
   
    
End Module
