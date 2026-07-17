import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class PostAPILogin extends StatefulWidget {
  const PostAPILogin({super.key});

  @override
  _PostAPILoginState createState() => _PostAPILoginState();
}

class _PostAPILoginState extends State<PostAPILogin> {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passController = TextEditingController();
  bool _obscureText = true;
  bool _isLoading = false;

  Future<void> loginUser(BuildContext context) async {
    String email = emailController.text.trim();
    String password = passController.text.trim();

    if (email.isEmpty || password.isEmpty) {
      showDialog(
        context: context,
        builder: (_) => AlertDialog(
          title: Text("Error", style: GoogleFonts.poppins(color: Colors.red)),
          content: Text("Please fill all fields!", style: GoogleFonts.inter()),
        ),
      );
      return;
    }

    setState(() {
      _isLoading = true;
    });

    final url = Uri.parse('https://dummyjson.com/auth/login');

    try {
      final response = await http.post(
        url,
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'username': email, 'password': password}),
      );

      print('Status: ${response.statusCode}');
      print('Response: ${response.body}');

      setState(() {
        _isLoading = false;
      });
      // port number 200 is success number
      if (response.statusCode == 200) {
        var data = jsonDecode(response.body);

        //  FIXED: Using correct key 'accessToken'
        String token = data['accessToken'] ?? 'No token received';
        String username = data['username'] ?? 'User';
        String firstName = data['firstName'] ?? '';
        String lastName = data['lastName'] ?? '';

        if (!mounted) return;
        showDialog(
          context: context,
          builder: (_) => AlertDialog(
            title: Text(
              "Success! 🎉",
              style: GoogleFonts.poppins(fontWeight: FontWeight.bold),
            ),
            content: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "Welcome $firstName $lastName!",
                  style: GoogleFonts.inter(fontWeight: FontWeight.w500),
                ),
                Text(
                  "Username: $username",
                  style: GoogleFonts.inter(fontSize: 14),
                ),
                const SizedBox(height: 10),
                Text(
                  "Token:",
                  style: GoogleFonts.inter(
                    fontSize: 12,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                Text(
                  token,
                  style: GoogleFonts.inter(fontSize: 11, color: Colors.green),
                ),
              ],
            ),
          ),
        );
      } else {
        String errorMessage = "Login failed.";
        try {
          var errorData = jsonDecode(response.body);
          errorMessage =
              errorData['message'] ?? errorData['error'] ?? errorMessage;
        } catch (e) {
          errorMessage = "Server error: ${response.statusCode}";
        }

        if (!mounted) return;
        showDialog(
          context: context,
          builder: (_) => AlertDialog(
            title: Text(
              "Error",
              style: GoogleFonts.poppins(
                fontWeight: FontWeight.bold,
                color: Colors.red,
              ),
            ),
            content: Text(errorMessage, style: GoogleFonts.inter()),
          ),
        );
      }
    } catch (e) {
      setState(() {
        _isLoading = false;
      });
      debugPrint("Error: $e");

      if (!mounted) return;
      showDialog(
        context: context,
        builder: (_) => AlertDialog(
          title: Text("Error", style: GoogleFonts.poppins(color: Colors.red)),
          content: Text("Network error: $e", style: GoogleFonts.inter()),
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          "Post API Login",
          style: GoogleFonts.poppins(fontWeight: FontWeight.w600),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            TextField(
              controller: emailController,
              style: GoogleFonts.inter(),
              decoration: InputDecoration(
                labelText: "Username",
                labelStyle: GoogleFonts.inter(),
              ),
            ),
            TextField(
              controller: passController,
              style: GoogleFonts.inter(),
              decoration: InputDecoration(
                labelText: "Password",
                labelStyle: GoogleFonts.inter(),
                suffixIcon: IconButton(
                  icon: Icon(
                    _obscureText ? Icons.visibility_off : Icons.visibility,
                  ),
                  onPressed: () {
                    setState(() {
                      _obscureText = !_obscureText;
                    });
                  },
                ),
              ),
              obscureText: _obscureText,
            ),
            const SizedBox(height: 20),
            ElevatedButton(
              onPressed: _isLoading ? null : () => loginUser(context),
              child: _isLoading
                  ? const SizedBox(
                      height: 20,
                      width: 20,
                      child: CircularProgressIndicator(
                        strokeWidth: 2,
                        color: Colors.white,
                      ),
                    )
                  : Text(
                      "Login",
                      style: GoogleFonts.poppins(fontWeight: FontWeight.w600),
                    ),
            ),
          ],
        ),
      ),
    );
  }
}

// -----------------Here is the username and password --------------------------
//username: emilys
//password: emilyspass

//username: michaelw
//password: michaelwpass

//username: sophiab
//password: sophiabpass
