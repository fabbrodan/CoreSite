// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.card-img').click(function () {
    $("#myModal").css("display", "block");
    $("#modalImg").attr("src", $(this).attr("src"));
    $("#modalImg").attr("alt", $(this).attr("alt"));
    $('#modalCaption').html($(this).attr('data-caption'));
});

$("#modalClose").click(function () {
    $("#myModal").css("display", "none");
});

$(".home-btn").click(function () {
    window.location.href = "/Home/Start";
});