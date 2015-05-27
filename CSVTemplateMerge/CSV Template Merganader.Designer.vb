<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSVTemplateMerge
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
        Me.csvDataGrid = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadDataCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveOutputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveDataCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.templateBox = New System.Windows.Forms.TextBox()
        Me.genresButton = New System.Windows.Forms.Button()
        Me.outputBox = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.varHeaderBox = New System.Windows.Forms.ListBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.csvDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'csvDataGrid
        '
        Me.csvDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.csvDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.csvDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.csvDataGrid.Location = New System.Drawing.Point(12, 27)
        Me.csvDataGrid.Name = "csvDataGrid"
        Me.csvDataGrid.Size = New System.Drawing.Size(532, 196)
        Me.csvDataGrid.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(556, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadDataCSVToolStripMenuItem, Me.LoadTemplateToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadDataCSVToolStripMenuItem
        '
        Me.LoadDataCSVToolStripMenuItem.Name = "LoadDataCSVToolStripMenuItem"
        Me.LoadDataCSVToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.LoadDataCSVToolStripMenuItem.Text = "Load Data CSV"
        '
        'LoadTemplateToolStripMenuItem
        '
        Me.LoadTemplateToolStripMenuItem.Name = "LoadTemplateToolStripMenuItem"
        Me.LoadTemplateToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.LoadTemplateToolStripMenuItem.Text = "Load Template"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveOutputToolStripMenuItem, Me.SaveTemplateToolStripMenuItem, Me.SaveDataCSVToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveOutputToolStripMenuItem
        '
        Me.SaveOutputToolStripMenuItem.Name = "SaveOutputToolStripMenuItem"
        Me.SaveOutputToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SaveOutputToolStripMenuItem.Text = "Save Output"
        '
        'SaveTemplateToolStripMenuItem
        '
        Me.SaveTemplateToolStripMenuItem.Name = "SaveTemplateToolStripMenuItem"
        Me.SaveTemplateToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SaveTemplateToolStripMenuItem.Text = "Save Template"
        '
        'SaveDataCSVToolStripMenuItem
        '
        Me.SaveDataCSVToolStripMenuItem.Name = "SaveDataCSVToolStripMenuItem"
        Me.SaveDataCSVToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SaveDataCSVToolStripMenuItem.Text = "Save Data CSV"
        '
        'templateBox
        '
        Me.templateBox.Location = New System.Drawing.Point(204, 229)
        Me.templateBox.Multiline = True
        Me.templateBox.Name = "templateBox"
        Me.templateBox.Size = New System.Drawing.Size(340, 215)
        Me.templateBox.TabIndex = 3
        '
        'genresButton
        '
        Me.genresButton.Location = New System.Drawing.Point(13, 421)
        Me.genresButton.Name = "genresButton"
        Me.genresButton.Size = New System.Drawing.Size(184, 23)
        Me.genresButton.TabIndex = 4
        Me.genresButton.Text = "Generate"
        Me.genresButton.UseVisualStyleBackColor = True
        '
        'outputBox
        '
        Me.outputBox.BackColor = System.Drawing.SystemColors.Window
        Me.outputBox.Location = New System.Drawing.Point(13, 451)
        Me.outputBox.Multiline = True
        Me.outputBox.Name = "outputBox"
        Me.outputBox.ReadOnly = True
        Me.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.outputBox.Size = New System.Drawing.Size(531, 129)
        Me.outputBox.TabIndex = 5
        Me.outputBox.WordWrap = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 586)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(556, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "Select a CSV..."
        '
        'varHeaderBox
        '
        Me.varHeaderBox.FormattingEnabled = True
        Me.varHeaderBox.Location = New System.Drawing.Point(13, 229)
        Me.varHeaderBox.Name = "varHeaderBox"
        Me.varHeaderBox.Size = New System.Drawing.Size(184, 186)
        Me.varHeaderBox.TabIndex = 7
        '
        'CSVTemplateMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 608)
        Me.Controls.Add(Me.varHeaderBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.outputBox)
        Me.Controls.Add(Me.genresButton)
        Me.Controls.Add(Me.templateBox)
        Me.Controls.Add(Me.csvDataGrid)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CSVTemplateMerge"
        Me.Text = "CSV Template Merganader"
        CType(Me.csvDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents csvDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadDataCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents templateBox As System.Windows.Forms.TextBox
    Friend WithEvents genresButton As System.Windows.Forms.Button
    Friend WithEvents outputBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents varHeaderBox As System.Windows.Forms.ListBox
    Friend WithEvents SaveOutputToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveDataCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusLabel As ToolStripStatusLabel
End Class
