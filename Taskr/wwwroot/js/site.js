// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function startTimer(hou,sec) {

    
    start.style.display = "none";
    range.style.display = "none";
    pause.style.display = "inline";
    reset.style.display = "inline";
    //resume.style.display = "inline";
    var hou = input.value-1;

    var sec = 59;
    var interval =  setInterval(function () {
        var a = new Date();
        pause.onclick = function () {
            pause.style.display = "none";
            //resume.style.display = "inline";
            document.getElementById("maintimer").innerHTML = hou + " : " + sec;
            clearInterval(interval);
           
        }
        document.getElementById("maintimer").innerHTML = hou + " : " + sec;
        sec--;
        if (sec == 00 || sec == 0) {
            hou--;
            sec = 59;
        } else 
            if (hou == -1) {
                hou = 0
                sec=0
                document.getElementById("maintimer").innerHTML = hou + " : " + sec;
                stopTimer()
                
            }
        function stopTimer() {
            
            document.getElementById("maintimer").innerHTML = 00 + " : " + 00;
            alert("Congratulations! Timer completed!");
            stop()
            clearInterval(interval);
        }
    }, 1000);
    
}

function stop() {
    window.location.reload();
}

function resume() {
    startTimer(hou, sec)
}
