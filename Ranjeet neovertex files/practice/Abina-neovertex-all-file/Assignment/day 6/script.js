// //function student name
// function studentname (name){
//     return name
// }
// console.log ("Students name are:")
// console.log(studentname("Abina"))
// console.log(studentname("Krishna"))
// //total marks
// function  Total_marks(marks1,marks2,marks3,marks4){
//     return marks1+marks2+marks3+marks4;

// }
// let total=Total_marks(100,100,100,100)
// console.log("Total marks of student:")
// console.log(total)
// console.log(total)

// //obtained marks 
// function Obtained_marks(marks1,marks2,marks3,marks4){
//         return marks1+marks2+marks3+marks4;
// }
// obtained1=Obtained_marks(67,76,56,80)
// obtained2=Obtained_marks(98,68,87,56)
// console.log("Obtained_marks are :")
// console.log(obtained1);
// console.log(obtained2)

// //percentage 
// function percentage(total,obtained){
//     return (obtained / total)*100;

// }
// console.log("Percentage of the students ")
// console.log(percentage(total,obtained1))
// console.log(percentage(total,obtained2))
function Student_detail(name,total_marks,obtained_marks){
    let percentage=(obtained_marks/total_marks)*100
    let status=percentage>=45?"pass":"fail";
     
    console.log("Student Name:", name);
    console.log("Total Marks:", total_marks);
    console.log("Obtained Marks:", obtained_marks);
    console.log("Percentage:", percentage.toFixed(2) + "%");
    console.log("Status:", status);


}
Student_detail("Abina",500,430);
Student_detail("Krishna",500,450);
