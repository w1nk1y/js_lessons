// Доступ к элементам
document.getElementById('changeTextBtn').addEventListener('click', function() {
    document.getElementById('textElement').textContent = 'Текст был изменён! Вот это магия!';
});

// Изменение атрибутов
document.getElementById('changeImageBtn').addEventListener('click', function() {
    document.getElementById('imageElement').setAttribute('src', 'https://via.placeholder.com/300');
    document.getElementById('imageElement').setAttribute('alt', 'Новая картинка-заполнитель');
});

// Манипуляции со стилями
document.getElementById('changeStyleBtn').addEventListener('click', function() {
    const styleElement = document.getElementById('styleElement');
    styleElement.style.color = 'white';
    styleElement.style.backgroundColor = 'blue';
    styleElement.style.padding = '10px';
});

// Создание и удаление элементов
document.getElementById('addElementBtn').addEventListener('click', function() {
    const newElement = document.createElement('p');
    newElement.textContent = 'Я новый элемент! Привет!';
    document.getElementById('elementContainer').appendChild(newElement);
});

document.getElementById('removeElementBtn').addEventListener('click', function() {
    const container = document.getElementById('elementContainer');
    if (container.lastChild) {
        container.removeChild(container.lastChild);
    }
});

// События и обработчики событий
document.getElementById('eventBtn').addEventListener('mouseover', function() {
    alert('Кнопка была нажата! Ура!');
});

// Возможности JavaScript
// Операции с массивами
document.getElementById('arrayBtn').addEventListener('click', function() {
    const array = [1, 2, 3, 4, 5];
    const doubledArray = array.map(num => num * 2);
    document.getElementById('arrayOutput').textContent = 'Оригинальный массив: ' + array.join(', ') + 
    ' | Удвоенный массив: ' + doubledArray.join(', ');
});

// Операции с объектами
document.getElementById('objectBtn').addEventListener('click', function() {
    const person = { name: 'Алиса', age: 25, city: 'Нью-Йорк' };
    person.age += 1;
    document.getElementById('objectOutput').textContent = 'Обновленный объект: ' + JSON.stringify(person);
});

// Операции с циклами
document.getElementById('loopBtn').addEventListener('click', function() {
    let output = '';
    for (let i = 1; i <= 5; i++) {
        output += 'Число: ' + i + ' ';
    }
    document.getElementById('loopOutput').textContent = output;
});

// Операции с функциями
document.getElementById('functionBtn').addEventListener('click', function() {
    function add(a, b) {
        return a + b;
    }
    document.getElementById('functionOutput').textContent = 'Результат add(3, 4): ' + add(3, 4);
});

// Пример замыкания
const makeCounter = (function() {
    let count = 0;
    return function() {
        count += 1;
        return count;
    };
})();

document.getElementById('closureBtn').addEventListener('click', function() {
    document.getElementById('closureOutput').textContent = 'Счётчик замыкания: ' + makeCounter();
});


