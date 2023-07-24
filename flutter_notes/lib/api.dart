import 'dart:convert';

import 'package:http/http.dart' as http;

class NoteService {
  static const String baseUrl = "http://192.168.11.74:5446";

  static Future<List<Note>> getNotes() async {
    var res = await http.get(Uri.parse('$baseUrl/Notes'));
    if (res.statusCode == 200) {
      Iterable l = json.decode(res.body);
      return List.from(l.map((e) => Note.fromJson(e)));
    }
    return List.empty();
  }

  static Future<Note> getNote(int id) async {
    var res = await http.get(Uri.parse('$baseUrl/Notes/$id'));
    if (res.statusCode == 200) {
      return Note.fromJson(jsonDecode(res.body));
    }
    return Note(id: 0, content: "");
  }

  static Future<void> addNote(Note note) async {
    await http.post(Uri.parse('$baseUrl/Notes'),
        headers: {
          'Content-Type': 'application/json',
        },
        body: jsonEncode(note));
  }

  static Future<void> updateNote(Note note) async {
    await http.put(Uri.parse('$baseUrl/Notes'),
        headers: {
          'Content-Type': 'application/json', // Specify JSON body type
        },
        body: jsonEncode(note));
  }

  static Future<void> deleteNote(int id) async {
    await http.delete(Uri.parse('$baseUrl/Notes/$id'));
  }
}

class Note {
  final int id;
  String content;

  Note({required this.id, required this.content});

  factory Note.fromJson(Map<String, dynamic> json) {
    return Note(id: json["id"], content: json["content"]);
  }

  Map<String, dynamic> toJson() => {'id': id, 'content': content};
}
