@Code
    ViewData("Title") = "Weather Forecasr"
End Code

<div class="jumbotron">
    <h1>Weather forecast</h1>
    <p class="lead">Upload a CSV file to obtain a weather forecast</p>
</div>

<div class="row">
    @Using (Html.BeginForm("UploadFile", "Home", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
        @<div>
            @Html.TextBox("file", "", New With {.type = "file"}) <br />
            <input type="submit" value="Upload" />
            @ViewBag.Message
        </div>
    End Using
</div>

<div class="row">
    @Html.Raw(ViewBag.Results)
</div>


