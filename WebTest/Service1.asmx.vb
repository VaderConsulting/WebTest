Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.OleDb

<System.Web.Services.WebService(Namespace:="http://Empired/WebServices")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service1
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function InsertStatus(ByVal strComputername As String, ByVal strData As String) As String
        Dim oConnection As New OleDb.OleDbConnection(My.Settings.SQLConnectionString)
        Dim oCommand As New System.Data.OleDb.OleDbCommand()
        Dim intOperationType As Integer
        Dim strResult As String = ""

        intOperationType = 2 ' Read = 1, Write = 2

        oCommand.CommandType = CommandType.Text

        Select Case intOperationType
            Case 1
                ' Read
                oCommand.CommandText = "SELECT * FROM tblStatus"
                oCommand.Connection = oConnection
                oConnection.Open()

                Dim oReader As OleDbDataReader = oCommand.ExecuteReader()
                Try
                    While oReader.Read()
                        Console.WriteLine(oReader.GetString(0))
                    End While
                    strResult = "Read complete"
                Finally
                    oReader.Close()
                    oConnection.Close()
                End Try
            Case 2
                ' Write
                oCommand.CommandText = "INSERT INTO tblStatus (Computer, Status) VALUES ('" & strComputername & "','" & strData & "')"
                oCommand.Connection = oConnection
                Try
                    oConnection.Open()

                    oCommand.ExecuteNonQuery()

                    oConnection.Close()

                    strResult = "Write complete"
                Catch ex As Exception
                    strResult = "Error " & ex.ToString
                End Try

        End Select

        Return strResult

    End Function

End Class