import 'package:entregar/components/personagem.dart';
import 'package:flutter/material.dart';

class PersonagemProvider extends InheritedWidget {
  PersonagemProvider({
    super.key,
    required super.child,
  });

  final List<Personagem> personagemList = [];

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