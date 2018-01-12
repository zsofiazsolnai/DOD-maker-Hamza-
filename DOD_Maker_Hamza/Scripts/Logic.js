var exists = [];
function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function dropDelete(ev) {
    ev.preventDefault();
    var x = ev.dataTransfer.getData("text");
    var index = exists.indexOf(x);
    exists.splice(index, 1);
    var el = document.getElementById(x);
    el.parentNode.removeChild(el);
}

function rad(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalM');
    var span = document.getElementById('rad');
    var selectedOpt = "";
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        for (var i = 0; i < dodText.length; i++) {
            if (dodText[i].startsWith("#")) {
                DODTEXT = DODTEXT.concat(getValuesfromOptions(dodText[i][1]));
            }
            else if (dodText[i].startsWith("@")) {
                var value = document.getElementById("param3").value;
                DODTEXT = DODTEXT.concat(value);
            }
            else {
                DODTEXT = DODTEXT.concat(dodText[i]);
            }
            exists.push(x);

        }
        nodeCopy.textContent = DODTEXT;
        document.getElementById("ListBox2").appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function getValuesfromOptions(id) {
    var radioButtons = document.getElementsByName("opt" + id);
    for (var x = 0; x < radioButtons.length; x++) {
        if (radioButtons[x].checked) {
            selectedOpt = radioButtons[x].value;
        }
    }
    var rbWithInput = document.getElementsByName("optWithParam" + id);
    for (var x = 0; x < rbWithInput.length; x++) {
        if (rbWithInput[x].checked) {
            var name = "inputopt" + x + "";
            selectedOpt = document.getElementById(name).value;// rbWithInput[x].value;
        }
    }

    return selectedOpt;
}

function decide(ev, x, nodeCopy) {
    var name = String(nodeCopy.textContent);
    rad(ev, x, nodeCopy);
}

function dropCopy(ev) {
    ev.preventDefault();
    var x = ev.dataTransfer.getData("text");
    if (exists.includes(x)) {
        alert("You already added this template!");
    }
    else {
        var nodeCopy = document.getElementById(x).cloneNode(true);
        nodeCopy.id = "newId";
        decide(ev, x, nodeCopy);
    } 
}

function copyOnClick(ev) {
    parseDODforOptions();
    var x = document.getElementById("ListBox1").selectedIndex;
    if (exists.includes(x)) {
        alert("You already added this template!");
    }
    else {
        var nodeCopy = document.getElementById(x).cloneNode(true);
        nodeCopy.id = x;
        //document.getElementById("ListBox2").appendChild(nodeCopy);
        decide(ev, x, nodeCopy);
    }
}

function removeOnClick() {
    var x = document.getElementById("ListBox2");
    x.remove(x.selectedIndex);
}

function saveOnClick() {
    var x = document.getElementById("ListBox2");
    var arr = [];
    //var txt = "All options: ";
    var i;
    for (i = 0; i < x.length; i++) {
        //txt = txt + "\n" + x.options[i].value;
        arr.push(x.options[i].value);
    }
    $.ajax({
        type: "POST",
        traditional: true,
        url: "../Home/saveMyDODs",
        data: { dodList: arr, name: 'hamza' }
    });
    x.innerHTML = "";
    alert("DOD's successfully saved");

}

var DODTEXT = "";
var dodText = [""];

function parseDODforOptions() {
    var dod = "All (<subtasks>|<TODO items>) are done by (dev|QA) to test <parameter> done";
    var newDod = "";
    var options = [];
    var option = "";
    var optionStart = false;
    var paramStart = false;
    var paramValue = "";
    var optionhtml = "<div>";
    var inputNumber = 1;
    for (var i = 0; i < dod.length; i++) {
        if (dod[i] == '(') {
            optionStart = true;
            if (newDod != "") { 
                dodText.push(newDod);
                newDod = "";
            }
        }
        else if (dod[i] == '|') {
            options.push(option);
            option = "";
        }
        else if (dod[i] == ')') {
            options.push(option);
            option = "";
            optionStart = false;
            dodText.push("#" + inputNumber);
            optionhtml = displayingOptions(optionhtml, options, inputNumber);
            options = [];
            inputNumber++;
        }
        else if (optionStart) {
            option = option.concat(dod[i]);
        }
        else if (dod[i] == '<') {
            paramStart = true;
            if (newDod != "") {
                dodText.push(newDod);
                newDod = "";
            }
        }
        else if (dod[i] == '>') {
            paramStart = false;
            dodText.push("@" + inputNumber);
            optionhtml = displayingParameter(inputNumber, paramValue, optionhtml);
        }
        else if (paramStart) {
            paramValue = paramValue.concat(dod[i]);
        }
        else {
            optionhtml = optionhtml.concat(dod[i]);
            newDod = newDod.concat(dod[i]);
        }
    }
    dodText.push(newDod);
    optionhtml.concat("</div>");
    //DODTEXT = dodText.join("*");
    //document.getElementById("optionText").innerHTML = optionhtml;

    var span = $("<span />");
    span.html(optionhtml);
    $("#OptionsArea").append(span);
}

function displayingOptions(optionhtml, options, inputNumber) {
    var inputTextId = 0;
    for (var i = 0; i < options.length; i++) {
        var inputStart = false;
        var input = "";
        if (options[i].includes('<')) {
            var paramInOpt = options[i];
            for (var j = 0; j < paramInOpt.length; j++) {
                if (paramInOpt[j] == '<') {
                    inputStart = true;
                }
                else if (paramInOpt[j] == '>') {
                    inputStart = false;
                }
                else if (inputStart) {
                    input = input.concat(paramInOpt[j]);
                }
            }
            var name = "inputopt" + inputTextId + "";
            optionhtml = optionhtml.concat('<br /> <input type="radio" name="optWithParam' + inputNumber + '" value="' + input + '"/><input id="' + name + '" type="text" placeholder="' + input + '"/><br />');
            inputTextId = inputTextId + 1;
        }
        else {
            optionhtml = optionhtml.concat('<br /> <input type="radio" name="opt' + inputNumber + '" value="' + options[i] + '"/>' + options[i] + '<br />');
        }

    }
    
    return optionhtml;
}

function displayingParameter(inputNumber, paramValue, paramHtml) {
    paramHtml = paramHtml.concat('<br /> <input id="param' + inputNumber + '" type="text" placeholder="' + paramValue + '"/><br />');
    return paramHtml;
}
