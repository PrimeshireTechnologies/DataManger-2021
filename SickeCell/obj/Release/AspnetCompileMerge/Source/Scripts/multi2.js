var myapp = angular.module('app', []);
myapp.controller("viewController", ["$scope", "$http", "$rootScope", "$window", function ($scope, $http, $rootScope, $window) {

    let GlobalFullName;
    let Globalonlineoffline;
    let globalID;
    let globalschoolkey;
    let confirmedmail;
    let globalRole;
    let sPath = window.location.pathname;
    let sPage = sPath.substring(sPath.lastIndexOf('/') + 1);
    let globalusrfname;
    let globalusrlname;
    let vnotes;

    let varname;
    let varfirstname;
    let varlastname;
    let varemail;
    let vrole;
    let lblclient;
    let vempty = 0;
    let scope = $scope;

    let vtextright; 
    let vtextright2;
    let vtextempty;
    let counterright = 0;
    let updatecounter;   
    let devicestat = "";      
    let link3 = "";

    if (sPage === "Register" || sPage === "Register_Staff") {
        document.getElementById("checkboxlist").style.display = "inherit";
    }

    if (sPage.trim() === "Successful" || sPage.trim() === "PleaseConfirm") {
        document.getElementById("my_account").style.visibility = "hidden";
        document.getElementById("my_account2").style.visibility = "hidden";
        document.getElementById("my_account3").style.visibility = "hidden";
        document.getElementById("my_account4").style.visibility = "hidden";
        //document.getElementById("footer").style.marginTop = "70px";
    }

    $scope.mlistshow = false;
    $scope.inputboxshow = false;

    localStorage.setItem("globalfile", "");
    $scope.Edit = function () {

        globalID = localStorage.getItem("vGlobalid");
        listfilter = {
            'Globalid': globalID
        };

        globalRole = localStorage.getItem("variableRole");
        if (globalRole.trim() === "Admin/Super User" || globalRole === "Head Teacher" || globalRole === "Super Admin") {
            var search = $window.document.getElementById('search');
            $scope.mulcheckbox = true;                    

            $scope.search = "";
            $http({ method: "POST", url: "/Search/List", data: JSON.stringify(listfilter), dataType: 'json', contentType: "application/json" }).success(function (response) {
                let objects = [];
                let counter = 0;
                for (var item in response) {
                    objects.push(response[counter]["FirstName"] + '  ' + response[counter]["LastName"]);
                    counter = counter + 1;
                }                
                search.focus();
                $scope.name = objects;

                angular.element("#search").focus();
            });
        } else { alert("You don't have an access in this Edit feature"); }
    };

    /// this is for the keyup and the keypress //

    $scope.clientidkeyup = function () {
        if (event.keyCode === 13 ) {
            document.getElementById('lname').focus();
        }
        if (event.keyCode === 39) {
            document.getElementById('lname').focus();
        }
    };

    $scope.lnamekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('fname').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('clientid').focus();
        }
    };

    $scope.fnamekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('mi').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('lname').focus();
        }
    };

    $scope.mikeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('uniqueid').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('fname').focus();
        }
    };

    $scope.uniqueidkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('dob').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('mi').focus();
        }
    };

    $scope.dobkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('age').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('uniqueid').focus();
        }
    };

    $scope.agekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39) {
            document.getElementById('agegroup').focus();
        }
        if (event.keyCode === 37) {
            document.getElementById('dob').focus();
        }
    };

    $scope.agegroupkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('ageat').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('age').focus();
        }
    };

    $scope.ageatkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('gender').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('agegroup').focus();
        }
    };

    $scope.genderchange = function () {
        document.getElementById('race').focus();
    };
    $scope.genderkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('race').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('ageat').focus();
        }
    };  

    $scope.racechange = function () {
        document.getElementById('ethnicity').focus();
    };
    $scope.racekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('ethnicity').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('gender').focus();
        }
    };    

    $scope.ethnicitychange = function () {
        document.getElementById('eligibility').focus();
    }
    $scope.ethnicitykeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('eligibility').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('race').focus();
        }
    };

    $scope.eligibilitykeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('sssno').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('ethnicity').focus();
        }
    };

    $scope.sssnokeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('countrycode').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('eligibility').focus();
        }
    };

    $scope.countrycodekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('countrycodedes').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('sssno').focus();
        }
    };

    $scope.countrycodedeskeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('cpnumber').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('countrycode').focus();
        }
    };

    $scope.cpnumberkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('sickdiag').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('countrycodedes').focus();
        }
    };

    $scope.sickdiagkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('address').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('cpnumber').focus();
        }
    };

    $scope.address1keyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('address2').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('sickdiag').focus();
        }
    };

    $scope.address2keyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('city').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('address').focus();
        }
    };

    $scope.citykeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('state').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('address2').focus();
        }
    };

    $scope.statekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('zipcode').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('city').focus();
        }
    };

    $scope.zipcodekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hphone').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('state').focus();
        }
    };

    $scope.hphonekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('wphone').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('zipcode').focus();
        }
    };                                        

    $scope.wphonekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('pmppro').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hphone').focus();
        }
    };                                        

    $scope.pmpprokeyup = function () {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('ccucase').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('wphone').focus();
        }
    };

    $scope.ccucasekeyup = function () {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('email').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('pmppro').focus();
        }
    };

    $scope.emailkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('clientresideyes').focus();            
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('ccucase').focus();
        }
    };

    $scope.nameofmotherkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('motheraddress').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('clientresideyes').focus();  
        }
    };

    $scope.motheraddresskeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('mothertel').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('nameofmother').focus();
        }
    };

    $scope.mothertelkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('nameoffather').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('motheraddress').focus();
        }
    };

    $scope.nameoffatherkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('fatheraddress').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('mothertel').focus();
        }
    };

    $scope.fatheraddresskeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('fathertel').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('nameoffather').focus();
        }
    };

    $scope.fathertelkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('nameofguardian').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('fatheraddress').focus();
        }
    };

    $scope.nameofguardiankeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('guardianaddress').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('fathertel').focus();
        }
    };

    $scope.guardianaddresskeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('guardiantel').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('nameofguardian').focus();
        }
    };

    $scope.guardiantelkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('emercont1').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('guardianaddress').focus();
        }
    };

    $scope.emercont1keyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('emercont1homephone').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('guardiantel').focus();
        }
    };

    $scope.emercont1homephonekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('emercont1cellphone').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('emercont1').focus();
        }
    };

    $scope.emercont1cellphonekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('emercont2').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('emercont1homephone').focus();
        }
    };

    $scope.emercont2keyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('emercont2homephone').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('emercont1cellphone').focus();
        }
    };

    $scope.emercont2homephonekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('emercont2cellphone').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('emercont2').focus();
        }
    };

    $scope.emercont2cellphonekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('sicklecellss').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('emercont2homephone').focus();
        }
    };

    $scope.sicklecellspecifykeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hydroxyureaheardyes').focus();
        }        
    };

    $scope.hydroxyureadosagekeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hydroxyureadosageunknown').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hydroxyureapasttakenno').focus();
        }
    };

    $scope.hydroxyureadosageunknownkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hydroxyureacapsulescolor').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hydroxyureadosage').focus();
        }
    };

     $scope.hydroxyureadosageunknownkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hydroxyureacapsulescolor').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hydroxyureadosage').focus();
        }
    };

    $scope.hydroxyureacapsulescolorkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hydroxyureadatelasttaken').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hydroxyureadosageunknown').focus();
        }
    };

    $scope.hydroxyureadatelasttakenkeyuo = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('hydroxyureadatepickedup').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hydroxyureacapsulescolor').focus();
        }
    };

    $scope.hydroxyureadatepickedupkeyup = function (keyCode) {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('save').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('hydroxyureadatelasttaken').focus();
        }
    };

    if (sPage.trim() === "Entry" || sPage.trim() === "entry") {

        document.getElementById("test").style.width = "240px";
        document.getElementById("test").style.marginLeft = "-20px";

        // this is for client reside //
        $scope.clientresyes = function () {
            document.getElementById('clientresideyes').checked = true;
            document.getElementById('clientresideno').checked = false;
            document.getElementById("nameofmother").focus();
        };

        $scope.clientresno = function () {
            document.getElementById('clientresideyes').checked = false;
            document.getElementById('clientresideno').checked = true;
            document.getElementById("nameofmother").focus();
        };


        // this is for sicklecelltype//
        $scope.ss = function () {
            document.getElementById("sicklecellss").checked = true;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.sc = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = true;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;

        };
        $scope.sbthal = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = true;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.sbthal0 = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = true;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.notsure = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellnotsure").checked = true;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.other = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = true;
            document.getElementById("sicklecellspecify").focus();
        };

        // Have you ever heard of Hydroxyurea //
        $scope.hydroxyureaeverheardyes = function () {
            document.getElementById("hydroxyureaheardyes").checked = true;
            document.getElementById("hydroxyureaheardno").checked  = false;
        };

        $scope.hydroxyureaeverheardno = function () {
            document.getElementById("hydroxyureaheardyes").checked = false;
            document.getElementById("hydroxyureaheardno").checked  = true;
        };

        // Have you ever taken Hydroxyurea before //
        $scope.hydroxyureaevertakenyes = function () {
            document.getElementById("hydroxyureatakenyes").checked = true;
            document.getElementById("hydroxyureatakenno").checked   = false;
        };

        $scope.hydroxyureaevertakenno = function () {
            document.getElementById("hydroxyureatakenyes").checked = false;
            document.getElementById("hydroxyureatakenno").checked   = true;
        };

        // Do you currently use Hydroxyurea //
        $scope.hydroxyureacurryes = function () {
            document.getElementById("hydroxyureacurrentlyyes").checked = true;
            document.getElementById("hydroxyureacurrentlyno").checked  = false;
        };

        $scope.hydroxyureacurrno = function () {
            document.getElementById("hydroxyureacurrentlyyes").checked = false;
            document.getElementById("hydroxyureacurrentlyno").checked  = true;
        };

        // If No: Have you taken it in the past //
        $scope.hydroxyureatakenpastyes = function () {
            document.getElementById("hydroxyureapasttakenyes").checked = true;
            document.getElementById("hydroxyureapasttakenno").checked = false;
            document.getElementById("hydroxyureadosage").focus();
        };

        $scope.hydroxyureatakenpastno = function () {
            document.getElementById("hydroxyureapasttakenyes").checked = false;
            document.getElementById("hydroxyureapasttakenno").checked = true;
            document.getElementById("hydroxyureadosage").focus();
        };

    }        

    ////// first load for Registration module//////
    globalID = localStorage.getItem("vGlobalid");
    listfilter = {
        'Globalid': globalID
    };

    $http({ method: "POST", url: "/Search/List", data: JSON.stringify(listfilter), dataType: 'json', contentType: "application/json" }).success(function (response) {
        $scope.mulcheckbox = true;       

        //$scope.mulcheckbox = true;
        let objects = [];
        let counter = 0;
        for (var item in response) {
            objects.push(response[counter]["FirstName"] + '  ' + response[counter]["LastName"]);
            counter = counter + 1;
        }
        $scope.name = objects;
    });

    if (sPage === "Attendance" || sPage.trim() === "Attendance") {
        document.getElementById('scan_child_id')['value'] = "";
        document.getElementById('scan_child_id').focus();
    }

    $scope.Savedata = function () {
        if (document.getElementById('clientid')['value'] !== "") {

            globalID = localStorage.getItem("vGlobalid");

            let x = 0;
            var datavalue;
            let globalfile = localStorage.getItem("globalfile");
            if (globalfile === "Edited") {
                alert("This person os already exist in the Database");
                datavalue = '';
                localStorage.setItem("globalfile", "");
                document.getElementById('clientid')['value'] = '';
                document.getElementById('lname')['value'] = '';
                document.getElementById('fname')['value'] = '';
                document.getElementById('mi')['value'] = '';
                document.getElementById('uniqueid')['value'] = '';
                document.getElementById('dob')['value'] = '';
                document.getElementById('age')['value'] = '';
                document.getElementById('agegroup')['value'] = '';
                document.getElementById('ageat')['value'] = '';
                document.getElementById('gender')['value'] = '';
                document.getElementById('race')['value'] = '';
                document.getElementById('ethnicity')['value'] = '';
                document.getElementById('eligibility')['value'] = '';
                document.getElementById('sssno')['value'] = '';
                document.getElementById('countrycode')['value'] = '';
                document.getElementById('countrycodedes')['value'] = '';
                document.getElementById('cpnumber')['value'] = '';
                document.getElementById('sickdiag')['value'] = '';
                document.getElementById('address')['value'] = '';
                document.getElementById('address2')['value'] = '';
                document.getElementById('city')['value'] = '';
                document.getElementById('state')['value'] = '';
                document.getElementById('zipcode')['value'] = '';
                document.getElementById('hphone')['value'] = '';
                document.getElementById('wphone')['value'] = '';
                document.getElementById('pmppro')['value'] = '';
                document.getElementById('ccucase')['value'] = '';
                document.getElementById('email')['value'] = '';                

                // this is for client reside //
                document.getElementById('clientresideyes').checked = false;
                document.getElementById('clientresideno').checked = false;

                document.getElementById('nameofmother')['value'] = '';
                document.getElementById('motheraddress')['value'] = '';
                document.getElementById('mothertel')['value'] = '';
                document.getElementById('nameoffather')['value'] = '';
                document.getElementById('fatheraddress')['value'] = '';
                document.getElementById('fathertel')['value'] = '';
                document.getElementById('nameofguardian')['value'] = '';
                document.getElementById('guardianaddress')['value'] = '';
                document.getElementById('guardiantel')['value'] = '';
                document.getElementById('emercont1')['value'] = '';
                document.getElementById('emercont1homephone')['value'] = '';
                document.getElementById('emercont1cellphone')['value'] = '';
                document.getElementById('emercont2')['value'] = '';
                document.getElementById('emercont2homephone')['value'] = '';
                document.getElementById('emercont2cellphone')['value'] = '';

                // this is for sicklecelltype//
                document.getElementById("sicklecellss").checked = false;
                document.getElementById("sicklecellsc").checked = false;
                document.getElementById("sicklecellThal").checked = false;
                document.getElementById("sicklecellThal0").checked = false;
                document.getElementById("sicklecellnotsure").checked = false;
                document.getElementById("sicklecellother").checked = false;

                // Have you ever heard of Hydroxyurea //
                document.getElementById("hydroxyureaheardyes").checked = false;
                document.getElementById("hydroxyureaheardno").checked = false;

                // Have you ever taken Hydroxyurea before //
                document.getElementById("hydroxyureatakenyes").checked = false;
                document.getElementById("hydroxyureatakenno").checked = false;

                // Do you currently use Hydroxyurea //
                document.getElementById("hydroxyureacurrentlyyes").checked = false;
                document.getElementById("hydroxyureacurrentlyno").checked = false;

                // If No: Have you taken it in the past //
                document.getElementById("hydroxyureapasttakenyes").checked = false;
                document.getElementById("hydroxyureapasttakenno").checked = false;

                document.getElementById('hydroxyureadosage')['value'] = '';
                document.getElementById('hydroxyureadosageunknown')['value'] = '';
                document.getElementById('hydroxyureacapsulescolor')['value'] = '';
                document.getElementById('hydroxyureadatelasttaken')['value'] = '';
                document.getElementById('hydroxyureadatepickedup')['value'] = '';                                                
                
            } else {
                let clientresideinruralid;
                let sicklecelltypeid;
                let hydroxyureaheardid;
                let hydroxyureatakenid;
                let hydroxyureacurrentlyid;
                let hydroxyureapasttakenid;
                updatecounter = 0;

                // this is for client reside //
                if (document.getElementById('clientresideyes').checked === true) {
                    clientresideinruralid = "yes";
                } else if (document.getElementById('clientresideno').checked === true) {
                    clientresideinruralid = "no";
                } else {
                    clientresideinruralid = "";
                }

                // this is for sicklecelltype desktop//
                if (document.getElementById('sicklecellss').checked === true) {
                    sicklecelltypeid = "SS";
                } else if (document.getElementById("sicklecellsc").checked === true) {
                    sicklecelltypeid = "SC";
                } else if (document.getElementById("sicklecellThal").checked === true) {
                    sicklecelltypeid = "SBThal";
                } else if (document.getElementById("sicklecellThal0").checked === true) {
                    sicklecelltypeid = "SBThal0";
                } else if (document.getElementById("sicklecellnotsure").checked === true) {
                    sicklecelltypeid = "NotSure";
                } else if (document.getElementById("sicklecellother").checked === true) {
                    sicklecelltypeid = "Other";
                } else {
                    sicklecelltypeid = "";
                }
                // this is for sicklecelltype Mobile Phone//
                if (document.getElementById('sicklecellss2').checked === true) {
                    sicklecelltypeid = "SS";
                } else if (document.getElementById("sicklecellsc2").checked === true) {
                    sicklecelltypeid = "SC";
                } else if (document.getElementById("sicklecellThal2").checked === true) {
                    sicklecelltypeid = "SBThal";
                } else if (document.getElementById("sicklecellThal02").checked === true) {
                    sicklecelltypeid = "SBThal0";
                } else if (document.getElementById("sicklecellnotsure2").checked === true) {
                    sicklecelltypeid = "NotSure";
                } else if (document.getElementById("sicklecellother2").checked === true) {
                    sicklecelltypeid = "Other";
                } else {
                    sicklecelltypeid = "";
                }

                // Have you ever heard of Hydroxyurea Desktop//
                if (document.getElementById('hydroxyureaheardyes').checked === true) {
                    hydroxyureaheardid = "yes";
                } else if (document.getElementById('hydroxyureaheardno').checked === true) {
                    hydroxyureaheardid = "no";
                } else {
                    hydroxyureaheardid = "";
                }
                // Have you ever heard of Hydroxyurea Mobile Phone//
                if (document.getElementById('hydroxyureaheardyes2').checked === true) {
                    hydroxyureaheardid = "yes";
                } else if (document.getElementById('hydroxyureaheardno2').checked === true) {
                    hydroxyureaheardid = "no";
                } else {
                    hydroxyureaheardid = "";
                }

                // Have you ever taken Hydroxyurea before Desktop//
                if (document.getElementById('hydroxyureatakenyes').checked === true) {
                    hydroxyureatakenid = "yes";
                } else if (document.getElementById('hydroxyureatakenno').checked === true) {
                    hydroxyureatakenid = "no";
                } else {
                    hydroxyureatakenid = "";
                }
                // Have you ever taken Hydroxyurea before Mobile Phone//
                if (document.getElementById('hydroxyureatakenyes2').checked === true) {
                    hydroxyureatakenid = "yes";
                } else if (document.getElementById('hydroxyureatakenno2').checked === true) {
                    hydroxyureatakenid = "no";
                } else {
                    hydroxyureatakenid = "";
                }

                // Do you currently use Hydroxyurea Desktop 
                if (document.getElementById('hydroxyureacurrentlyyes').checked === true) {
                    hydroxyureacurrentlyid = "yes";
                } else if (document.getElementById('hydroxyureacurrentlyno').checked === true) {
                    hydroxyureacurrentlyid = "no";
                } else {
                    hydroxyureacurrentlyid = "";
                }
                // Do you currently use Hydroxyurea Mobile Phone
                if (document.getElementById('hydroxyureacurrentlyyes2').checked === true) {
                    hydroxyureacurrentlyid = "yes";
                } else if (document.getElementById('hydroxyureacurrentlyno2').checked === true) {
                    hydroxyureacurrentlyid = "no";
                } else {
                    hydroxyureacurrentlyid = "";
                }

                // If No: Have you taken it in the past Desktop//
                if (document.getElementById('hydroxyureapasttakenyes').checked === true) {
                    hydroxyureapasttakenid = "yes";
                } else if (document.getElementById('hydroxyureapasttakenno').checked === true) {
                    hydroxyureapasttakenid = "no";
                } else {
                    hydroxyureapasttakenid = "";
                }
                // If No: Have you taken it in the past Mobile Phone//
                if (document.getElementById('hydroxyureapasttakenyes2').checked === true) {
                    hydroxyureapasttakenid = "yes";
                } else if (document.getElementById('hydroxyureapasttakenno2').checked === true) {
                    hydroxyureapasttakenid = "no";
                } else {
                    hydroxyureapasttakenid = "";
                }

                datavalue = {
                    'ClientID'             : document.getElementById('clientid')['value'],
                    'LastName'             : document.getElementById('lname')['value'],
                    'FirstName'            : document.getElementById('fname')['value'],         
                    'Mi'                   : document.getElementById('mi')['value'],         
                    'UniqueID'             : document.getElementById('uniqueid')['value'],
                    'DOB'                  : document.getElementById('dob')['value'],
                    'Age'                  : document.getElementById('age')['value'],
                    'AgeGroup'             : document.getElementById('agegroup')['value'],
                    'Ageat'                : document.getElementById('ageat')['value'],
                    'Gender'               : document.getElementById('gender')['value'],
                    'Race'                 : document.getElementById('race')['value'],                                                                                                          
                    'Ethnicity'            : document.getElementById('ethnicity')['value'],
                    'Eligibility'          : document.getElementById('eligibility')['value'],
                    'SSSno'                : document.getElementById('sssno')['value'],
                    'CountryCode'          : document.getElementById('countrycode')['value'],
                    'CountyCodeDescription': document.getElementById('countrycodedes')['value'],
                    'CpNumber'             : document.getElementById('cpnumber')['value'],                    
                    'SickleCellDiagnosis'  : document.getElementById('sickdiag')['value'],
                    'FullStreetAddress'    : document.getElementById('address')['value'],
                    'FullStreetAddress2'   : document.getElementById('address2')['value'],
                    'City'                 : document.getElementById('city')['value'],
                    'State'                : document.getElementById('state')['value'],
                    'ZipCode'              : document.getElementById('zipcode')['value'],                                                                                
                    'PMPProviderName'      : document.getElementById('pmppro')['value'],
                    'CCUCase'              : document.getElementById('ccucase')['value'],
                    'Email_Address'        : document.getElementById('email')['value'],
                    'ClientresideinruralID': clientresideinruralid,                                                             
                    'Nameofmother'         : document.getElementById('nameofmother')['value'],
                    'Motheraddress'        : document.getElementById('motheraddress')['value'],
                    'Mothertel'            : document.getElementById('mothertel')['value'],
                    'Nameoffather'         : document.getElementById('nameoffather')['value'],
                    'Fatheraddress'        : document.getElementById('fatheraddress')['value'],
                    'Fathertel'            : document.getElementById('fathertel')['value'],
                    'Nameofguardian'       : document.getElementById('nameofguardian')['value'],
                    'Guardianaddress'      : document.getElementById('guardianaddress')['value'],
                    'Guardiantel'          : document.getElementById('guardiantel')['value'],
                    'Emercont1'            : document.getElementById('emercont1')['value'],
                    'Emercont1homephone'   : document.getElementById('emercont1homephone')['value'],
                    'Emercont1cellphone'   : document.getElementById('emercont1cellphone')['value'],
                    'Emercont2'            : document.getElementById('emercont2')['value'],
                    'Emercont2homephone'   : document.getElementById('emercont2homephone')['value'],
                    'Emercont2cellphone'   : document.getElementById('emercont2cellphone')['value'],
                    'SicklecelltypeID'     : sicklecelltypeid,
                    'HydroxyureaheardID'   : hydroxyureaheardid,
                    'HydroxyureatakenID'   : hydroxyureatakenid,
                    'HydroxyureacurrentlyID': hydroxyureacurrentlyid,
                    'HydroxyureapasttakenID': hydroxyureapasttakenid,
                    'Globalid'              : globalID
                };
            }
            $.ajax({
                url: '/Home/Save', type: 'POST', data: JSON.stringify(datavalue), dataType: 'json', contentType: "application/json", success: function (response) {                
                    alert("Successfully Save");
                    document.getElementById('clientid')['value'] = '';
                    document.getElementById('lname')['value'] = '';
                    document.getElementById('fname')['value'] = '';
                    document.getElementById('mi')['value'] = '';
                    document.getElementById('uniqueid')['value'] = '';
                    document.getElementById('dob')['value'] = '';
                    document.getElementById('age')['value'] = '';
                    document.getElementById('agegroup')['value'] = '';
                    document.getElementById('ageat')['value'] = '';
                    document.getElementById('gender')['value'] = '';
                    document.getElementById('race')['value'] = '';
                    document.getElementById('ethnicity')['value'] = '';
                    document.getElementById('eligibility')['value'] = '';
                    document.getElementById('sssno')['value'] = '';
                    document.getElementById('countrycode')['value'] = '';
                    document.getElementById('countrycodedes')['value'] = '';
                    document.getElementById('cpnumber')['value'] = '';
                    document.getElementById('sickdiag')['value'] = '';
                    document.getElementById('address')['value'] = '';
                    document.getElementById('address2')['value'] = '';
                    document.getElementById('city')['value'] = '';
                    document.getElementById('state')['value'] = '';
                    document.getElementById('zipcode')['value'] = '';
                    document.getElementById('hphone')['value'] = '';
                    document.getElementById('wphone')['value'] = '';
                    document.getElementById('pmppro')['value'] = '';
                    document.getElementById('ccucase')['value'] = '';
                    document.getElementById('email')['value'] = '';

                    // this is for client reside //
                    document.getElementById('clientresideyes').checked = false;
                    document.getElementById('clientresideno').checked = false;

                    document.getElementById('nameofmother')['value'] = '';
                    document.getElementById('motheraddress')['value'] = '';
                    document.getElementById('mothertel')['value'] = '';
                    document.getElementById('nameoffather')['value'] = '';
                    document.getElementById('fatheraddress')['value'] = '';
                    document.getElementById('fathertel')['value'] = '';
                    document.getElementById('nameofguardian')['value'] = '';
                    document.getElementById('guardianaddress')['value'] = '';
                    document.getElementById('guardiantel')['value'] = '';
                    document.getElementById('emercont1')['value'] = '';
                    document.getElementById('emercont1homephone')['value'] = '';
                    document.getElementById('emercont1cellphone')['value'] = '';
                    document.getElementById('emercont2')['value'] = '';
                    document.getElementById('emercont2homephone')['value'] = '';
                    document.getElementById('emercont2cellphone')['value'] = '';

                    // this is for sicklecelltype//
                    document.getElementById("sicklecellss").checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;

                    // Have you ever heard of Hydroxyurea //
                    document.getElementById("hydroxyureaheardyes").checked = false;
                    document.getElementById("hydroxyureaheardno").checked = false;

                    // Have you ever taken Hydroxyurea before //
                    document.getElementById("hydroxyureatakenyes").checked = false;
                    document.getElementById("hydroxyureatakenno").checked = false;

                    // Do you currently use Hydroxyurea //
                    document.getElementById("hydroxyureacurrentlyyes").checked = false;
                    document.getElementById("hydroxyureacurrentlyno").checked = false;

                    // If No: Have you taken it in the past //
                    document.getElementById("hydroxyureapasttakenyes").checked = false;
                    document.getElementById("hydroxyureapasttakenno").checked = false;

                    document.getElementById('hydroxyureadosage')['value'] = '';
                    document.getElementById('hydroxyureadosageunknown')['value'] = '';
                    document.getElementById('hydroxyureacapsulescolor')['value'] = '';
                    document.getElementById('hydroxyureadatelasttaken')['value'] = '';
                    document.getElementById('hydroxyureadatepickedup')['value'] = '';
                    document.getElementById('clientid').focus();

                    ////////////////////////////////////////////////////////
                }, error: function (response) {
                    //alert('Registration failed');
                }
            });
        } else {
            alert("You should fill-up all the feilds first");
            document.getElementById('fname').focus();
        }   
    };

    if (sPage.trim() === "Entry" || sPage.trim() === "entry") {

        var isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
        if (isMobile2===true) {
            document.getElementById("searching").style.visibility = "hidden";
            document.getElementById("test").style.width = "310px";
            document.getElementById("test").style.maxWidth = "310px";
        } else { document.getElementById("searching").style.visibility = "visible";}
        
        $scope.Search = function () {                    
            document.getElementById("searching").style.visibility = "visible";
            
            if (isMobile2 === true) {
                document.getElementById("test").style.width = "310px";
                document.getElementById("test").style.maxWidth = "310px";
            } else {
                document.getElementById("test").style.width = "240px";
                document.getElementById("test").style.maxWidth = "240px";
            }                       

            $scope.mlistshow = true;
            $scope.inputboxshow = true;            
            
            angular.element("#search").focus();
        };

        $scope.selected = function () {            
        };

        //////////////////////////////////////

        $scope.Search2 = function () {
            $scope.mlistshow = true;
            $scope.inputboxshow = true;
            angular.element("#search").focus();
        };

        $scope.Select = function () {           
            globalID = localStorage.getItem("vGlobalid");
            var selected = {
                'FullName': this.person
            };

            var items = document.getElementsByName('todo[]');
            var numselected = this.$index;
            for (var i = 0; i < items.length; i++) {
                if (items[i].type === 'checkbox') {

                    if (numselected !== i) {
                        items[i].checked = false;
                    } else {
                        items[i].checked = true;
                    }
                }
            }

            $http({ method: "POST", url: "/Home/Select", data: JSON.stringify(selected), dataType: 'json', contentType: "application/json" }).success(function (response) {
                console.log(response);
                document.getElementById('clientid')['value'] = response["0"].ClientID;
                document.getElementById('lname')['value'] = response["0"].LastName;
                document.getElementById('fname')['value'] = response["0"].FirstName;
                document.getElementById('mi')['value'] = response["0"].Mi;
                document.getElementById('uniqueid')['value'] = response["0"].UniqueID;
                document.getElementById('dob')['value'] = formatDate(response["0"].DOB);
                document.getElementById('age')['value'] = response["0"].Age;
                document.getElementById('agegroup')['value'] = response["0"].AgeGroup;
                document.getElementById('ageat')['value'] = response["0"].Ageat;
                document.getElementById('gender')['value'] = response["0"].Gender;
                document.getElementById('race')['value'] = response["0"].Race;
                document.getElementById('ethnicity')['value'] = response["0"].Ethnicity;
                document.getElementById('eligibility')['value'] = response["0"].Eligibility;
                document.getElementById('sssno')['value'] = response["0"].SSSno;
                document.getElementById('countrycode')['value'] = response["0"].CountryCode;
                document.getElementById('countrycodedes')['value'] = response["0"].CountyCodeDescription;
                document.getElementById('cpnumber')['value'] = response["0"].CpNumber;
                document.getElementById('sickdiag')['value'] = response["0"].SickleCellDiagnosis;
                document.getElementById('address')['value'] = response["0"].FullStreetAddress;
                document.getElementById('address2')['value'] = response["0"].FullStreetAddress2;
                document.getElementById('city')['value'] = response["0"].City;
                document.getElementById('state')['value'] = response["0"].State;
                document.getElementById('zipcode')['value'] = response["0"].ZipCode;
                document.getElementById('pmppro')['value'] = response["0"].clientid;
                document.getElementById('email')['value'] = response["0"].Email_Address;
                document.getElementById('ccucase')['value'] = response["0"].CCUCase;

                if (response["0"].ClientresideinruralID === 'yes') {
                    document.getElementById("clientresideyes").checked = true;
                    document.getElementById("clientresideno").checked = false;
                } else if (response["0"].ClientresideinruralID === 'no') {
                    document.getElementById("clientresideyes").checked = false;
                    document.getElementById("clientresideno").checked = true;
                } else {
                    document.getElementById("clientresideyes").checked = false;
                    document.getElementById("clientresideno").checked = false;
                }
                document.getElementById('nameofmother')['value'] = response["0"].Nameofmother;
                document.getElementById('motheraddress')['value'] = response["0"].Motheraddress;
                document.getElementById('mothertel')['value'] = response["0"].Mothertel;
                document.getElementById('nameoffather')['value'] = response["0"].Nameoffather;
                document.getElementById('fatheraddress')['value'] = response["0"].Fatheraddress;
                document.getElementById('fathertel')['value'] = response["0"].Fathertel;
                document.getElementById('nameofguardian')['value'] = response["0"].Nameofguardian;
                document.getElementById('guardianaddress')['value'] = response["0"].Guardianaddress;
                document.getElementById('guardiantel')['value'] = response["0"].Guardiantel;
                document.getElementById('emercont1')['value'] = response["0"].Emercont1;
                document.getElementById('emercont1homephone')['value'] = response["0"].Emercont1homephone;
                document.getElementById('emercont1cellphone')['value'] = response["0"].Emercont1cellphone;
                document.getElementById('emercont2')['value'] = response["0"].Emercont2;
                document.getElementById('emercont2homephone')['value'] = response["0"].Emercont2homephone;
                document.getElementById('emercont2cellphone')['value'] = response["0"].Emercont2cellphone;

                if (response["0"].SicklecelltypeID === "SS") {
                    document.getElementById('sicklecellss').checked = true;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;

                } else if (response["0"].SicklecelltypeID === "SC") {
                    document.getElementById('sicklecellss').checked = false;
                    document.getElementById("sicklecellsc").checked = true;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;

                } else if (response["0"].SicklecelltypeID === "SBThal") {
                    document.getElementById('sicklecellss').checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = true;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;

                } else if (response["0"].SicklecelltypeID === "SBThal0") {
                    document.getElementById('sicklecellss').checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = true;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;
                } else if (response["0"].SicklecelltypeID === "NotSure") {
                    document.getElementById('sicklecellss').checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = true;
                    document.getElementById("sicklecellother").checked = false;
                } else if (response["0"].SicklecelltypeID === "Other") {
                    document.getElementById('sicklecellss').checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = true;
                } else {
                    document.getElementById('sicklecellss').checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;
                }

                if (response["0"].HydroxyureaheardID === "yes") {
                    document.getElementById("hydroxyureaheardyes").checked = true;
                    document.getElementById("hydroxyureaheardno").checked = false;
                } else if (response["0"].HydroxyureaheardID === "no") {
                    document.getElementById("hydroxyureaheardyes").checked = false;
                    document.getElementById("hydroxyureaheardno").checked = true;
                } else {
                    document.getElementById("hydroxyureaheardyes").checked = false;
                    document.getElementById("hydroxyureaheardno").checked = false;
                }

                if (response["0"].HydroxyureatakenID === "yes") {
                    document.getElementById("hydroxyureatakenyes").checked = true;
                    document.getElementById("hydroxyureatakenno").checked = false;
                } else if (response["0"].HydroxyureatakenID === "no") {
                    document.getElementById("hydroxyureatakenyes").checked = false;
                    document.getElementById("hydroxyureatakenno").checked = true;
                } else {
                    document.getElementById("hydroxyureatakenyes").checked = false;
                    document.getElementById("hydroxyureatakenno").checked = false;
                }

                if (response["0"].HydroxyureacurrentlyID === "yes") {
                    document.getElementById("hydroxyureacurrentlyyes").checked = true;
                    document.getElementById("hydroxyureacurrentlyno").checked = false;
                } else if (response["0"].HydroxyureacurrentlyID === "no") {
                    document.getElementById("hydroxyureacurrentlyyes").checked = false;
                    document.getElementById("hydroxyureacurrentlyno").checked = true;
                } else {
                    document.getElementById("hydroxyureacurrentlyyes").checked = false;
                    document.getElementById("hydroxyureacurrentlyno").checked = false;
                }

                if (response["0"].HydroxyureapasttakenID === "yes") {
                    document.getElementById("hydroxyureapasttakenyes").checked = true;
                    document.getElementById("hydroxyureapasttakenno").checked = false;
                } else if (response["0"].HydroxyureapasttakenID === "no") {
                    document.getElementById("hydroxyureapasttakenyes").checked = false;
                    document.getElementById("hydroxyureapasttakenno").checked = true;
                } else {
                    document.getElementById("hydroxyureapasttakenyes").checked = false;
                    document.getElementById("hydroxyureapasttakenno").checked = false;
                }

                document.getElementById('lblclientid').innerHTML = response["0"].ClientID;                

                let stateofdata = "Edited";
                localStorage.setItem("globalfile", stateofdata);

                $scope.mlistshow = false;
                $scope.inputboxshow = false;

                document.getElementById("test").style.width = "240px";
                document.getElementById("test").style.marginLeft = "-20px";

                var isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
                if (isMobile2 === true) {
                    document.getElementById("searching").style.visibility = "hidden";                    
                } else { document.getElementById("searching").style.visibility = "visible"; }

            }, function (failed) {
                alert("failed");
            });
        };        
        //////////////////////////////////////
    }    

    //$scope.Search2 = function () {
    //    $scope.mlistshow = true;
    //    $scope.inputboxshow = true;
    //    angular.element("#search").focus();
    //};

    //$scope.Select = function () {
    //    globalID = localStorage.getItem("vGlobalid");
    //    var selected = {
    //        'FullName': this.person           
    //    };

    //    $http({ method: "POST", url: "/Home/Select", data: JSON.stringify(selected), dataType: 'json', contentType: "application/json" }).success(function (response) {
    //        console.log(response);
    //        document.getElementById('clientid')['value']       = response["0"].ClientID;
    //        document.getElementById('lname')['value']          = response["0"].LastName;
    //        document.getElementById('fname')['value']          = response["0"].FirstName;
    //        document.getElementById('mi')['value']             = response["0"].Mi;            
    //        document.getElementById('uniqueid')['value']       = response["0"].UniqueID;
    //        document.getElementById('dob')['value']            = formatDate(response["0"].DOB);
    //        document.getElementById('age')['value']            = response["0"].Age;
    //        document.getElementById('agegroup')['value']       = response["0"].AgeGroup;
    //        document.getElementById('ageat')['value']          = response["0"].Ageat;
    //        document.getElementById('gender')['value']         = response["0"].Gender;
    //        document.getElementById('race')['value']           = response["0"].Race;
    //        document.getElementById('ethnicity')['value']      = response["0"].Ethnicity;
    //        document.getElementById('eligibility')['value']    = response["0"].Eligibility;
    //        document.getElementById('sssno')['value']          = response["0"].SSSno;
    //        document.getElementById('countrycode')['value']    = response["0"].CountryCode;
    //        document.getElementById('countrycodedes')['value'] = response["0"].CountyCodeDescription;
    //        document.getElementById('cpnumber')['value']       = response["0"].CpNumber;            
    //        document.getElementById('sickdiag')['value']       = response["0"].SickleCellDiagnosis;            
    //        document.getElementById('address')['value']        = response["0"].FullStreetAddress;
    //        document.getElementById('address2')['value']       = response["0"].FullStreetAddress2;
    //        document.getElementById('city')['value']           = response["0"].City;
    //        document.getElementById('state')['value']          = response["0"].State;
    //        document.getElementById('zipcode')['value']        = response["0"].ZipCode;
    //        document.getElementById('pmppro')['value']         = response["0"].clientid;
    //        document.getElementById('email')['value']          = response["0"].Email_Address;
    //        document.getElementById('ccucase')['value']        = response["0"].CCUCase;               

    //        if (response["0"].ClientresideinruralID === 'yes') {
    //            document.getElementById("clientresideyes").checked = true;
    //            document.getElementById("clientresideno").checked = false;
    //        } else if (response["0"].ClientresideinruralID === 'no') {
    //            document.getElementById("clientresideyes").checked = false;
    //            document.getElementById("clientresideno").checked = true;
    //        } else {
    //            document.getElementById("clientresideyes").checked = false;
    //            document.getElementById("clientresideno").checked  = false;
    //        }
    //        document.getElementById('nameofmother')['value']  = response["0"].Nameofmother;
    //        document.getElementById('motheraddress')['value'] = response["0"].Motheraddress;
    //        document.getElementById('mothertel')['value']     = response["0"].Mothertel;
    //        document.getElementById('nameoffather')['value']  = response["0"].Nameoffather;
    //        document.getElementById('fatheraddress')['value'] = response["0"].Fatheraddress;
    //        document.getElementById('fathertel')['value'] = response["0"].Fathertel;
    //        document.getElementById('nameofguardian')['value'] = response["0"].Nameofguardian;
    //        document.getElementById('guardianaddress')['value'] = response["0"].Guardianaddress;
    //        document.getElementById('guardiantel')['value'] = response["0"].Guardiantel;
    //        document.getElementById('emercont1')['value'] = response["0"].Emercont1;
    //        document.getElementById('emercont1homephone')['value'] = response["0"].Emercont1homephone;
    //        document.getElementById('emercont1cellphone')['value'] = response["0"].Emercont1cellphone;
    //        document.getElementById('emercont2')['value'] = response["0"].Emercont2;
    //        document.getElementById('emercont2homephone')['value'] = response["0"].Emercont2homephone;
    //        document.getElementById('emercont2cellphone')['value'] = response["0"].Emercont2cellphone;           

    //        if (response["0"].SicklecelltypeID === "SS") {                
    //            document.getElementById('sicklecellss').checked = true;
    //            document.getElementById("sicklecellsc").checked = false;
    //            document.getElementById("sicklecellThal").checked = false;
    //            document.getElementById("sicklecellThal0").checked = false;
    //            document.getElementById("sicklecellnotsure").checked = false;
    //            document.getElementById("sicklecellother").checked = false;

    //        } else if (response["0"].SicklecelltypeID === "SC") {                
    //            document.getElementById('sicklecellss').checked = false;
    //            document.getElementById("sicklecellsc").checked = true;
    //            document.getElementById("sicklecellThal").checked = false;
    //            document.getElementById("sicklecellThal0").checked = false;
    //            document.getElementById("sicklecellnotsure").checked = false;
    //            document.getElementById("sicklecellother").checked = false;

    //        } else if (response["0"].SicklecelltypeID === "SBThal") {                
    //            document.getElementById('sicklecellss').checked = false;
    //            document.getElementById("sicklecellsc").checked = false;
    //            document.getElementById("sicklecellThal").checked = true;
    //            document.getElementById("sicklecellThal0").checked = false;
    //            document.getElementById("sicklecellnotsure").checked = false;
    //            document.getElementById("sicklecellother").checked = false;

    //        } else if (response["0"].SicklecelltypeID === "SBThal0") {                
    //            document.getElementById('sicklecellss').checked = false;
    //            document.getElementById("sicklecellsc").checked = false;
    //            document.getElementById("sicklecellThal").checked = false;
    //            document.getElementById("sicklecellThal0").checked = true;
    //            document.getElementById("sicklecellnotsure").checked = false;
    //            document.getElementById("sicklecellother").checked = false;
    //        } else if (response["0"].SicklecelltypeID === "NotSure") {                
    //            document.getElementById('sicklecellss').checked = false;
    //            document.getElementById("sicklecellsc").checked = false;
    //            document.getElementById("sicklecellThal").checked = false;
    //            document.getElementById("sicklecellThal0").checked = false;
    //            document.getElementById("sicklecellnotsure").checked = true;
    //            document.getElementById("sicklecellother").checked = false;
    //        } else if (response["0"].SicklecelltypeID === "Other") {                
    //            document.getElementById('sicklecellss').checked = false;
    //            document.getElementById("sicklecellsc").checked = false;
    //            document.getElementById("sicklecellThal").checked = false;
    //            document.getElementById("sicklecellThal0").checked = false;
    //            document.getElementById("sicklecellnotsure").checked = false;
    //            document.getElementById("sicklecellother").checked = true;
    //        } else {
    //            document.getElementById('sicklecellss').checked      = false;
    //            document.getElementById("sicklecellsc").checked      = false;
    //            document.getElementById("sicklecellThal").checked    = false;
    //            document.getElementById("sicklecellThal0").checked   = false;
    //            document.getElementById("sicklecellnotsure").checked = false;
    //            document.getElementById("sicklecellother").checked   = false;
    //        }

    //        if (response["0"].HydroxyureaheardID === "yes") {
    //            document.getElementById("hydroxyureaheardyes").checked = true;
    //            document.getElementById("hydroxyureaheardno").checked  = false;
    //        } else if (response["0"].HydroxyureaheardID === "no") {
    //            document.getElementById("hydroxyureaheardyes").checked = false;
    //            document.getElementById("hydroxyureaheardno").checked  = true;
    //        } else {
    //            document.getElementById("hydroxyureaheardyes").checked = false;
    //            document.getElementById("hydroxyureaheardno").checked  = false;
    //        }
                
    //        if (response["0"].HydroxyureatakenID === "yes") {
    //            document.getElementById("hydroxyureatakenyes").checked = true;
    //            document.getElementById("hydroxyureatakenno").checked  = false;
    //        } else if (response["0"].HydroxyureatakenID === "no") {
    //            document.getElementById("hydroxyureatakenyes").checked = false;
    //            document.getElementById("hydroxyureatakenno").checked  = true;
    //        } else {
    //            document.getElementById("hydroxyureatakenyes").checked = false;
    //            document.getElementById("hydroxyureatakenno").checked  = false;
    //        }

    //        if (response["0"].HydroxyureacurrentlyID === "yes") {
    //            document.getElementById("hydroxyureacurrentlyyes").checked = true;
    //            document.getElementById("hydroxyureacurrentlyno").checked  = false;
    //        } else if (response["0"].HydroxyureacurrentlyID === "no") {
    //            document.getElementById("hydroxyureacurrentlyyes").checked = false;
    //            document.getElementById("hydroxyureacurrentlyno").checked  = true;
    //        } else {
    //            document.getElementById("hydroxyureacurrentlyyes").checked = false;
    //            document.getElementById("hydroxyureacurrentlyno").checked  = false;
    //        }

    //        if (response["0"].HydroxyureapasttakenID === "yes") {
    //            document.getElementById("hydroxyureapasttakenyes").checked = true;
    //            document.getElementById("hydroxyureapasttakenno").checked  = false;
    //        } else if (response["0"].HydroxyureapasttakenID === "no") {
    //            document.getElementById("hydroxyureapasttakenyes").checked = false;
    //            document.getElementById("hydroxyureapasttakenno").checked  = true;
    //        } else {
    //            document.getElementById("hydroxyureapasttakenyes").checked = false;
    //            document.getElementById("hydroxyureapasttakenno").checked  = false;
    //        }

    //        document.getElementById('lblclientid').innerHTML   = response["0"].ClientID; 

    //        let stateofdata = "Edited";
    //        localStorage.setItem("globalfile", stateofdata);

    //        $scope.mlistshow = false;
    //        $scope.inputboxshow = false;

    //        document.getElementById("test").style.width = "240px";
    //        document.getElementById("test").style.marginLeft = "-20px";

    //    }, function (failed) {
    //        alert("failed");
    //    });
    //};

    $scope.Update = function () {
        globalID = localStorage.getItem("vGlobalid");
        lblclient = document.getElementById('lblclientid').innerHTML;

        let clientresideinruralid;
        let sicklecelltypeid;
        let hydroxyureaheardid;
        let hydroxyureatakenid;
        let hydroxyureacurrentlyid;
        let hydroxyureapasttakenid;
        updatecounter = 0;

        // this is for client reside //
        if (document.getElementById('clientresideyes').checked === true) {
            clientresideinruralid = "yes";
        } else if (document.getElementById('clientresideno').checked === true) {
            clientresideinruralid = "no";
        } else {
            clientresideinruralid = "";
        }

        // this is for sicklecelltype//
        if (document.getElementById('sicklecellss').checked === true) {
            sicklecelltypeid = "SS";
        } else if (document.getElementById("sicklecellsc").checked === true) {
            sicklecelltypeid = "SC";
        } else if (document.getElementById("sicklecellThal").checked === true) {
            sicklecelltypeid = "SBThal";
        } else if (document.getElementById("sicklecellThal0").checked === true) {
            sicklecelltypeid = "SBThal0";
        } else if (document.getElementById("sicklecellnotsure").checked === true) {
            sicklecelltypeid = "NotSure";
        } else if (document.getElementById("sicklecellother").checked === true) {
            sicklecelltypeid = "Other";
        } else {
            sicklecelltypeid = "";
        }

        // Have you ever heard of Hydroxyurea //
        if (document.getElementById('hydroxyureaheardyes').checked === true) {
            hydroxyureaheardid = "yes";
        } else if (document.getElementById('hydroxyureaheardno').checked === true) {
            hydroxyureaheardid = "no";
        } else {
            hydroxyureaheardid = "";
        }

        // Have you ever taken Hydroxyurea before //
        if (document.getElementById('hydroxyureatakenyes').checked === true) {
            hydroxyureatakenid = "yes";
        } else if (document.getElementById('hydroxyureatakenno').checked === true) {
            hydroxyureatakenid = "no";
        } else {
            hydroxyureatakenid = "";
        }

        // Do you currently use Hydroxyurea 
        if (document.getElementById('hydroxyureacurrentlyyes').checked === true) {
            hydroxyureacurrentlyid = "yes";
        } else if (document.getElementById('hydroxyureacurrentlyno').checked === true) {
            hydroxyureacurrentlyid = "no";
        } else {
            hydroxyureacurrentlyid = "";
        }

        // If No: Have you taken it in the past //
        if (document.getElementById('hydroxyureapasttakenyes').checked === true) {
            hydroxyureapasttakenid = "yes";
        } else if (document.getElementById('hydroxyureapasttakenno').checked === true) {
            hydroxyureapasttakenid = "no";
        } else {
            hydroxyureapasttakenid = "";
        }
        
        let datavalue = {
                'Clientidx'             : lblclient, 
                'ClientID'              : document.getElementById('clientid')['value'],
                'LastName'              : document.getElementById('lname')['value'],
                'FirstName'             : document.getElementById('fname')['value'],
                'Mi'                    : document.getElementById('mi')['value'],
                'UniqueID'              : document.getElementById('uniqueid')['value'],
                'DOB'                   : document.getElementById('dob')['value'],
                'Age'                   : document.getElementById('age')['value'],
                'AgeGroup'              : document.getElementById('agegroup')['value'],
                'Ageat'                 : document.getElementById('ageat')['value'],
                'Gender'                : document.getElementById('gender')['value'],
                'Race'                  : document.getElementById('race')['value'],
                'Ethnicity'             : document.getElementById('ethnicity')['value'],
                'Eligibility'           : document.getElementById('eligibility')['value'],
                'SSSno'                 : document.getElementById('sssno')['value'],
                'CountryCode'           : document.getElementById('countrycode')['value'],
                'CountyCodeDescription' : document.getElementById('countrycodedes')['value'],
                'CpNumber'              : document.getElementById('cpnumber')['value'],
                'SickleCellDiagnosis'   : document.getElementById('sickdiag')['value'],
                'FullStreetAddress'     : document.getElementById('address')['value'],
                'FullStreetAddress2'    : document.getElementById('address2')['value'],
                'City'                  : document.getElementById('city')['value'],
                'State'                 : document.getElementById('state')['value'],
                'ZipCode'               : document.getElementById('zipcode')['value'],
                'PMPProviderName'       : document.getElementById('pmppro')['value'],
                'CCUCase'               : document.getElementById('ccucase')['value'],
                'Email_Address'         : document.getElementById('email')['value'],
                'ClientresideinruralID' : clientresideinruralid,            
                'Nameofmother'          : document.getElementById('nameofmother')['value'],
                'Motheraddress'         : document.getElementById('motheraddress')['value'],
                'Mothertel'             : document.getElementById('mothertel')['value'],
                'Nameoffather'          : document.getElementById('nameoffather')['value'],
                'Fatheraddress'         : document.getElementById('fatheraddress')['value'],
                'Fathertel'             : document.getElementById('fathertel')['value'],
                'Nameofguardian'        : document.getElementById('nameofguardian')['value'],
                'Guardianaddress'       : document.getElementById('guardianaddress')['value'],
                'Guardiantel'           : document.getElementById('guardiantel')['value'],
                'Emercont1'             : document.getElementById('emercont1')['value'],
                'Emercont1homephon'     : document.getElementById('emercont1homephone')['value'],
                'Emercont1cellphone'    : document.getElementById('emercont1cellphone')['value'],
                'Emercont2'             : document.getElementById('emercont2')['value'],
                'Emercont2homephone'    : document.getElementById('emercont2homephone')['value'],
                'Emercont2cellphone'    : document.getElementById('emercont2cellphone')['value'],
                'SicklecelltypeID'      : sicklecelltypeid,
                'HydroxyureaheardID'    : hydroxyureaheardid,
                'HydroxyureatakenID'    : hydroxyureatakenid,
                'HydroxyureacurrentlyID': hydroxyureacurrentlyid,
                'HydroxyureapasttakenID': hydroxyureapasttakenid,
            };

            $http({ method: "POST", url: "/Home/Update", data: JSON.stringify(datavalue), dataType: 'json', contentType: "application/json" }).success(function (response) {

             if (updatecounter===0) {
                    document.getElementById('lblclientid').innerHTML   = '';
                    document.getElementById('clientid')['value'] = '';
                    document.getElementById('lname')['value'] = '';
                    document.getElementById('fname')['value'] = '';
                    document.getElementById('mi')['value'] = '';
                    document.getElementById('uniqueid')['value'] = '';
                    document.getElementById('dob')['value'] = '';
                    document.getElementById('age')['value'] = '';
                    document.getElementById('agegroup')['value'] = '';
                    document.getElementById('ageat')['value'] = '';
                    document.getElementById('gender')['value'] = '';
                    document.getElementById('race')['value'] = '';
                    document.getElementById('ethnicity')['value'] = '';
                    document.getElementById('eligibility')['value'] = '';
                    document.getElementById('sssno')['value'] = '';
                    document.getElementById('countrycode')['value'] = '';
                    document.getElementById('countrycodedes')['value'] = '';
                    document.getElementById('cpnumber')['value'] = '';
                    document.getElementById('sickdiag')['value'] = '';
                    document.getElementById('address')['value'] = '';
                    document.getElementById('address2')['value'] = '';
                    document.getElementById('city')['value'] = '';
                    document.getElementById('state')['value'] = '';
                    document.getElementById('zipcode')['value'] = '';
                    document.getElementById('hphone')['value'] = '';
                    document.getElementById('wphone')['value'] = '';
                    document.getElementById('pmppro')['value'] = '';
                    document.getElementById('ccucase')['value'] = '';
                    document.getElementById('email')['value'] = '';

                    // this is for client reside //
                    document.getElementById('clientresideyes').checked = false;
                    document.getElementById('clientresideno').checked = false;

                    document.getElementById('nameofmother')['value'] = '';
                    document.getElementById('motheraddress')['value'] = '';
                    document.getElementById('mothertel')['value'] = '';
                    document.getElementById('nameoffather')['value'] = '';
                    document.getElementById('fatheraddress')['value'] = '';
                    document.getElementById('fathertel')['value'] = '';
                    document.getElementById('nameofguardian')['value'] = '';
                    document.getElementById('guardianaddress')['value'] = '';
                    document.getElementById('guardiantel')['value'] = '';
                    document.getElementById('emercont1')['value'] = '';
                    document.getElementById('emercont1homephone')['value'] = '';
                    document.getElementById('emercont1cellphone')['value'] = '';
                    document.getElementById('emercont2')['value'] = '';
                    document.getElementById('emercont2homephone')['value'] = '';
                    document.getElementById('emercont2cellphone')['value'] = '';

                    // this is for sicklecelltype//
                    document.getElementById("sicklecellss").checked = false;
                    document.getElementById("sicklecellsc").checked = false;
                    document.getElementById("sicklecellThal").checked = false;
                    document.getElementById("sicklecellThal0").checked = false;
                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;

                    // Have you ever heard of Hydroxyurea //
                    document.getElementById("hydroxyureaheardyes").checked = false;
                    document.getElementById("hydroxyureaheardno").checked = false;

                    // Have you ever taken Hydroxyurea before //
                    document.getElementById("hydroxyureatakenyes").checked = false;
                    document.getElementById("hydroxyureatakenno").checked = false;

                    // Do you currently use Hydroxyurea //
                    document.getElementById("hydroxyureacurrentlyyes").checked = false;
                    document.getElementById("hydroxyureacurrentlyno").checked = false;

                    // If No: Have you taken it in the past //
                    document.getElementById("hydroxyureapasttakenyes").checked = false;
                    document.getElementById("hydroxyureapasttakenno").checked = false;

                    document.getElementById('hydroxyureadosage')['value'] = '';
                    document.getElementById('hydroxyureadosageunknown')['value'] = '';
                    document.getElementById('hydroxyureacapsulescolor')['value'] = '';
                    document.getElementById('hydroxyureadatelasttaken')['value'] = '';
                    document.getElementById('hydroxyureadatepickedup')['value'] = '';
                    document.getElementById('clientid').focus();

                    alert("Updated successfully");
                    updatecounter = 1; 
             }

            }, function (failed) {
                alert("Update failed");
            });        
    };       

    $scope.Delete = function () {
        globalID = localStorage.getItem("vGlobalid");
        globalRole = localStorage.getItem("variableRole");

        lblclient = document.getElementById('lblclientid').innerHTML;

            let datavalue = {
                'Clientidx': lblclient
            };
            $http({ method: "POST", url: "/Home/Delete", data: JSON.stringify(datavalue), dataType: 'json', contentType: "application/json" }).success(function (response) {
                document.getElementById('lblclientid').innerHTML = '';
                document.getElementById('clientid')['value'] = '';
                document.getElementById('fname')['value'] = '';
                document.getElementById('lname')['value'] = '';
                document.getElementById('uniqueid')['value'] = '';
                document.getElementById('dob')['value'] = '';
                document.getElementById('age')['value'] = '';
                document.getElementById('agegroup')['value'] = '';
                document.getElementById('gender')['value'] = '';
                document.getElementById('ethnicity')['value'] = '';
                document.getElementById('eligibility')['value'] = '';
                document.getElementById('countrycode')['value'] = '';
                document.getElementById('countrycodedes')['value'] = '';
                document.getElementById('phnumber')['value'] = '';
                document.getElementById('sickdiag')['value'] = '';
                document.getElementById('address')['value'] = '';
                document.getElementById('address2')['value'] = '';
                document.getElementById('city')['value'] = '';
                document.getElementById('state')['value'] = '';
                document.getElementById('zipcode')['value'] = '';
                document.getElementById('pmppro')['value'] = '';
                document.getElementById('email')['value'] = '';
                document.getElementById('ccucase')['value'] = '';
                document.getElementById('clientid').focus();

                alert("Deleted successfully");

            }, function (failed) {
                alert("Deleted failed");
            });        
    };              

    $scope.login = function () {
        var url = window.location.href;
        var arr = url.split("/");
        var result = arr[0] + "//" + arr[2];

        if (document.getElementById('email').validity.valid && document.getElementById('email')['value'] !== "") {

            try {
                var datalogin = {
                    'Email': document.getElementById('email')['value'],
                    'Password': document.getElementById('pwd')['value']
                };
                $http({ url: result + '/api/Login/Validate', method: "POST", data: JSON.stringify(datalogin), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {
                    if (response[0]["Email"] !== null) {
                        if (response[0]["Password"] !== "") {

                            document.getElementById('show-hide').checked = false;

                            varname = response[0]["FirstName"] + " " + response[0]["LastName"];
                            localStorage.setItem("vname", varname);

                            varfirstname = response[0]["FirstName"];
                            varlastname = response[0]["LastName"];

                            localStorage.setItem("userglobalfirstname", varfirstname);
                            localStorage.setItem("usergloballastname",  varlastname);

                            varemail = response[0]["Email"];
                            localStorage.setItem("vEmail", varemail);
                            localStorage.setItem("vEmail2", varemail);

                            vrole = response[0]["Role"];
                            localStorage.setItem("vRole", vrole);

                            localStorage.setItem("variableEmail", varemail);
                            localStorage.setItem("variableEmail2", varemail);
                            localStorage.setItem("variableRole", vrole); 

                            //window.location.href = "/Home/Entry";
                            window.location.href = "/Home/Index";

                        } else {
                            alert("wrong password");
                            document.getElementById('pwd').focus();
                        }
                    } else {
                        alert("Email Address is Invalid Or it's not Registered");
                        document.getElementById("email").focus();
                    }
                    count = 0;
                    //window.location.href = "#login";
                }, function (failed) {
                    alert('Failed');
                });
                
            }
            catch (error) {
                console.error(error);
            }                              

        } else {
            if (document.getElementById('email')['value'] === "") {
                alert("Empty Email Address");
            } else {
                alert("Invalid Email Address");
            }
        }
    };    

    $scope.main = function () {
        window.location.href = 'index';
    };

    $scope.Updaterecord = function () {
        location.reload();
    };

    if (sPage.trim() === "index" || sPage.trim() === "Index") {
        $scope.mouseover1 = function () {           
            document.getElementById("case_notes").style.backgroundColor       = "white";   
            document.getElementById("patient_overview").style.backgroundColor = "white";   
            document.getElementById("upload_csv").style.backgroundColor       = "white";   
            
            document.getElementById("entry").style.backgroundColor            = "#28c4f4";
        };
        $scope.mouseover2 = function () {
            document.getElementById("entry").style.backgroundColor            = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";  
            document.getElementById("upload_csv").style.backgroundColor       = "white";   

            document.getElementById("case_notes").style.backgroundColor       = "#28c4f4";
        };    
        $scope.mouseover3 = function () {
            document.getElementById("entry").style.backgroundColor            = "white";
            document.getElementById("case_notes").style.backgroundColor       = "white";
            document.getElementById("upload_csv").style.backgroundColor       = "white";   

            document.getElementById("patient_overview").style.backgroundColor = "#28c4f4";
        };    
        $scope.mouseover4 = function () {
            document.getElementById("entry").style.backgroundColor            = "white";
            document.getElementById("case_notes").style.backgroundColor       = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";

            document.getElementById("upload_csv").style.backgroundColor       = "#28c4f4";
        };            
        $scope.leave = function () {
            document.getElementById("case_notes").style.backgroundColor       = "white";
            document.getElementById("entry").style.backgroundColor            = "white";            
            document.getElementById("patient_overview").style.backgroundColor = "white";   
            document.getElementById("upload_csv").style.backgroundColor       = "white";   
        };
    }

    if (sPage.trim() === "index_Admin" || sPage.trim() === "Index_Admin") {
        $scope.mouseover0 = function () {
            document.getElementById("classes").style.backgroundColor           = "white";
            document.getElementById("viewlogs").style.backgroundColor          = "white";
            document.getElementById("student_mngt").style.backgroundColor      = "white";
            document.getElementById("staff_mngt").style.backgroundColor        = "white";            

            document.getElementById("school_register").style.backgroundColor = "#28c4f4";
        };
        $scope.mouseover1 = function () {
            document.getElementById("classes").style.backgroundColor           = "white";
            document.getElementById("viewlogs").style.backgroundColor          = "white";
            document.getElementById("school_register").style.backgroundColor   = "white";
            document.getElementById("staff_mngt").style.backgroundColor        = "white";
            
            document.getElementById("student_mngt").style.backgroundColor      = "#28c4f4";
        };
        $scope.mouseover2 = function () {
            document.getElementById("classes").style.backgroundColor           = "white";
            document.getElementById("viewlogs").style.backgroundColor          = "white";
            document.getElementById("school_register").style.backgroundColor   = "white";
            document.getElementById("student_mngt").style.backgroundColor      = "white";
            
            document.getElementById("staff_mngt").style.backgroundColor        = "#28c4f4";
        };
        $scope.mouseover3 = function () {
            document.getElementById("school_register").style.backgroundColor   = "white";
            document.getElementById("student_mngt").style.backgroundColor      = "white";
            document.getElementById("staff_mngt").style.backgroundColor        = "white";
            document.getElementById("viewlogs").style.backgroundColor          = "white";

            document.getElementById("classes").style.backgroundColor           = "#28c4f4";
        };       
        $scope.mouseover4 = function () {
            document.getElementById("classes").style.backgroundColor           = "white";
            document.getElementById("school_register").style.backgroundColor   = "white";
            document.getElementById("student_mngt").style.backgroundColor      = "white";
            document.getElementById("staff_mngt").style.backgroundColor        = "white";
            
            document.getElementById("viewlogs").style.backgroundColor          = "#28c4f4";
        };       

        $scope.leave = function () {
            document.getElementById("school_register").style.backgroundColor   = "white";
            document.getElementById("classes").style.backgroundColor           = "white";
            document.getElementById("viewlogs").style.backgroundColor          = "white";
            document.getElementById("student_mngt").style.backgroundColor      = "white";
            document.getElementById("staff_mngt").style.backgroundColor        = "white";           
        };
    }

    ////// this is to load school //////
    if (sPage.toString().trim() === "Registered_School") {
        //function formatDate(date) {
        //    var d = new Date(date),
        //        month = '' + (d.getMonth() + 1),
        //        day = '' + d.getDate(),
        //        year = d.getFullYear();

        //    if (month.length < 2) month = '0' + month;
        //    if (day.length < 2) day = '0' + day;

        //    return [year, month, day].join('-');
        //}

        //// right padding s with c to a total of n chars for customer
        //function padding_right(s, c, n) {
        //    // this is to give the value with the response data field if the response data is empty//
        //    if (s === "") { s = '\u00A0', 2; }
        //    // this is to give the value with the response data field if the response data is empty//

        //    if (!s || !c || s.length >=n) {
        //        return s;
        //    }
        //    var max = (n - s.length) / c.length;
        //    for (var i = 0; i < max; i++) {
        //        s += c;
        //    }
        //    return s;
        //}

        ///////////////
        $http({ method: "GET", url: '/Home/School_Load'}).success(function (response) {
            var ddlSchool = document.getElementById("school_name");

            let count = 30;
            let count2 = 13;
            let count3 = 20;
            let editcust = [];

            //Add the Options to the DropDownList.
            for (var i = 0; i < response.length; i++) {
                editcust.push({ School_ID: padding_right(response[i].School_ID, '\u00A0', 6), School_Name: padding_right(response[i].School_Name, '\u00A0', 40), Date_Register: padding_right(formatDate(response[i].Date_Register), '\u00A0', count2), School_Type: padding_right(response[i].School_Type, '\u00A0', count3) });
            }
          
            console.log(editcust);
            $scope.val = editcust;

        }, function (failed) {
            alert("Load Failed");
        });

        $scope.back = function () {
            window.location.href = "/Home/School_Register";
        };

    }                
    
    if (sPage.trim() === "login" || sPage.trim() === "Login" || sPage.trim() === "Successful" || sPage.trim() === "Signup" || sPage.trim() === "Login2" || sPage.trim() === "login2" || sPage.trim() === "PleaseConfirm") {
        document.getElementById("navigation").style.visibility = "hidden";
        document.getElementById("ul").style.visibility = "hidden";

        document.getElementById("my_account").style.visibility = "hidden";
        document.getElementById("username").style.visibility = "hidden";

        document.getElementById("navigation2").style.visibility = "hidden";
        document.getElementById("ul2").style.visibility = "hidden";

        document.getElementById("my_account2").style.visibility = "hidden";
        document.getElementById("username2").style.visibility = "hidden";
    } else {
        if (sPage.trim() === "Uploadcsv" || sPage.trim() === "uploadcsv" || sPage.trim() === "PatientOverview" || sPage.trim() === "patientoverview" || sPage.trim() === "Entry" || sPage.trim() === "entry" || sPage.trim() === "Casenotes" || sPage.trim() === "casenotes" || sPage.trim() === "Index" || sPage.trim() === "index" || sPage.trim() === "Register" || sPage.trim() === "register" || sPage.trim() === "Viewlogs" || sPage.trim() === "viewlogs" || sPage.trim() === "Classes.html" || sPage.trim() === "classes.html") {

            var globalEmail = localStorage.getItem("variableEmail2");
            var globalRoleName = localStorage.getItem("variableRole");

            if (globalRoleName === "" && globalEmail === "") {
                window.location.href = "/Home/Login2";
                document.getElementById("email")["value"] = "";
                document.getElementById("email").focus();
            } else {                      

                // For use within normal web clients 
                var isiPad = navigator.userAgent.match(/iPad/i) !== null;

                // For use within iPad developer UIWebView
                // Thanks to Andrew Hedges!
                var ua = navigator.userAgent;
                var isiPad2 = /iPad/i.test(ua) || /iPhone OS 3_1_2/i.test(ua) || /iPhone OS 3_2_2/i.test(ua);
                
                var isMobile = navigator.userAgent.match(/(iPad)|(iPhone)|(iPod)|(android)|(webOS)/i);                
                isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);

                devicestat = localStorage.getItem("layout");
                if (devicestat === "Mobile Phone" && isMobile2===true) {
                    globalRole = localStorage.getItem("variableRole");                    
                    if (globalRole === "Super Admin") {

                        document.getElementById("nav1").style.visibility = "visible";
                        document.getElementById("cnt1").style.visibility = "visible";
                        document.getElementById("navigation1").style.visibility = "visible";
                        document.getElementById("ul1").style.visibility = "visible";

                        document.getElementById("my_account3").style.visibility = "visible";
                        document.getElementById("username3").style.visibility = "visible";   

                        document.getElementById("my_account3").style.width = "auto";
                        document.getElementById("username3").style.width = "auto";                                                

                    } else {
                        
                        document.getElementById("nav2").style.visibility = "visible";
                        document.getElementById("cnt2").style.visibility = "visible";
                        document.getElementById("navigation2").style.visibility = "visible";
                        document.getElementById("ul2").style.visibility = "visible";                       

                        document.getElementById("my_account4").style.visibility = "visible";
                        document.getElementById("username4").style.visibility = "visible";                                                

                        document.getElementById("my_account4").style.width = "auto";
                        document.getElementById("username4").style.width = "auto";                                                
                    }

                } else {                    
                    globalRole = localStorage.getItem("variableRole");
                    if (globalRole === "Super Admin") {
                        document.getElementById("nav1").style.visibility = "hidden";
                        document.getElementById("cnt1").style.visibility = "hidden";
                        document.getElementById("navigation").style.visibility = "hidden";
                        document.getElementById("ul").style.visibility = "hidden";

                        document.getElementById("my_account").style.visibility = "hidden";
                        document.getElementById("username").style.visibility = "hidden";

                        document.getElementById("mobile1").style.visibility = "hidden";
                        document.getElementById("mobile2").style.visibility = "hidden";


                        document.getElementById("nav2").style.visibility = "visible";
                        document.getElementById("cnt2").style.visibility = "visible";

                        document.getElementById("navigation2").style.visibility = "visible";
                        document.getElementById("ul2").style.visibility = "visible";

                        document.getElementById("my_account2").style.visibility = "visible";
                        document.getElementById("username2").style.visibility = "visible";

                    } else {
                        document.getElementById("nav2").style.visibility = "hidden";
                        document.getElementById("cnt2").style.visibility = "hidden";
                        document.getElementById("navigation2").style.visibility = "hidden";
                        document.getElementById("ul2").style.visibility = "hidden";

                        document.getElementById("my_account2").style.visibility = "hidden";
                        document.getElementById("username2").style.visibility = "hidden";

                        document.getElementById("mobile1").style.visibility = "hidden";
                        document.getElementById("mobile2").style.visibility = "hidden";


                        document.getElementById("nav1").style.visibility = "visible";
                        document.getElementById("cnt1").style.visibility = "visible";
                        document.getElementById("navigation").style.visibility = "visible";
                        document.getElementById("ul").style.visibility = "visible";

                        document.getElementById("my_account").style.visibility = "visible";
                        document.getElementById("username").style.visibility = "visible";
                    }
                }                                              
            }
        }
    }

    if (sPage.trim() === "Casenotes" || sPage.trim() === "casenotes") {             

        isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
        if (isMobile2 === true) {                    
            document.getElementById("spanid").style.visibility = "hidden";
            document.getElementById("checkboxlist2").style.visibility   = "hidden";
        } else {        
            //alert("");
        }

        $scope.Searchnotes = function () {                                  

            isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
            if (isMobile2 === true) {                
                document.getElementById("comments2").style.visibility = "visible";
                document.getElementById("spanid").style.visibility = "visible";
                document.getElementById("checkboxlist2").style.visibility = "visible";
            } else {
                //alert("Desktop");
            }

            $scope.mlistshow = true;
            $scope.inputboxshow = true;

            document.getElementById("search").innerHTML = '';
            document.getElementById("search").value = '';                        
            
            angular.element("#search").focus();
        };

        
    scope.Selectnotes = function () {    

        var selected = {
            'FullName': this.person
        };

        if (selected.FullName === undefined) {
            selected = {
                'FullName': document.getElementById("fname")["value"] + " " + document.getElementById("lname")["value"]
            };
        }

        var items = document.getElementsByName('todo[]');
        var numselected = this.$index;
        for (var i = 0; i < items.length; i++) {
            if (items[i].type === 'checkbox') {

                if (numselected !== i) {
                    items[i].checked = false;
                } else {
                    items[i].checked = true;
                }
            }
        }

        $http({ method: "POST", url: "/Home/Select", data: JSON.stringify(selected), dataType: 'json', contentType: "application/json" }).success(function (responseselect) {
            document.getElementById('clientid')['value'] = responseselect["0"].ClientID;
            document.getElementById('fname')['value'] = responseselect["0"].FirstName;
            document.getElementById('lname')['value'] = responseselect["0"].LastName;
            document.getElementById('dob')['value'] = responseselect["0"].DOB;

            $scope.mlistshow = false;
            $scope.inputboxshow = false;
            //$scope.mulcheckbox = false;

            let currdate = new Date(); // for now            
            let currtime = new Date().toLocaleTimeString();
            let currdate2 = new Date().toLocaleDateString();

            globalusrfname = localStorage.getItem("userglobalfirstname");
            globalusrlname = localStorage.getItem("usergloballastname");

            //document.getElementById('notes')['value'] = "." + currdate2 + " - " + currtime + "   " + globalusrfname + " " + globalusrlname + " -- ";

            /////////////////
            if (document.getElementById('clientid')['value'] !== "") {

                var selectednotes = {
                    'ClientID': document.getElementById('clientid')['value']
                };
                $http({ method: "POST", url: "/Home/Loadnotes", data: JSON.stringify(selectednotes), dataType: 'json', contentType: "application/json" }).success(function (responseload) {

                    let count = 30;
                    let counterlength = 0;
                    let count3 = 0;
                    let counter4 = 0;
                    let strcounter = "";                
                    let answer = 0;
                    let editcust = [];

                    //Add the Options to the DropDownList.
                    for (var i = 0; i < responseload.length; i++) {

                        if (responseload[i].Comments.toString().length >= 230) {
                            counterlength = responseload[i].Comments.toString().length;
                            
                            answer = Math.round(counterlength / 185);
                            counter4 = 185;

                             for (var n = 0; n < answer; n++) {                               

                                strcounter = responseload[i].Comments.substring(count3, counter4);                               

                                 if (strcounter.substring(strcounter.length - 1) !== " ") {
                                     for (var p = 0; p < 20; p++) {
                                         vtextright = strcounter.substring(strcounter.length - p);
                                         vtextempty = vtextright.substring(0, 1);
                                         if (vtextempty === " ") {

                                             strcounter = responseload[i].Comments.substring(count3, counter4 - counterright);

                                             editcust.push({ Comments: strcounter });

                                             count3 = count3 + 185 - counterright;
                                             counter4 = counter4 + 185 - counterright;
                                             counterright = 0;

                                             break;

                                         } else { counterright = counterright + 1; }
                                     }
                                 } else {

                                     editcust.push({ Comments: strcounter });
                                     count3 = count3 + 185;
                                     counter4 = counter4 + 185;
                                 }                                                                                                                                                                                                    
                             }

                            counterlength = 0;
                            count3 = 0;
                            counter4 = 0;
                            strcounter = "";                

                        } else {
                            editcust.push({ Comments: (responseload[i].Comments) });
                        }
                        editcust.push("");                                                
                    }
                    $scope.comm = editcust;                    

                }, function (error) {
                    alert("Load Failed");
                });

                if (isMobile2 === true) {
                    //document.getElementById("comments2").style.visibility = "hidden";
                    document.getElementById("spanid").style.visibility = "hidden";
                    document.getElementById("checkboxlist2").style.visibility = "hidden";
                } else {
                    //alert("Desktop");
                }
            }
            /////////////////

            document.getElementById('notes').focus();

        }, function (failed) {
            alert("failed");
        });            
    };

    scope.Savenotes = function () {

            globalusrfname = localStorage.getItem("userglobalfirstname");
            globalusrlname = localStorage.getItem("usergloballastname");

            console.log(document.getElementById("clientid")["value"]);
            var currdate = new Date(); // for now            
            let currtime = new Date().toLocaleTimeString();
            let currdate2 = new Date().toLocaleDateString();

            var savingnotes = {
                'ClientID': document.getElementById("clientid")["value"],
                'FirstName': document.getElementById("fname")["value"],
                'LastName': document.getElementById("lname")["value"],
                'DOB': document.getElementById("dob")["value"],
                'Comments': currdate2 + " - " + currtime + "   " + globalusrfname + " " + globalusrlname + " -- " + document.getElementById("notes")["value"],
                //'Comments': document.getElementById("notes")["value"].substring(1, 5000),               
                'UserFirstName': globalusrfname,
                'UserLastName': globalusrlname,
                'TimeStamp': currtime,
                'Datenotescreated': formatDate(currdate)
            };
        
        vnotes = document.getElementById("notes")["value"].trim();
        if (vnotes!== "") {
                $http({ method: "POST", url: "/Home/Savenotes", data: JSON.stringify(savingnotes), dataType: 'json', contentType: "application/json" }).success(function (responsesave) {                    
                    document.getElementById("notes")["value"] = '';
                    
                    scope.Selectnotes();

                    vnotes = "";

                    alert("Successfully saved");

                    vnotes = "";
                    document.getElementById("notes")["value"] = '';                    

                }, function (failed) {
                    alert("failed");
                });
            } else {
                alert("Invalid, You have an empty New Comments / Notes");
            }            
        };                       
    };

    $scope.signup = function () {
        var url = window.location.href;
        var arr = url.split("/");
        var result = arr[0] + "//" + arr[2];

        if (document.getElementById('email').validity.valid && document.getElementById('email')['value'] !== "") {
            if (document.getElementById('pwd')['value'] === document.getElementById('confirmpass')['value']) {
                let xc = 0;
                var datasigned = {
                    'FirstName': document.getElementById('fname')['value'],
                    'LastName': document.getElementById('lname')['value'],
                    'Role': document.getElementById('role')['value'],
                    'Email': document.getElementById('email')['value'],
                    'Password': document.getElementById('pwd')['value'],
                    'Confirmpass': document.getElementById('confirmpass')['value'],
                    'link': 'http://localhost:59371/Home/Login2'
                };
                $http({ url: result + '/api/Sign/Sign_Post', method: "POST", data: JSON.stringify(datasigned), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {

                    //if (response.slice(1,1) ==='"') {
                    if (response === '""') {
                        document.getElementById("already").style.visibility = "hidden";
                        document.getElementById('show-hide').checked = false;
                        document.getElementById('show-hide2').checked = false;
                        document.getElementById('fname')['value'] = "";
                        document.getElementById('lname')['value'] = "";
                        document.getElementById('role')['value'] = "";
                        document.getElementById('email')['value'] = "";
                        document.getElementById('pwd')['value'] = "";
                        document.getElementById('confirmpass')['value'] = "";

                        confirmedmail = datasigned.Email;
                        localStorage.setItem("variableEmail", confirmedmail);

                        window.location.href = "/Home/Successful";
                    } else {
                        alert('This Email Address is already exist in our Database please retype');
                    }
                    count = 0;
                    window.location.href = "#signup";
                }, function (failed) {
                    alert('Data posted failed');
                });

            } else {
                alert("confirmation of your password doesn't matched");
            }
        } else {
            if (document.getElementById('email')['value'] === "") {
                alert("Empty Email address");
            } else {
                alert("Invalid Email Address");
            }
        }
    };            

    //$('input[type=file]').change(function () {
    //    //.log(this.files[0].mozFullPath);
    //    console.log(document.getElementById("one").files[0].name);
    //});

    $('#fileUpload').on('change', function () {

        //let link3 = document.getElementById("fileUpload").files[0].name;

        //var link = $(this).val();
        //console.log(link);
        link = document.getElementById("fileUpload").files[0].name;

        var fileUpload = $("#fileUpload").get(0);
        var files = fileUpload.files;

        let variablePath = { 'Path': link, 'Jresult': '' };

        var fileData = new FormData();     

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        try {
            $.ajax({
                url: '/Upload/Open',
                type: "POST",
                contentType: false, // Not to set any content header  
                processData: false, // Not to process data  
                data: fileData,
                success: function (result) {

                    var k = "";                    
                    // Simplified here for illustration.
                    $http({ method: "POST", url: "/Upload/CsvExtraction", data: JSON.stringify(variablePath), dataType: 'json', contentType: "application/json" }).success(function (response) {

                        alert("succeed");

                    }, function (failed) {
                        alert("Access failed");
                    });

                }
            });
        } catch (err) {
            alert(err.message);
        }
                 
    });

    if (sPage.trim() === "Uploadcsv" || sPage.trim() === "uploadcsv") {
        $scope.upload = function (){             

            var x = "";
            //var i = this.files[0].mozFullPath;
            var filePath = $('#one').mozFullPath.val(); 
            let link2 = document.getElementById("one").files[0].name;
            var f = document.getElementById('importPfForm');
            var fileName = f.datafile.value;

            var files = fileUpload.files;

            let link = fileName;

            var fileData = new FormData();            

            let variablePath = {'Path': link, 'Jresult': ''};           
            $http({ method: "POST", url: "/Home/CsvExtraction", data: JSON.stringify(variablePath), dataType: 'json', contentType: "application/json" }).success(function (response) {

                alert("succeed");

            }, function (failed) {
                alert("Access failed");
            });        
            
        };        
    }

    if (sPage.trim() === "Login" || sPage.trim() === "login") {
        confirmedmail = localStorage.getItem("variableEmail");

        var confirmvalue = {
            'Confirmed': "Yes",
            'Email': confirmedmail
        };

        $.ajax({
            url: '/Home/Validation', type: 'POST', data: JSON.stringify(confirmvalue), dataType: 'json', contentType: "application/json", success: function (response) {
                console.log(response);

                if (response[0].Message.trim() === "No") {
                    window.location.href = "/Home/PleaseConfirm";                        
                }
                if (response[0].Message.trim() === "") {
                    window.location.href = "/Home/Login";                    
                }

                //document.getElementById("divfooter").style.visibility = "visible";

            }, error: function (response) {
                alert('Validation failed');
                window.location.href = "";
            }
        });
    }

    if (sPage === "Index" || sPage === "index") {
        localStorage.setItem("variableEmail", "");          
    }
   
    $scope.namechange = function () {
        document.getElementById("schid").focus();
    };      
        
    /// This is to convert from 'mm-dd-yyyy(10-28-2016)' format to 'yyyy-mm-dd(2016-10-28)' format for customer ///
    function formatDate(date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        return [year, month, day].join('-');
    }

    $(document).keyup(function (escape) {
        if (escape.keyCode === 27) {
            $scope.$apply(function () {
                $scope.searchname = "";
                //$scope.mulcheckbox = false;
                $scope.mlistshow = false;
                $scope.inputboxshow = false;
                document.getElementById("spanid").style.visibility = "hidden";
                document.getElementById("checkboxlist2").style.visibility = "hidden";
            });
        }
    });

    setTimeout(function () {
        $scope.$apply(function () {
            $("#checkboxlist").focus();
        });
    }, 0);       
    
    if (sPage.trim() === "PatientOverview" || sPage.trim() === "patientoverview") {   

        let table = document.getElementById("myTable");
        let row = table.insertRow(0);
        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        let cell3 = row.insertCell(2);
        let cell4 = row.insertCell(3);
        let cell5 = row.insertCell(4);
        let cell6 = row.insertCell(5);
        let cell7 = row.insertCell(6);
        let cell8 = row.insertCell(7);
        
        var patientdataview = {
            'ClientID': '0'
        };

        $.ajax({
            url: '/Home/PatientView', type: 'POST', data: JSON.stringify(patientdataview), dataType: 'json', contentType: "application/json", success: function (response) {
                console.log(response);

                if (response !== "") {

                    for (var i = 0; i < response.length; i++) {

                        table = document.getElementById('myTable').insertRow(i);
                        cell1 = table.insertCell(0);
                        cell2 = table.insertCell(1);
                        cell3 = table.insertCell(2);
                        cell4 = table.insertCell(3);
                        cell5 = table.insertCell(4);
                        cell6 = table.insertCell(5);
                        cell7 = table.insertCell(6);
                        cell8 = table.insertCell(7);                       

                        cell1.innerHTML = response[i].ClientID;
                        cell2.innerHTML = '\u00A0' + '\u00A0' + response[i].FirstName + '  ' + response[i].LastName;

                        document.getElementById("col3").style.marginLeft = "-53px";
                        cell3.innerHTML = response[i].DOB.substring(0,9);

                        document.getElementById("col4").style.marginLeft = "-53px";
                        cell4.innerHTML = response[i].Gender;

                        document.getElementById("col5").style.marginLeft = "5px";

                        document.getElementById("col6").style.marginLeft = "-3px";
                        cell5.innerHTML = response[i].FullStreetAddress;

                        document.getElementById("col6").style.marginLeft = "-3px";
                        cell6.innerHTML = response[i].City;

                        document.getElementById("col7").style.marginLeft = "-53px";
                        cell7.innerHTML = response[i].State;

                        document.getElementById("col8").style.marginLeft = "-53px";
                        cell8.innerHTML = '\u00A0' + '\u00A0' + response[i].Email_Address;                        

                        if (i === response.length) {
                            break;
                        }
                    }
                                                     
                } else {
                    alert('empty');
                }

            }, error: function (response) {
                alert('Overview Data Posted failed');
            }
        });        

        $scope.exportoverview = function () {
            var breakdownfilter = {
                'ClientID': '0'
            };
            $http({ url: '/Home/Breakdown', method: "POST", data: JSON.stringify(breakdownfilter), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {
                             

            }, function (failed) {
                alert('Data posted failed');
            });      
        };
    } 

    return;
}]);



