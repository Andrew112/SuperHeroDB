function getAllHeroes() {
    $.ajax({
        url: "Service/SuperHeroService.svc/GetAllHeroes",
        type: "GET",
        dataType: "json",
        success: function (result) {
            heroes = result;
            drawHeroTable(result); 
            //console.log(result); 
        }
    });
}

function addHero() {
    var newHero = {
        "FirstName": $("#addFirstname").val(),
        "LastName": $("#addLastname").val(),
        "HeroName": $("#addHeroname").val(),
        "PlaceOfBirth": $("#addPlaceOfBirth").val(),
        "Combat": $("#addCombatPoints").val()
    };

    $.ajax({
        url: "Service/SuperHeroService.svc/AddHero",
        type: "POST",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(newHero),
        success: function () {
            showOverview();
        }
    });
}

function putHero() {
    updateHero.Firstname = $("#UpdateFirstname").val();        
    updateHero.LastName = $("#UpdateLastname").val();
    updateHero.HeroName = $("#UpdateHeroname").val();
    updateHero.PlaceOfBirth = $("#UpdatePlaceOfBirth").val();
    updateHero.Combat = $("#UpdateCombatPoints").val();


    $.ajax({
        url: "Service/SuperHeroService.svc/UpdateHero/" + updateHero.Id,
        type: "PUT",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(updateHero),
        success: function () {
            showOverview();
           

        }
    });
}
function deleteHero(heroId) {

    $.ajax({
        url: "Service/SuperHeroService.svc/DeleteHero/" + heroId,
        type: "GET",
        dataType: "json",
        success: function (result) {
            getAllHeroes();

        }
    });
}
