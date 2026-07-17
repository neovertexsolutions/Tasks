
let courses = [
  "Artificial Intelligence",
  "Theory of Computation",
  "Computer Network",
  "Operating System",
  "Database Management System"
];

console.log("Course List\n");

// All courses
console.log("All Courses:");
console.log([...courses]);

// Add new course
console.log("\nAdding one new course");
courses.push("DSA");
console.log([...courses]);

// Remove one course
console.log("\nRemove one course");
courses.pop();
console.log([...courses]);

// Updated courses
console.log("\nUpdated Courses");
courses[4]="Computer Graphics"
console.log([...courses]);