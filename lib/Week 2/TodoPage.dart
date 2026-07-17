import 'package:flutter/material.dart';

class Todo {
  String title;
  bool isDone;

  Todo({required this.title, this.isDone = false});
}

class TodoHomePage extends StatefulWidget {
  const TodoHomePage({super.key});

  @override
  State<TodoHomePage> createState() => _TodoHomePageState();
}

class _TodoHomePageState extends State<TodoHomePage> {
  final TextEditingController controller = TextEditingController();
  final List<Todo> todos = [];

  // initstate is initialized
  @override
  void initState() {
    super.initState();
    print("Todo App started...");
  }

  // Dispose action
  @override
  void dispose() {
    controller.dispose();
    super.dispose();
    print("Todo App closed 🧹");
  }

  //Add task function
  void addTask() {
    final text = controller.text.trim();

    if (text.isEmpty) {
      ScaffoldMessenger.of(
        context,
      ).showSnackBar(const SnackBar(content: Text("Task Is Empty!")));
      return;
    }

    setState(() {
      // Ui rebuild from here
      todos.add(Todo(title: text));
      controller.clear();
    });
  }

  // toogle button function
  void toggleTask(int index) {
    setState(() {
      todos[index].isDone = !todos[index].isDone;
    });
  }

  // delete task function
  void deleteTask(int index) {
    setState(() {
      todos.removeAt(index);
    });
  }

  // edit task function
  void editTask(int index) {
    final editController = TextEditingController(text: todos[index].title);

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: const Text("Edit Task"),

          content: TextField(controller: editController, autofocus: true),

          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text("Cancel"),
            ),

            ElevatedButton(
              onPressed: () {
                final newText = editController.text.trim();

                if (newText.isNotEmpty) {
                  setState(() {
                    todos[index].title = newText;
                  });
                }

                Navigator.pop(context);
              },
              child: const Text("Save"),
            ),
          ],
        );
      },
    );
  }

  // finally build UI from here
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF4F6FA),

      appBar: AppBar(
        title: const Text("Todo App"),
        centerTitle: true,
        backgroundColor: Colors.blue,
      ),

      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(12),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: controller,
                    decoration: InputDecoration(
                      hintText: "Enter task...",
                      filled: true,
                      fillColor: Colors.white,
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(10),
                      ),
                    ),
                    onSubmitted: (_) => addTask(),
                  ),
                ),

                const SizedBox(width: 10),

                ElevatedButton(onPressed: addTask, child: const Text("Add")),
              ],
            ),
          ),

          // TASK list
          Expanded(
            child: todos.isEmpty
                ? const Center(child: Text("No tasks yet 😊"))
                : ListView.builder(
                    itemCount: todos.length,
                    itemBuilder: (context, index) {
                      final todo = todos[index];

                      return Container(
                        margin: const EdgeInsets.symmetric(
                          horizontal: 12,
                          vertical: 6,
                        ),
                        decoration: BoxDecoration(
                          color: Colors.white,
                          borderRadius: BorderRadius.circular(10),
                          boxShadow: const [
                            BoxShadow(blurRadius: 4, color: Colors.black12),
                          ],
                        ),

                        child: ListTile(
                          leading: Checkbox(
                            value: todo.isDone,
                            onChanged: (_) => toggleTask(index),
                          ),

                          title: Text(
                            todo.title,
                            style: TextStyle(
                              decoration: todo.isDone
                                  ? TextDecoration.lineThrough
                                  : null,
                              color: todo.isDone ? Colors.grey : Colors.black,
                            ),
                          ),

                          trailing: Row(
                            mainAxisSize: MainAxisSize.min,
                            children: [
                              IconButton(
                                icon: const Icon(
                                  Icons.edit,
                                  color: Colors.orange,
                                ),
                                onPressed: () => editTask(index),
                              ),
                              IconButton(
                                icon: const Icon(
                                  Icons.delete,
                                  color: Colors.red,
                                ),
                                onPressed: () => deleteTask(index),
                              ),
                            ],
                          ),
                        ),
                      );
                    },
                  ),
          ),
        ],
      ),
    );
  }
}
