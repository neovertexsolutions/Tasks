console.log("Student Grading System")
let english=76;
let nepali=86;
let math=77;
let science=70;
let social=83;
 let total ;
 let percentage;

  total=english+nepali+math+science+social;
  percentage=(total/500)*100;
console.log("Total Marks is : ",total);
console.log("Percentage is :", percentage)
  if(percentage>=90){
    console.log("Grade : A+")

  }
  else if(percentage>80&&percentage<89){
    console.log("Grade :A")
  }
  else if(percentage>70&&percentage<79){
    console.log("Grade :B")
  }
  else if(percentage>60&&percentage<69){
    console.log("Grade :C")
  }
  else if(percentage>50&&percentage<59){
    console.log("Grade :D")
  }
  else{
    console.log("sorry, Fail")
  }
  
  
