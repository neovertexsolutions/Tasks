import 'package:flutter/material.dart';

class CalculatorPage extends StatefulWidget {
  const CalculatorPage({super.key});

  @override
  State<CalculatorPage> createState() => _CalculatorPageState();
}

class _CalculatorPageState extends State<CalculatorPage> {
  final TextEditingController _num1Controller = TextEditingController();
  final TextEditingController _num2Controller = TextEditingController();
  double _result = 0;

  void _add() {
    setState(() {
      double num1 = double.parse(_num1Controller.text);
      double num2 = double.parse(_num2Controller.text);
      _result = num1 + num2;
    });
  }

  void _subtract() {
    setState(() {
      double num1 = double.parse(_num1Controller.text);
      double num2 = double.parse(_num2Controller.text);
      _result = num1 - num2;
    });
  }

  void _multiply() {
    setState(() {
      double num1 = double.parse(_num1Controller.text);
      double num2 = double.parse(_num2Controller.text);
      _result = num1 * num2;
    });
  }

  void _divide() {
    setState(() {
      double num1 = double.parse(_num1Controller.text);
      double num2 = double.parse(_num2Controller.text);
      _result = num1 / num2;
    });
  }

  void _clear() {
    setState(() {
      _num1Controller.clear();
      _num2Controller.clear();
      _result = 0;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Calculator Page')),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            TextField(
              controller: _num1Controller,
              keyboardType: TextInputType.number,
              decoration: const InputDecoration(
                labelText: 'Enter First Number',
                border: OutlineInputBorder(),
              ),
            ),

            const SizedBox(height: 20),

            TextField(
              controller: _num2Controller,
              keyboardType: TextInputType.number,
              decoration: const InputDecoration(
                labelText: 'Enter Second Number',
                border: OutlineInputBorder(),
              ),
            ),

            const SizedBox(height: 30),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                ElevatedButton(
                  onPressed: _add,
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.blueGrey,
                    foregroundColor: Colors.white,
                  ),
                  child: const Text('+'),
                ),
                ElevatedButton(
                  onPressed: _subtract,
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.blueGrey,
                    foregroundColor: Colors.white,
                  ),
                  child: const Text('-'),
                ),
                ElevatedButton(
                  onPressed: _multiply,
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.blueGrey,
                    foregroundColor: Colors.white,
                  ),
                  child: const Text('*'),
                ),
                ElevatedButton(
                  onPressed: _divide,
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.blueGrey,
                    foregroundColor: Colors.white,
                  ),
                  child: const Text('/'),
                ),
                ElevatedButton(
                  onPressed: _clear,
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.blueGrey,
                    foregroundColor: Colors.white,
                  ),
                  child: const Text('Clear'),
                ),
              ],
            ),

            const SizedBox(height: 30),

            Text(
              'Result: $_result',
              style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
          ],
        ),
      ),
    );
  }
}
