import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:practice/users_model.dart/user_models.dart';

class UserListPage extends StatefulWidget {
  const UserListPage({super.key});

  @override
  State<UserListPage> createState() => _UserListPageState();
}

class _UserListPageState extends State<UserListPage> {
  List<User> users = [];
  bool isLoading = true;

  // Calling GET API, http package, Future, async/await, JSON parsing
  Future<void> fetchUsers() async {
    try {
      final response = await http.get(
        Uri.parse(
          kIsWeb
              ? "http://localhost:3000/messages"
              : "http://10.0.2.2:3000/messages",
        ),
      );

      if (response.statusCode == 200) {
        List<dynamic> body = jsonDecode(response.body);

        setState(() {
          // Model Class and JSON Parsing, List, separating JSON from UI
          users = body.map((item) => User.fromJson(item)).toList();
        });
      }
    } catch (e) {
      debugPrint("Error: $e");
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  @override
  void initState() {
    super.initState();
    fetchUsers(); // Fetch users/products from API and show in ListView
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Clean Model API List")),
      body: isLoading
          ? const Center(child: CircularProgressIndicator())
          : users.isEmpty
          ? const Center(child: Text("No data found!"))
          : ListView.builder(
              itemCount: users.length,
              itemBuilder: (context, index) {
                return ListTile(
                  leading: CircleAvatar(child: Text("${index + 1}")),
                  title: Text(users[index].text),
                );
              },
            ),
    );
  }
}
