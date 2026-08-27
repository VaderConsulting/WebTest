Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As New d820.Service1
        Dim strResult As String = ""

        strResult = x.InsertStatus("EXAMPLE-HOST", "Started")

        x = Nothing

    End Sub
End Class
