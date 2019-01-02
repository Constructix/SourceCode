// JavaScript source code
// check to make sure storage is defined in the browser

if (typeof (Storage) !== "undefined") {
    // local storage is enabled.
    document.getElementById("storageEnabled").innerText = "Storage is Enabled.";
    document.getElementById("storageEnabled").style.backgroundColor = "#00b33c";

    // Now check for lastName in storage.
    // if not found, Update to indicate value is not found and make it set to red.
    let lastName = localStorage.getItem("lastName");
    if (lastName !== null) {
        document.getElementById("lastName").innerText = "LastName: " + lastName;
        document.getElementById("lastName").style.backgroundColor =  "#00b33c";
    }
    else {
        document.getElementById("lastName").innerText = "No lastName has been set.";
        document.getElementById("lastName").style.backgroundColor = "#ff1a1a";
        // setting the lastName
        localStorage.setItem("lastName", "Jones");
    }  

    var person = { firstName: "Richard", lastName: "Jones", email: "blinkyBill@gmail.com" };

    document.getElementById("personDetails").innerHTML = person.firstName + " " + person.lastName + " " + person.email;
}
else {
    // no storage enabled.
    document.getElementById("storageEnabled").innerText = "No Storage is Enabled.";
    document.getElementById("storageEnabled").style.backgroundColor = "#ff1a1a";
}

function GetPersonDetails() {

}