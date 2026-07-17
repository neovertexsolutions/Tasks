import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:practice/Week%203/APIScreenPage.dart';
import 'package:practice/Week%203/PostAPILogin.dart';
import 'package:practice/Week%203/UsersListPage.dart';
import 'APIBasicPage.dart';

class Week3HomePage extends StatefulWidget {
  final String title;

  const Week3HomePage({super.key, required this.title});

  @override
  State<Week3HomePage> createState() => _Week3HomePageState();
}

class _Week3HomePageState extends State<Week3HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        title: Text(
          widget.title,
          style: GoogleFonts.poppins(
            fontWeight: FontWeight.w600,
            fontSize: 20,
            color: Colors.white,
          ),
        ),
        centerTitle: true,
        backgroundColor: Colors.deepPurple,
        elevation: 0,
      ),
      body: SafeArea(
        child: SingleChildScrollView(
          physics: const BouncingScrollPhysics(),
          child: Padding(
            padding: const EdgeInsets.symmetric(
              horizontal: 20.0,
              vertical: 24.0,
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Welcome to ${widget.title}',
                  style: GoogleFonts.poppins(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: const Color(0xFF212529),
                  ),
                ),
                const SizedBox(height: 6),
                Text(
                  'Tap any button below to explore the API.',
                  style: GoogleFonts.inter(
                    fontSize: 14,
                    color: Colors.grey[600],
                  ),
                ),
                const SizedBox(height: 20),

                // Note Card: Placed the terminal text cleanly inside a box.
                _buildNoteCard(),

                const SizedBox(height: 24),

                // Button 1: Goes to APIBasicPage
                _buildMenuButton(
                  title: 'Button 1',
                  subtitle: 'Explore GET & POST',
                  onTap: () => Navigator.push(
                    context,
                    MaterialPageRoute(builder: (_) => const APIBasicPage()),
                  ),
                ),
                const SizedBox(height: 16),

                // Button 3:Goes to UserListPage
                _buildMenuButton(
                  title: 'Button 2',
                  subtitle: 'Check JSON Format (User List)',
                  onTap: () => Navigator.push(
                    context,
                    MaterialPageRoute(builder: (_) => const UserListPage()),
                  ),
                ),
                const SizedBox(height: 16),
                // Button 3:Goes to UserListPage
                _buildMenuButton(
                  title: 'Button 3',
                  subtitle: 'Check JSON Format (User List)',
                  onTap: () => Navigator.push(
                    context,
                    MaterialPageRoute(builder: (_) => PostAPILogin()),
                  ),
                ),

                const SizedBox(height: 16),
                // Button 3:Goes to UserListPage
                _buildMenuButton(
                  title: 'Button 4',
                  subtitle: 'Check JSON Format (User List)',
                  onTap: () => Navigator.push(
                    context,
                    MaterialPageRoute(builder: (_) => ApiScreenPage()),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  // Function that makes the terminal note into a readable container
  Widget _buildNoteCard() {
    return Container(
      width: double.infinity,
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: Colors.amber.shade50,
        borderRadius: BorderRadius.circular(12),
        border: Border.all(color: Colors.amber.shade200),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            children: [
              Icon(Icons.terminal, color: Colors.amber.shade800, size: 20),
              const SizedBox(width: 8),
              Text(
                "Server Status Note:",
                style: GoogleFonts.poppins(
                  fontSize: 14,
                  fontWeight: FontWeight.w600,
                  color: Colors.amber.shade900,
                ),
              ),
            ],
          ),
          const SizedBox(height: 10),
          Container(
            width: double.infinity,
            padding: const EdgeInsets.all(12),
            decoration: BoxDecoration(
              color: const Color(0xFF1E1E1E),
              borderRadius: BorderRadius.circular(8),
            ),
            child: Text(
              "C:\\Users\\ranje>cd /d D:\\api_server\n\n"
              "D:\\api_server>node server.js\n"
              "Server running on http://localhost:3000",
              style: GoogleFonts.firaCode(
                // Terminal font type
                fontSize: 12,
                color: const Color(0xFF4AF626),
                height: 1.5,
              ),
            ),
          ),
        ],
      ),
    );
  }

  // Dynamic button design
  Widget _buildMenuButton({
    required String title,
    required String subtitle,
    required VoidCallback onTap,
  }) {
    return InkWell(
      onTap: onTap,
      borderRadius: BorderRadius.circular(16),
      child: Container(
        width: double.infinity,
        padding: const EdgeInsets.all(20),
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(16),
          boxShadow: [
            BoxShadow(
              color: Colors.black.withOpacity(0.04),
              blurRadius: 10,
              offset: const Offset(0, 4),
            ),
          ],
          border: Border.all(color: Colors.grey.withOpacity(0.15), width: 1),
        ),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              title,
              style: GoogleFonts.poppins(
                fontSize: 16,
                fontWeight: FontWeight.w600,
                color: const Color(0xFF212529),
              ),
            ),
            const SizedBox(height: 4),
            Text(
              subtitle,
              style: GoogleFonts.inter(fontSize: 12, color: Colors.grey[500]),
            ),
          ],
        ),
      ),
    );
  }
}
