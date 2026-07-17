import 'package:flutter/material.dart';
import 'package:practice/Week%201/AssesmentPage.dart';
import 'package:practice/Week%201/CalculatorPage.dart';
import 'package:practice/Week%201/EvenOdd.dart';
import 'package:practice/Week%201/MarksCalculator.dart';
import 'package:practice/Week%201/StudentList.dart';
import 'package:practice/Week%201/TotalPage.dart';

class Week1HomePage extends StatefulWidget {
  const Week1HomePage({super.key, required this.title});
  final String title;

  @override
  State<Week1HomePage> createState() => _Week1HomePageState();
}

class _Week1HomePageState extends State<Week1HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(
          widget.title,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            letterSpacing: 1.5,
          ),
        ),
        centerTitle: true,
        elevation: 4,
      ),
      body: Container(
        decoration: BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
            colors: [
              Colors.deepPurple.shade50,
              Colors.white,
              Colors.deepPurple.shade50,
            ],
          ),
        ),
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              _buildDecorativeButton(
                context: context,
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const CalculatorPage(),
                    ),
                  );
                },
                icon: Icons.calculate,
                label: 'Calculator',
                color: Colors.purple,
              ),
              const SizedBox(height: 15),
              _buildDecorativeButton(
                context: context,
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => const EvenOdd()),
                  );
                },
                icon: Icons.numbers,
                label: 'Odd Even',
                color: Colors.purple,
              ),
              const SizedBox(height: 15),
              _buildDecorativeButton(
                context: context,
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const MarksCalculator(),
                    ),
                  );
                },
                icon: Icons.grade,
                label: 'Marks Calculator',
                color: Colors.purple,
              ),
              const SizedBox(height: 15),
              _buildDecorativeButton(
                context: context,
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const StudentList(),
                    ),
                  );
                },
                icon: Icons.people,
                label: 'Student List',
                color: Colors.purple,
              ),
              const SizedBox(height: 15),
              _buildDecorativeButton(
                context: context,
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const ProfileScreen(),
                    ),
                  );
                },
                icon: Icons.calendar_today,
                label: 'Week day',
                color: Colors.purple,
              ),
              const SizedBox(height: 15),
              _buildDecorativeButton(
                context: context,
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const AssessmentPage(),
                    ),
                  );
                },
                icon: Icons.assignment,
                label: 'Assessment',
                color: Colors.purple,
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildDecorativeButton({
    required BuildContext context,
    required VoidCallback onPressed,
    required IconData icon,
    required String label,
    required Color color,
  }) {
    return SizedBox(
      width: double.infinity,
      child: ElevatedButton(
        onPressed: onPressed,
        style: ElevatedButton.styleFrom(
          backgroundColor: color,
          foregroundColor: Colors.white,
          padding: const EdgeInsets.symmetric(vertical: 16, horizontal: 20),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(15),
          ),
          elevation: 8,
          shadowColor: color.withOpacity(0.5),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Icon(icon, size: 28),
            const SizedBox(width: 12),
            Text(
              label,
              style: const TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.w600,
                letterSpacing: 0.5,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
