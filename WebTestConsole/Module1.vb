Module Module1

    Sub Main()
        Dim x As New D820.Service1
        Dim strResult As String = ""

        Try
            Dim strComputername As String = My.Application.CommandLineArgs(0).ToString
            Dim strStatus As String = My.Application.CommandLineArgs(1).ToString

            Console.WriteLine("Opening Web Service")

            strResult = x.InsertStatus(strComputername, strStatus)

            x = Nothing
            Console.WriteLine("Complete. Result=" & strResult)
        Catch
            Console.WriteLine("Error")
        End Try
    End Sub

End Module
