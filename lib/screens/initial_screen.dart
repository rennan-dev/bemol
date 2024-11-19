

import 'package:entregar/components/task.dart';
import 'package:flutter/material.dart';

class InitialScreen extends StatefulWidget {
  const InitialScreen({super.key});

  @override
  State<InitialScreen> createState() => _InitialScreenState();
}

class _InitialScreenState extends State<InitialScreen> {
  bool opacidade = true;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Lista de Personagens'),
        backgroundColor: Colors.lightGreen,
      ),
      body: AnimatedOpacity(
        opacity: opacidade?1:0,
        duration: const Duration(milliseconds: 1000),
        child: ListView(
          children: const [
            PersonagemCard('Meliodas', 5, 'Demônio', 'assets/images/meliodas.png'),
            PersonagemCard('Ban', 4, 'Humano', 'assets/images/ban.png'),
            PersonagemCard('Diane', 3, 'Gigante', 'assets/images/diane.jpg'),
            PersonagemCard('Escanor', 5, 'Humano', 'assets/images/escanor.jpg'),
            PersonagemCard('Gowther', 3, 'Marionete ', 'assets/images/gowther.jpg'),
            PersonagemCard('King', 4, 'Fada', 'assets/images/king.png'),
            PersonagemCard('Merlin', 4, 'Humana', 'assets/images/merlin.png'),
            SizedBox(height: 90,),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(onPressed: (){
        setState(() {
          opacidade = !opacidade;
        });
      },
        backgroundColor: const Color(0xFF05A52F),
        child: const Icon(Icons.remove_red_eye, color: Colors.white,),
      ),
    );
  }
}