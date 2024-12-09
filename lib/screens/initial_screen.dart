

import 'package:entregar/components/personagem.dart';
import 'package:entregar/data/personagem_dao.dart';
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
        actions: [
          IconButton(onPressed: (){setState(() {

          });}, icon: const Icon(Icons.refresh)),
        ],
        backgroundColor: Colors.lightGreen,
      ),
      body: Padding(padding: const EdgeInsets.only(top: 8, bottom: 70),
        child: FutureBuilder<List<Personagem>>
          (future: PersonagemDao().findAll(), builder: (context, snapshot){
            List<Personagem>? personagens = snapshot.data;
            switch(snapshot.connectionState) {

              case ConnectionState.none:
                return const Center(child: Column(
                  children: [
                    CircularProgressIndicator(),
                    Text('Carregando'),
                  ],
                ),);
              case ConnectionState.waiting:
                return const Center(child: Column(
                  children: [
                    CircularProgressIndicator(),
                    Text('Carregando'),
                  ],
                ),);
              case ConnectionState.active:
                return const Center(child: Column(
                  children: [
                    CircularProgressIndicator(),
                    Text('Carregando'),
                  ],
                ),);
              case ConnectionState.done:
                if(snapshot.hasData && personagens!=null) {
                  if(personagens.isNotEmpty) {
                    return ListView.builder(itemCount: personagens.length, itemBuilder: (BuildContext context, int index){
                      final Personagem personagemCard = personagens[index];
                      return personagemCard;
                    });
                  }
                  return const Center(child: Column(
                    children: [
                      Icon(Icons.error_outline, size: 128,),
                      Text('Não há nenhum personagem.',
                      style: TextStyle(fontSize: 24),),
                    ],
                  ),);
                }
                return const Text('Erro ao carregar personagens.');
            }
        },),
      ),
      floatingActionButton: FloatingActionButton(onPressed: (){
        Navigator.push(
            context, MaterialPageRoute(
            builder: (contextNew) => FormScreen(formContext: context,),),
        ).then((value) {
          if (value == true) {
            setState(() {
            });
          }
        });
      },
        backgroundColor: const Color(0xFF05A52F),
        child: const Icon(Icons.add, color: Colors.white,),
      ),
    );
  }
}