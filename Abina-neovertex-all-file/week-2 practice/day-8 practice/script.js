//Day 8: Arrays in JavaScript 
let students=["Abina","Asmina","Asmita"];

//add new students
console.log("Adding new Students")
students.push("Anita");
console.log([...students]);
//Remove last Students
console.log("Removing last students")
students.pop()
console.log([...students]);
//print all students
console.log("All Students :")
console.log([...students]);
//total number of students
console.log(students.length)


// shift()
console.log("Shift student :")
students.shift()
console.log([...students]);
//unshift()
console.log("UnShift student :")
students.unshift("Anisha")
console.log([...students]);
//includes()
console.log(students.includes("Asmina"))
//index of()
console.log(students.indexOf("Asmita"))
console.log([...students]);


// let number = new Array ( 55,22,77)
// console.log([...number])
// console.log(number[0]);
// number[1]=87
// console.log([...number])
// console.log(number.length)
