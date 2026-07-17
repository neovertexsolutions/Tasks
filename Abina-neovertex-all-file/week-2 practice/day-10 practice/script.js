const student = {
     name: "Abina", 
     course: "JavaScript",
       marks: 85, 
      isPassed: true,
greet : function(){
   console.log("hello", this.name);
}
}; 
      
console.log(student)
console.log(student.name)
console.log(student["course"])
student.greet()