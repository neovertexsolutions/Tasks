// Day 9: Advanced Array Method
let students =[
{name:"Abina",marks:75},
{name:"Asmina",marks:85},
{name:"Asmita",marks:79},
{name:"Anuska",marks:41},
{name:"Aayusha",marks:35},
]
//foreach
console.log("Marks of all students")
students.forEach(students =>{
    console.log(students.name + ":" , students.marks)
})
//map
let bonus_marks =students.map( students =>{
    return {
        name: students.name,
        marks: students.marks + 5
    }
})
console.log(" Bonus Marks:", bonus_marks)
//filter
let passed_students = students.filter( students =>{
    return students.marks >=40;
})
console.log(" Passed students : ",passed_students)
// find
let search_name="Asmita";
let found_student = students.find( students=>{
    return students.name==search_name
})
console.log("Student found :", found_student)
//reduce
let total_marks=students.reduce((sum,student)=>{
    return sum + student.marks;
},0)
console.log("Total Marks :", total_marks)