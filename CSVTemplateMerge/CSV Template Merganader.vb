'Imports LINQtoCSV
Imports System
Imports System.IO
Imports Microsoft

Public Class CSVTemplateMerge
    Dim csvName As String = ""
    Dim listSize As Integer
    Dim rowCount As Integer
    Dim listVariables As New Generic.List(Of String)
    Dim csvTable As New DataTable

    Private Sub LoadDataCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadDataCSVToolStripMenuItem.Click
        Try
            Dim csvName As String = ""
            OpenFileDialog1.InitialDirectory = "c:\temp\"                                       'doesnt actually open c/temp
            OpenFileDialog1.Filter = "CSV files (*.csv)|*.csv"                                  'filters for CSVs
            OpenFileDialog1.FilterIndex = 2                                                     'sets the filterindex to 2, otherwise out of bounds. 
            OpenFileDialog1.RestoreDirectory = True                                             'remembers the directory you last opened
            OpenFileDialog1.Multiselect = False                                                 'only allows selecting of 1 file
            If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then              'if user clicks OK, grab the filename and set it to csvName
                csvName = OpenFileDialog1.FileName
            End If
            Me.StatusStrip1.Text = csvName                                                      'set the StatusStrip1 to read the csvName DOESNT WORK
            Dim CSVFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(csvName)      'inits the csv reader, passes in the csvName
            CSVFileReader.TextFieldType = FileIO.FieldType.Delimited                            'indicates it is delimited, as opposed to fixed width
            CSVFileReader.SetDelimiters(",")                                                    'indicates the delimiter - could potentially make this a preferences variable. 

            Dim CSVFileTable As DataTable = Nothing

            Dim Column As DataColumn
            Dim Row As DataRow
            Dim UpperBound As Int32
            Dim ColumnCount As Int32
            Dim CurrentRow As String()
            Dim pubHeaders As New Generic.List(Of String)

            While Not CSVFileReader.EndOfData
                Try
                    CurrentRow = CSVFileReader.ReadFields()
                    If Not CurrentRow Is Nothing Then
                        'Check if DataTable has been created
                        If CSVFileTable Is Nothing Then
                            CSVFileTable = New DataTable("CSVFileTable")
                            'Get Number of columns
                            UpperBound = CurrentRow.GetUpperBound(0)
                            'Create new datatable
                            Dim colHeaders(UpperBound)
                            For ColumnCount = 0 To UpperBound
                                colHeaders(ColumnCount) = CurrentRow(ColumnCount).ToString
                                pubHeaders.Add(colHeaders(ColumnCount).ToString)                'use the column headers as column names
                            Next
                            For ColumnCount = 0 To UpperBound
                                Column = New DataColumn
                                Column.DataType = System.Type.GetType("System.String")
                                Column.ColumnName = colHeaders(ColumnCount)
                                Column.Caption = CurrentRow(ColumnCount).ToString
                                CSVFileTable.Columns.Add(Column)
                            Next
                        End If
                        Row = CSVFileTable.NewRow
                        For ColumnCount = 0 To UpperBound
                            Row(pubHeaders(ColumnCount)) = CurrentRow(ColumnCount).ToString
                            'Row()
                        Next
                        CSVFileTable.Rows.Add(Row)

                    End If
                Catch ex As Exception
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
            CSVFileReader.Dispose()
            CSVFileTable.Rows.RemoveAt(0)
            rowCount = CSVFileTable.Rows.Count
            csvDataGrid.DataSource = CSVFileTable
            csvTable = CSVFileTable.Copy()                                                              ' makes the csvTable public
            listSize = pubHeaders.Count - 1                                                             ' accounts for header row
            varHeaderBox.Items.Clear()                                                                  ' empties the listbox so new entries wouldnt be appended to bottom of old list
            For i = 0 To listSize
                varHeaderBox.Items.Add("<<" + pubHeaders(i) + ">>")                                     'Adds the << >> brackets for search/replace later
                listVariables.Add("<<" + pubHeaders(i) + ">>")                                          'creates a list of variables with the same entries.
            Next
        Catch exp As Exception
            MsgBox(exp.Message)

        End Try

    End Sub

    Private Sub LoadTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadTemplateToolStripMenuItem.Click
        Dim tplName = ""
        Try
            OpenFileDialog1.InitialDirectory = "c:\temp\"
            OpenFileDialog1.Filter = "Text files (*.txt)|*.txt|TPL Files (*.tpl)|*.tpl"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True
            OpenFileDialog1.Multiselect = False

            If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                Dim tplRead As IO.StreamReader
                tplName = OpenFileDialog1.FileName
                tplRead = IO.File.OpenText(tplName)
                templateBox.Text = tplRead.ReadToEnd
                tplRead.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub varHeaderBox_DoubleClick(sender As Object, e As EventArgs) Handles varHeaderBox.MouseDoubleClick
        templateBox.Text = templateBox.Text.Insert(0, varHeaderBox.SelectedItem)

    End Sub

    Private Sub genresButton_Click(sender As Object, e As EventArgs) Handles genresButton.Click
        Dim temp = templateBox.Text
        Dim outputBoxLength = outputBox.Text.Length
        Dim media = temp
        Dim arMedia As New Generic.List(Of String)

        outputBox.Text = ""

        For l = 0 To rowCount - 1
            Dim arRow = csvTable.Rows.Item(l)
            Dim rowLength As Integer = arRow.Table.Columns.Count - 1
            arMedia.Add(media)
            media = temp

            For r = 0 To rowLength
                media = media.Replace(listVariables(r), arRow(r))
            Next

        Next
        arMedia.Add(media)
        For i = 1 To rowCount
            outputBoxLength = outputBox.Text.Length
            outputBox.Text = outputBox.Text.Insert(outputBoxLength, arMedia.Item(i))
            outputBox.Text = outputBox.Text + Environment.NewLine
        Next

    End Sub

    Private Sub SaveDataCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveDataCSVToolStripMenuItem.Click
        Dim saveCSV As String = ""

        SaveFileDialog1.InitialDirectory = "c:\temp\"
        SaveFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        SaveFileDialog1.FilterIndex = 2
        SaveFileDialog1.RestoreDirectory = True

        If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            saveCSV = SaveFileDialog1.FileName
        End If
        If saveCSV <> "" Then
            Dim headers = (From header As DataGridViewColumn In csvDataGrid.Columns.Cast(Of DataGridViewColumn)() Select header.HeaderText).ToArray
            Dim rows = From row As DataGridViewRow In csvDataGrid.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow _
                       Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
            Using sw As New IO.StreamWriter(saveCSV)
                sw.WriteLine(String.Join(",", headers))
                For Each r In rows
                    sw.WriteLine(String.Join(",", r))
                Next
            End Using
            'Process.Start(saveCSV)
        End If
    End Sub

    Private Sub SaveOutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveOutputToolStripMenuItem.Click
        Dim saveOutputName = ""
        Try
            If outputBox.Text <> "" Then


                SaveFileDialog1.InitialDirectory = "c:\temp\"
                SaveFileDialog1.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*"
                SaveFileDialog1.FilterIndex = 2
                SaveFileDialog1.RestoreDirectory = True
                If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    saveOutputName = SaveFileDialog1.FileName
                End If
                If saveOutputName <> "" Then
                    Dim objWriter As New System.IO.StreamWriter(saveOutputName, False)
                    objWriter.WriteLine(outputBox.Text)
                    objWriter.Close()
                End If

            Else
                MessageBox.Show("The Output box is empty")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub SaveTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveTemplateToolStripMenuItem.Click
        Dim savetplName = ""
        Try
            If templateBox.Text <> "" Then


                SaveFileDialog1.InitialDirectory = "c:\temp\"
                SaveFileDialog1.Filter = "Text files (*.txt)|*.txt|TPL files (*.tpl)|*.tpl"
                SaveFileDialog1.FilterIndex = 2
                SaveFileDialog1.RestoreDirectory = True
                If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    savetplName = SaveFileDialog1.FileName
                End If
                If savetplName <> "" Then
                    Dim objWriter As New System.IO.StreamWriter(savetplName, False)
                    objWriter.WriteLine(outputBox.Text)
                    objWriter.Close()
                Else
                    MsgBox("Template Not Saved. Please Select a filepath")
                End If

            Else
                MessageBox.Show("The template box is empty")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



End Class
