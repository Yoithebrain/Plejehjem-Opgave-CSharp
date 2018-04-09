//Text getter til pop-up vinduer, i tilfælde af at flere skal bruge den.
//Made by Christian
//Used for pop-ups.


function clickHanlder() {
    newWin();
}
function newWin() {
    var mywindow = window.open("", "_blank", "height = 200, width = 300", false);
    mywindow.focus;
}