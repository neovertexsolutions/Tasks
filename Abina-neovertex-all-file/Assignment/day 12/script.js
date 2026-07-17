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
    if(count>0){
        count--;
    }
        countDisplay.textContent = count;

}
)
reset.addEventListener("click", function(){
    count=0
        countDisplay.textContent = count;

}
)