<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTN_RESERVEAROOM = New System.Windows.Forms.Button()
        Me.BTN_BOOKAROOM = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BTN_MANAGEUSERS = New System.Windows.Forms.Button()
        Me.BTN_MANAGEADDONS = New System.Windows.Forms.Button()
        Me.BTN_MANAGEROOMTYPES = New System.Windows.Forms.Button()
        Me.BTN_MANAGEGUEST = New System.Windows.Forms.Button()
        Me.BTN_MANAGEROOMS = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BTN_INCLUSIVEDATES = New System.Windows.Forms.Button()
        Me.BTN_MONTHLY = New System.Windows.Forms.Button()
        Me.BTN_WEEKLY = New System.Windows.Forms.Button()
        Me.BTN_DAILY = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BTN_BOOKINGS = New System.Windows.Forms.Button()
        Me.BTN_RESERVATION = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsLogin = New System.Windows.Forms.ToolStripButton()
        Me.tsWelcomeGuest = New System.Windows.Forms.ToolStripButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.BTN_RESERVEAROOM)
        Me.GroupBox1.Controls.Add(Me.BTN_BOOKAROOM)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 89)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TRANSACTION"
        '
        'BTN_RESERVEAROOM
        '
        Me.BTN_RESERVEAROOM.Location = New System.Drawing.Point(6, 51)
        Me.BTN_RESERVEAROOM.Name = "BTN_RESERVEAROOM"
        Me.BTN_RESERVEAROOM.Size = New System.Drawing.Size(188, 26)
        Me.BTN_RESERVEAROOM.TabIndex = 1
        Me.BTN_RESERVEAROOM.Text = "RESERVE A ROOM"
        Me.BTN_RESERVEAROOM.UseVisualStyleBackColor = True
        '
        'BTN_BOOKAROOM
        '
        Me.BTN_BOOKAROOM.Location = New System.Drawing.Point(6, 19)
        Me.BTN_BOOKAROOM.Name = "BTN_BOOKAROOM"
        Me.BTN_BOOKAROOM.Size = New System.Drawing.Size(188, 26)
        Me.BTN_BOOKAROOM.TabIndex = 0
        Me.BTN_BOOKAROOM.Text = "BOOK A ROOM"
        Me.BTN_BOOKAROOM.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox3.Controls.Add(Me.BTN_MANAGEUSERS)
        Me.GroupBox3.Controls.Add(Me.BTN_MANAGEADDONS)
        Me.GroupBox3.Controls.Add(Me.BTN_MANAGEROOMTYPES)
        Me.GroupBox3.Controls.Add(Me.BTN_MANAGEGUEST)
        Me.GroupBox3.Controls.Add(Me.BTN_MANAGEROOMS)
        Me.GroupBox3.Location = New System.Drawing.Point(220, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 213)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MAINTENANCE"
        '
        'BTN_MANAGEUSERS
        '
        Me.BTN_MANAGEUSERS.Location = New System.Drawing.Point(6, 160)
        Me.BTN_MANAGEUSERS.Name = "BTN_MANAGEUSERS"
        Me.BTN_MANAGEUSERS.Size = New System.Drawing.Size(188, 26)
        Me.BTN_MANAGEUSERS.TabIndex = 7
        Me.BTN_MANAGEUSERS.Text = "MANAGE USERS"
        Me.BTN_MANAGEUSERS.UseVisualStyleBackColor = True
        '
        'BTN_MANAGEADDONS
        '
        Me.BTN_MANAGEADDONS.Location = New System.Drawing.Point(7, 128)
        Me.BTN_MANAGEADDONS.Name = "BTN_MANAGEADDONS"
        Me.BTN_MANAGEADDONS.Size = New System.Drawing.Size(188, 26)
        Me.BTN_MANAGEADDONS.TabIndex = 3
        Me.BTN_MANAGEADDONS.Text = "MANAGE ADD-ONS"
        Me.BTN_MANAGEADDONS.UseVisualStyleBackColor = True
        '
        'BTN_MANAGEROOMTYPES
        '
        Me.BTN_MANAGEROOMTYPES.Location = New System.Drawing.Point(6, 96)
        Me.BTN_MANAGEROOMTYPES.Name = "BTN_MANAGEROOMTYPES"
        Me.BTN_MANAGEROOMTYPES.Size = New System.Drawing.Size(188, 26)
        Me.BTN_MANAGEROOMTYPES.TabIndex = 2
        Me.BTN_MANAGEROOMTYPES.Text = "MANAGE ROOM TYPES"
        Me.BTN_MANAGEROOMTYPES.UseVisualStyleBackColor = True
        '
        'BTN_MANAGEGUEST
        '
        Me.BTN_MANAGEGUEST.Location = New System.Drawing.Point(6, 64)
        Me.BTN_MANAGEGUEST.Name = "BTN_MANAGEGUEST"
        Me.BTN_MANAGEGUEST.Size = New System.Drawing.Size(188, 26)
        Me.BTN_MANAGEGUEST.TabIndex = 1
        Me.BTN_MANAGEGUEST.Text = "MANAGE GUEST"
        Me.BTN_MANAGEGUEST.UseVisualStyleBackColor = True
        '
        'BTN_MANAGEROOMS
        '
        Me.BTN_MANAGEROOMS.Location = New System.Drawing.Point(6, 32)
        Me.BTN_MANAGEROOMS.Name = "BTN_MANAGEROOMS"
        Me.BTN_MANAGEROOMS.Size = New System.Drawing.Size(188, 26)
        Me.BTN_MANAGEROOMS.TabIndex = 0
        Me.BTN_MANAGEROOMS.Text = "MANAGE ROOMS"
        Me.BTN_MANAGEROOMS.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox4.Controls.Add(Me.BTN_INCLUSIVEDATES)
        Me.GroupBox4.Controls.Add(Me.BTN_MONTHLY)
        Me.GroupBox4.Controls.Add(Me.BTN_WEEKLY)
        Me.GroupBox4.Controls.Add(Me.BTN_DAILY)
        Me.GroupBox4.Location = New System.Drawing.Point(427, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(201, 213)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "REPORTS"
        '
        'BTN_INCLUSIVEDATES
        '
        Me.BTN_INCLUSIVEDATES.Location = New System.Drawing.Point(7, 128)
        Me.BTN_INCLUSIVEDATES.Name = "BTN_INCLUSIVEDATES"
        Me.BTN_INCLUSIVEDATES.Size = New System.Drawing.Size(188, 26)
        Me.BTN_INCLUSIVEDATES.TabIndex = 3
        Me.BTN_INCLUSIVEDATES.Text = "INCLUSIVE DATES"
        Me.BTN_INCLUSIVEDATES.UseVisualStyleBackColor = True
        '
        'BTN_MONTHLY
        '
        Me.BTN_MONTHLY.Location = New System.Drawing.Point(7, 96)
        Me.BTN_MONTHLY.Name = "BTN_MONTHLY"
        Me.BTN_MONTHLY.Size = New System.Drawing.Size(188, 26)
        Me.BTN_MONTHLY.TabIndex = 2
        Me.BTN_MONTHLY.Text = "MONTHLY REPORT"
        Me.BTN_MONTHLY.UseVisualStyleBackColor = True
        '
        'BTN_WEEKLY
        '
        Me.BTN_WEEKLY.Location = New System.Drawing.Point(7, 64)
        Me.BTN_WEEKLY.Name = "BTN_WEEKLY"
        Me.BTN_WEEKLY.Size = New System.Drawing.Size(188, 26)
        Me.BTN_WEEKLY.TabIndex = 1
        Me.BTN_WEEKLY.Text = "WEEKLY REPORT"
        Me.BTN_WEEKLY.UseVisualStyleBackColor = True
        '
        'BTN_DAILY
        '
        Me.BTN_DAILY.Location = New System.Drawing.Point(7, 32)
        Me.BTN_DAILY.Name = "BTN_DAILY"
        Me.BTN_DAILY.Size = New System.Drawing.Size(188, 26)
        Me.BTN_DAILY.TabIndex = 0
        Me.BTN_DAILY.Text = "DAILY REPORT"
        Me.BTN_DAILY.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox5.Controls.Add(Me.BTN_BOOKINGS)
        Me.GroupBox5.Controls.Add(Me.BTN_RESERVATION)
        Me.GroupBox5.Location = New System.Drawing.Point(13, 108)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(201, 110)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "TRANSACTION HISTORY"
        '
        'BTN_BOOKINGS
        '
        Me.BTN_BOOKINGS.Location = New System.Drawing.Point(6, 55)
        Me.BTN_BOOKINGS.Name = "BTN_BOOKINGS"
        Me.BTN_BOOKINGS.Size = New System.Drawing.Size(188, 26)
        Me.BTN_BOOKINGS.TabIndex = 1
        Me.BTN_BOOKINGS.Text = "BOOKINGS"
        Me.BTN_BOOKINGS.UseVisualStyleBackColor = True
        '
        'BTN_RESERVATION
        '
        Me.BTN_RESERVATION.Location = New System.Drawing.Point(6, 23)
        Me.BTN_RESERVATION.Name = "BTN_RESERVATION"
        Me.BTN_RESERVATION.Size = New System.Drawing.Size(188, 26)
        Me.BTN_RESERVATION.TabIndex = 0
        Me.BTN_RESERVATION.Text = "RESERVATION"
        Me.BTN_RESERVATION.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLogin, Me.tsWelcomeGuest})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(889, 31)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsLogin
        '
        Me.tsLogin.Image = Global.HotelManagement.My.Resources.Resources.loginCLIP
        Me.tsLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLogin.Name = "tsLogin"
        Me.tsLogin.Size = New System.Drawing.Size(65, 28)
        Me.tsLogin.Text = "Login"
        '
        'tsWelcomeGuest
        '
        Me.tsWelcomeGuest.Image = CType(resources.GetObject("tsWelcomeGuest.Image"), System.Drawing.Image)
        Me.tsWelcomeGuest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsWelcomeGuest.Name = "tsWelcomeGuest"
        Me.tsWelcomeGuest.Size = New System.Drawing.Size(126, 28)
        Me.tsWelcomeGuest.Text = "Welcome Guest's"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(138, 152)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(644, 244)
        Me.FlowLayoutPanel1.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(889, 485)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hotel Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTN_RESERVEAROOM As Button
    Friend WithEvents BTN_BOOKAROOM As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BTN_PAYMENTS As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BTN_MANAGEROOMTYPES As Button
    Friend WithEvents BTN_MANAGEGUEST As Button
    Friend WithEvents BTN_MANAGEROOMS As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BTN_MONTHLY As Button
    Friend WithEvents BTN_WEEKLY As Button
    Friend WithEvents BTN_DAILY As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents BTN_BOOKINGS As Button
    Friend WithEvents BTN_RESERVATION As Button
    Friend WithEvents BTN_MANAGEUSERS As Button
    Friend WithEvents BTN_MANAGEADDONS As Button
    Friend WithEvents BTN_INCLUSIVEDATES As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsLogin As ToolStripButton
    Friend WithEvents tsWelcomeGuest As ToolStripButton
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
