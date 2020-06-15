fetch('http://localhost:5001/api/question/All/', {
    method: 'GET'
})
  .then(response => response.json())
  .then(result => {
      console.log(result)
});


// let form = document.getElementById('main_form');
