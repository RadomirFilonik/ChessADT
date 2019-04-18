
function createDivChessBoard() {
    var mainBody = document.getElementsByTagName("body")[0];
    mainBody.appendChild(document.createElement("div")).setAttribute("id", "boardDiv");
    var boardDiv = document.getElementById("boardDiv");
    boardDiv.setAttribute("style", "width: 820px; height: 820px; float:left; padding: 10px; text-align: center; background-color: gray");

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