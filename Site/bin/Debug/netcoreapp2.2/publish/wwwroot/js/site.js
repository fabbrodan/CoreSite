// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.card-img').click(function () {
    $("#myModal").css("display", "block");
    $("#modalImg").attr("src", $(this).attr("src"));
    $("#modalImg").attr("alt", $(this).attr("alt"));
});

$("#modalClose").click(function () {
    $("#myModal").css("display", "none");
});

$(".home-btn").click(function () {
    window.location.href = "/";
});

$(".delete-folder-btn").click(function () {
    var doDelete = confirm("This will delete all files in the folder as well!");
    if (doDelete) {

        $.ajax({
            url: "/File/DeleteFolder",
            data: { "id": $(this).attr('data-folderid') },
            type: "post"
        });
        console.log("Deleted");
    }
    else {
        window.location.href = "/Image/LoadAllFiles";
        console.log($(this).attr('data-folderid'));
        console.log("Not deleted");
    }
});