Public Class Form1
    Dim csvName As String = ""
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
                        For ColumnCount = 0 To UpperBound
                            Column = New DataColumn
                            Column.DataType = System.Type.GetType("System.String")
                            Column.ColumnName = "Column" & ColumnCount
                            Column.Caption = "Column" & ColumnCount
                            CSVFileTable.Columns.Add(Column)
                        Next
                    End If
                    Row = CSVFileTable.NewRow
                    For ColumnCount = 0 To UpperBound
                        Row("Column" & ColumnCount) = CurrentRow(ColumnCount).ToString
                    Next
                    CSVFileTable.Rows.Add(Row)
                End If
            Catch ex As Exception
                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
            End Try
        End While
        CSVFileReader.Dispose()
        csvDataGrid.DataSource = CSVFileTable


    End Sub
   
    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

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

    Private Sub headerBox_TextChanged(sender As Object, e As EventArgs) Handles headerBox.TextChanged

    End Sub
End Class
