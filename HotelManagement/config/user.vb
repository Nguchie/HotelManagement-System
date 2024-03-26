Imports MySql.Data.MySqlClient
Module user
    Public con As MySqlConnection = mysqldb()
    Public Sub invisible()
        With Form1
            .GroupBox1.Visible = False
            .GroupBox3.Visible = False
            .GroupBox4.Visible = False
            .GroupBox5.Visible = False
            .FlowLayoutPanel1.Visible = False

        End With

    End Sub
    Public Sub login(ByVal username As TextBox, ByVal pass As TextBox)
        Try
            con.Open()
            reloadtxt("SELECT * FROM tbluseraccount WHERE USER_NAME= '" & username.Text & "' and UPASS = sha1('" & pass.Text & "')")


            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("ROLE") = "Administrator" Then
                    MsgBox("You have successfully logged in as an " & dt.Rows(0).Item("ROLE"))
                    With Form1

                        .GroupBox1.Visible = True
                        .GroupBox3.Visible = True
                        .GroupBox4.Visible = True
                        .GroupBox5.Visible = True

                        .tsLogin.Text = "Logout"
                        .tsWelcomeGuest.Text = "Welcome " & dt.Rows(0).Item("ROLE")

                        .FlowLayoutPanel1.Visible = True
                        .tsLogin.Image = My.Resources.logoutCLIP

                        FRMlOGIN.Close()
                    End With
                    'FRMLOGIN.Close()
                ElseIf dt.Rows(0).Item("ROLE") = "Staff" Then
                    MsgBox("You have successfully logged in as an " & dt.Rows(0).Item("ROLE"))

                    With Form1

                        FRMlOGIN.Close()
                    End With
                ElseIf dt.Rows(0).Item("ROLE") = "Receptionist" Then
                    MsgBox("You have successfully logged in as an " & dt.Rows(0).Item("Role"))

                    With Form1


                        .GroupBox1.Visible = False
                        .GroupBox3.Visible = False
                        .GroupBox4.Visible = False
                        .GroupBox5.Visible = False
                        .tsLogin.Text = "Logout"
                        FRMlOGIN.Close()
                    End With
                Else

                    MsgBox("Acount doest not exist!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Acount doest not exist!", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            da.Dispose()

        End Try
    End Sub
    Public Sub append(ByVal sql As String, ByVal field As String, ByVal txt As Object)
        reloadtxt(sql)
        Try
            Dim r As DataRow
            txt.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txt.AutoCompleteCustomSource.Add(r.Item(field).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Module
