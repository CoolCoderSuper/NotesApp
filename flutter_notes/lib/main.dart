import 'package:flutter/material.dart';
import 'package:darq/darq.dart';

import 'api.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Notes',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const MyHomePage(title: 'Notes'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<Note>? notes;

  @override
  void initState() {
    loadNotes().then((value) => setState(() => {}));
    super.initState();
  }

  Future<void> loadNotes() async {
    notes = await NoteService.getNotes();
  }

  Future<void> addNote() async {
    Iterable<Note> l = notes!;
    var note = Note(id: (l.isNotEmpty ? l.select((x, i) => x.id).max() : 0) + 1, content: "");
    setState(() {
      notes?.add(note);
    });
    await NoteService.addNote(note);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            FilledButton(onPressed: addNote, child: const Icon(Icons.add)),
            Expanded(
                child: ListView(
                    children: List.generate(notes?.length ?? 0, (index) {
              var note = notes![index];
              var controller = TextEditingController(text: note.content);
              controller.addListener(() async {
                note.content = controller.value.text;
                await NoteService.updateNote(note);
              });
              return Row(mainAxisAlignment: MainAxisAlignment.start, children: [
                Flexible(child: TextField(controller: controller)),
                FilledButton(
                    onPressed: () async {
                      setState(() {
                        notes?.remove(note);
                      });
                      await NoteService.deleteNote(note.id);
                    },
                    child: const Icon(Icons.delete))
              ]);
            })))
          ],
        ),
      ),
    );
  }
}
