let count=0;
let countDisplay=document.getElementById("count");
let increase=document.getElementById("increase");
let decrease=document.getElementById("decrease");
let reset=document.getElementById("reset");

increase.addEventListener("click", function(){
    count++
        countDisplay.textContent = count;

}
)
decrease.addEventListener("click", function(){
        count--;
    
        countDisplay.textContent = count;

}
)
reset.addEventListener("click", function(){
    count=0
        countDisplay.textContent = count;

}
)





let message = document.getElementById("message");
let button = document.getElementById("btn");
let input = document.getElementById("inputBox");
let form = document.getElementById("myForm");

        //  Input Event

    input.addEventListener("input", function(){


    console.log("You typed:", input.value);

        });

        //  Mouse Events

    message.addEventListener("mouseover", function(){

        message.innerText = "Mouse is over me";

        });


    message.addEventListener("mouseout", function(){

        message.innerText = "Mouse left";

        });



        //  Form Submit Event

        form.addEventListener("submit", function(event){


            // 5. event.preventDefault()

            event.preventDefault();


            message.innerText = "Form submitted successfully";

        });
