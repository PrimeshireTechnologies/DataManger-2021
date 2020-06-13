
let globalID;

function telnokeypress(evt) {
    if (evt.keyCode >= 60 && evt.keyCode !== 13) {
        alert('invalid, because this is a Phone No. and a numeric data type please re-type');
    }
    else {
        keyCode = evt.keyCode;
    }
}

function wfnamekeyup(keyCode) {                                 
    if (keyCode === 40 || keyCode===13) {
        document.getElementById("wlname").focus();
    }
}
function wlnamekeyup(keyCode) {                 
    if (keyCode === 38) {
        document.getElementById("wfname").focus();
    }
    if (keyCode === 40 || keyCode===13) {
        document.getElementById("keyid").focus();
    }
}

function keyidkeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("wlname").focus();
    }
    if (keyCode === 40 || keyCode === 13) {
        document.getElementById("dob").focus();
    }
}

function dobkeyup (keyCode) {
    if (keyCode === 38) {
        document.getElementById("keyid").focus();
    }
    if (keyCode === 40 || keyCode === 13) {
        document.getElementById("gender").focus();
    }
}

function genderkeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("dob").focus();
    }
    if (keyCode === 40) {
        document.getElementById("pfname").focus();
    }
}

function genderchange() {
        document.getElementById("pfname").focus();
}

function pfnamekeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("gender").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("plname").focus();
    }
}

function plnamekeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("pfname").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("relationship").focus();
    }
}

function relationchange() {
        document.getElementById("ptitle").focus();
}

function relationkeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("plname").focus();
    }
    if (keyCode === 40) {
        document.getElementById("ptitle").focus();
    }
}

function ptitlekeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("relationship").focus();
    }
    if (keyCode === 40) {
        document.getElementById("phnumber").focus();
    }
}
function ptitlechange() {
        document.getElementById("phnumber").focus();
}

function phnumberkeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("ptitle").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("email").focus();
    }
}

function emailkeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("phnumber").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("address").focus();
    }
}

function addresskeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("email").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("city").focus();
    }
}

function citykeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("address").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("state").focus();
    }
}

function statekeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("city").focus();
    }
    if (keyCode === 40 || keyCode === 13) {
        document.getElementById('zipcode')['value'] = '';
        document.getElementById("zipcode").focus();
    }
}

function zipcodekeyup(keyCode) {
    if (keyCode === 38) {
        document.getElementById("state").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("enrollmenttype").focus();
    }
}

//////////////////////////////
function studenttype(keyCode) {
    if (keyCode === 38) {
        document.getElementById('zipcode')['value'] = '';
        document.getElementById("zipcode").focus();
    }
    if (keyCode === 40 || keyCode === 13) {
        document.getElementById("enrollmenttype").focus();
    }
}

function studenttypechange() {
    document.getElementById("enrollmenttype").focus();
}
//////////////////////////////

function enrolltype(keyCode) {
    if (keyCode === 38) {
        document.getElementById('studenttype')['value'] = '';
        document.getElementById("studenttype").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("enrollmentstatus").focus();
    }
}

function enrolltypechange() {
        document.getElementById("enrollmentstatus").focus();
}

function enrollstat(keyCode) {
    if (keyCode === 38) {
        document.getElementById("enrollmenttype").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("enrollmentrate").focus();
    }
}
function enrollstatchange() {
        document.getElementById("enrollmentrate").focus();
}

function enrollrate(keyCode) {
    if (keyCode === 38) {
        document.getElementById("enrollmentstatus").focus();
    }
    if (keyCode === 40||keyCode === 13) {
        document.getElementById("register").focus();
    }
}

function enrollratekeypress(evt) {
    if (evt.keyCode >= 60 && evt.keyCode !== 13) {
        alert('invalid, because this is a Phone No. and a numeric data type please re-type');
    }
    else {
        keyCode = evt.keyCode;
    }
}

function Register() {    
   if (document.getElementById('keyid')['value'] !== "") {

       globalID = localStorage.getItem("vGlobalid");       

       let x = 0;
       var datavalue;
       let globalfile = localStorage.getItem("globalfile");
       if (globalfile === "Edited") {
           alert("This person os already exist in the Database");
           datavalue = '';
           localStorage.setItem("globalfile", "");
           document.getElementById('wfname')['value'] = '';
           document.getElementById('wlname')['value'] = '';
           document.getElementById('dob')['value'] = '';
           document.getElementById('gender')['value'] = '';
           document.getElementById('keyid')['value'] = '';
           document.getElementById('pfname')['value'] = '';
           document.getElementById('plname')['value'] = '';
           document.getElementById('relationship')['value'] = '';
           document.getElementById('ptitle')['value'] = '';
           document.getElementById('phnumber')['value'] = '';
           document.getElementById('email')['value'] = '';
           document.getElementById('address')['value'] = '';
           document.getElementById('city')['value'] = '';
           document.getElementById('state')['value'] = '';
           document.getElementById('zipcode')['value'] = '';
           document.getElementById('studenttype')['value'] = '';
           document.getElementById('enrollmenttype')['value'] = '';
           document.getElementById('enrollmentstatus')['value'] = '';
           document.getElementById('enrollmentrate')['value'] = '00.00';
       } else {        
           datavalue = {
               'FirstName': document.getElementById('wfname')['value'],
               'LastName': document.getElementById('wlname')['value'],
               'DateOfBirth': document.getElementById('dob')['value'],
               'Gender': document.getElementById('gender')['value'],
               'KeyId': document.getElementById('keyid')['value'],
               'ParentFirstName': document.getElementById('pfname')['value'],
               'ParentLastName': document.getElementById('plname')['value'],
               'Relationship': document.getElementById('relationship')['value'],
               'Title': document.getElementById('ptitle')['value'],
               'PhoneNumber': document.getElementById('phnumber')['value'],
               'EmailAddress': document.getElementById('email')['value'],
               'Address': document.getElementById('address')['value'],
               'City': document.getElementById('city')['value'],
               'State': document.getElementById('state')['value'],
               'ZipCode': document.getElementById('zipcode')['value'],
               'StudentType': document.getElementById('studenttype')['value'],
               'EnrollmentType': document.getElementById('enrollmenttype')['value'],
               'EnrollmentStatus': document.getElementById('enrollmentstatus')['value'],
               'EnrollmentRate': document.getElementById('enrollmentrate')['value'],
               'Globalid': globalID
           };
       }                          
            $.ajax({
               url: '/Home/Save', type: 'POST', data: JSON.stringify(datavalue), dataType: 'json', contentType: "application/json", success: function (response) {                                                           
               console.log(response);
                   alert("Successfully Registered");
                   document.getElementById('wfname')['value'] = '';
                   document.getElementById('wlname')['value'] = '';
                   document.getElementById('dob')['value'] = '';
                   document.getElementById('gender')['value'] = '';
                   document.getElementById('keyid')['value'] = '';
                   document.getElementById('pfname')['value'] = '';
                   document.getElementById('plname')['value'] = '';
                   document.getElementById('relationship')['value'] = '';
                   document.getElementById('ptitle')['value'] = '';
                   document.getElementById('phnumber')['value'] = '';
                   document.getElementById('email')['value'] = '';
                   document.getElementById('address')['value'] = '';
                   document.getElementById('city')['value'] = '';
                   document.getElementById('state')['value'] = '';
                   document.getElementById('zipcode')['value'] = '';
                   document.getElementById('studenttype')['value'] = '';
                   document.getElementById('enrollmenttype')['value'] = '';
                   document.getElementById('enrollmentstatus')['value'] = '';
                   document.getElementById('enrollmentrate')['value'] = '00.00';
                   ////////////////////////////////////////////////////////
               }, error: function (response) {
                  //alert('Registration failed');
               }
            });
   } else {
       alert("You should fill-up all the feilds first");
       document.getElementById('wfname').focus();
   }
}
