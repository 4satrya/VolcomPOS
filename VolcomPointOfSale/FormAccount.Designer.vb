<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccount
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPass = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPassConfirm = New DevExpress.XtraEditors.TextEdit()
        Me.BtnSignIn = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassConfirm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Username"
        '
        'TxtUsername
        '
        Me.TxtUsername.Location = New System.Drawing.Point(16, 35)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(358, 20)
        Me.TxtUsername.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 61)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Password"
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(16, 80)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(358, 20)
        Me.TxtPass.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 106)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Confirm Password"
        '
        'TxtPassConfirm
        '
        Me.TxtPassConfirm.Location = New System.Drawing.Point(16, 125)
        Me.TxtPassConfirm.Name = "TxtPassConfirm"
        Me.TxtPassConfirm.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassConfirm.Size = New System.Drawing.Size(358, 20)
        Me.TxtPassConfirm.TabIndex = 3
        '
        'BtnSignIn
        '
        Me.BtnSignIn.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnSignIn.Appearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.BtnSignIn.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSignIn.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSignIn.Appearance.Options.UseBackColor = True
        Me.BtnSignIn.Appearance.Options.UseBorderColor = True
        Me.BtnSignIn.Appearance.Options.UseFont = True
        Me.BtnSignIn.Appearance.Options.UseForeColor = True
        Me.BtnSignIn.Location = New System.Drawing.Point(303, 155)
        Me.BtnSignIn.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnSignIn.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnSignIn.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSignIn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSignIn.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSignIn.Name = "BtnSignIn"
        Me.BtnSignIn.Size = New System.Drawing.Size(71, 27)
        Me.BtnSignIn.TabIndex = 4
        Me.BtnSignIn.Text = "Save"
        '
        'BtnCancel
        '
        Me.BtnCancel.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnCancel.Appearance.BorderColor = System.Drawing.Color.Crimson
        Me.BtnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCancel.Appearance.Options.UseBackColor = True
        Me.BtnCancel.Appearance.Options.UseBorderColor = True
        Me.BtnCancel.Appearance.Options.UseFont = True
        Me.BtnCancel.Appearance.Options.UseForeColor = True
        Me.BtnCancel.Location = New System.Drawing.Point(229, 155)
        Me.BtnCancel.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnCancel.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnCancel.LookAndFeel.SkinName = "Metropolis"
        Me.BtnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCancel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(71, 27)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        '
        'FormAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 194)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSignIn)
        Me.Controls.Add(Me.TxtPassConfirm)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtUsername)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account"
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassConfirm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPassConfirm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnSignIn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
End Class
