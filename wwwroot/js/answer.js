let question = {
    name: 'Название вопроса',
    type: 'SingleAnswer',
    answer: 'Это ответ'
}

// Создание карточки
let card_html = document.createElement('div');
card_html.className = ['card'];
// Заголовок карточки
let h5 = document.createElement('h5');
h5.className = 'card-header';
h5.innerHTML = 'Вопрос';
card_html.append(h5);

// Тело карточки
let card_body_html = document.createElement('div');
card_body_html.className = 'card-body';

// Название вопроса в карточке
let question_name_html = document.createElement('h5');
question_name_html.className = 'card-title';
question_name_html.innerHTML = question.name;

// Тип вопроса
let question_type_html = document.createElement('p');
question_type_html.className = 'text-muted';
question_type_html.innerHTML = 'Тип: ' + question.type;


// Ответ в карточке
let question_answer = document.createElement('p');
question_answer.className = 'card-text';
question_answer.innerHTML = question.answer;


// Добавление потомков в тело карточки
card_body_html.append(question_name_html);
card_body_html.append(question_type_html);
card_body_html.append(question_answer);

card_html.append(card_body_html);
document.getElementsByClassName('jumbotron')[0].append(card_html);