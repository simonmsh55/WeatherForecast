Imports System.Runtime.InteropServices
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    <HttpGet>
    Function UploadFile() As ActionResult
        Return View()
    End Function


    <HttpPost>
    Function UploadFile(file As HttpPostedFileBase) As ActionResult
        Try
            If (file.ContentLength > 0) Then
                Dim _FileName As String = Path.GetFileName(file.FileName)
                Dim _path As String = Path.Combine(Server.MapPath("~/Uploads"), _FileName)
                file.SaveAs(_path)

                ViewBag.Results = ""

                Dim webResponse As String
                Dim openMeteoClient As New OpenMeteoClient


                Dim results As String = ""
                For Each Line As String In System.IO.File.ReadLines(_path)
                    Dim lineElements = Line.Split(",")
                    Try
                        Dim lat As Double = Double.Parse(lineElements(0))
                        Dim lon As Double = Double.Parse(lineElements(1))
                        webResponse = openMeteoClient.GetForecast(lat, lon)
                        Dim jsonObject As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(webResponse)
                        Dim hourly As Newtonsoft.Json.Linq.JObject = jsonObject("hourly")
                        Dim time As Newtonsoft.Json.Linq.JArray = hourly("time")
                        Dim temperature_2m As Newtonsoft.Json.Linq.JArray = hourly("temperature_2m")
                        results += "<h1>" + lineElements(2).Replace("""", "") + "</h1><br/>"
                        results += "<table class=""table table-striped table-bordered table-condensed"">"
                        results += "<tr><td>Time (GMT)</td><td>Temperature (Celcius)</td></tr>"
                        For i As Integer = 0 To time.Count - 1
                            results += "<tr><td>" + time(i).ToString + "</td><td>" + temperature_2m(i).ToString + "</td></tr>"
                        Next i
                        results += "</table>"

                        'results += webResponse + "<br/>"
                    Catch ex As Exception
                        'Do nothing
                    End Try
                Next

                ViewBag.Results = results

                Return View("index")
            End If
        Catch
            ViewBag.Message = "File upload failed!!"
            Return View("index")
        End Try
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
