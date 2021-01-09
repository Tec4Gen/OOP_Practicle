$(document).ready(function () {
    $('#submit').click(function (e) {
        let flag = false;
        $("input").removeClass("error");
        $('.labal-pass').text("");
        let login = $('#inputLogin').val();
        let password = $('#inputPassword').val();
        if (login == undefined || login == null) {
            $(".alert-danger").removeClass("show");
            $("#inputLogin").addClass("error");
            flag = true;
        }
        if (password.length < 3) {
            $('.labal-pass').text("Пароль не может быть меньше 3 символов");
            $(".alert-danger").removeClass("show");
            $("#inputPassword").addClass("error");
            flag = true;
        }

        if (flag === true)
        {
            e.preventDefault();
            return;
        }     
        $.ajax({
            type: "POST",
            url: '/Model/AuthCheck.aspx/CheckSignIn',
            data: '{login:"' + login + '",password:"' + password + '"}',
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
                e.preventDefault();
            }
        });

    });
});