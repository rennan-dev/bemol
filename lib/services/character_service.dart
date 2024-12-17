import 'dart:convert';
import 'dart:io';

import 'package:entregar/components/personagem.dart';
import 'package:http/http.dart' as http;
import 'package:http_interceptor/http/intercepted_client.dart';

import 'http_interceptors.dart';

class CharacterService {
  static const String url = "http://192.168.80.106:3000/";
  static const String resource = "characters/";

  http.Client client = InterceptedClient.build(interceptors: [LoggerInterceptor()]);

  String getUrl() {
    return "$url$resource";
  }

  Future<bool> register(Personagem personagem) async {
    String jsonPersonagem = json.encode(personagem.toMap());
    http.Response response = await client.post(
      Uri.parse(getUrl()),
      headers: {
        'Content-type': "application/json",
      },
      body: jsonPersonagem,
    );
    if(response.statusCode==201) {
      return true;
    }
    return false;
  }

  Future<List<Personagem>> getAllCharacters() async {
    try {
      http.Response response = await client.get(Uri.parse(getUrl()));

      if (response.statusCode != 200) {
        throw HttpException(
            "Erro ao buscar personagens. Código: ${response.statusCode}");
      }

      List<dynamic> personagensDynamic = json.decode(response.body);
      return personagensDynamic.map((jMap) => Personagem.fromMap(jMap)).toList();
    } catch (e) {
      print("Erro no getAllCharacters: $e");
      rethrow;
    }
  }


  Future<bool> delete(String id) async {
    final url = Uri.parse("${getUrl()}$id");
    final http.Response response = await http.delete(url);

    if (response.statusCode != 200) {
      throw HttpException("Erro ao excluir personagem: ${response.body}");
    }
    return true;
  }

}