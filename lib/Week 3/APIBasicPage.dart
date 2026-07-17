import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class APIBasicPage extends StatefulWidget {
  const APIBasicPage({super.key});

  @override
  State<APIBasicPage> createState() => _APIBasicPageState();
}

class _APIBasicPageState extends State<APIBasicPage> {
  TextEditingController controller = TextEditingController();

  List<String> messages = [];
  bool isLoading = false;

  // Auto base url
  String get baseUrl {
    if (kIsWeb) {
      return "http://localhost:3000/messages";
    } else {
      return "http://10.0.2.2:3000/messages";
    }
  }

  // Get Api - calling GET Api, http package, future, async/await, json parsing
  Future<void> fetchMessages() async {
    setState(() {
      isLoading = true;
    });

    try {
      final response = await http.get(Uri.parse(baseUrl)); // Http get method

      if (response.statusCode == 200) {
        List data = jsonDecode(response.body); // JSON parsing

        setState(() {
          messages = data.map((e) => e['text'].toString()).toList();
        });
      } else {
        setState(() {
          messages = ["Server Error: ${response.statusCode}"];
        });
      }
    } catch (e) {
      setState(() {
        messages = ["Error: $e"];
      });
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  // Post Api - Http post method use here, Json encoding
  Future<void> sendMessage() async {
    final text = controller.text;

    if (text.isEmpty) return;

    try {
      final response = await http.post(
        Uri.parse(baseUrl), // API HTTP methods concept
        headers: {"Content-Type": "application/json"}, // JSON (API Basics)
        body: jsonEncode({"text": text}), // JSON formatting
      );

      if (response.statusCode == 200 || response.statusCode == 201) {
        controller.clear();
        fetchMessages();
      }
    } catch (e) {
      debugPrint("POST Error: $e");
    }
  }

  @override
  void initState() {
    super.initState();
    fetchMessages(); // Fetch users/products from API and show in ListView
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("GET & POST"),
        backgroundColor: Colors.blue,
      ),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          children: [
            Container(
              width: double.infinity,
              padding: const EdgeInsets.all(10),
              decoration: BoxDecoration(
                color: Colors.blue.shade100,
                borderRadius: BorderRadius.circular(10),
              ),
              child: const Text(
                "GET METHOD - from Server",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.blue,
                ),
              ),
            ),

            const SizedBox(height: 10),

            Expanded(
              child: Container(
                width: double.infinity,
                padding: const EdgeInsets.all(12),
                decoration: BoxDecoration(
                  color: Colors.grey.shade200,
                  borderRadius: BorderRadius.circular(12),
                ),
                child: isLoading
                    ? const Center(child: CircularProgressIndicator())
                    : messages.isEmpty
                    ? const Center(child: Text("No messages found"))
                    : ListView.builder(
                        itemCount: messages.length,
                        itemBuilder: (context, index) {
                          return Container(
                            margin: const EdgeInsets.only(bottom: 8),
                            padding: const EdgeInsets.all(10),
                            decoration: BoxDecoration(
                              color: Colors.white,
                              borderRadius: BorderRadius.circular(10),
                            ),
                            child: Text("Message: ${messages[index]}"),
                          );
                        },
                      ),
              ),
            ),

            const SizedBox(height: 10),

            TextField(
              controller: controller,
              decoration: InputDecoration(
                hintText: "Type message...",
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(50),
                ),
              ),
            ),

            const SizedBox(height: 10),

            ElevatedButton(
              onPressed: sendMessage,
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.green,
                minimumSize: const Size(double.infinity, 45),
              ),
              child: const Text("POST (Send Message)"),
            ),

            const SizedBox(height: 10),

            ElevatedButton(
              onPressed: fetchMessages,
              child: const Text("GET (Refresh)"),
            ),
          ],
        ),
      ),
    );
  }
}
