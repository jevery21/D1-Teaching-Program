<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Teacher_Menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnquit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnk
        '
        Me.btnk.Location = New System.Drawing.Point(12, 45)
        Me.btnk.Name = "btnk"
        Me.btnk.Size = New System.Drawing.Size(297, 28)
        Me.btnk.TabIndex = 19
        Me.btnk.Text = "Kruskal's algorithm"
        Me.btnk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 33)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Teacher's Menu"
        '
        'btnquit
        '
        Me.btnquit.Location = New System.Drawing.Point(12, 79)
        Me.btnquit.Name = "btnquit"
        Me.btnquit.Size = New System.Drawing.Size(297, 28)
        Me.btnquit.TabIndex = 24
        Me.btnquit.Text = "Quit to Main Menu"
        Me.btnquit.UseVisualStyleBackColor = True
        '
        'Teacher_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 118)
        Me.Controls.Add(Me.btnquit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Teacher_Menu"
        Me.Text = "Teacher's section: Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnquit As System.Windows.Forms.Button
End Class
