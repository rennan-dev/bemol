import 'dart:io';

import 'package:entregar/services/character_service.dart';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../helpers/logout.dart';
import '../../commom/confirmation_dialog.dart';
import '../../commom/exception_dialog.dart';
import 'forca_personagem.dart';

class Personagem extends StatefulWidget {
  final String? id;
  final String nome;
  final int forca;
  final String raca;
  final String image;
  final VoidCallback? onRefresh;
  final int userId;

  // Construtor padrão com onRefresh opcional
  Personagem(this.nome, this.forca, this.raca, this.image, this.userId, {this.id, this.onRefresh, super.key});

  int life = 10;

  // Construtor de fábrica com onRefresh opcional (valores default)
  Personagem.fromMap(Map<String, dynamic> map, [this.onRefresh])
      : id = map["id"] != null ? map["id"].toString() : null,
        nome = map["nome"],
        forca = map["forca"],
        raca = map["raca"],
        image = map["image"],
        userId = map["userId"];

  Map<String, dynamic> toMap() {
    final map = {
      "nome": nome,
      "forca": forca,
      "raca": raca,
      "image": image,
      "userId": userId
    };

    if (id != null) {
      map["id"] = id.toString();
    }
    return map;
  }

  @override
  State<Personagem> createState() => _PersonagemState();
}

class _PersonagemState extends State<Personagem> {

  bool assetOrNetwork() {
    if(widget.image.contains('http')) {
      return false;
    }
    return true;
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8),
      child: Stack(
        children: [
          Container(
            decoration: BoxDecoration(borderRadius: BorderRadius.circular(4), color: const Color(0xFF4A00E0)), height: 140, ),
          Column(
            children: [
              Container(
                decoration: BoxDecoration(color: Colors.white60, borderRadius: BorderRadius.circular(4)), height: 100, child:
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Container(
                    decoration: BoxDecoration(color: Colors.black26, borderRadius: BorderRadius.circular(4)), width: 72, height: 100,
                    child: ClipRRect(
                      borderRadius: BorderRadius.circular(4),
                      child: assetOrNetwork() ? Image.asset(widget.image, fit: BoxFit.cover) : Image.network(widget.image, fit: BoxFit.cover),
                    ),
                  ),
                  Column(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      SizedBox(
                          width: 200, child: Text(widget.nome, style: const TextStyle(fontSize: 18), overflow: TextOverflow.ellipsis,
                      )),
                      SizedBox(
                        width: 200, child: Text(widget.raca, style: const TextStyle(fontSize: 15), overflow: TextOverflow.ellipsis,),
                      ),
                      ForcaPersonagem(forca: widget.forca),
                    ],
                  ),
                  Column(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        ElevatedButton(onPressed: () {
                          setState(() {
                            widget.life < 10 ? widget.life++ : widget.life;
                          });
                        }, style: ElevatedButton.styleFrom(
                          minimumSize: const Size(40, 40),
                          backgroundColor: const Color(0xFF8E2DE2),
                          shape: const CircleBorder(),
                        ),
                          child: const Icon(Icons.arrow_drop_up_outlined, color: Colors.white),
                        ),
                        ElevatedButton(onPressed: () {
                          setState(() {
                            widget.life > 0 ? widget.life-- : widget.life;
                          });
                        },
                          onLongPress: () {
                            setState(() {
                              if (widget.life == 0) {
                                removePersonagem(context, widget.id);
                              }
                            });
                          }, style: ElevatedButton.styleFrom(
                            minimumSize: const Size(40, 40),
                            backgroundColor: const Color(0xFF8E2DE2),
                            shape: const CircleBorder(),
                          ),
                          child: const Icon(Icons.arrow_drop_down_outlined, color: Colors.white),
                        ),
                      ]
                  ),
                ],
              ),),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Padding(
                      padding: const EdgeInsets.all(8),
                      child: SizedBox(width: 200, child: LinearProgressIndicator(
                        color: Colors.green,
                        value: widget.life / 10,
                      ))),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: Text('Vida ${widget.life * 10}', style: const TextStyle(color: Colors.white, fontSize: 16),),
                  ),
                ],
              ),
            ],
          )
        ],
      ),
    );
  }

  void removePersonagem(BuildContext context, String? personagemId) {

    SharedPreferences.getInstance().then((prefs) {
      String? token = prefs.getString("accessToken");
      if(token!=null) {
        if (personagemId == null || personagemId.isEmpty) {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text("ID do personagem inválido")),
          );
          return;
        }

        CharacterService personagemService = CharacterService();
        showConfirmationDialog(
          context,
          content: "Deseja excluir personagem?",
          affirmativeOption: "Excluir",
        ).then((confirmar) {
          if (confirmar != null && confirmar) {
            personagemService.delete(personagemId, token).then((success) {
              if (success) {
                ScaffoldMessenger.of(context).showSnackBar(
                  const SnackBar(content: Text("Personagem removido com sucesso.")),
                );
                if (widget.onRefresh != null) {
                  widget.onRefresh!(); // Só chama se onRefresh não for nulo
                }
              }
            }).catchError(
                  (error) {
                logout(context);
              },
              test: (error) => error is TokenNotValidException,
            ).catchError(
                    (error) {
                  var innerError = error as HttpException;
                  showExceptionDialog(context, content: innerError.message);
                },
                test: (error) => error is HttpException
            );
          }
        });
      }
    });
  }
}
