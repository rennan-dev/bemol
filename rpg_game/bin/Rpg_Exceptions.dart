import 'Personagem.dart';

class PersonagemDerrotadoException implements Exception {
  static const String report = 'PersonagemDerrotadoException';
  Personagem personagem;

  PersonagemDerrotadoException({required this.personagem});

  @override
  String toString() {
    return '${report}\nPersonagem ${personagem.getNome} está sem vida.';
  }
}