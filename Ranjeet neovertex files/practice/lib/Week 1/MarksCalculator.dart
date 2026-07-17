import 'package:flutter/material.dart';

class MarksCalculator extends StatefulWidget {
  const MarksCalculator({super.key});

  @override
  State<MarksCalculator> createState() => _MarksCalculatorState();
}

class _MarksCalculatorState extends State<MarksCalculator> {
  final TextEditingController _mathController = TextEditingController();
  final TextEditingController _scienceController = TextEditingController();
  final TextEditingController _englishController = TextEditingController();

  // variables for stroing results
  double total = 0;
  double percentage = 0;
  String status = "Result awaiting";

  void _calculateMarks() {
    double math = double.tryParse(_mathController.text) ?? 0;
    double science = double.tryParse(_scienceController.text) ?? 0;
    double english = double.tryParse(_englishController.text) ?? 0;

    setState(() {
      total = math + science + english;
      percentage = (total / 300) * 100;

      // Pass Fail Logic
      if (math >= 40 && science >= 40 && english >= 40) {
        status = "PASSED 🎉";
      } else {
        status = "FAILED ❌";
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Marks Calculator'),
        backgroundColor: Colors.teal,
        foregroundColor: Colors.white,
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: SingleChildScrollView(
          child: Column(
            children: [
              TextField(
                controller: _mathController,
                keyboardType: TextInputType.number,
                decoration: const InputDecoration(
                  labelText: 'Math Marks',
                  border: OutlineInputBorder(),
                ),
              ),
              const SizedBox(height: 15),

              TextField(
                controller: _scienceController,
                keyboardType: TextInputType.number,
                decoration: const InputDecoration(
                  labelText: 'Science Marks',
                  border: OutlineInputBorder(),
                ),
              ),
              const SizedBox(height: 15),

              TextField(
                controller: _englishController,
                keyboardType: TextInputType.number,
                decoration: const InputDecoration(
                  labelText: 'English Marks',
                  border: OutlineInputBorder(),
                ),
              ),
              const SizedBox(height: 25),

              // Calculate Button
              ElevatedButton(
                onPressed: _calculateMarks,
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.teal,
                  foregroundColor: Colors.white,
                  minimumSize: const Size(double.infinity, 50),
                ),
                child: const Text(
                  'Calculate Result',
                  style: TextStyle(fontSize: 18),
                ),
              ),
              const SizedBox(height: 30),

              // Output Box Area
              Container(
                width: double.infinity,
                padding: const EdgeInsets.all(20),
                decoration: BoxDecoration(
                  color: Colors.teal.withOpacity(0.1),
                  borderRadius: BorderRadius.circular(10),
                ),
                child: Column(
                  children: [
                    Text(
                      "Total Marks: $total / 300",
                      style: const TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const SizedBox(height: 10),
                    Text(
                      "Percentage: ${percentage.toStringAsFixed(2)}%",
                      style: const TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const SizedBox(height: 10),
                    Text(
                      "Status: $status",
                      style: const TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                        color: Colors.blueGrey,
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
