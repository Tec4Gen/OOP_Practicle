$(document).ready(function () {
    $('#submit').click(function (e) {
        $("input").removeClass("error");
        $('.label-password').text("");
        $('.label-re-password').text("");

        $('.label-surname').text("");
        $('.label-frist-name').text("");
        $('.label-middle-name').text("");

        let login = $('#inputLogin').val();
        let password = $('#inputPassword').val();
        let rePassword = $('#input-re-enter').val();
        let surname = $('#input-surname').val();
        let firstName = $('#input-first-name').val();
        let middleName = $('#input-middle-name').val();
        let flag = false;

        if (password.length < 3) {
            $('.label-password').text("Пароль не может быть меньше 3 символов");
            $("#inputPassword").addClass("error");
            flag = true;
        }

        if (rePassword != password) {
            $('.label-re-password').text("Пароли не совпадают");
            $("#input-re-enter").addClass("error");
            flag = true;
        }

        if (surname.length < 3) {
            $('.label-surname').text("Фамилия не может быть меньше 3 символов");
            $("#input-surname").addClass("error");
            e.preventDefault();
            return;
        }
        if (firstName.length < 3) {
            $('.label-frist-name').text("Имя не может быть меньше 3 символов");
            $("#input-first-name").addClass("error");
            flag = true;
        }

        if (middleName.length < 3) {
            $('.label-middle-name').text("Отчество не может быть меньше 3 символов");
            $("#input-middle-name").addClass("error");
            flag = true;
        }

        if (flag === true) {
            e.preventDefault();
            return;
        } 
        $.ajax({
            type: "POST",
            url: '/Model/AuthCheck.aspx/CheckSignUp',
            data: '{login:"' + login + '"}',
            async: false,
            cache: false,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                let data = response.d;
                data = $.parseJSON(data);
                console.log(data);
                if (data.status === "OK") {
                    $(".alert-danger").removeClass("show");
                } else {
                    $(".alert-danger").addClass("show");
                    e.preventDefault();
                    return;
                };
            },
            error: function () {
                alert(1);
            }
        });

    });
});