import 'package:entregar/components/task.dart';
import 'package:flutter/material.dart';

class PersonagemProvider extends InheritedWidget {
  PersonagemProvider({
    super.key,
    required super.child,
  });

  final List<PersonagemCard> personagemList = [
    PersonagemCard('Meliodas', 5, 'Demônio', 'assets/images/meliodas.png'),
    PersonagemCard('Ban', 4, 'Humano', 'assets/images/ban.png'),
    PersonagemCard('Diane', 3, 'Gigante', 'assets/images/diane.jpg'),
    PersonagemCard('Escanor', 5, 'Humano', 'assets/images/escanor.jpg'),
    PersonagemCard('Gowther', 3, 'Marionete ', 'assets/images/gowther.jpg'),
    PersonagemCard('King', 4, 'Fada', 'assets/images/king.png'),
    PersonagemCard('Merlin', 4, 'Humana', 'assets/images/merlin.png'),
  ];

  void newPersonagem(String nome, String raca, int forca, String urlImage) {
    personagemList.add(PersonagemCard(nome, forca, raca, urlImage));
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