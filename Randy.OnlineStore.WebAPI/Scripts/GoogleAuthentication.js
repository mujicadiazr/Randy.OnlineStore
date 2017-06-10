/// <reference path="jquery-1.10.2.min.js" />

function getAccessToken() {
    if (location.hash) {
        if (location.hash.split("access_token=")) {
            var accessToken = location.hash.split("access_token=")[1].split("&")[0];
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }
}

function isUserRegistered(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'Content-Type': 'Application/Json',
            'Authorization': 'Bearer '+accessToken
        },
        success: function (response) {
            if (response.hasRegistered) {
                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('userName', response.email);
                window.location.href = "Data.html";
            } else {
                signupExternalUser(accessToken);
            }
        }
        
    });
}

function signupExternalUser(accessToken) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'POST',
        headers: {
            'Content-Type': 'Application/Json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A52709%2FLogin.html&state=RU8YlBoEPF8CxxVvMMzEKax6oj-0FjTkNCg25MsmmHY1";
        }
    });
}