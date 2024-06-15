document.addEventListener("DOMContentLoaded", function() {
    const getWeatherBtn = document.getElementById('getWeatherBtn');
    getWeatherBtn.addEventListener('click', async function() {
    try{
        response = await axios.get("http://localhost:5197/weatherforecast");
        const forecastDiv = document.getElementById('forecast');
        forecastDiv.innerHTML = '';
        response.data.forEach(forecast => {
            const forecastItem = document.createElement('div');
            forecastItem.innerHTML = `
                <p>Date: ${forecast.date}</p>
                <p>Temperature (C): ${forecast.temperatureC}</p>
                <p>Temperature (F): ${forecast.temperatureF}</p>
                <p>Summary: ${forecast.summary}</p>
             `;
             forecastDiv.appendChild(forecastItem);
        }); 
    }    
     catch(error){
        console.log(error);
      }
      });
     
        

    const postButton = document.getElementById('postBtn');  /получаем кнопку запроса по айди/
    postButton.addEventListener('click', async function(){  /прикручиваем обработку событий (что будет при нажатии)/
        try{
            const response = await fetch("http://localhost:5197/submitdata", {
                method: 'POST',
                headers:{
                    'Content-Type':'application/json'
                },
                body: JSON.stringify({name:'ANDREY', age: 16})
            });
            if (!response.ok){
                throw new Error('Something Wrong');
            }
            const data = await response.json();/преобразуем объект js в json строку и/
            const postResultContainer = document.getElementById('postResult'); /получаем айди поля для вывода данных запроса/
            postResultContainer.innerHTML = '';  /очищаем блок текста от старой информации/
            postResultContainer.innerHTML = JSON.stringify(data, null, 2); / передаём в блок с текстом в html/
        }
        catch(error){
            console.log(error);
        }

    });
});
