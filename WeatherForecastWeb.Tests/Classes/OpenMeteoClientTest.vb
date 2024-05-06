Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports WeatherForecastWeb

<TestClass()> Public Class OpenMeteoClientTest

    <TestMethod()> Public Sub GetForecast()
        ' Arrange
        Dim openMeteoClient As New OpenMeteoClient


        Dim webResponse = openMeteoClient.GetForecast(10.0, 10.0)

        Assert.IsNotNull(webResponse)
    End Sub

End Class