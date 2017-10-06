$(function () {
  var result = [{ name: "Hyatt", address: "pune"},
  { name: "Novotel", address: "Nagar Road"},
  { name: "Taj", address: "Mumbai" },
  { name: "Bombay Hotel", address: "Guess??" }];

  var template = $('#hotel-item');

  var compiledTemplate = Handlebars.compile(template.html());

  var html = compiledTemplate(result);

  $('#hotelList-container').html(html);
});