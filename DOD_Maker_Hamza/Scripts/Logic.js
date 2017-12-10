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

function param(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalP');
    var span = document.getElementById('par');
    modal.style.display = "block";
    span.onclick = function() {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
        
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function rad(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalM');
    var span = document.getElementById('rad');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function opt(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalO');
    var span = document.getElementById('opt');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function radparam(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalMP');
    var span = document.getElementById('radp');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function radparamopt(ev, x, nodeCopy) {
    var modal = document.getElementById('Complicated');
    var span = document.getElementById('comp');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function radparamrad(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalRPO');
    var span = document.getElementById('rpo');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function radoptopt(ev, x, nodeCopy) {
    var modal = document.getElementById('myModalRPP');
    var span = document.getElementById('rpp');
    modal.style.display = "block";
    span.onclick = function () {
        modal.style.display = "none";
        exists.push(x);
        ev.target.appendChild(nodeCopy);
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

function decide(ev, x, nodeCopy) {
    var name = String(nodeCopy.textContent);
    if (name.includes('<')) {
        param(ev, x, nodeCopy);  
    }
    else
        if (name.includes('(')) {
            rad(ev, x, nodeCopy);
        }
        else
            if (name.includes('[')) {
                opt(ev, x, nodeCopy);
            }
            else
                if (name.includes('*')) {
                    radparam(ev, x, nodeCopy);
                }
                else
                    if (name.includes('đ')) {
                        radparamopt(ev, x, nodeCopy);
                    }
                    else
                        if (name.includes('ä')) {
                            radparamrad(ev, x, nodeCopy);
                        }
                        else
                            if (name.includes('ł')) {
                                radoptopt(ev, x, nodeCopy);
                            }
                            else {
                                exists.push(x);
                                ev.target.appendChild(nodeCopy);
                            }
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

function copyOnClick() {
    var x = document.getElementById("ListBox1").selectedIndex;
    var nodeCopy = document.getElementById(x).cloneNode(true);
    nodeCopy.id = x;
    document.getElementById("ListBox2").appendChild(nodeCopy);
}

function removeOnClick() {
    var x = document.getElementById("ListBox2");
    x.remove(x.selectedIndex);
}
