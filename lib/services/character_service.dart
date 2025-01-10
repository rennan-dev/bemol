import 'dart:convert';
import 'dart:io';

import 'package:entregar/services/webclient.dart';
import 'package:http/http.dart' as http;
import '../screens/initial_screen/widgets/personagem.dart';

class CharacterService {

  String url = Webclient.url;
  http.Client client = Webclient().client;
  static const String resource = "characters/";

  String getUrl() {
    return "$url$resource";
  }

  Future<bool> register(Personagem personagem, String token) async {
    String jsonPersonagem = json.encode(personagem.toMap());
    http.Response response = await client.post(
      Uri.parse(getUrl()),
      headers: {
        'Content-type': "application/json", "Authorization" : "Bearer $token",
      },
      body: jsonPersonagem,
    );
    if(response.statusCode!=201) {
      if(json.decode(response.body) == "jwt expired") {
        throw TokenNotValidException();
      }
      throw HttpException(response.body);
    }
    return true;
  }

  Future<bool> edit(String id, Personagem personagem, String token) async {
    String jsonPersonagem = json.encode(personagem.toMap());
    http.Response response = await client.put(
      Uri.parse("${getUrl()}$id"),
      headers: {
        'Content-type': "application/json", "Authorization" : "Bearer $token",
      },
      body: jsonPersonagem,
    );
    if(response.statusCode!=200) {
      if(json.decode(response.body) == "jwt expired") {
        throw TokenNotValidException();
      }
      throw HttpException(response.body);
    }
    return true;
  }

  Future<List<Personagem>> getAllCharacters({required String id, required String token}) async {
    try {
      http.Response response = await client.get(Uri.parse
        ("${url}users/$id/characters"),
        headers: {
          "Authorization" : "Bearer $token"
        }
      );

      if (response.statusCode != 200) {
        if(json.decode(response.body) == "jwt expired") {
          throw TokenNotValidException();
        }
        throw HttpException(
            "Erro ao buscar personagens. Código: ${response.statusCode}");
      }

      List<dynamic> personagensDynamic = json.decode(response.body);
      return personagensDynamic.map((jMap) => Personagem.fromMap(jMap)).toList();
    } catch (e) {
      rethrow;
    }
  }

  Future<bool> delete(String id, String token) async {
    final url = Uri.parse("${getUrl()}$id");
    final http.Response response = await http.delete(
      url,
      headers: {
        "Authorization": "Bearer $token",
      },
    );

    if (response.statusCode != 200) {
      if(json.decode(response.body) == "jwt expired") {
        throw TokenNotValidException();
      }

      throw HttpException("Erro ao excluir personagem: ${response.body}");
    }
    return true;
  }
}

class TokenNotValidException implements Exception {}