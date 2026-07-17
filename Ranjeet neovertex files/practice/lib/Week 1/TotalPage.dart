import 'package:flutter/material.dart';

// day 4

// 1. Course Class
class Course {
  String courseName;
  String duration;

  // Constructor
  Course({required this.courseName, required this.duration});
}

// 2. Student Class
class Student {
  String name;
  String rollNo;
  Course enrolledCourse;

  // Constructor
  Student({
    required this.name,
    required this.rollNo,
    required this.enrolledCourse,
  });

  // for getting student info
  String getStudentInfo() {
    return "Roll No: $rollNo, Course: ${enrolledCourse.courseName}";
  }
}

// 3. Employee Class
class Employee {
  String empId;
  String designation;
  double salary;

  // Constructor
  Employee({
    required this.empId,
    required this.designation,
    required this.salary,
  });

  // Method to increase salary (triggers UI update in StatefulWidget)
  void promoteEmployee(double bonus) {
    salary += bonus;
  }
}

// DAY 6 & 7: STATEFUL WIDGET & LAYOUTS

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({super.key});

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  // Creating OOP objects based on real-world examples
  late Course flutterCourse;
  late Student studentInfo;
  late Employee employeeInfo;

  @override
  void initState() {
    super.initState();
    // insitialized the objects
    flutterCourse = Course(
      courseName: "Flutter Mobile App Dev",
      duration: "3 Months",
    );

    studentInfo = Student(
      name: "Ramesh Thapa",
      rollNo: "THA077-01",
      enrolledCourse: flutterCourse,
    );

    employeeInfo = Employee(
      empId: "EMP-2026",
      designation: "Junior Flutter Developer",
      salary: 35000.0,
    );
  }

  // State change garni function
  void updateEmployeeSalary() {
    setState(() {
      employeeInfo.promoteEmployee(5000.0);
    });
  }

  @override
  Widget build(BuildContext context) {
    // Day 5: Scaffold provides structural layout
    return Scaffold(
      appBar: AppBar(
        title: const Text('Weekly Assessment 1: Profile & OOP'),
        backgroundColor: Colors.blueAccent,
        centerTitle: true,
      ),

      // Day 7: Using ListView to make the screen scrollable
      body: ListView(
        padding: const EdgeInsets.all(16.0), // Day 7: Padding
        children: [
          // DAY 6: PERSONAL PROFILE SCREEN (Top Section)
          Card(
            // Day 7: Card Widget for styling
            elevation: 5,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(15),
            ),
            child: Container(
              // Day 6: Container
              padding: const EdgeInsets.all(16.0),
              child: Column(
                // Day 6: Column (Vertical alignment)
                children: [
                  // Day 6: Image
                  const CircleAvatar(
                    radius: 50,
                    backgroundImage: NetworkImage('https://picsum.photos/200'),
                  ),
                  const SizedBox(height: 12), // Day 7: SizedBox for spacing
                  // Day 6: Text
                  Text(
                    studentInfo.name,
                    style: const TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                    ),
                  ),

                  const SizedBox(height: 6),

                  Text(
                    employeeInfo.designation,
                    style: TextStyle(
                      fontSize: 16,
                      color: Colors.grey[700],
                      fontStyle: FontStyle.italic,
                    ),
                  ),
                ],
              ),
            ),
          ),

          const SizedBox(height: 20),

          // DAY 4 & 6: STUDENT & COURSE DETAILS (Row & Icon)
          const Text(
            "Academic Details (Student & Course Class)",
            style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
          ),
          const SizedBox(height: 10),

          Card(
            child: Padding(
              padding: const EdgeInsets.all(12.0),
              child: Column(
                children: [
                  // Day 6: Row (Horizontal alignment)
                  Row(
                    children: [
                      const Icon(
                        Icons.school,
                        color: Colors.blue,
                      ), // Day 6: Icon
                      const SizedBox(width: 10),
                      Text(
                        studentInfo.getStudentInfo(),
                        style: const TextStyle(fontSize: 14),
                      ),
                    ],
                  ),
                  const SizedBox(height: 10),
                  Row(
                    children: [
                      const Icon(Icons.timer, color: Colors.orange),
                      const SizedBox(width: 10),
                      Text(
                        "Duration: ${studentInfo.enrolledCourse.duration}",
                        style: const TextStyle(fontSize: 14),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),

          const SizedBox(height: 20),

          // DAY 4, 6 & 7: EMPLOYEE DETAILS & STATE CHANGE
          const Text(
            "Job Details (Employee Class - Stateful)",
            style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
          ),
          const SizedBox(height: 10),

          Card(
            color: Colors.lightBlue[50],
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment:
                    CrossAxisAlignment.start, // Day 7: Alignment
                children: [
                  Text(
                    "Employee ID: ${employeeInfo.empId}",
                    style: const TextStyle(fontSize: 15),
                  ),
                  const SizedBox(height: 8),
                  Text(
                    "Current Salary: Rs. ${employeeInfo.salary}",
                    style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                      color: Colors.green,
                    ),
                  ),
                  const SizedBox(height: 15),

                  // Day 6: ElevatedButton to trigger state update
                  Center(
                    child: ElevatedButton.icon(
                      onPressed:
                          updateEmployeeSalary, //Calls the method and re-renders the screen
                      icon: const Icon(Icons.trending_up),
                      label: const Text("Promote & Increase Salary (Rs. 5000)"),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.green,
                        foregroundColor: Colors.white,
                        padding: const EdgeInsets.symmetric(
                          horizontal: 20,
                          vertical: 12,
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
