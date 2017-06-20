function randomQuote() {
  $.ajax({
      url: "https://api.forismatic.com/api/1.0/?",
      dataType: "jsonp",
      data: "method=getQuote&format=jsonp&lang=en&jsonp=?",
      success: function( response ) {
        $("#random_quote").html("<p id='random_quote' class='lead text-center'>" +
          response.quoteText + "<br/>&dash; " + response.quoteAuthor + " &dash;</p>");
        $("#tweet").attr("href", "https://twitter.com/home/?status=" + response.quoteText +
          ' (' + response.quoteAuthor + ')');
      }
  });
}


$(function() {
  randomQuote();
});

// $(document).ready(function(){
//   $("#RemedyCategoryForm").submit(function(event){
//     event.preventDefault();
//     var nameCategoryRemedy = $("input#remedyCategory").val();
//     if (nameCategoryRemedy == "")
//     {
//       alert("please fill in the form!");
//     }
//   });
//
//   $("#DiseaseCategoryForm").submit(function(event){
//     event.preventDefault();
//     var nameCategoryDisease = $("input#diseaseCategory").val();
//
//     if (nameCategoryDisease == "")
//     {
//       alert("please fill in the form!");
//     }
//   });
//   $("#RemedyForm").submit(function(event){
//     event.preventDefault();
//     var remedyName = $("input#RemedyName").val();
//     var remedyDescription = $("input#RemedyDescription").val();
//     var remedySideEffect = $("input#RemedySideEffect").val();
//
//     if (remedyName == "" || remedyDescription == "" || remedySideEffect == "")
//     {
//       alert("please fill in the form!");
//     }
//   });
//   $("#DiseaseForm").submit(function(event){
//     event.preventDefault();
//     var nameCategoryRemedy = $("input#remedyCategory").val();
//
//     if (nameCategoryRemedy == "")
//     {
//       alert("please fill in the form!");
//     }
//   });
//
// });
