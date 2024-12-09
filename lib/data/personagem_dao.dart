import 'package:entregar/components/personagem.dart';
import 'package:sqflite/sqflite.dart';

import 'database.dart';

class PersonagemDao {
  static const String tableSQL = 'CREATE TABLE $_tableName('
      '$_name TEXT,'
      '$_raca TEXT,'
      '$_forca INTEGER,'
      '$_imagem TEXT'
      ');';

  static const String _tableName = 'characterTable';
  static const String _name = 'name';
  static const String _raca = 'raca';
  static const String _forca = 'forca';
  static const String _imagem = 'image';

  save(Personagem personagem) async {
    final Database bancoDeDados = await getDatabase();
    var personagensExists = await find(personagem.nome);
    Map<String, dynamic> personagemMap = toMap(personagem);
    if(personagensExists.isEmpty) {
      return await bancoDeDados..insert(_tableName, personagemMap);
    }else {
      return await bancoDeDados.update(_tableName, personagemMap, where: '$_name = ?', whereArgs: [personagem.nome]);
    }
  }

  Future<List<Personagem>> find(String personagemName) async {
    final Database bancoDeDados = await getDatabase();
    final List<Map<String, dynamic>> result = await bancoDeDados.query(_tableName, where: '$_name = ?', whereArgs: [personagemName]);
    return toList(result);
  }

  Future<List<Personagem>> findAll() async {
    final Database bancoDeDados = await getDatabase();
    final List<Map<String, dynamic>> result = await bancoDeDados.query(_tableName);
    return toList(result);
  }

  List<Personagem> toList(List<Map<String, dynamic>> mapPersonagens) {
    List<Personagem> personagensList = [];
    for(Map<String,dynamic> linha in mapPersonagens) {
      final Personagem personagem = Personagem(linha[_name], linha[_forca], linha[_raca], linha[_imagem]);
      personagensList.add(personagem);
    }
    return personagensList;
  }

  delete(String nomePersonagem) async {
    final Database bancoDeDados = await getDatabase();
    return bancoDeDados.delete(_tableName, where: '$_name = ?', whereArgs: [nomePersonagem]);
  }

  Map<String,dynamic> toMap(Personagem personagem) {
    final Map<String,dynamic> mapaDePersonagens = {};
    mapaDePersonagens[_name] = personagem.nome;
    mapaDePersonagens[_forca] = personagem.forca;
    mapaDePersonagens[_raca] = personagem.raca;
    mapaDePersonagens[_imagem] = personagem.image;
    return mapaDePersonagens;
  }
}