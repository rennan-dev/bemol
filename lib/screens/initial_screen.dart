

import 'package:entregar/data/personagem_provider.dart';
import 'package:entregar/screens/form_screen.dart';
import 'package:flutter/material.dart';

class InitialScreen extends StatefulWidget {
  const InitialScreen({super.key});

  @override
  State<InitialScreen> createState() => _InitialScreenState();
}

class _InitialScreenState extends State<InitialScreen> {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Lista de Personagens'),
        backgroundColor: Colors.lightGreen,
      ),
      body: ListView(
        padding: const EdgeInsets.only(top: 8, bottom: 70),
        children: PersonagemProvider.of(context).personagemList,
      ),
      floatingActionButton: FloatingActionButton(onPressed: (){
        Navigator.push(context, MaterialPageRoute(builder: (contextNew) => FormScreen(formContext: context,)));
      },
        backgroundColor: const Color(0xFF05A52F),
        child: const Icon(Icons.add, color: Colors.white,),
      ),
    );
  }
}