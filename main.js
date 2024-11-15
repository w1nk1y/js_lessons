document.addEventListener("DOMContentLoaded", () => {
    loadComments();
    checkLikeStatus();
    updateLikeCount();
});

function Like() {//лайкаем)
    const likeIcon = document.getElementById("like-icon");
    let likes = parseInt(localStorage.getItem("counter")) || 0;
    
    if (localStorage.getItem("liked") === "true") {
        likeIcon.src = "heart.svg";
        localStorage.setItem("liked", "false");
        likes=likes-1;
    } else {
        likeIcon.src = "full_heart.svg";
        localStorage.setItem("liked", "true");
        likes+=1;
    }

    localStorage.setItem("counter", likes);
    updateLikeCount();
}

function checkLikeStatus() { //проверка статуса лайка
    const likeIcon = document.getElementById('like-icon');
    if (localStorage.getItem('liked') === 'true') {
        likeIcon.src = 'full_heart.svg';
    } else {
        likeIcon.src = 'heart.svg';
    }
}

function updateLikeCount() { //чтоб брать кол-во лайков из LS и отображать на странице
    const likeCount = document.getElementById('counter');
    const likes = parseInt(localStorage.getItem('counter')) || 0;
    likeCount.textContent = likes;
}
function loadComments() {//загружаем комментарии из массива в контейнер
    const commentsContainer = document.getElementById('comment-block');
    commentsContainer.innerHTML = '';

    const comments = [
        { username: 'Михаил', text: 'Когда фитанёшь с хайпом?' },
        { username: 'Melody', text: '0_0 мой кумир!!' }
    ];

    comments.forEach(comment => {
        addCommentToDOM(comment.username, comment.text);
    });
}

function addComment() {
    const newComment = prompt('Введите текст комментария');
    if (newComment) {
        addCommentToDOM('Andrei', newComment);
    }
}

function addCommentToDOM(username, text) {//добавление нового комментария пользователя andrei в ДОМ
    const commentsContainer = document.getElementById('comment-block');
    const commentElement = document.createElement('div');
    commentElement.classList.add('comment');
    commentElement.innerHTML = `<strong>${username}:</strong> ${text}`;
    commentsContainer.appendChild(commentElement);
}
