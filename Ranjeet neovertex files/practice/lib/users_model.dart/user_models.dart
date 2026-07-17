class User {
  final String text;

  User({required this.text});

  // convert the json file to object file  for users because users  didn't understand the json. file
  factory User.fromJson(Map<String, dynamic> json) {
    return User(text: json['text'] ?? "No message");
  }

  // this convert the object file to json file for server because server didn't understand the obj. file 
  Map<String, dynamic> toJson() {
    return {'text': text};
  }
}
