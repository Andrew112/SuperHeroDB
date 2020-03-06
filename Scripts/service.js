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

//New code for editHero function..
function editHero() {
    var heroId = {

        "FirstName": $("#updateFirstname").val(),
        "Lastname": $("#updateLastname").val(),
        "HeroName": $("#updateHeroname").val(),
        "PlaceOfBirth": $("#updatePlaceOfBirth").val(),
        "CombatPoints": $("#updateCombatPoints").val()
    };

    $.ajax({
        url: "Service/SuperHeroService.svc/editHero",
        type: "PUT",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(heroId),
        success: function (result) {
            heroId = result;
            editHero(result);
            showAdd();
           // console.log(heroId);

            //success: function () {
               // showAdd();
        }
    });
}
