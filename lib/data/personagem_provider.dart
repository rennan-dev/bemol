import 'package:entregar/components/personagem.dart';
import 'package:flutter/material.dart';

class PersonagemProvider extends InheritedWidget {
  PersonagemProvider({
    super.key,
    required super.child,
  });

  final List<Personagem> personagemList = [
    Personagem('Meliodas', 5, 'Demônio', 'assets/images/meliodas.png'),
    Personagem('Ban', 4, 'Humano', 'assets/images/ban.png'),
    Personagem('Diane', 3, 'Gigante', 'assets/images/diane.jpg'),
    Personagem('Escanor', 5, 'Humano', 'assets/images/escanor.jpg'),
    Personagem('Gowther', 3, 'Marionete ', 'assets/images/gowther.jpg'),
    Personagem('King', 4, 'Fada', 'assets/images/king.png'),
    Personagem('Merlin', 4, 'Humana', 'assets/images/merlin.png'),
  ];

  void newPersonagem(String nome, String raca, int forca, String urlImage) {
    personagemList.add(Personagem(nome, forca, raca, urlImage));
  }

  static PersonagemProvider of(BuildContext context) {
    final PersonagemProvider? result =
    context.dependOnInheritedWidgetOfExactType<PersonagemProvider>();
    assert(result != null, 'No PersonagemProvider found in context');
    return result!;
  }

  @override
  bool updateShouldNotify(PersonagemProvider oldWidget) {
    return oldWidget.personagemList.length != personagemList.length;
  }
}