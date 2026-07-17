// Create a list of students and print their details
import 'package:flutter/material.dart';

class StudentList extends StatefulWidget {
  const StudentList({super.key});

  @override
  State<StudentList> createState() => _StudentListState();
}

class _StudentListState extends State<StudentList> {
  // This is a list of maps, where each map contains the data of a student.
  final List<Map<String, String>> students = [
    {"name": "Ram Bahadur", "age": "20", "roll": "101"},
    {"name": "Sita Kumari", "age": "21", "roll": "102"},
    {"name": "Hari Prasad", "age": "19", "roll": "103"},
  ];

  String formatDetails(Map<String, String> studentMap) {
    return "Roll No: ${studentMap['roll']} | Age: ${studentMap['age']}";
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Student Details List'),
        backgroundColor: Colors.blueAccent,
        foregroundColor: Colors.white,
      ),
      body: Padding(
        padding: const EdgeInsets.all(10.0),
        child: ListView.builder(
          itemCount: students.length,
          itemBuilder: (context, index) {
            Map<String, String> currentStudent = students[index];

            return Card(
              elevation: 3,
              margin: const EdgeInsets.symmetric(vertical: 8),
              child: ListTile(
                leading: CircleAvatar(
                  backgroundColor: Colors.blueAccent,
                  child: Text(currentStudent['name']![0]),
                ),
                title: Text(
                  currentStudent['name']!,
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 18,
                  ),
                ),
                subtitle: Text(
                  formatDetails(currentStudent), 
                  style: const TextStyle(color: Colors.pink),
                ),
              ),
            );
          },
        ),
      ),
    );
  }
}
