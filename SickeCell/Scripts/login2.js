
 var confirmvalue = {
     'Confirmed': "No"
 };
 $.ajax({
     url:'/Home/Confirm', type: 'POST', data: JSON.stringify(confirmvalue), dataType: 'json', contentType: "application/json", success: function (response) {
         console.log(response);
         localStorage.setItem("variableEmail", "");

     }, error: function (response) {
        alert('confirmation failed');
     }
 });
 
