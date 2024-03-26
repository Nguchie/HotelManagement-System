Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Module connection
    Private server As String = "localhost"
    Private userid As String = "root"
    Private pass As String = ""
    Private databaseName As String = "db_hotelmanagement"
    Private conString As String = "server=" & server & ";user id=" & userid & ";password=" & pass & ";database=" & databaseName & ";sslMode=none;"

    Function mysqldb() As MySqlConnection
        Return New MySqlConnection(conString)
    End Function
    Public con As MySqlConnection = mysqldb() 
End Module
