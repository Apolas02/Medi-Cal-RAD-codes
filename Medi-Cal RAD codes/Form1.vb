Imports System.IO

Public Class Form1
    Dim radDict As IDictionary(Of String, Tuple(Of String, String)) = New Dictionary(Of String, Tuple(Of String, String))()

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("RAD_Repository.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                currentRow = MyReader.ReadFields
                If radDict.ContainsKey(currentRow(0)) Then
                    Continue While
                Else
                    Dim info = New Tuple(Of String, String)(currentRow(1), currentRow(2))
                    radDict.Add(currentRow(0), info)
                End If


            End While
        End Using
    End Sub



    Public Sub searchRad()
        If radDict.ContainsKey(txtSearch.Text) Then
            Dim searchValue = radDict(txtSearch.Text)
            txtOutput.Text = searchValue.Item1
            txtBilling.Text = searchValue.Item2
        Else
            txtOutput.Text = "RAD code not found"
        End If


    End Sub

    Private Sub searchDate()
        Dim searchInput As Integer
        searchInput = txtSearch.Text
        If txtSearch.Text < 366 Then txtOutput.Text = "Dec " + (searchInput - 334).ToString
        If txtSearch.Text < 335 Then txtOutput.Text = "Nov " + (searchInput - 304).ToString
        If txtSearch.Text < 305 Then txtOutput.Text = "Oct " + (searchInput - 273).ToString
        If txtSearch.Text < 274 Then txtOutput.Text = "Sep " + (searchInput - 243).ToString
        If txtSearch.Text < 244 Then txtOutput.Text = "Aug " + (searchInput - 212).ToString
        If txtSearch.Text < 213 Then txtOutput.Text = "Jul " + (searchInput - 181).ToString
        If txtSearch.Text < 182 Then txtOutput.Text = "Jun " + (searchInput - 151).ToString
        If txtSearch.Text < 152 Then txtOutput.Text = "May " + (searchInput - 120).ToString
        If txtSearch.Text < 121 Then txtOutput.Text = "Apr " + (searchInput - 90).ToString
        If txtSearch.Text < 91 Then txtOutput.Text = "Mar " + (searchInput - 59).ToString
        If txtSearch.Text < 60 Then txtOutput.Text = "Feb " + (searchInput - 31).ToString
        If txtSearch.Text < 32 Then txtOutput.Text = "Jan " + searchInput.ToString

    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        txtOutput.Clear()
        txtBilling.Clear()
        If radRADs.Checked Then searchRad()
        If radDate.Checked Then searchDate()
    End Sub
End Class
