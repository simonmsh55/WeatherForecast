Imports System.Net.Http
Imports System.Threading.Tasks

Public Class OpenMeteoClient
    Public Sub OpenMeteoClient()

    End Sub


    Public Function GetForecast(lat As Double, lon As Double) As String
        Dim answer As String

        Dim url As String = "https://api.open-meteo.com/v1/forecast?latitude=" + lat.ToString + "&longitude=" + lon.ToString & "&hourly=temperature_2m"

        Using client As HttpClient = New HttpClient()
            Dim response As HttpResponseMessage = client.GetAsync(url).Result
            answer = response.Content.ReadAsStringAsync.Result
        End Using

        Return answer
    End Function


End Class
