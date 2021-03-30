
sPath = window.location.pathname;
sPage = sPath.substring(sPath.lastIndexOf('/') + 1);

if (sPage.trim() === "Uploadcsv" || sPage.trim() === "uploadcsv") {
   //setTimeout(function () { $('.preloader').fadeIn(); }, 300);
   setTimeout(function () { $('.preloader').fadeOut('slow'); }, 400);
} else {
    //$(".preloader").remove();               
    setTimeout(function () { $('.preloader').fadeIn(); }, 500);
    setTimeout(function () { $('.preloader').fadeOut('slow'); }, 1000);
}
