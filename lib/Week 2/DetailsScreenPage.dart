import 'package:flutter/material.dart';

class DetailsScreenPage extends StatefulWidget {
  final String data;

  const DetailsScreenPage({super.key, required this.data});

  @override
  State<DetailsScreenPage> createState() => _DetailsScreenPageState();
}

class _DetailsScreenPageState extends State<DetailsScreenPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Details')),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text('Passed Data: ${widget.data}', style: TextStyle(fontSize: 20)),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () => Navigator.pop(context),
              child: Text('Go Back'),
            ),
          ],
        ),
      ),
    );
  }
}
