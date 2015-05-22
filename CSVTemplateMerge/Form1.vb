'Imports LINQtoCSV
Imports System
Imports Microsoft

Public Class CSVTemplateMerge
    Dim csvName As String = ""
    Dim listSize As Integer
    Dim rowCount As Integer
    Dim listVariables As New Generic.List(Of String)
    Private Sub LoadDataCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadDataCSVToolStripMenuItem.Click
        Dim csvName As String = ""
        OpenFileDialog1.InitialDirectory = "c:\temp\"
        OpenFileDialog1.Filter = "CSV files (*.csv)|*.CSV"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            csvName = OpenFileDialog1.FileName
        End If
        Me.StatusStrip1.Text = csvName
        Dim CSVFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(csvName)
        CSVFileReader.TextFieldType = FileIO.FieldType.Delimited
        CSVFileReader.SetDelimiters(",")

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
                            pubHeaders.Add(colHeaders(ColumnCount).ToString)
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
        listSize = pubHeaders.Count - 1
        For i = 0 To listSize
            varHeaderBox.Items.Add("<<" + pubHeaders(i) + ">>")
            listVariables.Add("<<" + pubHeaders(i) + ">>")
        Next

    End Sub

    Private Sub SaveDataCSVAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveDataCSVAsToolStripMenuItem.Click
        Dim I As Integer = 0
        Dim J As Integer = 0
        Dim cellvalue$
        Dim rowLine As String = ""
        Try
            Dim objWriter As New System.IO.StreamWriter(csvName, True)
            For J = 0 To (csvDataGrid.RowCount - 2)
                For I = 0 To (csvDataGrid.ColumnCount - 2)
                    If Not TypeOf csvDataGrid.CurrentRow.Cells.Item(I).Value Is DBNull Then
                        cellvalue = csvDataGrid.Item(I, J).Value
                    Else
                        cellvalue = ""
                    End If
                    rowLine = rowLine + cellvalue + ","
                Next
                objWriter.WriteLine(rowLine)

                rowLine = ""

            Next

            objWriter.Close()

            MsgBox("Text written to file")

        Catch ex As Exception

            MessageBox.Show("Error occured while writing to the file." + ex.ToString())

        Finally

            FileClose(1)

        End Try

    End Sub


    Private Sub varHeaderBox_DoubleClick(sender As Object, e As EventArgs) Handles varHeaderBox.MouseDoubleClick
        templateBox.Text = templateBox.Text.Insert(0, varHeaderBox.SelectedItem)

    End Sub

    Private Sub genresButton_Click(sender As Object, e As EventArgs) Handles genresButton.Click
        Dim temp = templateBox.Text
        For i = 1 To rowCount
            Dim media = temp
            For l = 0 To listSize
                media = media.Replace(listVariables(l), 11)
                Dim outputBoxLength = outputBox.Text.Length
                outputBox.Text = outputBox.Text.Insert(outputBoxLength, media)
            Next
        Next

    End Sub
End Class
