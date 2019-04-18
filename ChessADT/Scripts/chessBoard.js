
function createDivChessBoard() {
    var mainBody = document.getElementsByTagName("body")[0];
    mainBody.style.padding = "0px";
    mainBody.appendChild(document.createElement("div")).setAttribute("id", "boardDiv");
    var boardDiv = document.getElementById("boardDiv");

    var size = 8;
    var helper = "HGFEDCBA";

        for (var i = 0; i < size; i++) {

            for (var j = 1; j <= size; j++) {

                var color = i + j;
                var name = helper[i] + (j).toString();
                var newDiv = document.createElement("div");
                newDiv.setAttribute("id", name);
                
                if (color % 2 == 0) {
                    newDiv.setAttribute("class", "field inactiveOddField");
                    
                }
                else {
                    newDiv.setAttribute("class", "field inactiveEvenField");
                }
                newDiv.setAttribute("ondrop", "drop(event)");
                newDiv.setAttribute("ondragover", "allowDrop(event)");
                newDiv.innerHTML = name;
                boardDiv.appendChild(newDiv);
            }
        }
}

function allowDrop(ev) {
    ev.preventDefault();
}

function placePice(field, pieceName) {

    var srtUrl = "/ChessBoard/Move";
    $.ajax({
        url: srtUrl,
        type: 'POST',
        data: {
            'fieldId': field.id,
            'pieceName': pieceName
        },
        success: function (response) {

            for (var i = 0; i < response.length; i++) {
                var a = document.getElementById(response[i]);
                a.classList.add("activeField");
            }
        }
    });
}

function myDrop(ev, pieceName) {

    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");

    var srtUrl = "/ChessBoard/ValidMove";
    $.ajax({
        url: srtUrl,
        type: 'POST',
        data: {
            'fieldId': ev.target.id,
            'pieceName': pieceName
        },
        success: function (response) {
            if (response.allowMove == true) {

                ev.target.appendChild(document.getElementById(data));
                var fieldsDivs = document.getElementsByClassName("field");

                for (var i = 0; i < fieldsDivs.length; i++) {
                    fieldsDivs[i].classList.remove("activeField");
                }

                placePice(ev.target, pieceName);
            }
            else {
                alert("Wrong move!");
            }
        }
    });
}