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
    let loopcounter = 0;
    let counterfetch;
    let patientview = [];
    let movable = "";
    let vClientID;
    let vFirstName;
    let vLastName;
    let vDOB;
    let vGender;
    let vrace;
    let vEthnicity;
    let vSSSno;
    let vCpNumber;
    let vFullStreetAddress;
    let vCity;
    let vUniqueID;
    let vState;
    let vZipCode;
    let vSicklecelltypeID;
    let vEmail_Address;
    let vEligibility;
    let vSickleCellDiagnosis;
    let vPMPProviderName;
    let vCCUCase;
    let vspecialist;
    let vmedication;
    let vemercont1;
    let vemercont1homephone;
    let vemercont1cellphone;
    let vcomments;
    let dragged;
    let searchoption;
    let globalClientID;
    let globalFirstName;
    let globalLastName;
    let globalDOB;
    let modal;
    let span;
    let vdataresponse;
    let counterlog;
    let responseemail;
    let vresult;
    let vrefresh;
    let vlog;
    let back;
    let x;
    let y;
    var globalhistoryID;

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
        if (event.keyCode === 13) {
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
            document.getElementById('speprovider').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('wphone').focus();
        }
    };

    $scope.nameofspecialistkeyup = function () {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('ccucase').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('pmppro').focus();
        }
    };

    $scope.ccucasekeyup = function () {
        if (event.keyCode === 13 || event.keyCode === 39 || event.keyCode === 40) {
            document.getElementById('email').focus();
        }
        if (event.keyCode === 37 || event.keyCode === 38) {
            document.getElementById('speprovider').focus();
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
            document.getElementById('medication').focus();
        }
    };

    $scope.nameofmedicationkeyup = function (keyCode) {
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
            document.getElementById("sicklecellTraits").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.sc = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = true;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false
            document.getElementById("sicklecellTraits").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;

        };
        $scope.sbthal = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = true;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellTraits").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.sbthal0 = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = true;
            document.getElementById("sicklecellTraits").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.traits = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellTraits").checked = true;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.notsure = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellTraits").checked = false;
            document.getElementById("sicklecellnotsure").checked = true;
            document.getElementById("sicklecellother").checked = false;
        };
        $scope.other = function () {
            document.getElementById("sicklecellss").checked = false;
            document.getElementById("sicklecellsc").checked = false;
            document.getElementById("sicklecellThal").checked = false;
            document.getElementById("sicklecellThal0").checked = false;
            document.getElementById("sicklecellTraits").checked = false;
            document.getElementById("sicklecellnotsure").checked = false;
            document.getElementById("sicklecellother").checked = true;
            document.getElementById("sicklecellspecify").focus();
        };

        // This is for Hydroxyurea //
        // Have you ever heard of Hydroxyurea //
        $scope.hydroxyureaeverheardyes = function () {
            document.getElementById("hydroxyureaheardyes").checked = true;
            document.getElementById("hydroxyureaheardno").checked = false;
        };

        $scope.hydroxyureaeverheardno = function () {
            document.getElementById("hydroxyureaheardyes").checked = false;
            document.getElementById("hydroxyureaheardno").checked = true;
        };

        // Have you ever taken Hydroxyurea before //
        $scope.hydroxyureaevertakenyes = function () {
            document.getElementById("hydroxyureatakenyes").checked = true;
            document.getElementById("hydroxyureatakenno").checked = false;
        };

        $scope.hydroxyureaevertakenno = function () {
            document.getElementById("hydroxyureatakenyes").checked = false;
            document.getElementById("hydroxyureatakenno").checked = true;
        };

        // Do you currently use Hydroxyurea //
        $scope.hydroxyureacurryes = function () {
            document.getElementById("hydroxyureacurrentlyyes").checked = true;
            document.getElementById("hydroxyureacurrentlyno").checked = false;
        };

        $scope.hydroxyureacurrno = function () {
            document.getElementById("hydroxyureacurrentlyyes").checked = false;
            document.getElementById("hydroxyureacurrentlyno").checked = true;
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
        // This is for Hydroxyurea //


        // This is for Pharma 1 //
        // Have you ever heard of Pharma 1 //
        $scope.pharma1everheardyes = function () {
            document.getElementById("pharma1heardyes").checked = true;
            document.getElementById("pharma1heardno").checked = false;
        };

        $scope.pharma1everheardno = function () {
            document.getElementById("pharma1heardyes").checked = false;
            document.getElementById("pharma1heardno").checked = true;
        };

        // Have you ever taken Pharma 1 before //
        $scope.pharma1evertakenyes = function () {
            document.getElementById("pharma1takenyes").checked = true;
            document.getElementById("pharma1takenno").checked = false;
        };

        $scope.pharma1evertakenno = function () {
            document.getElementById("pharma1takenyes").checked = false;
            document.getElementById("pharma1takenno").checked = true;
        };

        // Do you currently use Pharma 1 //
        $scope.pharma1curryes = function () {
            document.getElementById("pharma1currentlyyes").checked = true;
            document.getElementById("pharma1currentlyno").checked = false;
        };

        $scope.pharma1currno = function () {
            document.getElementById("pharma1currentlyyes").checked = false;
            document.getElementById("pharma1currentlyno").checked = true;
        };

        // If No: Have you taken it in the past //
        $scope.pharma1takenpastyes = function () {
            document.getElementById("pharma1pasttakenyes").checked = true;
            document.getElementById("pharma1pasttakenno").checked = false;
            document.getElementById("pharma1dosage").focus();
        };

        $scope.pharma1takenpastno = function () {
            document.getElementById("pharma1pasttakenyes").checked = false;
            document.getElementById("pharma1pasttakenno").checked = true;
            document.getElementById("pharma1dosage").focus();
        };
        // This is for Pharma 1 //

        // This is for Pharma 2 //
        // Have you ever heard of Pharma 2 //
        $scope.pharma2everheardyes = function () {
            document.getElementById("pharma2heardyes").checked = true;
            document.getElementById("pharma2heardno").checked = false;
        };

        $scope.pharma2everheardno = function () {
            document.getElementById("pharma2heardyes").checked = false;
            document.getElementById("pharma2heardno").checked = true;
        };

        // Have you ever taken Pharma 2 before //
        $scope.pharma2evertakenyes = function () {
            document.getElementById("pharma2takenyes").checked = true;
            document.getElementById("pharma2takenno").checked = false;
        };

        $scope.pharma2evertakenno = function () {
            document.getElementById("pharma2takenyes").checked = false;
            document.getElementById("pharma2takenno").checked = true;
        };

        // Do you currently use Pharma 2 //
        $scope.pharma2curryes = function () {
            document.getElementById("pharma2currentlyyes").checked = true;
            document.getElementById("pharma2currentlyno").checked = false;
        };

        $scope.pharma2currno = function () {
            document.getElementById("pharma2currentlyyes").checked = false;
            document.getElementById("pharma2currentlyno").checked = true;
        };

        // If No: Have you taken it in the past //
        $scope.pharma2takenpastyes = function () {
            document.getElementById("pharma2pasttakenyes").checked = true;
            document.getElementById("pharma2pasttakenno").checked = false;
            document.getElementById("pharma2dosage").focus();
        };

        $scope.pharma2takenpastno = function () {
            document.getElementById("pharma2pasttakenyes").checked = false;
            document.getElementById("pharma2pasttakenno").checked = true;
            document.getElementById("pharma2dosage").focus();
        };
        // This is for Pharma 2 //


        // This is for Pharma 3 //
        // Have you ever heard of Pharma 3 //
        $scope.pharma3everheardyes = function () {
            document.getElementById("pharma3heardyes").checked = true;
            document.getElementById("pharma3heardno").checked = false;
        };

        $scope.pharma3everheardno = function () {
            document.getElementById("pharma3heardyes").checked = false;
            document.getElementById("pharma3heardno").checked = true;
        };

        // Have you ever taken Pharma 3 before //
        $scope.pharma3evertakenyes = function () {
            document.getElementById("pharma3takenyes").checked = true;
            document.getElementById("pharma3takenno").checked = false;
        };

        $scope.pharma3evertakenno = function () {
            document.getElementById("pharma3takenyes").checked = false;
            document.getElementById("pharma3takenno").checked = true;
        };

        // Do you currently use Pharma 3 //
        $scope.pharma3curryes = function () {
            document.getElementById("pharma3currentlyyes").checked = true;
            document.getElementById("pharma3currentlyno").checked = false;
        };

        $scope.pharma3currno = function () {
            document.getElementById("pharma3currentlyyes").checked = false;
            document.getElementById("pharma3currentlyno").checked = true;
        };

        // If No: Have you taken it in the past //
        $scope.pharma3takenpastyes = function () {
            document.getElementById("pharma3pasttakenyes").checked = true;
            document.getElementById("pharma3pasttakenno").checked = false;
            document.getElementById("pharma3dosage").focus();
        };

        $scope.pharma3takenpastno = function () {
            document.getElementById("pharma3pasttakenyes").checked = false;
            document.getElementById("pharma3pasttakenno").checked = true;
            document.getElementById("pharma3dosage").focus();
        };
        // This is for Pharma 3 //
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
                document.getElementById('speprovider')['value'] = '';
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
                document.getElementById("sicklecellTraits").checked = false;
                document.getElementById("sicklecellnotsure").checked = false;
                document.getElementById("sicklecellother").checked = false;

                document.getElementById('medication')['value'] = '';
                document.getElementById('medication3')['value'] = '';
                document.getElementById('medication4')['value'] = '';
                document.getElementById('medication5')['value'] = '';

                // This is for Hydroxyurea //
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
                // This is for Hydroxyurea //

                // This is for Pharma 1 //
                // Have you ever heard of Pharma 1 //
                document.getElementById("pharma1heardyes").checked = false;
                document.getElementById("pharma1heardno").checked = false;

                // Have you ever taken Pharma 1 before //
                document.getElementById("pharma1takenyes").checked = false;
                document.getElementById("pharma1takenno").checked = false;

                // Do you currently use Hydroxyurea //
                document.getElementById("pharma1currentlyyes").checked = false;
                document.getElementById("pharma1currentlyno").checked = false;

                // If No: Have you taken it in the past //
                document.getElementById("pharma1pasttakenyes").checked = false;
                document.getElementById("pharma1pasttakenno").checked = false;

                document.getElementById('pharma1dosage')['value'] = '';
                document.getElementById('pharma1dosageunknown')['value'] = '';
                document.getElementById('pharma1capsulescolor')['value'] = '';
                document.getElementById('pharma1datelasttaken')['value'] = '';
                document.getElementById('pharma1datepickedup')['value'] = '';
                // This is for Pharma 1 //

                // This is for Pharma 2 //
                // Have you ever heard of Pharma 2 //
                document.getElementById("pharma2heardyes").checked = false;
                document.getElementById("pharma2heardno").checked = false;

                // Have you ever taken Pharma 2 before //
                document.getElementById("pharma2takenyes").checked = false;
                document.getElementById("pharma2takenno").checked = false;

                // Do you currently use Hydroxyurea //
                document.getElementById("pharma2currentlyyes").checked = false;
                document.getElementById("pharma2currentlyno").checked = false;

                // If No: Have you taken it in the past //
                document.getElementById("pharma2pasttakenyes").checked = false;
                document.getElementById("pharma2pasttakenno").checked = false;

                document.getElementById('pharma2dosage')['value'] = '';
                document.getElementById('pharma2dosageunknown')['value'] = '';
                document.getElementById('pharma2capsulescolor')['value'] = '';
                document.getElementById('pharma2datelasttaken')['value'] = '';
                document.getElementById('phrama2datepickedup')['value'] = '';
                // This is for Pharma 2 //

                // This is for Pharma 3 //
                // Have you ever heard of Pharma 3 //
                document.getElementById("pharma3heardyes").checked = false;
                document.getElementById("pharma3heardno").checked = false;

                // Have you ever taken Pharma 3 before //
                document.getElementById("pharma3takenyes").checked = false;
                document.getElementById("pharma3takenno").checked = false;

                // Do you currently use Hydroxyurea //
                document.getElementById("pharma3currentlyyes").checked = false;
                document.getElementById("pharma3currentlyno").checked = false;

                // If No: Have you taken it in the past //
                document.getElementById("pharma3pasttakenyes").checked = false;
                document.getElementById("pharma3pasttakenno").checked = false;

                document.getElementById('pharma3dosage')['value'] = '';
                document.getElementById('pharma3dosageunknown')['value'] = '';
                document.getElementById('pharma3capsulescolor')['value'] = '';
                document.getElementById('pharma3datelasttaken')['value'] = '';
                document.getElementById('phrama3datepickedup')['value'] = '';
                // This is for Pharma 3 //

                //alert("This person is already exist in the Database");
                swal("Exist!", "This person is already exist in the Database!", {
                    className: "swal-title"
                });

            } else {
                let clientresideinruralid;
                let sicklecelltypeid;
                let hydroxyureaheardid;
                let hydroxyureatakenid;
                let hydroxyureacurrentlyid;
                let hydroxyureapasttakenid;

                let pharma1heardid;
                let pharma1takenid;
                let pharma1currentlyid;
                let pharma1pasttakenid;

                let pharma2heardid;
                let pharma2takenid;
                let pharma2currentlyid;
                let pharma2pasttakenid;

                let pharma3heardid;
                let pharma3takenid;
                let pharma3currentlyid;
                let pharma3pasttakenid;
                let deceasedoption;

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
                } else if (document.getElementById("sicklecellTraits").checked === true) {
                    sicklecelltypeid = "Traits";
                } else if (document.getElementById("sicklecellnotsure").checked === true) {
                    sicklecelltypeid = "NotSure";
                } else if (document.getElementById("sicklecellother").checked === true) {
                    sicklecelltypeid = "Other";
                } else {
                    sicklecelltypeid = "";
                }
                // this is for sicklecelltype Mobile Phone//
                if (document.getElementById('sicklecellss2').checked === true || document.getElementById('sicklecellss').checked === true) {
                    sicklecelltypeid = "SS";
                } else if (document.getElementById("sicklecellsc2").checked === true || document.getElementById("sicklecellsc").checked === true) {
                    sicklecelltypeid = "SC";
                } else if (document.getElementById("sicklecellThal2").checked === true || document.getElementById("sicklecellThal").checked === true) {
                    sicklecelltypeid = "SBThal";
                } else if (document.getElementById("sicklecellThal02").checked === true || document.getElementById("sicklecellThal0").checked === true) {
                    sicklecelltypeid = "SBThal0";
                } else if (document.getElementById("sicklecellTraits2").checked === true || document.getElementById("sicklecellTraits").checked === true) {
                    sicklecelltypeid = "Traits";
                } else if (document.getElementById("sicklecellnotsure2").checked === true || document.getElementById("sicklecellnotsure").checked === true) {
                    sicklecelltypeid = "NotSure";
                } else if (document.getElementById("sicklecellother2").checked === true || document.getElementById("sicklecellother").checked === true) {
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
                // Have you ever heard of Pharma 1 Desktop//
                if (document.getElementById('pharma1heardyes').checked === true) {
                    pharma1heardid = "yes";
                } else if (document.getElementById('pharma1heardno').checked === true) {
                    pharma1heardid = "no";
                } else {
                    pharma1heardid = "";
                }
                // Have you ever heard of Pharma 2 Desktop//
                if (document.getElementById('pharma2heardyes').checked === true) {
                    pharma3heardid = "yes";
                } else if (document.getElementById('pharma2heardno').checked === true) {
                    pharma2heardid = "no";
                } else {
                    pharma2heardid = "";
                }
                // Have you ever heard of Pharma 3 Desktop//
                if (document.getElementById('pharma3heardyes').checked === true) {
                    pharma3heardid = "yes";
                } else if (document.getElementById('pharma2heardno').checked === true) {
                    pharma3heardid = "no";
                } else {
                    pharma3heardid = "";
                }

                // Have you ever heard of Hydroxyurea Mobile Phone//
                if (document.getElementById('hydroxyureaheardyes2').checked === true || document.getElementById('hydroxyureaheardyes').checked === true) {
                    hydroxyureaheardid = "yes";
                } else if (document.getElementById('hydroxyureaheardno2').checked === true) {
                    hydroxyureaheardid = "no";
                } else {
                    hydroxyureaheardid = "";
                }

                // Have you ever heard of Pharma 1 Mobile Phone//
                //if (document.getElementById('phrama1heardyes2').checked === true) {
                //    pharma1heardid = "yes";
                //} else if (document.getElementById('phrama1heardno2').checked === true) {
                //    pharma1heardid = "no";
                //} else {
                //    pharma1heardid = "";
                //}

                // Have you ever heard of Pharma 2 Mobile Phone//
                //if (document.getElementById('phrama2heardyes2').checked === true) {
                //    pharma2heardid = "yes";
                //} else if (document.getElementById('phrama2heardno2').checked === true) {
                //    pharma2heardid = "no";
                //} else {
                //    pharma2heardid = "";
                //}


                // Have you ever taken Hydroxyurea before Desktop//
                if (document.getElementById('hydroxyureatakenyes').checked === true) {
                    hydroxyureatakenid = "yes";
                } else if (document.getElementById('hydroxyureatakenno').checked === true) {
                    hydroxyureatakenid = "no";
                } else {
                    hydroxyureatakenid = "";
                }
                // Have you ever taken Pharma 1 before Desktop//
                if (document.getElementById('pharma1takenyes').checked === true) {
                    pharma1takenid = "yes";
                } else if (document.getElementById('pharma1takenno').checked === true) {
                    pharma1takenid = "no";
                } else {
                    pharma1takenid = "";
                }
                // Have you ever taken Pharma 2 before Desktop//
                if (document.getElementById('pharma2takenyes').checked === true) {
                    pharma2takenid = "yes";
                } else if (document.getElementById('pharma2takenno').checked === true) {
                    pharma2takenid = "no";
                } else {
                    pharma2takenid = "";
                }
                // Have you ever taken Pharma 3 before Desktop//
                if (document.getElementById('pharma3takenyes').checked === true) {
                    pharma3takenid = "yes";
                } else if (document.getElementById('pharma3takenno').checked === true) {
                    pharma3takenid = "no";
                } else {
                    pharma3takenid = "";
                }

                // Have you ever taken Hydroxyurea before Mobile Phone//
                if (document.getElementById('hydroxyureatakenyes2').checked === true || document.getElementById('hydroxyureatakenyes').checked === true) {
                    hydroxyureatakenid = "yes";
                } else if (document.getElementById('hydroxyureatakenno2').checked === true) {
                    hydroxyureatakenid = "no";
                } else {
                    hydroxyureatakenid = "";
                }

                // Have you ever taken Pharma 1 before Mobile Phone//
                //if (document.getElementById('phrama1takenyes2').checked === true) {
                //    pharma1takenid = "yes";
                //} else if (document.getElementById('phrama1takenno2').checked === true) {
                //    pharma1takenid = "no";
                //} else {
                //    pharma1takenid = "";
                //}

                // Have you ever taken Pharma 2 before Mobile Phone//
                //if (document.getElementById('phrama2takenyes2').checked === true) {
                //    pharma2takenid = "yes";
                //} else if (document.getElementById('phrama2takenno2').checked === true) {
                //    pharma2takenid = "no";
                //} else {
                //    pharma2takenid = "";
                //}


                // Do you currently use Hydroxyurea Desktop 
                if (document.getElementById('hydroxyureacurrentlyyes').checked === true) {
                    hydroxyureacurrentlyid = "yes";
                } else if (document.getElementById('hydroxyureacurrentlyno').checked === true) {
                    hydroxyureacurrentlyid = "no";
                } else {
                    hydroxyureacurrentlyid = "";
                }
                // Do you currently use Pharma 1 Desktop 
                if (document.getElementById('pharma1currentlyyes').checked === true) {
                    pharma1currentlyid = "yes";
                } else if (document.getElementById('pharma1currentlyno').checked === true) {
                    pharma1currentlyid = "no";
                } else {
                    pharma1currentlyid = "";
                }
                // Do you currently use Pharma 2 Desktop 
                if (document.getElementById('pharma2currentlyyes').checked === true) {
                    pharma2currentlyid = "yes";
                } else if (document.getElementById('pharma2currentlyno').checked === true) {
                    pharma2currentlyid = "no";
                } else {
                    pharma2currentlyid = "";
                }
                // Do you currently use Pharma 3 Desktop 
                if (document.getElementById('pharma3currentlyyes').checked === true) {
                    pharma3currentlyid = "yes";
                } else if (document.getElementById('pharma3currentlyno').checked === true) {
                    pharma3currentlyid = "no";
                } else {
                    pharma3currentlyid = "";
                }

                // Do you currently use Hydroxyurea Mobile Phone
                if (document.getElementById('hydroxyureacurrentlyyes2').checked === true || document.getElementById('hydroxyureacurrentlyyes').checked === true) {
                    hydroxyureacurrentlyid = "yes";
                } else if (document.getElementById('hydroxyureacurrentlyno2').checked === true || document.getElementById('hydroxyureacurrentlyno').checked === true) {
                    hydroxyureacurrentlyid = "no";
                } else {
                    hydroxyureacurrentlyid = "";
                }

                // Do you currently use Pharma 1 Mobile Phone
                //if (document.getElementById('pharma1currentlyyes2').checked === true) {
                //    pharma1currentlyid = "yes";
                //} else if (document.getElementById('pharma1currentlyno2').checked === true) {
                //    pharma1currentlyid = "no";
                //} else {
                //    pharma1currentlyid = "";
                //}

                // Do you currently use Pharma 2 Mobile Phone
                //if (document.getElementById('pharma2currentlyyes2').checked === true) {
                //    pharma2currentlyid = "yes";
                //} else if (document.getElementById('pharma2currentlyno2').checked === true) {
                //    pharma2currentlyid = "no";
                //} else {
                //    pharma2currentlyid = "";
                //}

                // If No: Have you taken it in the past Desktop//
                if (document.getElementById('hydroxyureapasttakenyes').checked === true) {
                    hydroxyureapasttakenid = "yes";
                } else if (document.getElementById('hydroxyureapasttakenno').checked === true) {
                    hydroxyureapasttakenid = "no";
                } else {
                    hydroxyureapasttakenid = "";
                }
                // If No: Have you taken it in the past Desktop//
                if (document.getElementById('pharma1pasttakenyes').checked === true) {
                    pharma1pasttakenid = "yes";
                } else if (document.getElementById('pharma1pasttakenno').checked === true) {
                    pharma1pasttakenid = "no";
                } else {
                    pharma1pasttakenid = "";
                }
                // If No: Have you taken it in the past Desktop//
                if (document.getElementById('pharma2pasttakenyes').checked === true) {
                    pharma2pasttakenid = "yes";
                } else if (document.getElementById('pharma2pasttakenno').checked === true) {
                    pharma2pasttakenid = "no";
                } else {
                    pharma2pasttakenid = "";
                }
                // If No: Have you taken it in the past Desktop//
                if (document.getElementById('pharma3pasttakenyes').checked === true) {
                    pharma3pasttakenid = "yes";
                } else if (document.getElementById('pharma3pasttakenno').checked === true) {
                    pharma3pasttakenid = "no";
                } else {
                    pharma3pasttakenid = "";
                }


                // If No: Have you taken it in the past Mobile Phone//
                if (document.getElementById('hydroxyureapasttakenyes2').checked === true || document.getElementById('hydroxyureapasttakenyes').checked === true) {
                    hydroxyureapasttakenid = "yes";
                } else if (document.getElementById('hydroxyureapasttakenno2').checked === true || document.getElementById('hydroxyureapasttakenno').checked === true) {
                    hydroxyureapasttakenid = "no";
                } else {
                    hydroxyureapasttakenid = "";
                }

                deceasedoption = "";
                if (document.getElementById("deceasedyes").checked === true) {
                    deceasedoption = true;
                } else {
                    deceasedoption = false;
                }

                // If No: Have you taken it in the past Mobile Phone//
                //if (document.getElementById('pharma1pasttakenyes2').checked === true) {
                //    pharma1pasttakenid = "yes";
                //} else if (document.getElementById('pharma1pasttakenno2').checked === true) {
                //    pharma1pasttakenid = "no";
                //} else {
                //    pharma1pasttakenid = "";
                //}

                // If No: Have you taken it in the past Mobile Phone//
                //if (document.getElementById('pharma2pasttakenyes2').checked === true) {
                //    pharma2pasttakenid = "yes";
                //} else if (document.getElementById('pharma2pasttakenno2').checked === true) {
                //    pharma2pasttakenid = "no";
                //} else {
                //    pharma2pasttakenid = "";
                //}

                datavalue = {
                    'Clientidx': lblclient,
                    'ClientID': document.getElementById('clientid')['value'],
                    'LastName': document.getElementById('lname')['value'],
                    'FirstName': document.getElementById('fname')['value'],
                    'Middle_Initial': document.getElementById('mi')['value'],
                    'UniqueID': document.getElementById('uniqueid')['value'],
                    'DOB': document.getElementById('dob')['value'],
                    'Age': document.getElementById('age')['value'],
                    'AgeGroup': document.getElementById('agegroup')['value'],
                    'Ageat': document.getElementById('ageat')['value'],
                    'Gender': document.getElementById('gender')['value'],
                    'Race': document.getElementById('race')['value'],
                    'Ethnicity': document.getElementById('ethnicity')['value'],
                    'Eligibility': document.getElementById('eligibility')['value'],
                    'SSN': document.getElementById('sssno')['value'],
                    'Deceased': deceasedoption,
                    'CountyCode': document.getElementById('countrycode')['value'],
                    'CountyCodeDescription': document.getElementById('countrycodedes')['value'],
                    'PhoneNumber': document.getElementById('cpnumber')['value'],
                    'SickleCellDiagnosis': document.getElementById('sickdiag')['value'],
                    'FullStreetAddress': document.getElementById('address')['value'],
                    'FullStreetAddress2': document.getElementById('address2')['value'],
                    'City': document.getElementById('city')['value'],
                    'State': document.getElementById('state')['value'],
                    'ZipCode': document.getElementById('zipcode')['value'],
                    'HomePhone': document.getElementById('hphone')['value'],
                    'WorkPhone': document.getElementById('wphone')['value'],
                    'PMPProviderName': document.getElementById('pmppro')['value'],
                    'Specialist': document.getElementById('speprovider')['value'],
                    'CCUCase': document.getElementById('ccucase')['value'],
                    'Email_Address': document.getElementById('email')['value'],
                    'ClientresideinruralID': clientresideinruralid,
                    'Nameofmother': document.getElementById('nameofmother')['value'],
                    'Address_Of_Mother': document.getElementById('motheraddress')['value'],
                    'Telephone_Of_Mother': document.getElementById('mothertel')['value'],
                    'Nameoffather': document.getElementById('nameoffather')['value'],
                    'Address_Of_Father': document.getElementById('fatheraddress')['value'],
                    'Telephone_Of_Father': document.getElementById('fathertel')['value'],
                    'Nameofguardian': document.getElementById('nameofguardian')['value'],
                    'Address_Of_Guardian': document.getElementById('guardianaddress')['value'],
                    'Guardian_Telephone': document.getElementById('guardiantel')['value'],
                    'Emergency_Contact1': document.getElementById('emercont1')['value'],
                    'Emergency_Contact1_HomePhone': document.getElementById('emercont1homephone')['value'],
                    'Emergency_Contact1_CellPhone': document.getElementById('emercont1cellphone')['value'],
                    'Emergency_Contact2': document.getElementById('emercont2')['value'],
                    'Emergency_Contact2_HomePhone': document.getElementById('emercont2homephone')['value'],
                    'Emergency_Contact2_CellPhone': document.getElementById('emercont2cellphone')['value'],
                    'SicklecelltypeID': sicklecelltypeid,
                    'Medication': document.getElementById('medication')['value'],
                    'Medication2': document.getElementById('medication3')['value'],
                    'Medication3': document.getElementById('medication4')['value'],
                    'Medication4': document.getElementById('medication5')['value'],
                    'HydroxyureaheardID': hydroxyureaheardid,
                    'HydroxyureatakenID': hydroxyureatakenid,
                    'HydroxyureacurrentlyID': hydroxyureacurrentlyid,
                    'HydroxyureapasttakenID': hydroxyureapasttakenid,
                    'Hydroxyureadosage': document.getElementById('hydroxyureadosage')['value'],
                    'Hydroxyureadosageunknown': document.getElementById('hydroxyureadosageunknown')['value'],
                    'Hydroxyureacapsulescolor': document.getElementById('hydroxyureacapsulescolor')['value'],
                    'Hydroxyureadatelasttaken': document.getElementById('hydroxyureadatelasttaken')['value'],
                    'Hydroxyureadatepickedup': document.getElementById('hydroxyureadatepickedup')['value'],
                    'Pharma1heardID': pharma1heardid,
                    'Pharma1takenID': pharma1takenid,
                    'Pharma1currentlyID': pharma1currentlyid,
                    'Pharma1pasttakenID': pharma1pasttakenid,
                    'Pharma1dosage': document.getElementById('pharma1dosage')['value'],
                    'Pharma1dosageunknown': document.getElementById('pharma1dosageunknown')['value'],
                    'Pharma1capsulescolor': document.getElementById('pharma1capsulescolor')['value'],
                    'Pharma1datelasttaken': document.getElementById('pharma1datelasttaken')['value'],
                    'Pharma1datepickedup': document.getElementById('pharma1datepickedup')['value'],
                    'Pharma2heardID': pharma2heardid,
                    'Pharma2takenID': pharma2takenid,
                    'Pharma2currentlyID': pharma2currentlyid,
                    'Pharma2pasttakenID': pharma2pasttakenid,
                    'Pharma2dosage': document.getElementById('pharma2dosage')['value'],
                    'Pharma2dosageunknown': document.getElementById('pharma2dosageunknown')['value'],
                    'Pharma2capsulescolor': document.getElementById('pharma2capsulescolor')['value'],
                    'Pharma2datelasttaken': document.getElementById('pharma2datelasttaken')['value'],
                    'Pharma2datepickedup': document.getElementById('pharma2datepickedup')['value'],
                    'Pharma3heardID': pharma3heardid,
                    'Pharma3takenID': pharma3takenid,
                    'Pharma3currentlyID': pharma3currentlyid,
                    'Pharma3pasttakenID': pharma3pasttakenid,
                    'Pharma3dosage': document.getElementById('pharma3dosage')['value'],
                    'Pharma3dosageunknown': document.getElementById('pharma3dosageunknown')['value'],
                    'Pharma3capsulescolor': document.getElementById('pharma3capsulescolor')['value'],
                    'Pharma3datelasttaken': document.getElementById('pharma3datelasttaken')['value'],
                    'Pharma3datepickedup': document.getElementById('pharma3datepickedup')['value'],
                    'Globalid': globalID
                };
                var one = document.getElementById('pharma3datelasttaken')['value'];
                var two = document.getElementById('pharma3datepickedup')['value'];
                console.log(datavalue);
            }

            if (globalfile !== "Edited") {
                $.ajax({
                    url: '/Home/Save', type: 'POST', data: JSON.stringify(datavalue), dataType: 'json', contentType: "application/json", success: function (response) {
                        //alert("Successfully Save");
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

                        document.getElementById('deceasedyes').checked = false;
                        document.getElementById('deceasedno').checked = false;

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
                        document.getElementById('speprovider')['value'] = '';
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
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;

                        document.getElementById('medication')['value'] = '';
                        document.getElementById('medication3')['value'] = '';
                        document.getElementById('medication4')['value'] = '';
                        document.getElementById('medication5')['value'] = '';

                        // this is for Hydroxyurea //
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
                        // this is for Hydroxyurea //

                        // this is for Phrama 1 //
                        // Have you ever heard of Phrama 1 //
                        document.getElementById("pharma1heardyes").checked = false;
                        document.getElementById("pharma1heardno").checked = false;

                        // Have you ever taken Phrama 1 before //
                        document.getElementById("pharma1takenyes").checked = false;
                        document.getElementById("pharma1takenno").checked = false;

                        // Do you currently use Phrama 1 //
                        document.getElementById("pharma1currentlyyes").checked = false;
                        document.getElementById("pharma1currentlyno").checked = false;

                        // If No: Have you taken it in the past //
                        document.getElementById("pharma1pasttakenyes").checked = false;
                        document.getElementById("pharma1pasttakenno").checked = false;

                        document.getElementById('pharma1dosage')['value'] = '';
                        document.getElementById('pharma1dosageunknown')['value'] = '';
                        document.getElementById('pharma1capsulescolor')['value'] = '';
                        document.getElementById('pharma1datelasttaken')['value'] = '';
                        document.getElementById('pharma1datepickedup')['value'] = '';
                        // this is for Phrama 1 //

                        // this is for Phrama 2 //
                        // Have you ever heard of Phrama 2 //
                        document.getElementById("pharma2heardyes").checked = false;
                        document.getElementById("pharma2heardno").checked = false;

                        // Have you ever taken Phrama 2 before //
                        document.getElementById("pharma2takenyes").checked = false;
                        document.getElementById("pharma2takenno").checked = false;

                        // Do you currently use Phrama 2 //
                        document.getElementById("pharma2currentlyyes").checked = false;
                        document.getElementById("pharma2currentlyno").checked = false;

                        // If No: Have you taken it in the past //
                        document.getElementById("pharma2pasttakenyes").checked = false;
                        document.getElementById("pharma2pasttakenno").checked = false;

                        document.getElementById('pharma2dosage')['value'] = '';
                        document.getElementById('pharma2dosageunknown')['value'] = '';
                        document.getElementById('pharma2capsulescolor')['value'] = '';
                        document.getElementById('pharma2datelasttaken')['value'] = '';
                        document.getElementById('pharma2datepickedup')['value'] = '';
                        // this is for Phrama 2 //


                        // this is for Phrama 3 //
                        // Have you ever heard of Phrama 3 //
                        document.getElementById("pharma3heardyes").checked = false;
                        document.getElementById("pharma3heardno").checked = false;

                        // Have you ever taken Phrama 3 before //
                        document.getElementById("pharma3takenyes").checked = false;
                        document.getElementById("pharma3takenno").checked = false;

                        // Do you currently use Phrama 3 //
                        document.getElementById("pharma3currentlyyes").checked = false;
                        document.getElementById("pharma3currentlyno").checked = false;

                        // If No: Have you taken it in the past //
                        document.getElementById("pharma3pasttakenyes").checked = false;
                        document.getElementById("pharma3pasttakenno").checked = false;

                        document.getElementById('pharma3dosage')['value'] = '';
                        document.getElementById('pharma3dosageunknown')['value'] = '';
                        document.getElementById('pharma3capsulescolor')['value'] = '';
                        document.getElementById('pharma3datelasttaken')['value'] = '';
                        document.getElementById('pharma3datepickedup')['value'] = '';
                        // this is for Phrama 3 //


                        document.getElementById('clientid').focus();

                        //alert("Successfully Save");
                        swal("Saved!", "Successfully Saved!", {
                            className: "swal-title"
                        });

                        ////////////////////////////////////////////////////////
                    }, error: function (response) {
                        //alert('Registration failed');
                    }
                });
            }
        } else {
            //alert("You should fill-up all the feilds first");
            document.getElementById('fname').focus();

            swal("Incomplete form!", "Please complete form!", {
                className: "swal-title"
            });
        }

    };

    if (sPage.trim() === "Entry" || sPage.trim() === "entry") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        var isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
        if (isMobile2 === true) {
            document.getElementById("searching").style.visibility = "hidden";
            document.getElementById("test").style.width = "310px";
            document.getElementById("test").style.maxWidth = "310px";
        } else {
            //document.getElementById("searching").style.visibility = "visible";
        }

        document.getElementById("deceasedyes").checked = false;
        document.getElementById("deceasedno").checked = false;
        document.getElementById("update").style.visibility = "hidden";

        $scope.Search = function () {
            //document.getElementById("searching").style.visibility = "visible";

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


        $scope.empname = function () {
            document.getElementById("firstname")["value"] = "";
            document.getElementById("lastname")["value"] = "";
            document.getElementById("dob1")["value"] = "";
            document.getElementById("searchclient").focus();
        };

        $scope.empclientid = function () {
            document.getElementById("searchclient")["value"] = "";
        };

        $scope.buttonone = function () {
            searchoption = 3;
            document.getElementById("firstname")["value"] = "";
            document.getElementById("lastname")["value"] = "";
            document.getElementById("dob1")["value"] = "";
        };
        $scope.buttontwo = function () {
            searchoption = 4;
            document.getElementById("searchclient")["value"] = "";
        };

        //$scope.Select = function () {           
        $scope.Clientsearch = function () {
            globalID = localStorage.getItem("vGlobalid");

            let clientnum;
            //clientnum = JSON.parse(document.getElementById("searchclient")["value"]);
            selected = {
                'Clientseacrh': document.getElementById("searchclient")["value"],
                'ClientID': document.getElementById("searchclient")["value"],
                'FirstName': document.getElementById("firstname")["value"],
                'LastName': document.getElementById("lastname")["value"],
                'DOB': document.getElementById("dob1")["value"]
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

            if (document.getElementById("searchclient")["value"] !== "" || document.getElementById("firstname")["value"] !== "") {
                $http({ method: "POST", url: "/Home/Select", data: JSON.stringify(selected), dataType: 'json', contentType: "application/json" }).success(function (response) {
                    console.log(response);
                    if (response[0].ClientID === 0 || response[0].ClientID === null) {
                        swal("Not Found!", "This ClientID does not exist in the Database!", {
                            className: "swal-title"
                        });
                    }
                    document.getElementById('clientid')['value'] = response["0"].ClientID;
                    document.getElementById('lname')['value'] = response["0"].LastName;
                    document.getElementById('fname')['value'] = response["0"].FirstName;
                    document.getElementById('mi')['value'] = response["0"].Middle_Initial;
                    document.getElementById('uniqueid')['value'] = response["0"].UniqueID;

                    if (response[0].ClientID === 0 || response[0].ClientID === null) {
                        document.getElementById('dob')['value'] = "";
                    }
                    else {
                        document.getElementById('dob')['value'] = formatDate(response["0"].DOB);
                    }

                    document.getElementById('age')['value'] = response["0"].Age;
                    document.getElementById('agegroup')['value'] = response["0"].AgeGroup;
                    document.getElementById('ageat')['value'] = response["0"].Ageat;
                    document.getElementById('gender')['value'] = response["0"].Gender;
                    document.getElementById('race')['value'] = response["0"].Race;
                    if (response["0"].Ethnicity === "Not Hispanic") {
                        document.getElementById('ethnicity')['value'] = "Not Hispanic / Latino Origin";
                    } else { document.getElementById('ethnicity')['value'] = response["0"].Ethnicity; }
                    document.getElementById('eligibility')['value'] = response["0"].Eligibility;
                    document.getElementById('sssno')['value'] = response["0"].SSN;

                    if (response["0"].CountyCode === "" || response["0"].CountyCode === null) {
                        document.getElementById('countrycode')['value'] = response["0"].CountryCode2;
                    } else { document.getElementById('countrycode')['value'] = response["0"].CountyCode; }

                    document.getElementById('countrycodedes')['value'] = response["0"].CountyCodeDescription;

                    //if (response["0"].Mobile_Number === "" || response["0"].Mobile_Number === null) {
                    //    document.getElementById('cpnumber')['value'] = response["0"].PhoneNumber2;
                    //} else { document.getElementById('cpnumber')['value'] = response["0"].Mobile_Number; }    

                    if (response["0"].PhoneNumber === "" || response["0"].PhoneNumber === null) {
                        document.getElementById('cpnumber')['value'] = response["0"].PhoneNumber;
                    } else { document.getElementById('cpnumber')['value'] = response["0"].PhoneNumber; }

                    document.getElementById('sickdiag')['value'] = response["0"].SickleCellDiagnosis;
                    document.getElementById('address')['value'] = response["0"].FullStreetAddress;
                    document.getElementById('address2')['value'] = response["0"].FullStreetAddress2;
                    document.getElementById('city')['value'] = response["0"].City;
                    document.getElementById('state')['value'] = response["0"].State;

                    if (response["0"].ZipCode === "" || response["0"].ZipCode === null) {
                        document.getElementById('zipcode')['value'] = response["0"].ZipCode2;
                    } else { document.getElementById('zipcode')['value'] = response["0"].ZipCode; }

                    document.getElementById('hphone')['value'] = response["0"].HomePhone;
                    document.getElementById('wphone')['value'] = response["0"].WorkPhone;

                    document.getElementById('pmppro')['value'] = response["0"].PMPProviderName;
                    document.getElementById('email')['value'] = response["0"].Email_Address;
                    document.getElementById('speprovider')['value'] = response["0"].Specialist;
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
                    document.getElementById('motheraddress')['value'] = response["0"].Address_Of_Mother;
                    document.getElementById('mothertel')['value'] = response["0"].Telephone_Of_Mother;
                    document.getElementById('nameoffather')['value'] = response["0"].Nameoffather;
                    document.getElementById('fatheraddress')['value'] = response["0"].Address_Of_Father;
                    document.getElementById('fathertel')['value'] = response["0"].Telephone_Of_Father;
                    document.getElementById('nameofguardian')['value'] = response["0"].Nameofguardian;
                    document.getElementById('guardianaddress')['value'] = response["0"].Address_Of_Guardian;
                    document.getElementById('guardiantel')['value'] = response["0"].Guardian_Telephone;
                    document.getElementById('emercont1')['value'] = response["0"].Emergency_Contact1;
                    document.getElementById('emercont1homephone')['value'] = response["0"].Emergency_Contact1_HomePhone;
                    document.getElementById('emercont1cellphone')['value'] = response["0"].Emergency_Contact1_CellPhone;
                    document.getElementById('emercont2')['value'] = response["0"].Emergency_Contact2;
                    document.getElementById('emercont2homephone')['value'] = response["0"].Emergency_Contact2_HomePhone;
                    document.getElementById('emercont2cellphone')['value'] = response["0"].Emergency_Contact2_CellPhone;

                    if (response["0"].SicklecelltypeID === "SS") {
                        document.getElementById('sicklecellss').checked = true;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;

                    } else if (response["0"].SicklecelltypeID === "SC") {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = true;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;

                    } else if (response["0"].SicklecelltypeID === "SBThal") {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = true;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;

                    } else if (response["0"].SicklecelltypeID === "SBThal0") {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = true;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;

                    } else if (response["0"].SicklecelltypeID === "Traits") {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = true;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;

                    } else if (response["0"].SicklecelltypeID === "NotSure") {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = true;
                        document.getElementById("sicklecellother").checked = false;
                    } else if (response["0"].SicklecelltypeID === "Other") {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = true;
                    } else {
                        document.getElementById('sicklecellss').checked = false;
                        document.getElementById("sicklecellsc").checked = false;
                        document.getElementById("sicklecellThal").checked = false;
                        document.getElementById("sicklecellThal0").checked = false;
                        document.getElementById("sicklecellTraits").checked = false;
                        document.getElementById("sicklecellnotsure").checked = false;
                        document.getElementById("sicklecellother").checked = false;
                    }

                    document.getElementById('medication')['value'] = response["0"].Medication;
                    document.getElementById('medication3')['value'] = response["0"].Medication2;
                    document.getElementById('medication4')['value'] = response["0"].Medication3;
                    document.getElementById('medication5')['value'] = response["0"].Medication4;

                    // this is for Hydroxyurea //
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
                    document.getElementById('hydroxyureadosage')['value'] = response["0"].Hydroxyureadosage;
                    document.getElementById('hydroxyureadosageunknown')['value'] = response["0"].Hydroxyureadosageunknown;
                    document.getElementById('hydroxyureacapsulescolor')['value'] = response["0"].Hydroxyureacapsulescolor;

                    document.getElementById('hydroxyureadatelasttaken')['value'] = response["0"].Hydroxyureadatelasttaken;
                    document.getElementById('hydroxyureadatepickedup')['value'] = response["0"].Hydroxyureadatepickedup;

                    // this is for Hydroxyurea //

                    // this is for Pharma 1 //
                    if (response["0"].Pharma1heardID === "yes") {
                        document.getElementById("pharma1heardyes").checked = true;
                        document.getElementById("pharma1heardno").checked = false;
                    } else if (response["0"].Pharma1heardID === "no") {
                        document.getElementById("pharma1heardyes").checked = false;
                        document.getElementById("pharma1heardno").checked = true;
                    } else {
                        document.getElementById("pharma1heardyes").checked = false;
                        document.getElementById("pharma1heardno").checked = false;
                    }

                    if (response["0"].Pharma1takenID === "yes") {
                        document.getElementById("pharma1takenyes").checked = true;
                        document.getElementById("pharma1takenno").checked = false;
                    } else if (response["0"].Pharma1takenID === "no") {
                        document.getElementById("pharma1takenyes").checked = false;
                        document.getElementById("pharma1takenno").checked = true;
                    } else {
                        document.getElementById("pharma1takenyes").checked = false;
                        document.getElementById("pharma1takenno").checked = false;
                    }

                    if (response["0"].Pharma1currentlyID === "yes") {
                        document.getElementById("pharma1currentlyyes").checked = true;
                        document.getElementById("pharma1currentlyno").checked = false;
                    } else if (response["0"].Pharma1currentlyID === "no") {
                        document.getElementById("pharma1currentlyyes").checked = false;
                        document.getElementById("pharma1currentlyno").checked = true;
                    } else {
                        document.getElementById("pharma1currentlyyes").checked = false;
                        document.getElementById("pharma1currentlyno").checked = false;
                    }

                    if (response["0"].Pharma1pasttakenID === "yes") {
                        document.getElementById("pharma1pasttakenyes").checked = true;
                        document.getElementById("pharma1pasttakenno").checked = false;
                    } else if (response["0"].Pharma1pasttakenID === "no") {
                        document.getElementById("pharma1pasttakenyes").checked = false;
                        document.getElementById("pharma1pasttakenno").checked = true;
                    } else {
                        document.getElementById("pharma1pasttakenyes").checked = false;
                        document.getElementById("pharma1pasttakenno").checked = false;
                    }
                    document.getElementById('pharma1dosage')['value'] = response["0"].Pharma1dosage;
                    document.getElementById('pharma1dosageunknown')['value'] = response["0"].Pharma1dosageunknown;
                    document.getElementById('pharma1capsulescolor')['value'] = response["0"].Pharma1capsulescolor;

                    document.getElementById('pharma1datelasttaken')['value'] = response["0"].Pharma1datelasttaken;
                    document.getElementById('pharma1datepickedup')['value'] = response["0"].Pharma1datepickedup;

                    // this is for Pharma 1 //

                    // this is for Pharma 2 //
                    if (response["0"].Pharma2heardID === "yes") {
                        document.getElementById("pharma2heardyes").checked = true;
                        document.getElementById("pharma2heardno").checked = false;
                    } else if (response["0"].Pharma2heardID === "no") {
                        document.getElementById("pharma2heardyes").checked = false;
                        document.getElementById("pharma2heardno").checked = true;
                    } else {
                        document.getElementById("pharma2heardyes").checked = false;
                        document.getElementById("pharma2heardno").checked = false;
                    }

                    if (response["0"].Pharma2takenID === "yes") {
                        document.getElementById("pharma2takenyes").checked = true;
                        document.getElementById("pharma2takenno").checked = false;
                    } else if (response["0"].Pharma2takenID === "no") {
                        document.getElementById("pharma2takenyes").checked = false;
                        document.getElementById("pharma2takenno").checked = true;
                    } else {
                        document.getElementById("pharma2takenyes").checked = false;
                        document.getElementById("pharma2takenno").checked = false;
                    }

                    if (response["0"].Pharma2currentlyID === "yes") {
                        document.getElementById("pharma2currentlyyes").checked = true;
                        document.getElementById("pharma2currentlyno").checked = false;
                    } else if (response["0"].Pharma2currentlyID === "no") {
                        document.getElementById("pharma2currentlyyes").checked = false;
                        document.getElementById("pharma2currentlyno").checked = true;
                    } else {
                        document.getElementById("pharma2currentlyyes").checked = false;
                        document.getElementById("pharma2currentlyno").checked = false;
                    }

                    if (response["0"].Pharma2pasttakenID === "yes") {
                        document.getElementById("pharma2pasttakenyes").checked = true;
                        document.getElementById("pharma2pasttakenno").checked = false;
                    } else if (response["0"].Pharma2pasttakenID === "no") {
                        document.getElementById("pharma2pasttakenyes").checked = false;
                        document.getElementById("pharma2pasttakenno").checked = true;
                    } else {
                        document.getElementById("pharma2pasttakenyes").checked = false;
                        document.getElementById("pharma2pasttakenno").checked = false;
                    }
                    document.getElementById('pharma2dosage')['value'] = response["0"].Pharma2dosage;
                    document.getElementById('pharma2dosageunknown')['value'] = response["0"].Pharma2dosageunknown;
                    document.getElementById('pharma2capsulescolor')['value'] = response["0"].Pharma2capsulescolor;

                    document.getElementById('pharma2datelasttaken')['value'] = response["0"].Pharma2datelasttaken;
                    document.getElementById('pharma2datepickedup')['value'] = response["0"].Pharma2datepickedup;
                    // this is for Pharma 2 //

                    // this is for Pharma 3 //
                    if (response["0"].Pharma3heardID === "yes") {
                        document.getElementById("pharma3heardyes").checked = true;
                        document.getElementById("pharma3heardno").checked = false;
                    } else if (response["0"].Pharma3heardID === "no") {
                        document.getElementById("pharma3heardyes").checked = false;
                        document.getElementById("pharma3heardno").checked = true;
                    } else {
                        document.getElementById("pharma3heardyes").checked = false;
                        document.getElementById("pharma3heardno").checked = false;
                    }

                    if (response["0"].Pharma3takenID === "yes") {
                        document.getElementById("pharma3takenyes").checked = true;
                        document.getElementById("pharma3takenno").checked = false;
                    } else if (response["0"].Pharma3takenID === "no") {
                        document.getElementById("pharma3takenyes").checked = false;
                        document.getElementById("pharma3takenno").checked = true;
                    } else {
                        document.getElementById("pharma3takenyes").checked = false;
                        document.getElementById("pharma3takenno").checked = false;
                    }

                    if (response["0"].Pharma3currentlyID === "yes") {
                        document.getElementById("pharma3currentlyyes").checked = true;
                        document.getElementById("pharma3currentlyno").checked = false;
                    } else if (response["0"].Pharma3currentlyID === "no") {
                        document.getElementById("pharma3currentlyyes").checked = false;
                        document.getElementById("pharma3currentlyno").checked = true;
                    } else {
                        document.getElementById("pharma3currentlyyes").checked = false;
                        document.getElementById("pharma3currentlyno").checked = false;
                    }

                    if (response["0"].Pharma3pasttakenID === "yes") {
                        document.getElementById("pharma3pasttakenyes").checked = true;
                        document.getElementById("pharma3pasttakenno").checked = false;
                    } else if (response["0"].Pharma3pasttakenID === "no") {
                        document.getElementById("pharma3pasttakenyes").checked = false;
                        document.getElementById("pharma3pasttakenno").checked = true;
                    } else {
                        document.getElementById("pharma3pasttakenyes").checked = false;
                        document.getElementById("pharma3pasttakenno").checked = false;
                    }
                    document.getElementById('pharma3dosage')['value'] = response["0"].Pharma3dosage;
                    document.getElementById('pharma3dosageunknown')['value'] = response["0"].Pharma3dosageunknown;
                    document.getElementById('pharma3capsulescolor')['value'] = response["0"].Pharma3capsulescolor;

                    document.getElementById('pharma3datelasttaken')['value'] = response["0"].Pharma3datelasttaken;
                    document.getElementById('pharma3datepickedup')['value'] = response["0"].Pharma3datepickedup;
                    // this is for Pharma 3 //

                    var vinit = response["0"].Deceased.toString().trim();
                    if (vinit === "True") {
                        document.getElementById("deceasedyes").checked = true;
                        document.getElementById("deceasedno").checked = false;
                    } else {
                        document.getElementById("deceasedyes").checked = false;
                        document.getElementById("deceasedno").checked = true;
                    }

                    document.getElementById('lblclientid').innerHTML = response["0"].ClientID;

                    let stateofdata = "Edited";
                    localStorage.setItem("globalfile", stateofdata);

                    $scope.mlistshow = false;
                    $scope.inputboxshow = false;

                    //document.getElementById("test").style.width = "240px";
                    //document.getElementById("test").style.marginLeft = "-20px";

                    var isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
                    if (isMobile2 === true) {
                        //document.getElementById("searching").style.visibility = "hidden";
                    } else {
                        //document.getElementById("searching").style.visibility = "visible"; 
                    }

                    document.getElementById("update").style.visibility = "visible";
                    document.getElementById("save").style.visibility = "hidden";

                }, function (failed) {
                    swal("Failed!", "Selection failed!", {
                        className: "swal-title"
                    });
                });
            } else {
                if (searchoption === 3) {
                    swal("Re-Type!", "Please enter Client ID to continue search!", {
                        className: "swal-title"
                    });
                } else if (searchoption === 4) {
                    swal("Re-Type!", "Please enter last name, first name and DOB to continue search!", {
                        className: "swal-title"
                    });
                }
            }
        };
        //////////////////////////////////////

        $scope.deceasedopt1 = function () {
            if (document.getElementById("deceasedyes").checked === true) {
                document.getElementById("deceasedno").checked = false;
                document.getElementById("deceasedyes").checked = true;
            }
        };
        $scope.deceasedopt2 = function () {
            if (document.getElementById("deceasedno").checked === true) {
                document.getElementById("deceasedno").checked = true;
                document.getElementById("deceasedyes").checked = false;
            }
        };

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');        

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            event = event || window.event;
            if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }
        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 

    }

    $scope.Update = function () {

        if (globalRoleName === "Case Manager") {
            alert("You are not authorized to Update");
        } else {

            globalID = localStorage.getItem("vGlobalid");
            lblclient = document.getElementById('lblclientid').innerHTML;

            let clientresideinruralid;
            let sicklecelltypeid;
            let hydroxyureaheardid;
            let hydroxyureatakenid;
            let hydroxyureacurrentlyid;
            let hydroxyureapasttakenid;

            let pharma1heardid;
            let pharma1takenid;
            let pharma1currentlyid;
            let pharma1pasttakenid;

            let pharma2heardid;
            let pharma2takenid;
            let pharma2currentlyid;
            let pharma2pasttakenid;

            let pharma3heardid;
            let pharma3takenid;
            let pharma3currentlyid;
            let pharma3pasttakenid;
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
            } else if (document.getElementById("sicklecellTraits").checked === true) {
                sicklecelltypeid = "Traits";
            } else if (document.getElementById("sicklecellnotsure").checked === true) {
                sicklecelltypeid = "NotSure";
            } else if (document.getElementById("sicklecellother").checked === true) {
                sicklecelltypeid = "Other";
            } else {
                sicklecelltypeid = "";
            }

            // This is for Hydroxyurea //
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
            // This is for Hydroxyurea //


            // This is for Pharma 1 //
            // Have you ever heard of Pharma 1 //
            if (document.getElementById('pharma1heardyes').checked === true) {
                pharma1heardid = "yes";
            } else if (document.getElementById('pharma1heardno').checked === true) {
                pharma1heardid = "no";
            } else {
                pharma1heardid = "";
            }

            // Have you ever taken Pharma 1 before //
            if (document.getElementById('pharma1takenyes').checked === true) {
                pharma1takenid = "yes";
            } else if (document.getElementById('pharma1takenno').checked === true) {
                pharma1takenid = "no";
            } else {
                pharma1takenid = "";
            }

            // Do you currently use Pharma 1
            if (document.getElementById('pharma1currentlyyes').checked === true) {
                pharma1currentlyid = "yes";
            } else if (document.getElementById('pharma1currentlyno').checked === true) {
                pharma1currentlyid = "no";
            } else {
                pharma1currentlyid = "";
            }

            // If No: Have you taken it in the past //
            if (document.getElementById('pharma1pasttakenyes').checked === true) {
                pharma1pasttakenid = "yes";
            } else if (document.getElementById('pharma1pasttakenno').checked === true) {
                pharma1pasttakenid = "no";
            } else {
                pharma1pasttakenid = "";
            }
            // This is for Pharma 1 //


            // This is for Pharma 2 //
            // Have you ever heard of Pharma 2 //
            if (document.getElementById('pharma2heardyes').checked === true) {
                pharma2heardid = "yes";
            } else if (document.getElementById('pharma2heardno').checked === true) {
                pharma2heardid = "no";
            } else {
                pharma2heardid = "";
            }

            // Have you ever taken Pharma 2 before //
            if (document.getElementById('pharma2takenyes').checked === true) {
                pharma2takenid = "yes";
            } else if (document.getElementById('pharma2takenno').checked === true) {
                pharma2takenid = "no";
            } else {
                pharma2takenid = "";
            }

            // Do you currently use Pharma 2
            if (document.getElementById('pharma2currentlyyes').checked === true) {
                pharma2currentlyid = "yes";
            } else if (document.getElementById('pharma2currentlyno').checked === true) {
                pharma2currentlyid = "no";
            } else {
                pharma2currentlyid = "";
            }

            // If No: Have you taken it in the past //
            if (document.getElementById('pharma2pasttakenyes').checked === true) {
                pharma2pasttakenid = "yes";
            } else if (document.getElementById('pharma2pasttakenno').checked === true) {
                pharma2pasttakenid = "no";
            } else {
                pharma2pasttakenid = "";
            }
            // This is for Pharma 2 //


            // This is for Pharma 3 //
            // Have you ever heard of Pharma 3 //
            if (document.getElementById('pharma3heardyes').checked === true) {
                pharma3heardid = "yes";
            } else if (document.getElementById('pharma3heardno').checked === true) {
                pharma3heardid = "no";
            } else {
                pharma3heardid = "";
            }

            // Have you ever taken Pharma 2 before //
            if (document.getElementById('pharma3takenyes').checked === true) {
                pharma3takenid = "yes";
            } else if (document.getElementById('pharma3takenno').checked === true) {
                pharma3takenid = "no";
            } else {
                pharma3takenid = "";
            }

            // Do you currently use Pharma 3
            if (document.getElementById('pharma3currentlyyes').checked === true) {
                pharma3currentlyid = "yes";
            } else if (document.getElementById('pharma3currentlyno').checked === true) {
                pharma3currentlyid = "no";
            } else {
                pharma3currentlyid = "";
            }
            // If No: Have you taken it in the past //
            if (document.getElementById('pharma3pasttakenyes').checked === true) {
                pharma3pasttakenid = "yes";
            } else if (document.getElementById('pharma3pasttakenno').checked === true) {
                pharma3pasttakenid = "no";
            } else {
                pharma3pasttakenid = "";
            }

            deceasedoption = "";
            if (document.getElementById("deceasedyes").checked === true) {
                deceasedoption = true;
            } else {
                deceasedoption = false;
            }

            // This is for Pharma 3 //

            let datavalue = {
                'Clientidx': lblclient,
                'ClientID': document.getElementById('clientid')['value'],
                'LastName': document.getElementById('lname')['value'],
                'FirstName': document.getElementById('fname')['value'],
                'Middle_Initial': document.getElementById('mi')['value'],
                'UniqueID': document.getElementById('uniqueid')['value'],
                'DOB': document.getElementById('dob')['value'],
                'Age': document.getElementById('age')['value'],
                'AgeGroup': document.getElementById('agegroup')['value'],
                'Ageat': document.getElementById('ageat')['value'],
                'Gender': document.getElementById('gender')['value'],
                'Race': document.getElementById('race')['value'],
                'Ethnicity': document.getElementById('ethnicity')['value'],
                'Eligibility': document.getElementById('eligibility')['value'],
                'SSN': document.getElementById('sssno')['value'],
                'Deceased': deceasedoption,
                'CountyCode': document.getElementById('countrycode')['value'],
                'CountyCodeDescription': document.getElementById('countrycodedes')['value'],
                'PhoneNumber': document.getElementById('cpnumber')['value'],
                'SickleCellDiagnosis': document.getElementById('sickdiag')['value'],
                'FullStreetAddress': document.getElementById('address')['value'],
                'FullStreetAddress2': document.getElementById('address2')['value'],
                'City': document.getElementById('city')['value'],
                'State': document.getElementById('state')['value'],
                'ZipCode': document.getElementById('zipcode')['value'],
                'HomePhone': document.getElementById('hphone')['value'],
                'WorkPhone': document.getElementById('wphone')['value'],
                'PMPProviderName': document.getElementById('pmppro')['value'],
                'Specialist': document.getElementById('speprovider')['value'],
                'CCUCase': document.getElementById('ccucase')['value'],
                'Email_Address': document.getElementById('email')['value'],
                'ClientresideinruralID': clientresideinruralid,
                'Nameofmother': document.getElementById('nameofmother')['value'],
                'Address_Of_Mother': document.getElementById('motheraddress')['value'],
                'Telephone_Of_Mother': document.getElementById('mothertel')['value'],
                'Nameoffather': document.getElementById('nameoffather')['value'],
                'Address_Of_Father': document.getElementById('fatheraddress')['value'],
                'Telephone_Of_Father': document.getElementById('fathertel')['value'],
                'Nameofguardian': document.getElementById('nameofguardian')['value'],
                'Address_Of_Guardian': document.getElementById('guardianaddress')['value'],
                'Guardian_Telephone': document.getElementById('guardiantel')['value'],
                'Emergency_Contact1': document.getElementById('emercont1')['value'],
                'Emergency_Contact1_HomePhone': document.getElementById('emercont1homephone')['value'],
                'Emergency_Contact1_CellPhone': document.getElementById('emercont1cellphone')['value'],
                'Emergency_Contact2': document.getElementById('emercont2')['value'],
                'Emergency_Contact2_HomePhone': document.getElementById('emercont2homephone')['value'],
                'Emergency_Contact2_CellPhone': document.getElementById('emercont2cellphone')['value'],
                'SicklecelltypeID': sicklecelltypeid,
                'Medication': document.getElementById('medication')['value'],
                'Medication2': document.getElementById('medication3')['value'],
                'Medication3': document.getElementById('medication4')['value'],
                'Medication4': document.getElementById('medication5')['value'],
                'HydroxyureaheardID': hydroxyureaheardid,
                'HydroxyureatakenID': hydroxyureatakenid,
                'HydroxyureacurrentlyID': hydroxyureacurrentlyid,
                'HydroxyureapasttakenID': hydroxyureapasttakenid,
                'Hydroxyureadosage': document.getElementById('hydroxyureadosage')['value'],
                'Hydroxyureadosageunknown': document.getElementById('hydroxyureadosageunknown')['value'],
                'Hydroxyureacapsulescolor': document.getElementById('hydroxyureacapsulescolor')['value'],
                'Hydroxyureadatelasttaken': document.getElementById('hydroxyureadatelasttaken')['value'],
                'Hydroxyureadatepickedup': document.getElementById('hydroxyureadatepickedup')['value'],
                'Pharma1heardID': pharma1heardid,
                'Pharma1takenID': pharma1takenid,
                'Pharma1currentlyID': pharma1currentlyid,
                'Pharma1pasttakenID': pharma1pasttakenid,
                'Pharma1dosage': document.getElementById('pharma1dosage')['value'],
                'Pharma1dosageunknown': document.getElementById('pharma1dosageunknown')['value'],
                'Pharma1capsulescolor': document.getElementById('pharma1capsulescolor')['value'],
                'Pharma1datelasttaken': document.getElementById('pharma1datelasttaken')['value'],
                'Pharma1datepickedup': document.getElementById('pharma1datepickedup')['value'],
                'Pharma2heardID': pharma2heardid,
                'Pharma2takenID': pharma2takenid,
                'Pharma2currentlyID': pharma2currentlyid,
                'Pharma2pasttakenID': pharma2pasttakenid,
                'Pharma2dosage': document.getElementById('pharma2dosage')['value'],
                'Pharma2dosageunknown': document.getElementById('pharma2dosageunknown')['value'],
                'Pharma2capsulescolor': document.getElementById('pharma2capsulescolor')['value'],
                'Pharma2datelasttaken': document.getElementById('pharma2datelasttaken')['value'],
                'Pharma2datepickedup': document.getElementById('pharma2datepickedup')['value'],
                'Pharma3heardID': pharma3heardid,
                'Pharma3takenID': pharma3takenid,
                'Pharma3currentlyID': pharma3currentlyid,
                'Pharma3pasttakenID': pharma3pasttakenid,
                'Pharma3dosage': document.getElementById('pharma3dosage')['value'],
                'Pharma3dosageunknown': document.getElementById('pharma3dosageunknown')['value'],
                'Pharma3capsulescolor': document.getElementById('pharma3capsulescolor')['value'],
                'Pharma3datelasttaken': document.getElementById('pharma3datelasttaken')['value'],
                'Pharma3datepickedup': document.getElementById('pharma3datepickedup')['value']
            };

            $http({ method: "POST", url: "/Home/Update", data: JSON.stringify(datavalue), dataType: 'json', contentType: "application/json" }).success(function (response) {

                if (updatecounter === 0) {
                    document.getElementById('lblclientid').innerHTML = '';
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
                    document.getElementById("speprovider")["value"] = "";
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

                    document.getElementById("sicklecellTraits").checked = false;

                    document.getElementById("sicklecellnotsure").checked = false;
                    document.getElementById("sicklecellother").checked = false;

                    document.getElementById("medication")["value"] = "";
                    document.getElementById("medication3")["value"] = "";
                    document.getElementById("medication4")["value"] = "";
                    document.getElementById("medication5")["value"] = "";

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
                    //document.getElementById('hydroxyureadosageunknown')['value'] = "";
                    //document.getElementById('hydroxyureacapsulescolor')['value'] = "";

                    // this is for Phrama 1 //
                    // Have you ever heard of Phrama 1 //
                    document.getElementById("pharma1heardyes").checked = false;
                    document.getElementById("pharma1heardno").checked = false;

                    // Have you ever taken Phrama 1 before //
                    document.getElementById("pharma1takenyes").checked = false;
                    document.getElementById("pharma1takenno").checked = false;

                    // Do you currently use Phrama 1 //
                    document.getElementById("pharma1currentlyyes").checked = false;
                    document.getElementById("pharma1currentlyno").checked = false;

                    // If No: Have you taken it in the past //
                    document.getElementById("pharma1pasttakenyes").checked = false;
                    document.getElementById("pharma1pasttakenno").checked = false;

                    document.getElementById('pharma1dosage')['value'] = '';
                    document.getElementById('pharma1dosageunknown')['value'] = '';
                    document.getElementById('pharma1capsulescolor')['value'] = '';
                    document.getElementById('pharma1datelasttaken')['value'] = '';
                    document.getElementById('pharma1datepickedup')['value'] = '';
                    document.getElementById('pharma1dosage')['value'] = "";
                    document.getElementById('pharma1dosageunknown')['value'] = "";
                    document.getElementById('pharma1capsulescolor')['value'] = "";
                    // this is for Phrama 1 //

                    // this is for Phrama 2 //
                    // Have you ever heard of Phrama 2 //
                    document.getElementById("pharma2heardyes").checked = false;
                    document.getElementById("pharma2heardno").checked = false;

                    // Have you ever taken Phrama 2 before //
                    document.getElementById("pharma2takenyes").checked = false;
                    document.getElementById("pharma2takenno").checked = false;

                    // Do you currently use Phrama 2 //
                    document.getElementById("pharma2currentlyyes").checked = false;
                    document.getElementById("pharma2currentlyno").checked = false;

                    // If No: Have you taken it in the past //
                    document.getElementById("pharma2pasttakenyes").checked = false;
                    document.getElementById("pharma2pasttakenno").checked = false;

                    document.getElementById('pharma2dosage')['value'] = '';
                    document.getElementById('pharma2dosageunknown')['value'] = '';
                    document.getElementById('pharma2capsulescolor')['value'] = '';
                    document.getElementById('pharma2datelasttaken')['value'] = '';
                    document.getElementById('pharma2datepickedup')['value'] = '';
                    document.getElementById('pharma2dosage')['value'] = "";
                    document.getElementById('pharma2dosageunknown')['value'] = "";
                    document.getElementById('pharma2capsulescolor')['value'] = "";
                    // this is for Phrama 2 //

                    // this is for Phrama 3 //
                    // Have you ever heard of Phrama 3 //
                    document.getElementById("pharma3heardyes").checked = false;
                    document.getElementById("pharma3heardno").checked = false;

                    // Have you ever taken Phrama 3 before //
                    document.getElementById("pharma3takenyes").checked = false;
                    document.getElementById("pharma3takenno").checked = false;

                    // Do you currently use Phrama 3 //
                    document.getElementById("pharma3currentlyyes").checked = false;
                    document.getElementById("pharma3currentlyno").checked = false;

                    // If No: Have you taken it in the past //
                    document.getElementById("pharma3pasttakenyes").checked = false;
                    document.getElementById("pharma3pasttakenno").checked = false;

                    document.getElementById('pharma3dosage')['value'] = '';
                    document.getElementById('pharma3dosageunknown')['value'] = '';
                    document.getElementById('pharma3capsulescolor')['value'] = '';
                    document.getElementById('pharma3datelasttaken')['value'] = '';
                    document.getElementById('pharma3datepickedup')['value'] = '';
                    document.getElementById('pharma3dosage')['value'] = "";
                    document.getElementById('pharma3dosageunknown')['value'] = "";
                    document.getElementById('pharma3capsulescolor')['value'] = "";
                    document.getElementById("deceasedyes").checked = false;
                    document.getElementById("deceasedno").checked = false;
                    document.getElementById("deceasedyes").checked = false;
                    document.getElementById("deceasedno").checked = false;
                    // this is for Phrama 3 //                    

                    document.getElementById("update").style.visibility = "hidden";
                    document.getElementById("save").style.visibility = "visible";

                    document.getElementById('clientid').focus();
                    updatecounter = 1;
                    //alert("Updated successfully");
                    swal("Updated!", "Updated successfully!", {
                        className: "swal-title"
                    });
                }

            }, function (failed) {
                swal("Failed!", "Update Failed!", {
                    className: "swal-title"
                });
            });
        }
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

            //alert("Deleted successfully");
            swal("Deleted!", "Deleted successfully!", {
                className: "swal-title"
            });

        }, function (failed) {
            swal("Failed!", "Deleted Failed!", {
                className: "swal-title"
            });
        });
    };

    if (sPage.trim() === "Changepassword" || sPage.trim() === "changepassword") {
        var emailpassupdate = localStorage.getItem("emailchangepass");
        $scope.updatepassword = function () {

            var url = window.location.href;
            var arr = url.split("/");
            var result = arr[0] + "//" + arr[2];
            counterlog = 0;

            if (document.getElementById("pwd")["value"] === document.getElementById("confirmpass")["value"]) {

                var updatepass = {
                    'Email': emailpassupdate,
                    'Password': document.getElementById("pwd")["value"],
                    'Confirmpass': document.getElementById("confirmpass")["value"]
                };
                $http({ url: result + '/api/Mail/Updatepassword', method: "PUT", data: JSON.stringify(updatepass), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {
                    if (response[0]["Email"] !== null) {
                        //alert("Successfully changed");
                        window.location.href = "/Home/login";

                        swal("Changed", "Password was successfully changed", {
                            className: "swal-title"
                        });

                    } else {
                        alert("Not changed");
                    }
                }, function (failed) {
                    swal("Failed", "Failed to validate", {
                        className: "swal-title"
                    });
                });
            } else {
                swal("Invalid", "Password confirmation not matched", {
                    className: "swal-title"
                });
            }
        };
    }

    $scope.changepassword = function () {

        var url = window.location.href;
        var arr = url.split("/");
        var result = arr[0] + "//" + arr[2];
        counterlog = 0;

        if (document.getElementById('email').validity.valid && document.getElementById('email')['value'] !== "") {

            try {
                if (counterlog === 0) {
                    var datasearch = {
                        'Email': document.getElementById('email')['value']
                    };
                    responseemail = document.getElementById('email')['value'];
                    $http({ url: result + '/api/Mail/SearchEmail', method: "POST", data: JSON.stringify(datasearch), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {
                        if (response[0]["Email"] !== null) {
                            counterlog = 1;
                            localStorage.setItem("emailchangepass", responseemail);
                            window.location.href = "/home/Changepassverify";
                        } else {
                            //alert("Email Address is Invalid Or it's not Registered");
                            swal("Invalid", "Email Address is Invalid Or it's not Registered!", {
                                className: "swal-title"
                            });
                            document.getElementById("email").focus();
                        }
                        //window.location.href = "#login";
                    }, function (failed) {
                        swal("Failed", "Failed to validate", {
                            className: "swal-title"
                        });
                    });
                }
            }
            catch (error) {
                console.error(error);
            }

        } else {
            if (document.getElementById('email')['value'] === "") {
                //alert("Empty Email Address");
                swal("Empty", "Empty Email Address!", {
                    className: "swal-title"
                });
            } else {
                //alert("Invalid Email Address");
                swal("Invalid", "Invalid Email Address!", {
                    className: "swal-title"
                });
            }
        }

    };

    $scope.login = function () {
        var url = window.location.href;
        var arr = url.split("/");
        var result = arr[0] + "//" + arr[2];
        counterlog = 0;

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
                            localStorage.setItem("usergloballastname", varlastname);

                            varemail = response[0]["Email"];
                            localStorage.setItem("vEmail", varemail);
                            localStorage.setItem("vEmail2", varemail);

                            vrole = response[0]["Role"];
                            localStorage.setItem("vRole", vrole);

                            localStorage.setItem("variableEmail", varemail);
                            localStorage.setItem("variableEmail2", varemail);
                            localStorage.setItem("variableRole", vrole);

                            localStorage.setItem("globalEmailtype", varemail);
                            localStorage.setItem("globalRoletype", vrole);

                            var savelogin = {
                                'LastName': varlastname,
                                'FirstName': varfirstname,
                                'Role': vrole,
                                'Email': varemail
                            };

                            if (counterlog === 0 && document.getElementById('email')['value'] !== null) {
                                $http({ method: "POST", url: "/Home/Saveloggedin", data: JSON.stringify(savelogin), dataType: 'json', contentType: "application/json" }).success(function (dataresponse) {
                                    localStorage.setItem("historyloginID", dataresponse["0"].HistologinId);
                                    globalhistoryID = dataresponse["0"].HistologinId;

                                    counterlog = 1;
                                    document.getElementById('email')['value'] = null;

                                    localStorage.setItem("vEmail", "");
                                    localStorage.setItem("vEmail2", "");
                                    localStorage.setItem("variableEmail", "");
                                    localStorage.setItem("variableEmail2", "");

                                    window.location.href = "/Home/Index";
                                }, function (failed) {
                                    swal("Failed", "Loggein history failed", {
                                        className: "swal-title"
                                    });
                                });
                            }

                            //window.location.href = "/Home/Index";
                        } else {
                            //alert("wrong password");
                            swal("Invalid", "wrong password!", {
                                className: "swal-title"
                            });
                            document.getElementById("forgotpass").style.visibility = "visible";
                            document.getElementById('pwd').focus;
                        }
                    } else {
                        //alert("Email Address is Invalid Or it's not Registered");
                        swal("Invalid", "Email Address is Invalid Or it's not Registered!", {
                            className: "swal-title"
                        });
                        document.getElementById("email").focus();
                    }
                    count = 0;
                    //window.location.href = "#login";
                }, function (failed) {
                    swal("Failed", "Failed to validate", {
                        className: "swal-title"
                    });
                });

            }
            catch (error) {
                console.error(error);
            }

        } else {
            if (document.getElementById('email')['value'] === "") {
                //alert("Empty Email Address");
                swal("Empty", "Empty Email Address!", {
                    className: "swal-title"
                });
            } else {
                //alert("Invalid Email Address");
                swal("Invalid", "Invalid Email Address!", {
                    className: "swal-title"
                });
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
            document.getElementById("case_notes").style.backgroundColor = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";
            document.getElementById("upload_csv").style.backgroundColor = "white";
            document.getElementById("manageconsole").style.backgroundColor = "white";

            document.getElementById("entry").style.backgroundColor = "#28c4f4";
        };
        $scope.mouseover2 = function () {
            document.getElementById("entry").style.backgroundColor = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";
            document.getElementById("upload_csv").style.backgroundColor = "white";
            document.getElementById("manageconsole").style.backgroundColor = "white";

            document.getElementById("case_notes").style.backgroundColor = "#28c4f4";
        };
        $scope.mouseover3 = function () {
            document.getElementById("entry").style.backgroundColor = "white";
            document.getElementById("case_notes").style.backgroundColor = "white";
            document.getElementById("upload_csv").style.backgroundColor = "white";
            document.getElementById("manageconsole").style.backgroundColor = "white";

            document.getElementById("patient_overview").style.backgroundColor = "#28c4f4";
        };
        $scope.mouseover4 = function () {
            document.getElementById("entry").style.backgroundColor = "white";
            document.getElementById("case_notes").style.backgroundColor = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";
            document.getElementById("manageconsole").style.backgroundColor = "white";

            document.getElementById("upload_csv").style.backgroundColor = "#28c4f4";
        };
        $scope.mouseover5 = function () {
            document.getElementById("entry").style.backgroundColor = "white";
            document.getElementById("case_notes").style.backgroundColor = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";
            document.getElementById("upload_csv").style.backgroundColor = "white";

            document.getElementById("manageconsole").style.backgroundColor = "#28c4f4";
        };
        $scope.leave = function () {
            document.getElementById("case_notes").style.backgroundColor = "white";
            document.getElementById("entry").style.backgroundColor = "white";
            document.getElementById("patient_overview").style.backgroundColor = "white";
            document.getElementById("upload_csv").style.backgroundColor = "white";
            document.getElementById("manageconsole").style.backgroundColor = "white";
        };
    }

    if (sPage.trim() === "Manageconsoleoption" || sPage.trim() === "manageconsoleoption") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        $scope.mouseover1 = function () {
            document.getElementById("userhistory").style.backgroundColor = "white";
            document.getElementById("newuser").style.backgroundColor = "#28c4f4";
        };
        $scope.mouseover2 = function () {
            document.getElementById("newuser").style.backgroundColor = "white";
            document.getElementById("userhistory").style.backgroundColor = "#28c4f4";
        };

        $scope.leave = function () {
            document.getElementById("newuser").style.backgroundColor = "white";
            document.getElementById("userhistory").style.backgroundColor = "white";
        };

        //$(window).on('beforeunload', function () {           

        //    var t1 = localStorage.getItem("globalEmailtype");
        //    var t2 = localStorage.getItem("globalRoletype");                        

        //    localStorage.setItem("variableEmail2", t1);
        //    localStorage.setItem("variableRole", t2);            

        //    //return 'Are you sure you want to leave?';            
        //});                       

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            alert('oooops');
            event = event || window.event;
            //if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
            if (((typeof event.clientY === "undefined") && (x > 100))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }

        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 
    }

    ////// this is to load school //////
    if (sPage.toString().trim() === "Integration" || sPage.toString().trim() === "integration") {
        function formatDate(date) {
            var d = new Date(date),
                month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear();

            if (month.length < 2) month = '0' + month;
            if (day.length < 2) day = '0' + day;

            return [year, month, day].join('-');
        }

        var integrateClientID = localStorage.getItem("SelectedClientID");
        var clientvalue = {
            'ClientID': integrateClientID
        };
        ///////////////
        $http({ method: "POST", url: "/Home/Integrate", data: JSON.stringify(clientvalue), dataType: 'json', contentType: "application/json" }).success(function (response) {

            console.log(response);
            let count = 30;
            let count2 = 13;
            let count3 = 20;
            let editcust = [];

            //Add the Options to the DropDownList.
            for (var i = 0; i < response.length; i++) {
                editcust.push({ ClientID: "Client ID         :    " + response[i].ClientID });
                editcust.push({ FirstName: "FirstName         :    " + response[i].FirstName });
                editcust.push({ LastName: "LastName          :    " + response[i].LastName });
                editcust.push({ DOB: "Date Of Birth          :    " + formatDate(response[i].DOB) });
                editcust.push({ Gender: "Gender            :    " + response[i].Gender });
                editcust.push({ Race: "Race              :    " + response[i].Race });
                editcust.push({ Ethnicity: "Ethnicity         :    " + response[i].Ethnicity });
                editcust.push({ SSN: "SSS Number        :    " + response[i].SSN });
                editcust.push({ PhoneNumber: "Phone Number        :    " + response[i].PhoneNumber });
                editcust.push({ FullStreetAddress: "Address        :    " + response[i].FullStreetAddress });
                editcust.push({ City: "City        :    " + response[i].City });
                editcust.push({ State: "State        :    " + response[i].State });
                editcust.push({ ZipCode: "Zipcode        :    " + response[i].ZipCode });
                editcust.push({ SicklecelltypeID: "SickleCel Type ID        :    " + response[i].SicklecelltypeID });
                editcust.push({ Email_Address: "Email Address        :    " + response[i].Email_Address });
                editcust.push({ Eligibility: "Eligibility        :    " + response[i].Eligibility });
            }

            console.log(editcust);
            $scope.val = editcust;

        }, function (failed) {
            alert("Load Failed");
        });

        $scope.back = function () {
            window.location.href = "/Home/PatientOverview";
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
        if (sPage.trim() === "Uploadcsv" || sPage.trim() === "uploadcsv" || sPage.trim() === "PatientOverview" || sPage.trim() === "patientoverview" || sPage.trim() === "Entry" || sPage.trim() === "entry" || sPage.trim() === "Casenotes" || sPage.trim() === "casenotes" || sPage.trim() === "Index" || sPage.trim() === "index" || sPage.trim() === "Register" || sPage.trim() === "register" || sPage.trim() === "Viewlogs" || sPage.trim() === "viewlogs" || sPage.trim() === "Manageconsole" || sPage.trim() === "manageconsole" || sPage.trim() === "Manageconsoleoption" || sPage.trim() === "manageconsoleoption") {

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
                if (devicestat === "Mobile Phone" && isMobile2 === true) {
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
            document.getElementById("project_title").style.visibility = "hidden";
        }
    }

    if (sPage.trim() === "Manageconsole" || sPage.trim() === "manageconsole") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        let table = document.getElementById("myTable");
        let row;
        let cell1;
        let cell2;
        let cell3;
        let cell4;
        let cell5;
        let validateinfo;
        let apiloop;

        localStorage.setItem("counterloop", "0");

        var historydataview = {
            'CurrentDate': '0'
        };

        $http({ method: "POST", url: "/Home/History", data: JSON.stringify(historydataview), dataType: 'json', contentType: "application/json" }).success(function (response) {

            if (response !== "none") {

                apiloop = localStorage.getItem("counterloop");

                ///////////////////////////////////////////////////////                            
                //let myTable = document.getElementById("myTable");
                //let rowCount = myTable.rows.length;
                //if (rowCount !== 1) {
                //    document.getElementById("myTable").deleteRow(0);
                //}                    

                if (response !== "" && apiloop === "0") {

                    for (var i = 0; i < response.length; i++) {

                        table = document.getElementById('myTable').insertRow(i);
                        cell1 = table.insertCell(0);
                        cell2 = table.insertCell(1);
                        cell3 = table.insertCell(2);
                        cell4 = table.insertCell(3);
                        cell5 = table.insertCell(4);

                        cell1.style.width = "370px";
                        cell1.innerHTML = '\u00A0' + '\u00A0' + '\u00A0' + response[i].FirstName + " " + response[i].LastName;

                        cell2.style.marginLeft = "170px";
                        cell2.innerHTML = response[i].Email;

                        cell3.style.width = "200px";
                        cell3.style.marginLeft = "70px";
                        cell3.innerHTML = response[i].Role;

                        cell4.style.width = "200px";
                        cell4.style.marginLeft = "25px";
                        cell4.innerHTML = formatDate(response[i].CurrentDatehis);
                        cell4.style.fontWeight = '700';
                        cell4.style.color = "grey";
                        cell4.style.fontFamily = "Arial";
                        cell4.style.fontSize = "11px";

                        cell5.style.width = "150px";
                        cell5.style.marginLeft = "53px";
                        cell5.innerHTML = '\u00A0' + '\u00A0' + '\u00A0' + response[i].Logged_In;
                        cell5.style.fontWeight = '700';
                        cell5.style.color = "grey";
                        cell5.style.fontFamily = "Arial";
                        cell5.style.fontSize = "11px";
                        ///////////////////////////////////////////////////////

                        if (response.length === i) {
                            break;
                        }
                    }
                    localStorage.setItem("counterloop", "1");
                }
                //return;
            } else {
                myTable = document.getElementById("myTable");
                rowCount = myTable.rows.length;
                if (rowCount !== 1) {
                    document.getElementById("myTable").deleteRow(0);
                }
                if (validateinfo === 1) {
                    Notfound();
                } else if (validateinfo === 2) {
                    Notfound();
                } else {
                    if (searchoption === 3) {
                        clientfunc();
                    }
                    if (searchoption === 4) {
                        namefunc();
                    }
                }
            }

            localStorage.setItem("counterloop", "1");

            counterloop = 1;

        }, function (failed) {
            //alert("Overview Data Posted failed");
            swal("Failed!", "Overview Data Posted failed!", {
                className: "swal-title"
            });
        });

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            event = event || window.event;
            if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }

        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 

        function formatDate(date) {
            //var d = date;
            //day = '' + d.substring(0, 2);
            //month = '' + d.substring(3, 5);
            //year = d.substring(6,10);

            var d = new Date(date),
                month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear();

            if (month.length < 2) month = '0' + month;
            if (day.length < 2) day = '0' + day;

            return [year, month, day].join('-');
        }
    }

    if (sPage.trim() === "Casenotes" || sPage.trim() === "casenotes") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        isMobile2 = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
        if (isMobile2 === true) {
            document.getElementById("spanid").style.visibility = "hidden";
            document.getElementById("checkboxlist2").style.visibility = "hidden";
        } else {
            //alert("");
        }

        $scope.buttonone = function () {
            searchoption = 3;
            document.getElementById("firstname")["value"] = "";
            document.getElementById("lastname")["value"] = "";
            document.getElementById("dob1")["value"] = "";
        };
        $scope.buttontwo = function () {
            searchoption = 4;
            document.getElementById("searchclient")["value"] = "";
        };

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

        $scope.empname = function () {
            document.getElementById("firstname")["value"] = "";
            document.getElementById("lastname")["value"] = "";
            document.getElementById("dob1")["value"] = "";
            document.getElementById("searchclient").focus();
        };

        $scope.empclientid = function () {
            document.getElementById("searchclient")["value"] = "";
        };


        $scope.Clientsearch = function () {

            selected = {
                'ClientID': document.getElementById("searchclient")["value"],
                'FirstName': document.getElementById("firstname")["value"],
                'LastName': document.getElementById("lastname")["value"],
                'DOB': document.getElementById("dob1")["value"]
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
            if (document.getElementById("searchclient")["value"] !== "" || document.getElementById("firstname")["value"] !== "") {
                $http({ method: "POST", url: "/Home/Select", data: JSON.stringify(selected), dataType: 'json', contentType: "application/json" }).success(function (responseselect) {

                    function padding_right(s, c, n) {
                        // this is to give the value with the response data field if the response data is empty//
                        if (s === "") { s = '\u00A0', 2; }
                        // this is to give the value with the response data field if the response data is empty//

                        if (!s || !c || s.length >= n) {
                            return s;
                        }
                        var max = (n - s.length) / c.length;
                        for (var i = 0; i < max; i++) {
                            s += c;
                        }
                        return s;
                    }

                    if (responseselect["0"].ClientID !== 0) {

                        var fnamelength;
                        var lnamelength;
                        var fnamelname;
                        let vspace;
                        if (responseselect["0"].FirstName !== null || responseselect["0"].LastName !== null) {
                            fnamelength = responseselect["0"].FirstName.length;
                            lnamelength = responseselect["0"].LastName.length;
                            fnamelname = fnamelength + lnamelength;
                        }

                        if (fnamelname > 15) {
                            vspace = 47 - fnamelname;
                        } else if (fnamelname >= 10) {
                            vspace = 42 - fnamelname;
                        } else {
                            vspace = 38 - fnamelname;
                        }

                        //document.getElementById('clientid')['value'] = responseselect["0"].ClientID + "   " + responseselect["0"].FirstName + " " + responseselect["0"].LastName + "                " + responseselect["0"].DOB.substring(0, 10) + "         " + responseselect["0"].Gender;                      
                        document.getElementById('clientid')['value'] = responseselect["0"].ClientID + "   " + padding_right(responseselect[0].FirstName + ' ' + responseselect[0].LastName, '\u00A0', vspace) + " " + responseselect["0"].DOB.substring(0, 10) + "         " + responseselect["0"].Gender;

                        globalClientID = responseselect["0"].ClientID;
                        globalFirstName = responseselect["0"].FirstName;
                        globalLastName = responseselect["0"].LastName;
                        globalDOB = responseselect["0"].DOB;

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
                                'ClientID': globalClientID
                            };
                            $http({ method: "POST", url: "/Home/Loadnotes", data: JSON.stringify(selectednotes), dataType: 'json', contentType: "application/json" }).success(function (responseload) {
                                console.log(responseload);
                                if (responseload.length > 0) {
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
                                } else {
                                    Emptynotes();
                                    $scope.comm = "";
                                }


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

                    } else {
                        //alert("Patient not found in the system");
                        Notfound();
                        document.getElementById('clientid')['value'] = "";
                        document.getElementById('fname')['value'] = "";
                        document.getElementById('lname')['value'] = "";
                        document.getElementById('dob')['value'] = "";
                        //document.getElementById("comments").innerText = "";               
                        $scope.comm = "";
                    }

                }, function (failed) {
                    alert("failed");
                });

            } else {
                if (searchoption === 3) {
                    //alert("Please enter Client ID to continue search");  
                    clientfunc();
                } else if (searchoption === 4) {
                    namefunc();
                    //alert("Please enter last name, first name and DOB to continue search");   
                }
            }
        };

        $scope.newcommfocus = function () {
            var txtarea = document.getElementById("notes");
            txtarea.selectionEnd = 0;
            document.getElementById("notes").focus();
        };

        $scope.Savenotes = function () {

            globalusrfname = localStorage.getItem("userglobalfirstname");
            globalusrlname = localStorage.getItem("usergloballastname");

            console.log(document.getElementById("clientid")["value"]);
            var currdate = new Date(); // for now            
            let currtime = new Date().toLocaleTimeString();
            let currdate2 = new Date().toLocaleDateString();

            var savingnotes = {
                'ClientID': globalClientID,
                'FirstName': globalFirstName,
                'LastName': globalLastName,
                'DOB': globalDOB,
                'Comments': currdate2 + " - " + currtime + " --  " + globalusrfname + " " + globalusrlname + " -- " + document.getElementById("notes")["value"],
                //'Comments': document.getElementById("notes")["value"].substring(1, 5000),               
                'UserFirstName': globalusrfname,
                'UserLastName': globalusrlname,
                'TimeStamp': currtime,
                'Datenotescreated': formatDate(currdate)
            };

            vnotes = document.getElementById("notes")["value"].trim();
            if (vnotes !== "") {
                $http({ method: "POST", url: "/Home/Savenotes", data: JSON.stringify(savingnotes), dataType: 'json', contentType: "application/json" }).success(function (responsesave) {
                    document.getElementById("notes")["value"] = '';

                    //$scope.Selectnotes();
                    $scope.Clientsearch();

                    vnotes = "";
                    savingnotes = "";

                    //alert("New comments has been saved");
                    swal("Saved", "New comment saved!", {
                        className: "swal-title"
                    });

                    vnotes = "";
                    document.getElementById("notes")["value"] = '';

                }, function (failed) {
                    alert("failed");
                });
            } else {
                //alert("Invalid, You have an empty New Comments / Notes");
                swal("Invalid", "Invalid, You have an empty New Comments / Notes", {
                    className: "swal-title"
                });
            }
        };

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            event = event || window.event;
            if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }

        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                         
    }

    ////////////////////////////////
    function clientfunc() {
        //swal("Please enter Client ID to continue search!");        
        swal("Re-Type!", "Please enter Client ID to continue search!", {
            className: "swal-title"
        });
    }

    function namefunc() {
        //swal("Please enter last name, first name and DOB to continue search!; border: 3px solid black");  
        swal("Re-Type!", "Please enter last name, first name and DOB to continue search!", {
            className: "swal-title"
        });
    }

    function Notfound() {
        //swal("Patient not found in the system!");        
        swal("Not Found!", "Client not found in the system!!", {
            className: "swal-title"
        });
    }

    function Emptynotes() {
        //swal("There are no case notes in the system for this patient at this time!");                
        swal("No Case Notes!", "There are no case notes in the system for this client at this time!", {
            className: "swal-title"
        });
    }

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
                        swal("Invalid email!", "The email address is already being used. Please login  or sign up with a different email!", {
                            className: "swal-title"
                        });
                    }
                    count = 0;
                    window.location.href = "#signup";
                }, function (failed) {
                    swal("Invalid email!", "Data posted failed!", {
                        className: "swal-title"
                    });
                });

            } else {
                //alert("confirmation of your password doesn't matched");
                swal("Not Matched!", "confirmation of your password doesn't matched!", {
                    className: "swal-title"
                });
            }
        } else {
            if (document.getElementById('email')['value'] === "") {
                //alert("Empty Email address");
                swal("Empty!", "Empty Email address!", {
                    className: "swal-title"
                });
            } else {
                //alert("Invalid Email Address");
                swal("Invalid!", "Invalid Email Address!", {
                    className: "swal-title"
                });
            }
        }
    };

    if (sPage.trim() === "Uploadcsv" || sPage.trim() === "uploadcsv") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        vresult = localStorage.getItem("filename");
        vrefresh = localStorage.getItem("Refreshed");
        document.getElementById("fileUpload").style.fontWeight = "400";
        document.getElementById("fileUpload").style.width = "500px";

        if (vrefresh === "1") {
            document.getElementById("fileUpload").style.color = "transparent";
            document.getElementById("replace").style.visibility = "visible";
            document.getElementById("replace")["value"] = vresult;
            document.getElementById("replace").style.fontWeight = "500";
            document.getElementById("replace").style.backgroundColor = "transparent";

        } else {
            document.getElementById("replace").style.visibility = "hidden";

        }

        document.getElementById("saveopt").style.visibility = "hidden";
        document.getElementById("yeschoice").style.visibility = "hidden";
        document.getElementById("checkyes").style.visibility = "hidden";
        document.getElementById("nochoice").style.visibility = "hidden";
        document.getElementById("checkno").style.visibility = "hidden";

        $scope.formchange = function () {
            //$("#myTable").remove(); 
        };

        $scope.yes = function () {
            document.getElementById("saveopt").style.visibility = "hidden";
            document.getElementById("yeschoice").style.visibility = "hidden";
            document.getElementById("checkyes").style.visibility = "hidden";
            document.getElementById("nochoice").style.visibility = "hidden";
            document.getElementById("checkno").style.visibility = "hidden";

            var keepstr = { 'keep': '' };

            $http({ method: "POST", url: "/Upload/Keep", data: JSON.stringify(keepstr), dataType: 'json', contentType: "application/json" }).success(function (response) {

                alert("Uploaded data has been successfully retained in the system");
                //swal("Succeed!", "Succeed and keep it to the database!", {
                //    className: "swal-title"
                //});

                location.reload();

            }, function (failed) {
                //alert("Keeping to the Database failed");
                swal("Failed!", "Keeping to the Database failed!", {
                    className: "swal-title"
                });
            });
        };

        $scope.no = function () {
            document.getElementById("saveopt").style.visibility = "hidden";
            document.getElementById("yeschoice").style.visibility = "hidden";
            document.getElementById("checkyes").style.visibility = "hidden";
            document.getElementById("nochoice").style.visibility = "hidden";
            document.getElementById("checkno").style.visibility = "hidden";

            var removestr = { 'remove': '' };

            $http({ method: "POST", url: "/Upload/Remove", data: JSON.stringify(removestr), dataType: 'json', contentType: "application/json" }).success(function (response) {

                alert("Successfully deleted from Database");
                //swal("Deleted!", "Successfully deleted from Database!", {
                //    className: "swal-title"
                //});  

                location.reload();

            }, function (failed) {

                swal("Failed!", "Delete from the Database failed!", {
                    className: "swal-title"


                });
            });
        };

        $scope.upload = function () {

            var uploadstr = document.getElementById("fileUpload")["value"];
            if (uploadstr !== "") {
                document.getElementById("divprogress1").style.backgroundColor = "black";
                document.getElementById("divprogress2").style.width = "25%";
                document.getElementById("spanid").innerHTML = "25%";
                document.getElementById("spanid").style.color = "white";
                document.getElementById("spanid").style.fontWeight = "700";
                /////////////////////////////////////////////////////////////////////////////////////////////
                link = document.getElementById("fileUpload").files[0].name;

                let variablePath = { 'Path': link, 'Jresult': '' };

                if (loopcounter === 0) {
                    $http({ method: "POST", url: "/Upload/CsvExtraction", data: JSON.stringify(variablePath), dataType: 'json', contentType: "application/json" }).success(function (response) {

                        document.getElementById("divprogress2").style.width = "50%";
                        document.getElementById("spanid").innerHTML = "50%";
                        document.getElementById("spanid").style.color = "white";
                        document.getElementById("spanid").style.fontWeight = "700";

                        if (response.substring(1, 10) === "Worksheet") {
                            //window.location.reload();                                                    
                        }
                        var vresponse = response.substring(1, 10);
                        if (vresponse === "Violation") {
                            swal("Duplicate!", "Some of the ClientID in your Excell file has a duplicate ClientID in the system", {
                                className: "swal-title"
                            });
                        } else {
                            variablePath = { 'Path': '', 'Jresult': '' };
                            document.getElementById("fileUpload")["value"] = "";

                            loopcounter = loopcounter + 1;

                            ///////////////////////
                            var patientdataview = {
                                'ClientID': '0'
                            };
                            $.ajax({
                                url: '/Upload/PatientView', type: 'POST', data: JSON.stringify(patientdataview), dataType: 'json', contentType: "application/json", success: function (response) {
                                    document.getElementById("divprogress2").style.width = "75%";
                                    document.getElementById("spanid").innerHTML = "75%";
                                    document.getElementById("spanid").style.color = "white";
                                    document.getElementById("spanid").style.fontWeight = "700";

                                    if (response !== "") {
                                        //this is for the HTML table presentation                                        

                                        for (var i = 0; i < response.length; i++) {

                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            table = document.getElementById('myTable').insertRow(i);
                                            cell1 = table.insertCell(0);
                                            cell2 = table.insertCell(1);
                                            cell3 = table.insertCell(2);
                                            cell4 = table.insertCell(3);
                                            cell5 = table.insertCell(4);
                                            cell6 = table.insertCell(5);
                                            cell7 = table.insertCell(6);
                                            cell8 = table.insertCell(7);

                                            cell1.innerHTML = '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + response[i].ClientID;
                                            cell1.style.marginLeft = "5px";
                                            cell2.innerHTML = '\u00A0' + '\u00A0' + response[i].FirstName + '  ' + response[i].LastName;

                                            document.getElementById("col3").style.marginLeft = "-53px";
                                            cell3.innerHTML = response[i].DOB;
                                            //cell3.innerHTML = response[i].DOB.substring(0, 10);

                                            document.getElementById("col4").style.marginLeft = "-53px";
                                            cell4.innerHTML = response[i].Gender;

                                            document.getElementById("col5").style.marginLeft = "5px";

                                            document.getElementById("col6").style.marginLeft = "-3px";
                                            cell5.innerHTML = response[i].FullStreetAddress;

                                            document.getElementById("col6").style.marginLeft = "-3px";
                                            cell6.innerHTML = response[i].City;

                                            //document.getElementById("col7").style.marginLeft = "-53px";
                                            cell7.innerHTML = '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + response[i].State;

                                            cell8.style.color = "darkslategrey";
                                            var str = response[i].Email_Address;
                                            var res = str.toLowerCase();
                                            cell8.innerHTML = res;

                                            if (i === response.length) {
                                                break;
                                            }
                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////                                                                                                                                        
                                        }
                                        swal("Uploaded!", "File was successfully uploaded!", {
                                            className: "swal-title"
                                        });

                                    } else {
                                        swal("Empty!", "No records from the Database!", {
                                            className: "swal-title"
                                        });
                                    }

                                    localStorage.setItem("filename", "");
                                    localStorage.setItem("Refreshed", "0");

                                    document.getElementById("totnumber")["value"] = response.length;

                                    document.getElementById("saveopt").style.visibility = "visible";
                                    document.getElementById("yeschoice").style.visibility = "visible";
                                    document.getElementById("checkyes").style.visibility = "visible";
                                    document.getElementById("nochoice").style.visibility = "visible";
                                    document.getElementById("checkno").style.visibility = "visible";

                                    document.getElementById("divprogress2").style.width = "100%";
                                    document.getElementById("spanid").innerHTML = "100%";
                                    document.getElementById("spanid").style.color = "white";
                                    document.getElementById("spanid").style.fontWeight = "700";

                                }, error: function (response) {
                                    swal("Failed!", "Overview Data Posted failed", {
                                        className: "swal-title"
                                    });
                                }
                            });
                            ///////////////////////
                        }
                    }, function (failed) {
                        swal("Failed!", "Access failed", {
                            className: "swal-title"
                        });
                    });
                }
            } else {
                swal("Failed!", "Please select a file, you want to upload!", {
                    className: "swal-title"
                });
            }
        };

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');

        //back = 1;
        //window.onload = retour;
        //function retour() {
        //    console.log("retour  " + back);
        //    history.pushState({ page: 1 }, document.title, "");
        //    back = 1 - back;
        //}

        //window.onpopstate = function (event) {
        //    if (back) {
        //        alert("Return");
        //        history.pushState({ page: 1 }, document.title, "");
        //    }
        //    else {
        //        history.pushState({ page: 1 }, document.title, "");
        //        back = 1;
        //    }
        //};

        x;
        y;
        //function checkClose(event) {
        //    event = event || window.event;
        //    if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310) )) {
        //        localStorage.setItem("variableName", "");
        //        localStorage.setItem("variableEmail", "");
        //        localStorage.setItem("variableEmail2", "");
        //        localStorage.setItem("variableRole", "");
        //        return false;
        //    } else {
        //        if (x === 'undefined') {
        //            localStorage.setItem("variableName", "");
        //            localStorage.setItem("variableEmail", "");
        //            localStorage.setItem("variableEmail2", "");
        //            localStorage.setItem("variableRole", "");
        //            return false;
        //        }
        //    }
        //}  

        ///////////////////////////////////////////////////////////////////////////////////
        window.onbeforeunload = function (event) {

            if ((window.event.clientX < 0) || (window.event.clientY < 0)) // close button
            {
                //do something on closing event
            }
            else if (window.event.altKey === true) // ALT + F4
            {
                //do something on closing event
            }
            else if (window.history.back === true) {
                alert("closed");
            }
            else if ((window.event.clientX === undefined) || x === undefined) // ALT + F4
            {
                if ((x > 100 && x < 310) || x === undefined) {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                }
            }
            else // for all other unload events
            {
                //do something on closing event
            }
        };
        ///////////////////////////////////////////////////////////////////////////////////

        //window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        //window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 
    }

    if (sPage.trim() === "Login" || sPage.trim() === "login" || sPage.trim() === "Login2" || sPage.trim() === "login2") {

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

            }, error: function (response) {
                //swal("failed!", "Validation failed!", {
                //    className: "swal-title"
                //}); 

                window.location.href = "/Home/Banner";
            }
        });

        $scope.forgotpassword = function () {
            window.location.href = "/Home/Forgot";
        };
    }

    if (sPage.trim() === "Consolesignup" || sPage.trim() === "consolesignup") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            event = event || window.event;
            if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }
        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 
    }

    if (sPage === "Index" || sPage === "index") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }
        localStorage.setItem("variableEmail", "");
        localStorage.setItem("overviewfetch", 0);

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');        

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            event = event || window.event;
            if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }
        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 
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

    if (sPage.trim() === "Banner" || sPage.trim() === "banner") {
        $scope.back = function () {
            window.location.href = "/Home/Login";
        };
    }

    if (sPage.trim() === "PatientOverview" || sPage.trim() === "patientoverview") {

        vlog = localStorage.getItem("variableRole");
        if (vlog === "") {
            window.location.href = "/Home/Login";
        }

        $scope.buttonone = function () {
            searchoption = 3;
            document.getElementById("firstname")["value"] = "";
            document.getElementById("lastname")["value"] = "";
            document.getElementById("dob")["value"] = "";
        };
        $scope.buttontwo = function () {
            searchoption = 4;
            document.getElementById("searchclient")["value"] = "";
        };

        globalRoleName = localStorage.getItem("variableRole");
        if (globalRoleName === "Super Admin" || globalRoleName === "Admin User") {
            document.getElementById("listmembers").style.visibility = "visible";
        } else { document.getElementById("listmembers").style.visibility = "hidden"; }


        $scope.listall = function () {

            let url = window.location.href;
            let arr = url.split("/");
            let result = arr[0] + "//" + arr[2];
            counterlog = 0;

            localStorage.setItem("overviewfetch", "0");

            function padding_right(s, c, n) {
                if (s === "") { s = '\u00A0', 2; }

                if (!s || !c || s.length >= n) {
                    return s;
                }
                var max = (n - s.length) / c.length;
                for (var i = 0; i < max; i++) {
                    s += c;
                }
                return s;
            }

            let table = document.getElementById("myTable");
            let row;
            let cell1;
            let cell2;
            let cell3;
            let cell4;
            let cell5;
            let cell6;
            let cell7;
            let cell8;

            var listdataview = {
                'ClientID': '0'
            };

            $http({ url: result + '/api/Viewallpatients/ViewallList', method: "POST", data: JSON.stringify(listdataview), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {

                if (response.length === 0) {
                    swal("Empty!", "There is no data in the system", {
                        className: "swal-title"
                    });
                }

                patientview = response;
                var nard = response[8].UniqueID;
                counterfetch = localStorage.getItem("overviewfetch");

                if (response !== "" && counterfetch === "0") {
                    let myTable = document.getElementById("myTable");
                    myTable.innerHTML = "";

                    for (var i = 0; i < response.length; i++) {
                        ///////////////////////////////////////////////////////                  
                        table = document.getElementById('myTable').insertRow(i);
                        cell1 = table.insertCell(0);
                        cell2 = table.insertCell(1);
                        cell3 = table.insertCell(2);
                        cell4 = table.insertCell(3);
                        cell5 = table.insertCell(4);
                        cell6 = table.insertCell(5);
                        cell7 = table.insertCell(6);
                        cell8 = table.insertCell(7);

                        //cell1.innerHTML = '<a href="#">' + response[i].ClientID + '</a>' + '\u00A0' + '\u00A0' + '\u00A0';
                        //cell1.onclick = selected;

                        //cell2.innerHTML = '<a href="#">' + response[i].FirstName.toUpperCase() + '  ' + response[i].LastName.toUpperCase() + '</a>' + padding_right('', '\u00A0', 11);                        
                        //cell2.onclick = selected;                        

                        //cell3.style.marginLeft = "70px";
                        //cell3.innerHTML = response[i].DOB.toString().substring(0, 10) + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0' + '\u00A0';

                        //cell4.style.marginLeft = "-53px";                        
                        //cell4.innerHTML = padding_right(response[i].Gender, '\u00A0', 15);

                        //cell5.style.marginLeft = "-13px";
                        //cell5.style.fontSize = "14px";                        
                        //cell5.innerHTML = padding_right(response[i].FullStreetAddress, '\u00A0', 17);

                        //cell6.style.marginLeft = "3px";
                        //cell6.style.fontSize = "14px";
                        //cell6.innerHTML = padding_right(response[i].City, '\u00A0', 30);                        

                        //cell7.style.marginLeft = "-53px";
                        //cell7.style.fontSize = "14px";
                        //cell7.innerHTML = padding_right(response[i].State, '\u00A0', 13);

                        //cell8.style.marginLeft = "-53px";
                        //cell8.innerHTML = padding_right(response[i].Email_Address.toString().toLowerCase(), '\u00A0', 10);      

                        var fnamelength = response[i].FirstName.trim().length;
                        var lnamelength = response[i].LastName.trim().length;
                        var fnamelname = fnamelength + lnamelength;
                        let vspace;
                        if (fnamelname >= 20) {
                            vspace = 24 - fnamelname;
                        } else if (fnamelname === 19) {
                            vspace = 25 - fnamelname;
                        } else if (fnamelname === 18) {
                            vspace = 26 - fnamelname;
                        } else if (fnamelname === 17) {
                            vspace = 27 - fnamelname;
                        } else if (fnamelname === 16) {
                            vspace = 28 - fnamelname;
                        } else if (fnamelname === 15) {
                            vspace = 33 - fnamelname;
                        } else if (fnamelname === 14) {
                            vspace = 34 - fnamelname;
                        } else if (fnamelname === 13) {
                            vspace = 35 - fnamelname;
                        } else if (fnamelname === 12) {
                            vspace = 36 - fnamelname;
                        } else if (fnamelname === 11) {
                            vspace = 37 - fnamelname;
                        } else if (fnamelname === 10) {
                            vspace = 37 - fnamelname;
                        } else if (fnamelname === 9) {
                            vspace = 40 - fnamelname;
                        } else if (fnamelname === 8) {
                            vspace = 41 - fnamelname;
                        } else if (fnamelname === 7) {
                            vspace = 42 - fnamelname;
                        } else if (fnamelname === 6) {
                            vspace = 43 - fnamelname;
                        } else if (fnamelname === 5) {
                            vspace = 44 - fnamelname;
                        } else if (fnamelname === 4) {
                            vspace = 45 - fnamelname;
                        }

                        cell1.innerHTML = '<a href="#">' + response[i].ClientID + '</a>' + '\u00A0' + '\u00A0';
                        cell1.onclick = selected;
                        cell2.innerHTML = '<a href="#">' + response[i].FirstName.toUpperCase() + '  ' + response[i].LastName.toUpperCase() + '</a>' + padding_right('', '\u00A0', vspace);
                        cell2.onclick = selected;

                        cell3.style.marginLeft = "70px";
                        cell3.innerHTML = response[i].DOB.toString().substring(0, 10) + padding_right('', '\u00A0', 8);
                        //cell3.innerHTML = response[i].DOB.toString().substring(0, 10) + padding_right('', '\u00A0', 16);

                        cell4.style.marginLeft = "-53px";
                        //cell4.innerHTML = response[i].Gender;  
                        if (response[i].Gender.trim() === "Male") {
                            cell4.innerHTML = padding_right(response[i].Gender, '\u00A0', 21);
                        } else {
                            cell4.innerHTML = padding_right(response[i].Gender, '\u00A0', 17);
                        }

                        var addrelength = response[i].FullStreetAddress.trim().length;
                        let vspace2;
                        if (addrelength === 40) {
                            vspace2 = 53 - addrelength;
                        } else if (addrelength === 39) {
                            vspace2 = 54 - addrelength;
                        } else if (addrelength === 38) {
                            vspace2 = 55 - addrelength;
                        } else if (addrelength === 37) {
                            vspace2 = 56 - addrelength;
                        } else if (addrelength === 36) {
                            vspace2 = 57 - addrelength;
                        } else if (addrelength === 35) {
                            vspace2 = 58 - addrelength;
                        } else if (addrelength === 34) {
                            vspace2 = 59 - addrelength;
                        } else if (addrelength === 33) {
                            vspace2 = 60 - addrelength;
                        } else if (addrelength === 32) {
                            vspace2 = 61 - addrelength;
                        } else if (addrelength === 31) {
                            vspace2 = 62 - addrelength;
                        } else if (addrelength === 30) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 29) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 28) {
                            vspace2 = 65 - addrelength;
                        } else if (addrelength === 27) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 26) {
                            vspace2 = 64 - addrelength;
                        } else if (addrelength === 25) {
                            vspace2 = 64 - addrelength;
                        } else if (addrelength === 24) {
                            vspace2 = 65 - addrelength;
                        } else if (addrelength === 23) {
                            vspace2 = 65 - addrelength;
                        } else if (addrelength === 22) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 21) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 20) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 19) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 18) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 17) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 16) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 15) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 14) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 13) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 12) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 11) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 10) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 9) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 8) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 7) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 6) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 5) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 4) {
                            vspace2 = 63 - addrelength;
                        } else if (addrelength === 3) {
                            vspace2 = 63 - addrelength;
                        } else {
                            vspace2 = 63 - addrelength;
                        }

                        cell5.style.fontSize = "13.50px";
                        cell5.style.fontWeight = "500";
                        cell5.style.fontFamily = "Arial";
                        cell5.style.color = "black";
                        cell5.innerHTML = padding_right(response[i].FullStreetAddress.toUpperCase(), '\u00A0', vspace2);
                        //cell5.innerHTML = response[i].FullStreetAddress;                        

                        //cell6.style.marginLeft = "3px";
                        cell6.style.fontSize = "13.50px";
                        cell6.style.fontWeight = "500";
                        cell6.style.fontFamily = "Arial";
                        cell6.innerHTML = padding_right(response[i].City, '\u00A0', 20);
                        //cell6.innerHTML = response[i].City;

                        cell7.style.fontSize = "14px";
                        cell7.innerHTML = padding_right(response[i].State, '\u00A0', 12);
                        //cell7.innerHTML = response[i].State;

                        cell8.style.marginLeft = "-53px";
                        cell8.innerHTML = padding_right(response[i].Email_Address.toString().toLowerCase(), '\u00A0', 10);

                        ///////////////////////////////////////////////////////
                        if (i === response.length) {
                            break;
                        }
                    }
                    $scope.patients = patientview;
                    localStorage.setItem("overviewfetch", "1");
                }
                return;


            }, function (failed) {
                swal("Failed", "Accessing List of all Clients Failed", {
                    className: "swal-title"
                });
            });
        };

        $scope.searchclient = function () {
            localStorage.setItem("overviewfetch", "0");

            function padding_right(s, c, n) {
                if (s === "") { s = '\u00A0', 2; }

                if (!s || !c || s.length >= n) {
                    return s;
                }
                var max = (n - s.length) / c.length;
                for (var i = 0; i < max; i++) {
                    s += c;
                }
                return s;
            }

            let table = document.getElementById("myTable");
            let row;
            let cell1;
            let cell2;
            let cell3;
            let cell4;
            let cell5;
            let cell6;
            let cell7;
            let cell8;
            let validateinfo;

            if (document.getElementById("searchclient")["value"] !== "") {
                validateinfo = 1;
            } else if (document.getElementById("firstname")["value"] !== "") {
                validateinfo = 2;
            }
            else {
                validateinfo = 3;
            }

            var patientdataview = {
                'ClientID': document.getElementById("searchclient")["value"],
                'FirstName': document.getElementById("firstname")["value"],
                'LastName': document.getElementById("lastname")["value"],
                'DOB': document.getElementById("dob")["value"]
            };

            var ef = 0;
            $.ajax({
                url: '/Home/PatientView', type: 'POST', data: JSON.stringify(patientdataview), dataType: 'json', contentType: "application/json", success: function (response) {

                    function padding_right(s, c, n) {
                        // this is to give the value with the response data field if the response data is empty//
                        if (s === "") { s = '\u00A0', 2; }
                        // this is to give the value with the response data field if the response data is empty//

                        if (!s || !c || s.length >= n) {
                            return s;
                        }
                        var max = (n - s.length) / c.length;
                        for (var i = 0; i < max; i++) {
                            s += c;
                        }
                        return s;
                    }

                    if (response !== "none") {

                        let myTable = document.getElementById("myTable");
                        myTable.innerHTML = "";

                        patientview = response;

                        var vphone = response[0].PhoneNumber;
                        counterfetch = localStorage.getItem("overviewfetch");

                        if (response !== "" && counterfetch === "0") {
                            console.log(response);
                            for (var i = 0; i < response.length; i++) {

                                ///////////////////////////////////////////////////////                            
                                //let myTable = document.getElementById("myTable");
                                let rowCount = myTable.rows.length;
                                if (rowCount !== 1 && rowCount !== 0) {
                                    document.getElementById("myTable").deleteRow(0);
                                }

                                table = document.getElementById('myTable').insertRow(i);
                                cell1 = table.insertCell(0);
                                cell2 = table.insertCell(1);
                                cell3 = table.insertCell(2);
                                cell4 = table.insertCell(3);
                                cell5 = table.insertCell(4);
                                cell6 = table.insertCell(5);
                                cell7 = table.insertCell(6);
                                cell8 = table.insertCell(7);

                                var fnamelength = response[i].FirstName.trim().length;
                                var lnamelength = response[i].LastName.trim().length;
                                var fnamelname = fnamelength + lnamelength;
                                let vspace;
                                if (fnamelname >= 20) {
                                    vspace = 24 - fnamelname;
                                } else if (fnamelname === 19) {
                                    vspace = 25 - fnamelname;
                                } else if (fnamelname === 18) {
                                    vspace = 26 - fnamelname;
                                } else if (fnamelname === 17) {
                                    vspace = 27 - fnamelname;
                                } else if (fnamelname === 16) {
                                    vspace = 28 - fnamelname;
                                } else if (fnamelname === 15) {
                                    vspace = 33 - fnamelname;
                                } else if (fnamelname === 14) {
                                    vspace = 34 - fnamelname;
                                } else if (fnamelname === 13) {
                                    vspace = 35 - fnamelname;
                                } else if (fnamelname === 12) {
                                    vspace = 36 - fnamelname;
                                } else if (fnamelname === 11) {
                                    vspace = 37 - fnamelname;
                                } else if (fnamelname === 10) {
                                    vspace = 37 - fnamelname;
                                } else if (fnamelname === 9) {
                                    vspace = 40 - fnamelname;
                                } else if (fnamelname === 8) {
                                    vspace = 41 - fnamelname;
                                } else if (fnamelname === 7) {
                                    vspace = 42 - fnamelname;
                                } else if (fnamelname === 6) {
                                    vspace = 43 - fnamelname;
                                } else if (fnamelname === 5) {
                                    vspace = 44 - fnamelname;
                                } else if (fnamelname === 4) {
                                    vspace = 45 - fnamelname;
                                }

                                cell1.innerHTML = '<a href="#">' + response[i].ClientID + '</a>' + '\u00A0' + '\u00A0';
                                cell1.onclick = selected;
                                cell2.innerHTML = '<a href="#">' + response[i].FirstName.toUpperCase() + '  ' + response[i].LastName.toUpperCase() + '</a>' + padding_right('', '\u00A0', vspace);
                                cell2.onclick = selected;

                                cell3.style.marginLeft = "70px";
                                cell3.innerHTML = response[i].DOB.toString().substring(0, 10) + padding_right('', '\u00A0', 16);

                                cell4.style.marginLeft = "-53px";
                                //cell4.innerHTML = response[i].Gender;  
                                if (response[i].Gender.trim() === "Male") {
                                    cell4.innerHTML = padding_right(response[i].Gender, '\u00A0', 21);
                                } else {
                                    cell4.innerHTML = padding_right(response[i].Gender, '\u00A0', 17);
                                }

                                var addrelength = response[i].FullStreetAddress.trim().length;
                                let vspace2;
                                if (addrelength === 40) {
                                    vspace2 = 63 - addrelength;
                                } else if (addrelength === 39) {
                                    vspace2 = 64 - addrelength;
                                } else if (addrelength === 38) {
                                    vspace2 = 65 - addrelength;
                                } else if (addrelength === 37) {
                                    vspace2 = 66 - addrelength;
                                } else if (addrelength === 36) {
                                    vspace2 = 67 - addrelength;
                                } else if (addrelength === 35) {
                                    vspace2 = 68 - addrelength;
                                } else if (addrelength === 34) {
                                    vspace2 = 69 - addrelength;
                                } else if (addrelength === 33) {
                                    vspace2 = 70 - addrelength;
                                } else if (addrelength === 32) {
                                    vspace2 = 71 - addrelength;
                                } else if (addrelength === 31) {
                                    vspace2 = 72 - addrelength;
                                } else if (addrelength === 30) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 29) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 28) {
                                    vspace2 = 75 - addrelength;
                                } else if (addrelength === 27) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 26) {
                                    vspace2 = 74 - addrelength;
                                } else if (addrelength === 25) {
                                    vspace2 = 74 - addrelength;
                                } else if (addrelength === 24) {
                                    vspace2 = 75 - addrelength;
                                } else if (addrelength === 23) {
                                    vspace2 = 75 - addrelength;
                                } else if (addrelength === 22) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 21) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 20) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 19) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 18) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 17) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 16) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 15) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 14) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 13) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 12) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 11) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 10) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 9) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 8) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 7) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 6) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 5) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 4) {
                                    vspace2 = 73 - addrelength;
                                } else if (addrelength === 3) {
                                    vspace2 = 73 - addrelength;
                                } else {
                                    vspace2 = 73 - addrelength;
                                }

                                cell5.style.marginLeft = "-13px";
                                cell5.style.fontSize = "14px";
                                cell5.innerHTML = padding_right(response[i].FullStreetAddress.toUpperCase(), '\u00A0', vspace2);
                                //cell5.innerHTML = response[i].FullStreetAddress;

                                var citylength = response[i].City.trim().length;
                                let vspace3;
                                if (citylength <= 8) {
                                    vspace3 = 32 + citylength;
                                } else {
                                    vspace3 = 30;
                                }

                                cell6.style.marginLeft = "3px";
                                cell6.style.fontSize = "14px";
                                cell6.innerHTML = padding_right(response[i].City, '\u00A0', vspace3);
                                //cell6.innerHTML = response[i].City;

                                cell7.style.marginLeft = "-53px";
                                cell7.style.fontSize = "14px";
                                cell7.innerHTML = padding_right(response[i].State, '\u00A0', 25);
                                //cell7.innerHTML = response[i].State;

                                cell8.style.marginLeft = "-53px";
                                cell8.innerHTML = padding_right(response[i].Email_Address.toString().toLowerCase(), '\u00A0', 5);
                                //cell8.innerHTML = '\u00A0' + '\u00A0' + response[i].Email_Address.toString().toLowerCase();

                                ///////////////////////////////////////////////////////

                                break;
                            }
                            $scope.patients = patientview;
                            localStorage.setItem("overviewfetch", "1");
                        }
                        return;
                    } else {
                        myTable = document.getElementById("myTable");
                        rowCount = myTable.rows.length;
                        if (rowCount !== 1) {
                            document.getElementById("myTable").deleteRow(0);
                        }
                        if (validateinfo === 1) {
                            Notfound();
                        } else if (validateinfo === 2) {
                            Notfound();
                        } else {
                            if (searchoption === 3) {
                                clientfunc();
                            }
                            if (searchoption === 4) {
                                namefunc();
                            }
                        }
                    }

                }, error: function (response) {
                    alert('Overview Data Posted failed');
                }
            });
        };

        $scope.exportoverview = function () {
            var breakdownfilter = {
                'ClientID': '0'
            };
            $http({ url: '/Home/Breakdown', method: "POST", data: JSON.stringify(breakdownfilter), dataType: 'json', headers: { 'Content-Type': 'application/json' } }).success(function (response) {


            }, function (failed) {
                alert('Data posted failed');
            });
        };

        $scope.reportserver = function () {
            //window.location.href = "../Reports/Report.aspx";
            window.location.href = "/Reports/Report.aspx";
        };

        $scope.empname = function () {
            let myTable = document.getElementById("myTable");
            let rowCount = myTable.rows.length;
            if (rowCount > 2) {
                for (var r = 1; r < rowCount; r++) {
                    //location.reload();                     
                    break;
                }
                document.getElementById("searchclient").focus();
                //document.getElementById("firstname").focus();
            }
            document.getElementById("firstname")["value"] = "";
            document.getElementById("lastname")["value"] = "";
            document.getElementById("dob")["value"] = "";
        };

        $scope.empclientid = function () {
            let myTable = document.getElementById("myTable");
            let rowCount = myTable.rows.length;
            if (rowCount > 2) {
                for (var r = 1; r < rowCount; r++) {
                    //location.reload();                                   
                    break;
                }
                document.getElementById("firstname").focus();
                //document.getElementById("searchclient").focus();
            }
            document.getElementById("searchclient")["value"] = "";
        };

        $scope.searchfeild = function () {
            document.getElementById("search").focus();
        };

        function selected() {
            //var vrow = document.getElementById("col1").innerHTML;            
            var table = document.getElementById("myTable");
            var rows = table.getElementsByTagName("tr");
            for (i = 0; i < rows.length; i++) {
                var currentRow = table.rows[i];
                var createClickHandler = function (row) {
                    return function () {
                        var cell = row.getElementsByTagName("td")[0];
                        //var id = cell.innerHTML;
                        var id = cell.children[0].firstChild.nodeValue;

                        localStorage.setItem("SelectedClientID", id);

                        function formatDate(date) {
                            var d = new Date(date),
                                month = '' + (d.getMonth() + 1),
                                day = '' + d.getDate(),
                                year = d.getFullYear();

                            if (month.length < 2) month = '0' + month;
                            if (day.length < 2) day = '0' + day;

                            return [year, month, day].join('-');
                        }

                        var integrateClientID = localStorage.getItem("SelectedClientID");
                        let editcust = [];
                        for (var i = 0; i < patientview.length; i++) {

                            if (patientview[i].ClientID === undefined || patientview[i].ClientID === null) {
                                vClientID = "";
                            } else { vClientID = patientview[i].ClientID; }

                            if (patientview[i].FirstName === undefined || patientview[i].FirstName === null) {
                                vFirstName = "";
                            } else { vFirstName = patientview[i].FirstName; }

                            if (patientview[i].LastName === undefined || patientview[i].LastName === null) {
                                vLastName = "";
                            } else { vLastName = patientview[i].LastName; }

                            if (patientview[i].DOB === undefined || patientview[i].DOB === null) {
                                vDOB = "";
                            } else { vDOB = patientview[i].DOB; }

                            if (patientview[i].Gender === undefined || patientview[i].Gender === null) {
                                vGender = "";
                            } else { vGender = patientview[i].Gender; }

                            if (patientview[i].Race === undefined || patientview[i].Race === null) {
                                vrace = "";
                            } else { vrace = patientview[i].Race; }

                            if (patientview[i].Ethnicity === undefined || patientview[i].Ethnicity === null) {
                                vEthnicity = "";
                            } else { vEthnicity = patientview[i].Ethnicity; }

                            if (patientview[i].SSN === undefined || patientview[i].SSN === null) {
                                vSSSno = "";
                            } else { vSSSno = patientview[i].SSN; }

                            if (patientview[i].PhoneNumber === undefined || patientview[i].PhoneNumber === null) {
                                vCpNumber = "";
                            } else { vCpNumber = patientview[i].PhoneNumber; }

                            if (patientview[i].FullStreetAddress === undefined || patientview[i].FullStreetAddress === null) {
                                vFullStreetAddress = "";
                            } else { vFullStreetAddress = patientview[i].FullStreetAddress; }

                            if (patientview[i].City === undefined || patientview[i].City === null) {
                                vCity = "";
                            } else { vCity = patientview[i].City; }

                            if (patientview[i].UniqueID === undefined || patientview[i].UniqueID === null) {
                                vUniqueID = "";
                            } else { vUniqueID = patientview[i].UniqueID; }

                            if (patientview[i].State === undefined || patientview[i].State === null) {
                                vState = "";
                            } else { vState = patientview[i].State; }

                            if (patientview[i].ZipCode === undefined || patientview[i].ZipCode === null) {
                                vZipCode = "";
                            } else { vZipCode = patientview[i].ZipCode; }

                            if (patientview[i].SicklecelltypeID === undefined || patientview[i].SicklecelltypeID === null) {
                                vSicklecelltypeID = "";
                            } else { vSicklecelltypeID = patientview[i].SicklecelltypeID; }

                            if (patientview[i].Email_Address === undefined || patientview[i].Email_Address === null) {
                                vEmail_Address = "";
                            } else { vEmail_Address = patientview[i].Email_Address; }

                            if (patientview[i].Eligibility === undefined || patientview[i].Eligibility === null) {
                                vEligibility = "";
                            } else { vEligibility = patientview[i].Eligibility; }

                            if (patientview[i].SickleCellDiagnosis === undefined || patientview[i].SickleCellDiagnosis === null) {
                                vSickleCellDiagnosis = "";
                            } else { vSickleCellDiagnosis = patientview[i].SickleCellDiagnosis; }

                            if (patientview[i].PMPProviderName === undefined || patientview[i].PMPProviderName === null) {
                                vPMPProviderName = "";
                            } else { vPMPProviderName = patientview[i].PMPProviderName; }

                            if (patientview[i].CCUCase === undefined || patientview[i].CCUCase === null) {
                                vCCUCase = "";
                            } else { vCCUCase = patientview[i].CCUCase; }

                            if (patientview[i].Specialist === undefined || patientview[i].Specialist === null) {
                                vspecialist = "";
                            } else { vspecialist = patientview[i].Specialist; }

                            if (patientview[i].Medication === undefined || patientview[i].Medication === null) {
                                vmedication = "";
                            } else { vmedication = patientview[i].Medication; }

                            if (patientview[i].Emergency_Contact1 === undefined || patientview[i].Emergency_Contact1 === null) {
                                vemercont1 = "";
                            } else { vemercont1 = patientview[i].Emergency_Contact1; }

                            //if (patientview[i].Emergency_Contact1_HomePhone === undefined || patientview[i].Emergency_Contact1_HomePhone ===null) {
                            //    vemercont1homephone = "";
                            //} else { vemercont1homephone = patientview[i].PhoneNumber; }

                            if (patientview[i].HomePhone === undefined || patientview[i].HomePhone === null) {
                                vemercont1homephone = "";
                            } else { vemercont1homephone = patientview[i].HomePhone; }

                            if (patientview[i].WorkPhone === undefined || patientview[i].WorkPhone === null) {
                                vemercont1cellphone = "";
                            } else { vemercont1cellphone = patientview[i].WorkPhone }

                            if (patientview[i].Comments === undefined || patientview[i].Comments === null) {
                                vcomments = "";
                            } else { vcomments = patientview[i].Comments; }

                            //editcust.push({ DOB: "Date Of Birth          :    " + formatDate(vDOB) });
                            console.log(patientview);
                            if (patientview[i].ClientID.toString().trim() === integrateClientID.toString()) {
                                editcust.push({ ClientID: "Client ID         :    " + vClientID });
                                editcust.push({ FirstName: "FirstName         :    " + vFirstName });
                                editcust.push({ LastName: "LastName          :    " + vLastName });
                                editcust.push({ DOB: "Date Of Birth          :    " + vDOB.substring(0, 11) });
                                editcust.push({ Gender: "Gender            :    " + vGender });
                                editcust.push({ Race: "Race              :    " + vrace });
                                editcust.push({ Ethnicity: "Ethnicity         :    " + vEthnicity });
                                editcust.push({ SSN: "SSS Number        :    " + vSSSno });
                                editcust.push({ PhoneNumber: "Phone Number        :    " + vCpNumber });
                                editcust.push({ FullStreetAddress: "Address        :    " + vFullStreetAddress });
                                editcust.push({ City: "City        :    " + vCity });
                                editcust.push({ UniqueID: "Unique ID        :    " + vUniqueID });
                                editcust.push({ State: "State        :    " + vState });
                                editcust.push({ ZipCode: "Zipcode        :    " + vZipCode });
                                editcust.push({ SicklecelltypeID: "SickleCel Type ID        :    " + vSicklecelltypeID });
                                editcust.push({ Email_Address: "Email Address        :    " + vEmail_Address });
                                editcust.push({ Eligibility: "Eligibility        :    " + vEligibility });
                                editcust.push({ SickleCellDiagnosis: "SickleCell Diagnosis      :    " + vSickleCellDiagnosis });
                                editcust.push({ PMPProviderName: "PMPProvider Name        :    " + vPMPProviderName });
                                editcust.push({ CCUCase: "CCU Case        :    " + vCCUCase });
                                editcust.push({ Specialist: "Specialist Provider        :    " + vspecialist });
                                editcust.push({ Medication: "Medication        :    " + vmedication });
                                editcust.push({ Emergency_Contact1: "Emergency Contact        :    " + vemercont1 });
                                editcust.push({ Homephone: "Home Phone         :" + vemercont1homephone + ", " + "   " + "Work Phone        :" + vemercont1cellphone });
                                editcust.push({ Comments: "Most Recent Case Note      :    " + vcomments });
                                break;
                            }
                        }

                        var newSelect = document.createElement('select');
                        index = 0;
                        var optn = document.createElement("option");
                        //optn.style.marginLeft = "975px";
                        optn.style.marginLeft = "1121px";
                        optn.style.position = "inherit";
                        //optn.style.position = "fixed";
                        optn.style.color = "white";
                        optn.style.backgroundColor = "darkslategrey";
                        optn.style.width = "20px";
                        optn.style.height = "19px";
                        optn.style.fontWeight = "900";
                        //optn.style.fontFamily = "Tahoma";
                        optn.onclick = close;
                        optn.innerHTML = "X";

                        document.getElementById("comments3").onmouseleave = mouseout;

                        $("#comments3").empty();
                        $scope.val = editcust;

                        let counterlength = 0;
                        let filtered = "";
                        //let custlength = editcust[21].Comments.length;
                        let custlength = editcust[24].Comments.length;
                        let counterdash = 0;

                        for (var i = 0; i < custlength; i++) {
                            //filtered = filtered + editcust[21].Comments[i];
                            filtered = filtered + editcust[24].Comments[i];
                            counterlength = counterlength + 1;
                            //if (editcust[21].Comments[i] === "-") {
                            if (editcust[24].Comments[i] === "-") {
                                counterdash = counterdash + 1;

                                if (counterdash === 5) {
                                    break;
                                }

                            }
                        }

                        //let filtered2 = editcust[21].Comments.toString().substring(counterlength).trim();
                        let filtered2 = editcust[24].Comments.toString().substring(counterlength).trim();

                        let comment1 = "";
                        let counter = 0;
                        let countcom = 0;
                        //let editcustlength = editcust[21].Comments.length;                      
                        let editcustlength = filtered2.length;
                        var lineBreak = document.createElement("br");
                        let commentgroup = [];

                        for (var comm = 0; comm < editcustlength; comm++) {
                            if (comm <= 108 + countcom) {
                                //comment1 = comment1 + editcust[21].Comments[comm];
                                comment1 = comment1 + filtered2[comm];
                                counter = counter + 1;

                                if (comm === 108 + countcom) {
                                    //if (editcust[21].Comments[comm + 1] !== " ") {
                                    if (filtered2[comm + 1] !== " ") {
                                        comment1 = comment1 + "";
                                    } else {
                                        comment1 = comment1 + "";
                                    }
                                }
                            } else if (comm > 108 + countcom) {

                                //var casenotes = editcust[21].Comments[comm].toString();
                                var casenotes = filtered2[comm].toString();

                                if (casenotes !== " ") {
                                    //comment1 = comment1 + editcust[21].Comments[comm];
                                    comment1 = comment1 + filtered2[comm];
                                    counter = counter + 1;
                                } else if (casenotes !== "." && casenotes !== " ") {
                                    //comment1 = comment1 + editcust[21].Comments[comm];
                                    comment1 = comment1 + filtered2[comm];
                                    counter = counter + 1;
                                } else if (casenotes !== "-" && casenotes !== " ") {
                                    //comment1 = comment1 + editcust[21].Comments[comm];
                                    comment1 = comment1 + filtered2[comm];
                                    counter = counter + 1;
                                } else {
                                    countcom = counter;
                                    commentgroup.push(comment1);
                                    comment1 = "";
                                }
                            }
                        }
                        if (counter < 108 || counter > 108) {
                            commentgroup.push(comment1);
                        }

                        for (var ins = 0; ins < commentgroup.length; ins++) {
                            editcust.push(commentgroup[ins]);
                        }

                        for (var j = 0; j < editcust.length; j++) {
                            var opt = document.createElement("option");
                            opt.value = index;

                            if (j === 0) {
                                opt.innerHTML = editcust[j].ClientID;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onmouseover = move;
                            } else if (j === 1) {
                                opt.innerHTML = editcust[j].FirstName;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onmouseover = move;
                            } else if (j === 2) {
                                opt.innerHTML = editcust[j].LastName;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 3) {
                                opt.innerHTML = editcust[j].DOB;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 4) {
                                opt.innerHTML = editcust[j].Gender;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 5) {
                                opt.innerHTML = editcust[j].Race;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 6) {
                                opt.innerHTML = editcust[j].Ethnicity;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 7) {
                                opt.innerHTML = editcust[j].SSN;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 8) {
                                opt.innerHTML = editcust[j].PhoneNumber;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 9) {
                                opt.innerHTML = editcust[j].FullStreetAddress;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 10) {
                                opt.innerHTML = editcust[j].City;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 11) {
                                opt.innerHTML = editcust[j].UniqueID;
                                opt.style.marginLeft = "20px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 12) {
                                opt.innerHTML = editcust[j].State;
                                opt.style.marginLeft = "550px";
                                opt.style.marginTop = "-210px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 13) {
                                opt.innerHTML = editcust[j].ZipCode;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 14) {
                                opt.innerHTML = editcust[j].SicklecelltypeID;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 15) {
                                opt.innerHTML = editcust[j].Email_Address;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 16) {
                                opt.innerHTML = editcust[j].Eligibility;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 17) {
                                opt.innerHTML = editcust[j].SickleCellDiagnosis;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 18) {
                                opt.innerHTML = editcust[j].PMPProviderName;
                                opt.style.marginLeft = "550px";
                                //opt.style.marginTop = "40px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 19) {
                                opt.innerHTML = editcust[j].CCUCase;
                                opt.style.marginLeft = "550px";
                                //opt.style.marginTop = "60px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 20) {
                                opt.innerHTML = editcust[j].Specialist;
                                opt.style.marginLeft = "550px";
                                //opt.style.marginTop = "60px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 21) {
                                opt.innerHTML = editcust[j].Medication;
                                opt.style.marginLeft = "550px";
                                //opt.style.marginTop = "60px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 22) {
                                opt.innerHTML = editcust[j].Emergency_Contact1;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move
                            } else if (j === 23) {
                                opt.innerHTML = editcust[j].Homephone;
                                opt.style.marginLeft = "550px";
                                opt.style.resize = "both";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontWeight = 500;
                                opt.onclick = move
                            } else if (j === 24) {
                                opt.innerHTML = filtered;
                                opt.style.marginLeft = "20px";
                                opt.style.marginTop = "22px";
                                opt.style.position = "inherit";
                                opt.style.color = "darkslategray";
                                opt.style.fontSize = "14px";
                                opt.style.textshadow = "1px 1px 2px #000000";
                                opt.style.fontWeight = 900;
                                opt.onclick = move;
                            } else if (j === 25) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.color = "black";
                                opt.style.fontSize = "14px";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 26) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.color = "black";
                                opt.style.fontSize = "14px";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 27) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.style.fontSize = "14px";
                                opt.onclick = move;
                            } else if (j === 28) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.style.fontSize = "14px";
                                opt.onclick = move;
                            } else if (j === 29) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 30) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 31) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 32) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 33) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 34) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 35) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 36) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 37) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            } else if (j === 38) {
                                opt.innerHTML = editcust[j];
                                opt.style.marginLeft = "20px";
                                opt.style.position = "inherit";
                                opt.style.fontSize = "14px";
                                opt.style.color = "black";
                                opt.style.fontWeight = 500;
                                opt.onclick = move;
                            }

                            if (j === 0) {
                                document.getElementById("comments3").appendChild(optn);
                                document.getElementById("comments3").appendChild(opt);
                            } else {
                                document.getElementById("comments3").appendChild(opt);
                            }
                            index++;
                        }
                        document.getElementById("comments3").style.visibility = "visible";

                        //document.getElementById("comments3").opt.focus();
                        //document.getElementById("comments3").focus();                        
                    };
                };
                currentRow.onclick = createClickHandler(currentRow);
            }
            return;
        };

        function close() {
            document.getElementById("comments3").style.visibility = "hidden";
        }

        $scope.searchslcd = function () {

            var record = document.getElementById("search")["value"];
            var table = document.getElementById("myTable"), rindex, cindex;

            var index;
            var x = document.getElementsByTagName("tr");
            var txt = "";
            var i;
            var curr;
            for (i = 0; i < x.length; i++) {

                if (document.getElementById("searchoption").value === "ClientID") {
                    curr = x[i].firstElementChild.firstChild.innerHTML;
                } else if (document.getElementById("searchoption").value === "Name") {
                    curr = x[i].children[1].firstChild.innerHTML;
                    var currloop = "";
                    var recordloop = "";
                    for (var a = 0; a < curr.length; a++) {
                        if (curr[a] !== " ") {
                            currloop = currloop + curr[a];
                        }
                    }
                    curr = "";
                    curr = currloop;

                    for (var c = 0; c < record.length; c++) {
                        if (record[c] !== " ") {
                            recordloop = recordloop + record[c];
                        }
                    }
                    record = "";
                    record = recordloop;

                } else if (document.getElementById("searchoption").value === "") {
                    curr = "";
                    alert("Please select the search option");
                    documnet.getElementById("searchoption").focus();
                }

                if (curr === record) {
                    console.log(x[i].firstElementChild.firstChild.innerHTML);
                    console.log(x[i].rowIndex);

                    $('#myTable tr').removeClass('selected');
                    x[i].classList.toggle("selected");

                    //var element = document.getElementById("myTable");
                    //element.scrollIntoView();
                    //element.scrollIntoView(true);
                    //element.scrollIntoView({ block: "end" });
                    //element.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });    
                    //var xcoord = 300;
                    //var ycoord = 300;
                    //window.scrollTo(xcoord, ycoord);
                    //document.getElementById("myTable").scrollTop += 70;  

                    break;
                }
            }
        };

        $scope.searching = function () {
            var table = $('#myTable').html;

            var record = document.getElementById("search")["value"];
            var nodelist = document.getElementById('myTable').getElementsByTagName('tr');
            for (var i = 0; i < nodelist.length; i++) {
                var tr = nodelist.item(i);
                var tds = tr.getElementsByTagName('td');
                var x = tds[0].innerHTML.substring(0, tds[0].innerHTML.length - 4);
                var y = x.substring(12);
                if (tds.length > 0 && y === record && y !== "") {

                    $(table.column(i).nodes()).addClass('highlight');

                    break;
                }
            }
        };

        $(document).keyup(function (escape) {
            if (escape.keyCode === 27) {
                document.getElementById("comments3").style.visibility = "hidden";
                return;
            }
        });

        function move() {
            window.onload = addListeners();

            function addListeners() {
                document.getElementById('comments3').addEventListener('mousedown', mouseDown, true);
                window.addEventListener('mouseup', mouseUp, true);
            }

            function mouseUp() {
                window.removeEventListener('mousemove', divMove, true);
            }

            function mouseDown(e) {
                window.addEventListener('mousemove', divMove, true);
            }

            function divMove(e) {
                var select = document.getElementById('comments3');
                select.style.position = 'fixed';
                select.style.marginTop = (e.clientY - 150) + 'px';
                select.style.marginLeft = (e.clientX - 100) + 'px';
                select.focus;
            }
            dragged = 1;
        }

        function mouseout() {
            if (dragged === 1) {
            }
        }

        ////////////////////////////////////////////////////////////////
        //$(window).on('beforeunload');

        back = 1;
        window.onload = retour;
        function retour() {
            console.log("retour  " + back);
            history.pushState({ page: 1 }, document.title, "");
            back = 1 - back;
        }

        window.onpopstate = function (event) {
            if (back) {
                alert("Return");
                history.pushState({ page: 1 }, document.title, "");
            }
            else {
                history.pushState({ page: 1 }, document.title, "");
                back = 1;
            }
        };

        x;
        y;
        function checkClose(event) {
            event = event || window.event;
            if (((typeof event.clientY === "undefined") && (x > 100) && (x < 310))) {
                localStorage.setItem("variableName", "");
                localStorage.setItem("variableEmail", "");
                localStorage.setItem("variableEmail2", "");
                localStorage.setItem("variableRole", "");
                return false;
            } else {
                if (x === 'undefined') {
                    localStorage.setItem("variableName", "");
                    localStorage.setItem("variableEmail", "");
                    localStorage.setItem("variableEmail2", "");
                    localStorage.setItem("variableRole", "");
                    return false;
                }
            }
        }
        window.onbeforeunload = checkClose;
        window.onmousemove = savePosition;
        window.onmouseup = savePosition;
        window.onmousedown = savePosition;

        function savePosition(event) {
            if (event.clientX) {
                x = event.clientX;
            }
            if (event.clientY) {
                y = event.clientY;
            }
            if (y === undefined) {
            }
        }
        ////////////////////////////////////////////////////////////////                 
    }
    //return;
}]);



