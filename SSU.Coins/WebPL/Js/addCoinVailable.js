$(document).ready(function () {
    $('#submit').click(function (e) {
        $("input").removeClass("error");
        $("select").removeClass("error");
        $('.label-title').text("");
        $('.label-year').text("");
       

        let title = $('#inputTitle').val();
        let year = $('#inputYear').val();
        let material = $('#inputMaterial').val();
        let country = $('#inputCountry').val();
        let decription = $('#Decription').val();

        let flag = false;

        if (title.length < 3) {
            $('.label-title').text("Название не может быть меньше 10 символов");
            $("#inputTitle").addClass("error");
            flag = true;
        }

        if (year.length < 4 || year.length > 4 ) {
            $('.label-year').text("Введите год в формате 1234");
            $("#inputYear").addClass("error");
            flag = true;
        }
        if (material === null || material === undefined || material === "") {   
            $("#inputMaterial").addClass("error");
            flag = true;
        }

        if (country === null || material === undefined || material === "") {
            $("#inputCountry").addClass("error");
            flag = true;
        }

        if (decription.length < 3) {
            $("#Decription").addClass("error");
            flag = true;
        }

        if (flag === true) {
            e.preventDefault();
            return;
        }   

        let qua = confirm('Вы действительно хотите создать запись?');
        if (!qua) {
            e.preventDefault();
            return;
        }

    });
});