// let heading = document.getElementById("title");
// console.log(heading)
// let paragraph=
// document.getElementsByClassName("text")
// console.log(paragraph)
// let items=
// document.querySelectorAll(".heading")
// console.log(items)
// let title=
// document.getElementById("title")
// title.style.color="red"
// title.style.backgroundColor="yellow"
// document.getElementById("box").innerHTML= "<h2> Welcome </h2>"

// document.getElementById("box").classList.add("hidden")
// // document.getElementById("box").classList.remove("t")
function changeheading(){
    document.getElementById("heading").innerText="Neo vertix websites"
}
function changeparagraph(){
document.getElementById("paragraph").innerText="This is changed paragraph"

}
function changecolor(){
    document.body.style.backgroundColor="pink"
}
function hideshow(){
    let paragraph=document.getElementById("paragraph");
paragraph.classList.toggle("hide")
}
