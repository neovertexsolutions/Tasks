console.log("Student Result Calculator:")
function Result(name,marks1,marks2,marks3,marks4,marks5){
    let Total_marks=marks1+marks2+marks3+marks4+marks5;
    let percentage=(Total_marks/500)*100;
    let grade

    if (percentage >= 90) {
        grade = "A";
    }
    else if (percentage >= 80) {
        grade = "B";
    }
    else if (percentage >= 70) {
        grade = "C";
    }
    else if (percentage >= 60) {
        grade = "D";
    }
    else {
        grade = "F";
    }

let status =percentage>=40 ? "pass":"fail"

console.log("STUDENT RESULT :")
console.log(" Student name: ",name)
console.log(" Marks of 1st subject ",marks1)
console.log(" Marks of 2nd subject ",marks2)
console.log(" Marks of 3rd subject ",marks3)
console.log(" Marks of 4th subject ",marks4)
console.log(" Marks of 5th subject ",marks5)
console.log("Total marks: ",Total_marks);
console.log(" Your Grade: ",grade)
console.log("Your Percentage:",percentage)
console.log(" Status of Student:",status)
console.log(" Thanks !")

}
Result("Abina",91,82,79,78,84);
Result("Krishna",75,86,70,92,86);
