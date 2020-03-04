function getAllHeroes() {
    $.ajax({
        url: "Service / SuperHeroService.svc / GetAllHeroes",
        type: "GET",
        dataType: "json",
        success: function (result) {
            heroes = result;
            drawHeroTable(result); //"This is the first function in app.js", calls the main function method for this class.
            //console.log(result); //this test data inside of console without the need for "html output".
        }
    });
}