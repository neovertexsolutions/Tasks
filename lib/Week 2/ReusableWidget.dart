import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AuthScreen extends StatefulWidget {
  const AuthScreen({Key? key}) : super(key: key);

  @override
  State<AuthScreen> createState() => _AuthScreenState();
}

class _AuthScreenState extends State<AuthScreen> {
  bool isLoginMode = true;
  bool _isLoading = false;
  final _formKey = GlobalKey<FormState>();

  final TextEditingController _email = TextEditingController();
  final TextEditingController _password = TextEditingController();
  final TextEditingController _confirm = TextEditingController();
  final TextEditingController _name = TextEditingController();

  @override
  void dispose() {
    _email.dispose();
    _password.dispose();
    _confirm.dispose();
    _name.dispose();
    super.dispose();
  }

  // this function sets the current active user session after login/signup
  Future<void> _setCurrentUser(String email, String name) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setString('current_user_email', email);
    await prefs.setString('current_user_name', name);
    await prefs.setBool('isLoggedIn', true);
  }

  // Function to save user data during signup !! only signup
  Future<bool> _saveUserData(String email, String password, String name) async {
    final prefs = await SharedPreferences.getInstance();

    // Check if user already exists than it return false
    String? existingPassword = prefs.getString('user_${email}_password');
    if (existingPassword != null) {
      return false;
    }

    // Save credentials
    await prefs.setString('user_${email}_password', password);
    await prefs.setString('user_${email}_name', name);

    // Set current active session !! user is signup
    await _setCurrentUser(email, name);
    return true;
  }

  // Function to check login credentials
  Future<bool> _checkLoginCredentials(String email, String password) async {
    final prefs = await SharedPreferences.getInstance();
    String? savedPassword = prefs.getString('user_${email}_password');

    if (savedPassword != null && savedPassword == password) {
      String savedName = prefs.getString('user_${email}_name') ?? 'User';
      await _setCurrentUser(email, savedName);
      return true;
    }
    return false;
  }

  Future<void> _navigateToDbProfilePage() async {
    Navigator.pushReplacementNamed(context, '/profile');
  }

  void _submit() async {
    if (!_formKey.currentState!.validate()) return;

    setState(() {
      _isLoading = true;
    });

    try {
      if (!isLoginMode && _password.text != _confirm.text) {
        _showSnackBar('Passwords do not match');
        setState(() => _isLoading = false);
        return;
      }

      if (isLoginMode) {
        bool isValidUser = await _checkLoginCredentials(
          _email.text,
          _password.text,
        );

        if (isValidUser) {
          _showSnackBar('✅ Login Success!', seconds: 1);
          await _navigateToDbProfilePage();
        } else {
          setState(() => _isLoading = false);
          _showSnackBar('Invalid email or password! Please sign up first.');
        }
      } else {
        // SIGNUP MODE
        bool isSignedUp = await _saveUserData(
          _email.text,
          _password.text,
          _name.text,
        );

        if (isSignedUp) {
          _showSnackBar(
            '✅ Signup Successful! User data saved locally.',
            seconds: 1,
          );
          await _navigateToDbProfilePage();
        } else {
          setState(() => _isLoading = false);
          _showSnackBar('User already exists! Please login.');
        }
      }
    } catch (e) {
      setState(() => _isLoading = false);
      _showSnackBar('Error: ${e.toString()}');
    }
  }

  // Helper function to reduce repetitive SnackBar code
  void _showSnackBar(String message, {int seconds = 2}) {
    if (!mounted) return;
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text(message),
        duration: Duration(seconds: seconds),
      ),
    );
  }

  void _toggleMode() {
    setState(() {
      isLoginMode = !isLoginMode;
      _isLoading = false;
      _formKey.currentState?.reset();
      _email.clear();
      _password.clear();
      _confirm.clear();
      _name.clear();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      // costume appbar
      appBar: CustomHeader(
        title: isLoginMode ? 'Welcome Back' : 'Create Account',
        showBack: true,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(20),
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              // costume card
              CustomCard(
                child: Column(
                  children: [
                    Icon(isLoginMode ? Icons.lock : Icons.person_add, size: 70),
                    const SizedBox(height: 10),
                    Text(
                      isLoginMode ? 'Sign In' : 'Join Us',
                      style: const TextStyle(
                        fontSize: 22,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    Text(
                      isLoginMode
                          ? 'Enter your credentials'
                          : 'Create your account',
                      style: TextStyle(color: Colors.grey[600]),
                    ),
                  ],
                ),
              ),
              const SizedBox(height: 30),
              if (!isLoginMode)
              //costume input field
                CustomInput(
                  controller: _name,
                  label: 'Full Name',
                  icon: Icons.person,
                  validator: (v) => v!.isEmpty ? 'Enter name' : null,
                ),
              CustomInput(
                controller: _email,
                label: 'Email',
                icon: Icons.email,
                keyboard: TextInputType.emailAddress,
                validator: (v) => v!.isEmpty || !v.contains('@')
                    ? 'Valid email required'
                    : null,
              ),
              const SizedBox(height: 15),
              CustomInput(
                controller: _password,
                label: 'Password',
                icon: Icons.lock,
                isPassword: true,
                validator: (v) => v!.length < 6 ? 'Min 6 characters' : null,
              ),
              if (!isLoginMode)
                CustomInput(
                  controller: _confirm,
                  label: 'Confirm Password',
                  icon: Icons.lock,
                  isPassword: true,
                  validator: (v) => v!.isEmpty ? 'Confirm password' : null,
                ),
              if (isLoginMode)
                Align(
                  alignment: Alignment.centerRight,
                  child: TextButton(
                    onPressed: () => _showSnackBar('Reset link sent!'),
                    child: const Text('Forgot Password?'),
                  ),
                ),
              const SizedBox(height: 20),
              _isLoading
                  ? const Center(
                      child: Padding(
                        padding: EdgeInsets.all(16.0),
                        child: CircularProgressIndicator(),
                      ),
                    )
                  : CustomButton(
                      text: isLoginMode ? 'Login' : 'Sign Up',
                      onTap: _submit,
                    ),
              const SizedBox(height: 10),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(isLoginMode ? "New here?" : "Already have an account?"),
                  TextButton(
                    onPressed: _toggleMode,
                    child: Text(isLoginMode ? 'Sign Up' : 'Login'),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}

// Reusable widgets (CustomHeader, CustomCard, CustomInput, CustomButton) remain exactly same as yours...
class CustomHeader extends StatelessWidget implements PreferredSizeWidget {
  final String title;
  final bool showBack;
  const CustomHeader({required this.title, this.showBack = false, Key? key})
    : super(key: key);
  @override
  Widget build(BuildContext context) {
    return AppBar(
      title: Text(title, style: const TextStyle(fontWeight: FontWeight.bold)),
      centerTitle: true,
      leading: showBack
          ? IconButton(
              icon: const Icon(Icons.arrow_back),
              onPressed: () => Navigator.pop(context),
            )
          : null,
      elevation: 0,
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(56);
}

class CustomCard extends StatelessWidget {
  final Widget child;
  const CustomCard({required this.child, Key? key}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 3,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(15)),
      child: Padding(padding: const EdgeInsets.all(20), child: child),
    );
  }
}

class CustomInput extends StatelessWidget {
  final TextEditingController controller;
  final String label;
  final IconData icon;
  final bool isPassword;
  final TextInputType keyboard;
  final String? Function(String?)? validator;
  const CustomInput({
    required this.controller,
    required this.label,
    required this.icon,
    this.isPassword = false,
    this.keyboard = TextInputType.text,
    this.validator,
    Key? key,
  }) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(label, style: const TextStyle(fontWeight: FontWeight.w600)),
        const SizedBox(height: 5),
        TextFormField(
          controller: controller,
          obscureText: isPassword,
          keyboardType: keyboard,
          validator: validator,
          decoration: InputDecoration(
            prefixIcon: Icon(icon),
            border: OutlineInputBorder(borderRadius: BorderRadius.circular(10)),
            contentPadding: const EdgeInsets.symmetric(
              horizontal: 15,
              vertical: 12,
            ),
          ),
        ),
        const SizedBox(height: 15),
      ],
    );
  }
}

class CustomButton extends StatelessWidget {
  final String text;
  final VoidCallback onTap;
  final IconData? icon;
  const CustomButton({
    required this.text,
    required this.onTap,
    this.icon,
    Key? key,
  }) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: ElevatedButton(
        onPressed: onTap,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            if (icon != null) Icon(icon, size: 18),
            if (icon != null) const SizedBox(width: 8),
            Text(text, style: const TextStyle(fontSize: 16)),
          ],
        ),
      ),
    );
  }
}
