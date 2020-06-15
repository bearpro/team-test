function pushAnswer(e) {
    let answ = e.currentTarget;
    let question_guid = answ.parentNode.parentNode.parentNode.id;
    console.log(answ);
    console.log(question_guid);

    let answerGuid = answ.id;
    result = {
        answerGuid,
        question_guid
    };

    fetch('/api/question/answer/', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(result)
    });
}

fetch('/api/question/All/', {
    method: 'GET'
})
  .then(response => response.json())
  .then(result => {
    console.log(result);

    for (question of result) {
        new Card(question.guid, question.text, 'MultiAnswer', question.answers);
    }
    let form = document.getElementById('main_form');
});



class Card  {
    constructor(id = null, question_name, q_type = 'SingleAnswer', answers = []) {
        this.card_html = document.createElement('div');
        this.card_html.className = 'card';
        this.card_html.id = id;

        let card_name_html = document.createElement('h5');
        card_name_html.className = 'card-header';
        card_name_html.innerHTML = 'Вопрос';
        this.card_html.append(card_name_html);

        let card_body_html = document.createElement('div');
        card_body_html.className = 'card_body';

        let card_body_name_html = document.createElement('h5');
        card_body_name_html.className = 'card-title';
        card_body_name_html.innerHTML = question_name;

        let card_body_label_html = document.createElement('p');
        card_body_label_html.className = 'text-muted';
        card_body_label_html.innerHTML = q_type;

        let card_body_text_html = document.createElement('ul');
        card_body_text_html.className = 'list-group';

        // Рендеринг ответов
        for (let answer of answers) {
            let li_html = document.createElement('li');
            li_html.className = 'list-group-item';
            if (answer.isRight)
                li_html.classList.add('active');
            li_html.id = answer.guid;

            li_html.innerHTML = answer.text;
            li_html.addEventListener('click', pushAnswer);
            card_body_text_html.append(li_html);
        }

        card_body_html.append(card_body_name_html);
        card_body_html.append(card_body_label_html);
        card_body_html.append(card_body_text_html);
        this.card_html.append(card_body_html);
        document.getElementsByClassName('jumbotron')[0].append(this.card_html);
    }

    changeNameQuestion(question_name) {
        let q = this.card_html.getElementsByClassName('card-title')[0];
        q.innerHTML = question_name;
    }
}


let form = document.getElementById('main_form');
        form.addEventListener('submit', () => {
        let jumbotron = document.getElementsByClassName('jumbotron')[0];
        for (question of questions) {
            new Card(i, 'Имя вопроса', 'SingleAnswer', ['Вариант 1', 'Вариант 2', 'Вариант 3']);
        }
          
      })