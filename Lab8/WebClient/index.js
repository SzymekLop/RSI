
const BASE_URL = "http://192.168.43.18:10000/Service1.svc";
const JSON_ENDPOINT = BASE_URL + "/json"
const XML_ENDPOINT = BASE_URL


document.getElementById("toggle-json-btn").addEventListener("click", toggleJsonSection);
document.getElementById("toggle-both-btn").addEventListener("click", toggleBothSections);
document.getElementById("toggle-xml-btn").addEventListener("click", toggleXmlSection);

document.getElementById('json-get-author-btn').addEventListener('click', getJsonAuthor);
document.getElementById('xml-get-author-btn').addEventListener('click', getXMLAuthor);


document.getElementById('json-get-people-btn').addEventListener('click', getJsonPeople);
document.getElementById('json-get-person-btn').addEventListener('click', getJsonPerson);
document.getElementById('json-add-person-btn').addEventListener('click', postJsonPerson);
document.getElementById('json-update-person-btn').addEventListener('click', putJsonPerson);
document.getElementById('json-delete-person-btn').addEventListener('click', deleteJsonPerson);
document.getElementById('json-get-count-btn').addEventListener('click', getAllCountJson);
document.getElementById('json-get-filter-age-btn').addEventListener('click', getFilteredByAgeJson);
document.getElementById('json-get-filter-insurance-btn').addEventListener('click', getFilteredByInsurenceJson);
document.getElementById('json-get-filter-insurance-class-btn').addEventListener('click', getFilteredByInsuranceClassJson);

document.getElementById('xml-get-people-btn').addEventListener('click', getXmlPeople);
document.getElementById('xml-get-person-btn').addEventListener('click', getXmlPerson);
document.getElementById('xml-add-person-btn').addEventListener('click', postXmlPerson);
document.getElementById('xml-update-person-btn').addEventListener('click', putXmlPerson);
document.getElementById('xml-delete-person-btn').addEventListener('click', deleteXmlPerson);
document.getElementById('xml-get-count-btn').addEventListener('click', getAllCountXml);
document.getElementById('xml-get-filter-age-btn').addEventListener('click', getFilteredByAgeXml);
document.getElementById('xml-get-filter-insurance-btn').addEventListener('click', getFilteredByInsurenceXml);
document.getElementById('xml-get-filter-insurance-class-btn').addEventListener('click', getFilteredByInsuranceClassXml);


function toggleJsonSection() {
    document.getElementById("json-section").classList.remove("hidden");
    document.getElementById("xml-section").classList.add("hidden");
}

function toggleBothSections() {
    document.getElementById("json-section").classList.remove("hidden");
    document.getElementById("xml-section").classList.remove("hidden");
}

function toggleXmlSection() {
    document.getElementById("xml-section").classList.remove("hidden");
    document.getElementById("json-section").classList.add("hidden");
}


function getJsonAuthor() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            console.info(this.response)
            document.getElementById('json-author-container').innerHTML = this.responseText;
        } else if (this.readyState === 4) {
            alert("Data query/response error");
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people/authors', true);
    xhr.send();
}


function getXMLAuthor() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        
        if (this.readyState === 4 && this.status === 200) {
            console.info(this.response)
            document.getElementById('json-author-container').innerHTML = this.responseText;
        } else if (this.readyState === 4) {
            alert("Data query/response error");
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people/authors', true);
    xhr.send();
}


function getJsonPeople() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-people-container').innerHTML = this.responseText;
        } else if (this.readyState === 4) {
            alert("Data query/response error");
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people', true);
    xhr.send();
}


function getJsonPerson() {
    var xhr = new XMLHttpRequest();
    var id = document.getElementById('json-person-id-input').value;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-person-container').innerHTML = this.responseText;
        } else if (this.readyState === 4) {
            document.getElementById('json-person-container').innerHTML = "An error occured, data can't be loaded";
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people/' + id, true);
    xhr.send();
}



function postJsonPerson() {
    var xhr = new XMLHttpRequest();
    var name = document.getElementById('json-add-name-input').value;
    var age = document.getElementById('json-add-age-input').value;
    var email = document.getElementById('json-add-email-input').value;
    var insurance = document.getElementById('json-add-insurance-input').checked;
    var insuranceClass = document.getElementById('json-add-insurance-class-input').value || "0";
    var data = {
        Name: name,
        Age: age,
        Email: email,
        IsInsured: insurance,
        IncuranceClass: insuranceClass
    };


    xhr.open("POST", JSON_ENDPOINT + '/people', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(data));

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-add-person-container').innerHTML = "Person added successfully!";
        } else if (this.readyState === 4 && this.status === 409) {
            document.getElementById('json-add-person-container').innerHTML = "FAILURE: Person with this email alredy exists!";
        
    }
        else if (this.readyState === 4) {
            document.getElementById('json-add-person-container').innerHTML = "An error occurred while adding the person.";
        }
    };
}


function putJsonPerson() {
    var xhr = new XMLHttpRequest();
    var id = document.getElementById('json-update-id-input').value;
    var name = document.getElementById('json-update-name-input').value;
    var age = document.getElementById('json-update-age-input').value;
    var email = document.getElementById('json-update-email-input').value;
    var insurance = document.getElementById('json-update-insurance-input').checked;
    var insuranceClass = document.getElementById('json-update-insurance-class-input').value || "0";
    var data = {
        Id: id,
        Name: name,
        Age: age,
        Email: email,
        IsInsured: insurance,
        IncuranceClass: insuranceClass
    };
    xhr.open("PUT", JSON_ENDPOINT + '/people/' + id, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(data));

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-update-person-container').innerHTML = "Person updated successfully!";
        }  else if (this.readyState === 4 && this.status === 409) {
            document.getElementById('json-update-person-container').innerHTML = "FAILURE: Person with this email alredy exists!";
        } else if (this.readyState === 4 && this.status === 404) {
            document.getElementById('json-update-person-container').innerHTML = "FAILURE: Cant find person with this ID!";
        }else if (this.readyState === 4) {
            document.getElementById('json-update-person-container').innerHTML = "An error occurred while updating the person.";
        }
    };
}


function deleteJsonPerson() {
    var xhr = new XMLHttpRequest();
    var id = document.getElementById('json-delete-id-input').value;
    xhr.open("DELETE", JSON_ENDPOINT + '/people/' + id, true);
    xhr.send();

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-delete-person-container').innerHTML = "Person deleted successfully!";
        } else if (this.readyState === 4) {
            document.getElementById('json-delete-person-container').innerHTML = "An error occurred while deleting the person.";
        }
    };
}



function getAllCountJson() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-count-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people/count', true);
    xhr.send();

}



function getFilteredByAgeJson() {
    var xhr = new XMLHttpRequest();
    var age = document.getElementById('json-filter-age-input').value;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-filter-age-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people/age/' + age, true);
    xhr.send();
}



function getFilteredByInsurenceJson() {
    var xhr = new XMLHttpRequest();
    var isInsured = document.getElementById('json-filter-insurance-input').checked;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-filter-insurance-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people/insurance/' + isInsured, true);
    xhr.send();
}



function getFilteredByInsuranceClassJson() {
    var xhr = new XMLHttpRequest();
    var insuranceClass = document.getElementById('json-filter-insurance-class-input').value;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('json-filter-insurance-class-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", JSON_ENDPOINT + '/people/insuranceClass/' + insuranceClass, true);
    xhr.send();
}





// Using XML Endpoint
function getXmlPeople() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-people-container').innerHTML = this.responseText;
        } else if (this.readyState === 4) {
            alert("Data query/response error");
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people', true);
    xhr.send();
}



function getXmlPerson() {
    var xhr = new XMLHttpRequest();
    var id = document.getElementById('xml-person-id-input').value;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-person-container').innerHTML = this.responseText;
        } else if (this.readyState === 4) {
            alert("Data query/response error");
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people/' + id, true);
    xhr.send();
}

document.getElementById('xml-get-person-btn').addEventListener('click', getXmlPerson);

function postXmlPerson() {
    var xhr = new XMLHttpRequest();
    var name = document.getElementById('xml-add-name-input').value;
    var age = document.getElementById('xml-add-age-input').value;
    var email = document.getElementById('xml-add-email-input').value;
    var insurance = document.getElementById('xml-add-insurance-input').checked;
    var insuranceClass = document.getElementById('xml-add-insurance-class-input').value || "0";
    var data = {
        Id: 1,
        Name: name,
        Age: age,
        Email: email,
        IsInsured: insurance,
        IncuranceClass: insuranceClass
    };
    xhr.open("POST", XML_ENDPOINT + '/people', true);
    xhr.setRequestHeader('Content-Type', 'application/xml');
    
    xhr.send(createXmlData(data));

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-add-person-container').innerHTML = "Person added successfully!";
        } else if (this.readyState === 4 && this.status === 409) {
            document.getElementById('xml-add-person-container').innerHTML = "FAILURE: Person with this email alredy exists!";
        }else if (this.readyState === 4) {
            document.getElementById('xml-add-person-container').innerHTML = "An error occurred while adding the person.";
        }
    };
}



function putXmlPerson() {
    var xhr = new XMLHttpRequest();
    var id = document.getElementById('xml-update-id-input').value;
    var name = document.getElementById('xml-update-name-input').value;
    var age = document.getElementById('xml-update-age-input').value;
    var email = document.getElementById('xml-update-email-input').value;
    var insurance = document.getElementById('xml-update-insurance-input').checked;
    var insuranceClass = document.getElementById('xml-update-insurance-class-input').value || "0";
    var data = {
        Id: id,
        Name: name,
        Age: age,
        Email: email,
        IsInsured: insurance,
        IncuranceClass: insuranceClass
    };
    xhr.open("PUT", XML_ENDPOINT + '/people/' + id, true);
    xhr.setRequestHeader('Content-Type', 'application/xml');
    xhr.send(createXmlData(data));
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-update-person-container').innerHTML = "Person updated successfully!";
        } else if (this.readyState === 4 && this.status === 409) {
            document.getElementById('xml-update-person-container').innerHTML = "FAILURE: Person with this email alredy exists!";
        } else if (this.readyState === 4 && this.status === 404) {
            document.getElementById('xml-update-person-container').innerHTML = "FAILURE: Cant find person with this ID!";
        }else if (this.readyState === 4) {
            document.getElementById('xml-update-person-container').innerHTML = "An error occurred while updating the person.";
        }
    };
}



function deleteXmlPerson() {
    var xhr = new XMLHttpRequest();
    var id = document.getElementById('xml-delete-id-input').value;
    xhr.open("DELETE", XML_ENDPOINT + '/people/' + id, true);
    xhr.send();

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-delete-person-container').innerHTML = "Person deleted successfully!";
        } else if (this.readyState === 4) {
            document.getElementById('xml-delete-person-container').innerHTML = "An error occurred while deleting the person.";
        }
    };
}




function getAllCountXml() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-count-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people/count', true);
    xhr.send();
}

document.getElementById('xml-get-count-btn').addEventListener('click', getAllCountXml);

function getFilteredByAgeXml() {
    var xhr = new XMLHttpRequest();
    var age = document.getElementById('xml-filter-age-input').value;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-filter-age-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people/age/' + age, true);
    xhr.send();
}



function getFilteredByInsurenceXml() {
    var xhr = new XMLHttpRequest();
    var isInsured = document.getElementById('xml-filter-insurance-input').checked;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-filter-insurance-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people/insurance/' + isInsured, true);
    xhr.send();
}



function getFilteredByInsuranceClassXml() {
    var xhr = new XMLHttpRequest();
    var insuranceClass = document.getElementById('xml-filter-insurance-class-input').value;
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('xml-filter-insurance-class-container').innerHTML = this.responseText;
        }
    }
    xhr.open("GET", XML_ENDPOINT + '/people/insuranceClass/' + insuranceClass, true);
    xhr.send();
}
function addStringAtIndex(originalString, stringToAdd, index) {
    const part1 = originalString.substring(0, index);
    const part2 = originalString.substring(index);

    return part1 + stringToAdd + part2;
}




function createXmlData(data) {
    var xmlDoc = document.implementation.createDocument("", "", null);
    var root = xmlDoc.createElement('Person');
    for (var key in data) {
        var element = xmlDoc.createElement(key);
        var text = xmlDoc.createTextNode(data[key]);
        element.appendChild(text);
        root.appendChild(element);
    }
    xmlDoc.appendChild(root);
    return addStringAtIndex(new XMLSerializer().serializeToString(xmlDoc), ` xmlns="http://schemas.datacontract.org/2004/07/MyWebService" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"`, 7).toString();
}
