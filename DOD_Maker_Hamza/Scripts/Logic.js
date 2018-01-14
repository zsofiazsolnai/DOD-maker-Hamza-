var exists = [];
function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function copyDOD(ev) {
    ev.preventDefault();
    var x = document.getElementById("ListBox1").selectedIndex;
    if (exists.includes(x)) {
        alert("You already added this template!");
    }
    else {
        var nodeCopy = document.getElementById(x).cloneNode(true);
        nodeCopy.id = x;

        if (parseDODforOptions(String(nodeCopy.textContent))) {
            rad(x, nodeCopy);
        }
        else {
            document.getElementById("ListBox2").appendChild(nodeCopy);
        }

    }
}

function removeDOD(ev) {
    ev.preventDefault();
    var x = document.getElementById("ListBox2");
    x.remove(x.selectedIndex);
    exists.pop(x);
}

function saveOnClick() {
    var x = document.getElementById("ListBox2");
    var pId = document.getElementById("projDropDown").value;
    //var pId = proj.options[proj.selectedIndex].value;
    //if (pId == -1) {
    //    alert("Please select Project");
    //    return;
    //}
    var arr = [];
    var i;
    if (x.length == 0) {
        alert("No DOD is available to save");
        return;
    }
    else {
        for (i = 0; i < x.length; i++) {
            arr.push(x.options[i].value);
        }
        $.ajax({
            type: "POST",
            traditional: true,
            url: "../Home/saveMyDODs",
            data: { dodList: arr, projId: pId }
        });
        x.innerHTML = "";
        alert("DOD's successfully saved");
    }
}

function exportToPDF() {
    var lMargin = 10; //left margin in mm
    var rMargin = 10; //right margin in mm
    var pdfInMM = 300;  // width of A4 in mm
    var doc = new jsPDF("p", "mm", "a4");
    var options = document.getElementById("ListBox2").options;

    if (options.length == 0) {
        alert("No DOD is available to export");
    }
    else {
        for (var i = 0; i < options.length; i++) {
            text = text.concat((i + 1) + ". " + options[i].value + "\n\n");
        }
        doc.setFontSize(20);
        doc.text(lMargin, 20, 'Definition of Done');

        var text = "";

        var lines = doc.splitTextToSize(text, (pdfInMM - lMargin - rMargin));
        doc.setFontSize(14);
        doc.text(lMargin, 30, lines);

        doc.save('DOD.pdf');
    }
}

function rad(x, nodeCopy) {
    var modal = document.getElementById('myModalM');
    var span = document.getElementById('rad');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        for (var i = 0; i < dodText.length; i++) {
            if (dodText[i].startsWith("#") || dodText[i].startsWith("$")) {
                DODTEXT = DODTEXT.concat(getValuesfromOptions(dodText[i][1]));
            }
            else if (dodText[i].startsWith("@")) {
                var value = document.getElementById("param" + dodText[i][1]).value;
                DODTEXT = DODTEXT.concat(value);
            }
            else {
                DODTEXT = DODTEXT.concat(dodText[i]);
            }
        }
        nodeCopy.textContent = DODTEXT;
        document.getElementById("ListBox2").appendChild(nodeCopy);
        exists.push(x);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function getValuesfromOptions(id) {
    var selectedOpt = "";
    var radioButtons = document.getElementsByName("option" + id);
    for (var x = 0; x < radioButtons.length; x++) {
        if (radioButtons[x].checked) {
            if (radioButtons[x].value != ""){
                selectedOpt = radioButtons[x].value;
            }
            else {
                var name = "inputopt" + id + "" + x + "";
                var optWithParamValue = document.getElementById("optWithParamValue" + id + "" + x).value;
                var userInput = document.getElementById(name).value
                selectedOpt = optWithParamValue.replace("*", userInput);
            }
        }
    }

    return selectedOpt;
}

var DODTEXT = "";
var dodText = [""];

function parseDODforOptions(dod) {
    //var dod = "All (<subtasks>|<TODO items>) are done by (dev|QA) to test <parameter> done";
    var newDod = "";
    DODTEXT = "";
    dodText = [""];
    var options = [];
    var option = "";
    var optionStart = false;
    var paramStart = false;
    var chkBoxStart = false;
    var paramValue = "";
    var chkBoxValue = "";
    var optionhtml = "<div>";
    var inputNumber = 0;
    var inputNeeded = false;
    for (var i = 0; i < dod.length; i++) {
        if (dod[i] == '(') {
            optionStart = true;
            inputNeeded = true;
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
            optionhtml = displayingOptions(optionhtml, options, inputNumber, "radio");
            options = [];
            inputNumber++;
        }
        else if (optionStart) {
            option = option.concat(dod[i]);
        }
        else if (dod[i] == '[') {
            chkBoxStart = true;
            inputNeeded = true;
            if (newDod != "") {
                dodText.push(newDod);
                newDod = "";
            }
        }
        else if (dod[i] == ']') {
            chkBoxStart = false
            dodText.push("$" + inputNumber);
            options = [chkBoxValue];
            optionhtml = displayingOptions(optionhtml, options, inputNumber, "checkbox");
            inputNumber++;
            chkBoxValue = "";
        }
        else if (chkBoxStart) {
            chkBoxValue = chkBoxValue.concat(dod[i]);
        }
        else if (dod[i] == '<') {
            paramStart = true;
            inputNeeded = true;
            if (newDod != "") {
                dodText.push(newDod);
                newDod = "";
            }
        }
        else if (dod[i] == '>') {
            paramStart = false;
            dodText.push("@" + inputNumber);
            optionhtml = displayingParameter(inputNumber, paramValue, optionhtml);
            inputNumber++;
            paramValue = "";
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
    optionhtml.concat('</div>');
    //DODTEXT = dodText.join("*");
    //document.getElementById("optionText").innerHTML = optionhtml;
    if (inputNeeded) { 
        var span = $("<span />");
        span.html(optionhtml);
        $("#OptionsArea").html("");
        $("#OptionsArea").append(span);
    }
    return inputNeeded
}


function displayingOptions(optionhtml, options, inputNumber, inputType) {
    var inputTextId = 0;
    for (var i = 0; i < options.length; i++) {
        var inputStart = false;
        var input = "";
        var fixedText = "";
        var optionwithParam = ""
        if (options[i].includes('<')) {
            var paramInOpt = options[i];
            optionhtml = optionhtml.concat('<br /> <input type="' + inputType +'" name =option' + inputNumber + ' value=""/>');
            for (var j = 0; j < paramInOpt.length; j++) {
                if (paramInOpt[j] == '<') {
                    inputStart = true;
                    if (fixedText != "") {
                        optionhtml = optionhtml.concat(fixedText);
                        optionwithParam = optionwithParam.concat(fixedText + " *");
                        fixedText = "";
                    }
                }
                else if (paramInOpt[j] == '>') {
                    inputStart = false;
                }
                else if (inputStart) {
                    input = input.concat(paramInOpt[j]);
                }
                else {
                    fixedText = fixedText.concat(paramInOpt[j])
                }
            }
            optionwithParam = optionwithParam.concat(fixedText);
            var name = "inputopt" + inputNumber + "" + inputTextId + "";
            optionhtml = optionhtml.concat('<input id="' + name + '" type="text" placeholder="' + input + '"/>' + fixedText + '<br />');
            optionhtml = optionhtml.concat('<input type="hidden" id="optWithParamValue' + inputNumber + "" + inputTextId + '" value="' + optionwithParam + '"/>');
        }
        else {
            optionhtml = optionhtml.concat('<br /> <input type="' + inputType +'" name =option' + inputNumber + ' value="' + options[i] + '"/>' + options[i] + '<br />');
        }
        inputTextId = inputTextId + 1;
    }
    
    return optionhtml;
}

function displayingParameter(inputNumber, paramValue, paramHtml) {
    paramHtml = paramHtml.concat('<br /> <input id="param' + inputNumber + '" type="text" placeholder="' + paramValue + '"/><br />');
    return paramHtml;
}
