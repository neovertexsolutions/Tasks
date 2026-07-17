import 'package:flutter/material.dart';

class EvenOdd extends StatefulWidget {
  const EvenOdd({super.key});

  @override
  State<EvenOdd> createState() => _EvenOddState();
}

class _EvenOddState extends State<EvenOdd> {
  String result = '';
  final TextEditingController _controller = TextEditingController();
 
  void _checkEvenOdd() {
    
    int? number = int.tryParse(_controller.text);

    setState(() {
      if (number == null) {
        result = "Please enter a valid number!";
      } else if (number % 2 == 0) {
        result = "$number is an EVEN Number";
      } else {
        result = "$number is an ODD Number";
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Even Odd')),
      body: Center(
        child: Column(
          children: [
            SizedBox(height: 20),
            TextField(
              controller: _controller,
              style: const TextStyle(color: Colors.black),  
              decoration: const InputDecoration(
                labelText: 'Enter a number',
                labelStyle: TextStyle(color: Colors.blue), 
                filled: true,
                fillColor: Colors.white, 
                border: OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: 20),
            ElevatedButton(
              onPressed: _checkEvenOdd,
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.indigo, // Button background color
                foregroundColor: Colors.white, // Button text color
              ),
              child: const Text('Check'),
            ),

            SizedBox(height: 20),
            Text(result, style: const TextStyle(color: Colors.blue)),
          ],
        ),
      ),
    );
  }
}
