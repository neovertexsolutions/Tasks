import 'package:flutter/material.dart';
import 'package:practice/Week%202/DbProfilePage.dart';
import 'package:practice/Week%202/LoginPage.dart';
import 'package:practice/Week%202/MainPage.dart';
import 'package:practice/Week%202/ReusableWidget.dart';
import 'package:practice/Week%202/TodoPage.dart';

class Week2HomePage extends StatefulWidget {
  const Week2HomePage({super.key, required this.title});
  final String title;

  @override
  State<Week2HomePage> createState() => _Week2HomePageState();
}

class _Week2HomePageState extends State<Week2HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
        backgroundColor: Colors.deepPurple,
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            GestureDetector(
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => MainPage()),
                );
              },
              child: Container(
                height: 60,
                width: double.infinity,
                color: const Color(0xFF1A73E8),
                child: const Center(
                  child: Text(
                    'Day 8 ',
                    style: TextStyle(fontSize: 20, color: Colors.white),
                  ),
                ),
              ),
            ),

            const SizedBox(height: 10),

            GestureDetector(
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const LoginPage()),
                );
              },
              child: Container(
                height: 60,
                width: double.infinity,
                color: const Color(0xFF1A73E8),

                child: const Center(
                  child: Text(
                    'Login Page',
                    style: TextStyle(fontSize: 20, color: Colors.white),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 10),
            GestureDetector(
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => TodoHomePage()),
                );
              },
              child: Container(
                height: 60,
                width: double.infinity,
                color: const Color(0xFF1A73E8),
                child: const Center(
                  child: Text(
                    'Todo Page',
                    style: TextStyle(fontSize: 20, color: Colors.white),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 10),
            GestureDetector(
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => AuthScreen()),
                );
              },
              child: Container(
                height: 60,
                width: double.infinity,
                color: const Color(0xFF1A73E8),
                child: const Center(
                  child: Text(
                    'Reusable Widget',
                    style: TextStyle(fontSize: 20, color: Colors.white),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 10),
            GestureDetector(
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const DbProfilePage(),
                  ),
                );
              },
              child: Container(
                height: 60,
                width: double.infinity,
                color: const Color(0xFF1A73E8),
                child: const Center(
                  child: Text(
                    'Database Login',
                    style: TextStyle(fontSize: 20, color: Colors.white),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 10),
            GestureDetector(
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => MainPage()),
                );
              },
              child: Container(
                height: 60,
                width: double.infinity,
                color: const Color(0xFF1A73E8),
                child: const Center(
                  child: Text(
                    'Container 6',
                    style: TextStyle(fontSize: 20, color: Colors.white),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
