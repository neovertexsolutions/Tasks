let student =[
    {name:"Abina ", mark:76 , status : "pass"},
    {name:"Krishna" , mark:87 , status : "pass"},
    {name:"Rita", mark:85 , status : "pass"},
    { name :"sita", mark:34 , status : "fail"}
    
]
let passed_student = student.filter( student =>{
    return student.status =="pass"
})
console.log("Passed Students")
passed_student.forEach( student =>{
    console.log("Student name :",student.name,
        "Student marks :" , student.mark,
        "Student Status:", student.status
    )
})