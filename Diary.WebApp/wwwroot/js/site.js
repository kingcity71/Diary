var tokenKey = "accessToken";

// отпавка запроса к контроллеру AccountController для получения токена
async function getTokenAsync(username, password) {

    // получаем данные формы и фомируем объект для отправки
    const formData = new FormData();
    formData.append("grant_type", "password");
    formData.append("username", username);
    formData.append("password", password);

    // отправляет запрос и получаем ответ
    const response = await fetch("/auth/token", {
        method: "POST",
        headers: { "Accept": "application/json" },
        body: formData
    });
    // получаем данные
    const data = JSON.parse(await response.json());
    console.log(data);
    // если запрос прошел нормально
    if (response.ok === true) {
        sessionStorage.setItem(tokenKey, data.access_token);
        console.log(data.access_token);
    }
    else {
        // если произошла ошибка, из errorText получаем текст ошибки
        console.log("Error: ", response.status, data.errorText);
    }
};

async function getData(url) {
    const token = sessionStorage.getItem(tokenKey);

    const response = await fetch(url, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Authorization": "Bearer " + token  // передача токена в заголовке
        }
    });
    if (response.ok === true) {

        const data = await response.json();
        console.log(data)
    }
    else
        console.log("Status: ", response.status);
};

function clearToken() {
    sessionStorage.removeItem(tokenKey);
}