import 'package:flutter/material.dart';
import 'package:practice/Week%201/SplashScreenPage.dart';
import 'package:practice/Week%201/Week1HomePage.dart';
import 'package:practice/Week%202/DbProfilePage.dart';
import 'package:practice/Week%202/Week2HomePage.dart';
import 'package:practice/Week%203/Week3HomePage.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      routes: {
        '/profile': (context) => const DbProfilePage(), // Add this route
      },
      home: const SplashScreen(),
    );
  }
}

class DropdownNavigationPage extends StatefulWidget {
  const DropdownNavigationPage({super.key});

  @override
  State<DropdownNavigationPage> createState() => _DropdownNavigationPageState();
}

class _DropdownNavigationPageState extends State<DropdownNavigationPage> {
  String selectedWeek = 'Week 1';

  final Map<String, Widget> weekPages = {
    'Week 1': const Week1HomePage(title: 'Week 1 - Home'),
    'Week 2': const Week2HomePage(title: 'Week 2 - Home'),
    'Week 3': const Week3HomePage(title: 'Week 3 - Home'),
    'Week 4': const Week4Page(),
    'Week 5': const Week5Page(),
    'Week 6': const Week6Page(),
    'Week 7': const Week7Page(),
    'Week 8': const Week8Page(),
    'Week 9': const Week9Page(),
    'Week 10': const Week10Page(),
    'Week 11': const Week11Page(),
    'Week 12': const Week12Page(),
    'Week 13': const Week13Page(),
    'Week 14': const Week14Page(),
    'Week 15': const Week15Page(),
  };

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week Selector'),
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        centerTitle: true,
      ),
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 16),
                decoration: BoxDecoration(
                  border: Border.all(color: Colors.deepPurple, width: 2),
                  borderRadius: BorderRadius.circular(12),
                ),
                child: DropdownButton<String>(
                  value: selectedWeek,
                  isExpanded: true,
                  underline: const SizedBox(),
                  items: const [
                    DropdownMenuItem(
                      value: 'Week 1',
                      child: Text('Week 1', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 2',
                      child: Text('Week 2', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 3',
                      child: Text('Week 3', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 4',
                      child: Text('Week 4', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 5',
                      child: Text('Week 5', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 6',
                      child: Text('Week 6', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 7',
                      child: Text('Week 7', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 8',
                      child: Text('Week 8', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 9',
                      child: Text('Week 9', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 10',
                      child: Text('Week 10', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 11',
                      child: Text('Week 11', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 12',
                      child: Text('Week 12', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 13',
                      child: Text('Week 13', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 14',
                      child: Text('Week 14', style: TextStyle(fontSize: 18)),
                    ),
                    DropdownMenuItem(
                      value: 'Week 15',
                      child: Text('Week 15', style: TextStyle(fontSize: 18)),
                    ),
                  ],
                  onChanged: (String? newValue) {
                    if (newValue != null) {
                      setState(() {
                        selectedWeek = newValue;
                      });
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => weekPages[newValue]!,
                        ),
                      );
                    }
                  },
                ),
              ),
              const SizedBox(height: 30),
              const Text(
                'Select a week from dropdown',
                style: TextStyle(fontSize: 16, color: Colors.grey),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class Week4Page extends StatelessWidget {
  const Week4Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 4'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 4 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week5Page extends StatelessWidget {
  const Week5Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 5'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 5 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week6Page extends StatelessWidget {
  const Week6Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 6'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 6 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week7Page extends StatelessWidget {
  const Week7Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 7'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 7 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week8Page extends StatelessWidget {
  const Week8Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 8'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 8 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week9Page extends StatelessWidget {
  const Week9Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 9'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 9 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week10Page extends StatelessWidget {
  const Week10Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 10'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 10 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week11Page extends StatelessWidget {
  const Week11Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 11'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 11 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week12Page extends StatelessWidget {
  const Week12Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 12'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 12 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week13Page extends StatelessWidget {
  const Week13Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 13'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 13 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week14Page extends StatelessWidget {
  const Week14Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 14'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 14 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}

class Week15Page extends StatelessWidget {
  const Week15Page({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Week 15'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: Text('Week 15 Content', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}
