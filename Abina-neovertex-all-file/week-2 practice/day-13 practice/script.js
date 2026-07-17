let form = document.getElementById("formvalid");
let message = document.getElementById("message");

form.addEventListener("submit",function (event ) {
    event.preventDefault();


    let name=document.getElementById("name").value;
    let email=document.getElementById("email").value;
    let password=document.getElementById("password").value;
    let confirmPassword=document.getElementById("confirmPassword").value;


      if(name === ""){
        message.innerText = "Name is required";
        return;
    }

    if(email === ""){
        message.innerText = "Email is required";
        return;
    }

        let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if(!emailPattern.test(email)){
        message.innerText = "Invalid email";
        return;
    }

    if(password.length < 6){
        message.innerText = "Password must be at least 6 characters";
        return;
    }

    if(password !== confirmPassword){
        message.innerText = "Password does not match";
        return;
    }

    message.innerText = "Signup Successful";

});
