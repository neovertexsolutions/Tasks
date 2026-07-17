let form=document.getElementById("register_form");


form.addEventListener("submit", function(event){
event.preventDefault();

  // Get values
    let name = document.getElementById("name").value.trim();
    let email = document.getElementById("email").value.trim();
    let phone = document.getElementById("phone").value.trim();
    let course = document.getElementById("course").value;
    let password = document.getElementById("password").value;
    let confirmPassword = document.getElementById("confirmPassword").value;


    // Error elements
    let nameError = document.getElementById("nameError");
    let emailError = document.getElementById("emailError");
    let phoneError = document.getElementById("phoneError");
    let courseError = document.getElementById("courseError");
    let passwordError = document.getElementById("passwordError");
    let confirmError = document.getElementById("confirmError");
    let success = document.getElementById("success");

     nameError.innerText="";
    emailError.innerText="";
    phoneError.innerText="";
    courseError.innerText="";
    passwordError.innerText="";
    confirmError.innerText="";
    success.innerText="";

    let isvalid=true;

     if(name === ""){
        nameError.innerText="Full name is required";
        isvalid=false;
    }


    if(email === ""){
        emailError.innerText="Email is required";
        isvalid=false;
    }
   if(phone === ""){
        phoneError.innerText="Phone number is required";
        isvalid=false;
    }
    else if (phone.length !==10||isNaN(phone)){
        phoneError.innerText="Phone number are 10 digits";
        isvalid=false;
    }
    if(course===""){
        courseError.innerText="please select one course";
        isvalid=false;
    }
    if(password.length<6){
        passwordError.innerText="password at least 6 ";
        isvalid=false;
    }
    if(password!==confirmPassword){
        confirmError.innerText="please match your password";
        isvalid=false;
    }
    if(isvalid){
        success.innerText="Registration valid!"
 form.reset()
    }
   

})