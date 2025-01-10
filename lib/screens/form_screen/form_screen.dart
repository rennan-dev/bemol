import 'dart:io';

import 'package:entregar/services/character_service.dart';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../helpers/logout.dart';
import '../commom/exception_dialog.dart';
import '../initial_screen/widgets/personagem.dart';

class FormScreen extends StatefulWidget {
  const FormScreen({super.key, required this.formContext, this.personagem, required this.isEditing, required this.userId});

  final BuildContext formContext;
  final Personagem? personagem;
  final bool isEditing;
  final int userId;

  @override
  State<FormScreen> createState() => _FormScreenState();
}

class _FormScreenState extends State<FormScreen> {

  late TextEditingController nomeController;
  late TextEditingController racaController;
  late TextEditingController forcaController;
  late TextEditingController imagemController;

  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    super.initState();
    nomeController = TextEditingController(
      text: widget.personagem?.nome ?? '',
    );
    racaController = TextEditingController(
      text: widget.personagem?.raca ?? '',
    );
    forcaController = TextEditingController(
      text: widget.personagem?.forca.toString() ?? '',
    );
    imagemController = TextEditingController(
      text: widget.personagem?.image ?? '',
    );
  }

  @override
  void dispose() {
    nomeController.dispose();
    racaController.dispose();
    forcaController.dispose();
    imagemController.dispose();
    super.dispose();
  }

  bool valueValidate(String? value) {
    if(value!=null && value.isEmpty) {
      return true;
    }
    return false;
  }

  bool valueForcaValidate(String? value) {
    if(value!=null && value.isEmpty) {
      if(int.parse(forcaController.text)>5 || int.parse(forcaController.text)<1) {
        return true;
      }
    }
    return false;
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Scaffold(
        appBar: AppBar(
          iconTheme: const IconThemeData(
            color: Colors.white,
          ),
          title: Text(
            style: const TextStyle(color: Colors.white),
            widget.personagem == null
                ? 'Adicionar Personagem'
                : 'Editar Personagem',
          ),
          flexibleSpace: Container(
            decoration: const BoxDecoration(
              gradient: LinearGradient(
                colors: [Color(0xFF8E2DE2), Color(0xFF4A00E0)],
                begin: Alignment.topCenter,
                end: Alignment.bottomCenter,
              ),
            ),
          ),
        ),
        body: Center(
          child: SingleChildScrollView(
            child: Container(
              height: 650,
              width: 375,
              decoration: BoxDecoration(
                gradient: const LinearGradient(
                  colors: [Color(0xFF8E2DE2), Color(0xFF4A00E0)],
                  begin: Alignment.topCenter,
                  end: Alignment.bottomCenter,
                ),
                borderRadius: BorderRadius.circular(8),
                border: Border.all(width: 4),
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      validator: (String? value) {
                        if(valueValidate(value)) {
                          return 'Insira o nome do personagem';
                        }
                        return null;
                      },
                      keyboardType: TextInputType.text,
                      controller: nomeController,
                      textAlign: TextAlign.center,
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'Nome',
                        fillColor: Colors.white,
                        filled: true,
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      validator: (String? value) {
                        if(valueValidate(value)) {
                          return 'Insira a raça do personagem';
                        }
                        return null;
                      },
                      keyboardType: TextInputType.text,
                      controller: racaController,
                      textAlign: TextAlign.center,
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'Raça',
                        fillColor: Colors.white,
                        filled: true,
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      validator: (value) {
                        if(valueForcaValidate(value)) {
                          return 'Insira uma força entre 1 a 5';
                        }
                        return null;
                      },
                      controller: forcaController,
                      textAlign: TextAlign.center,
                      keyboardType: TextInputType.number,
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'Força',
                        fillColor: Colors.white,
                        filled: true,
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: TextFormField(
                      validator: (String? value) {
                        if(valueValidate(value)) {
                          return 'Insira uma url de imagem';
                        }
                        return null;
                      },
                      keyboardType: TextInputType.url,
                      onChanged: (text){
                        setState(() {
            
                        });
                      },
                      controller: imagemController,
                      textAlign: TextAlign.center,
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'Imagem',
                        fillColor: Colors.white,
                        filled: true,
                      ),
                    ),
                  ),
                  Container(
                    height: 100,
                    width: 72,
                    decoration: BoxDecoration(
                      color: Colors.black26,
                      borderRadius: BorderRadius.circular(10),
                      border: Border.all(width: 2),
                    ),
                    child: ClipRRect(
                      borderRadius: BorderRadius.circular(10),
                      child: Image.network(
                        imagemController.text,
                        errorBuilder: (BuildContext context, Object exception, StackTrace? stackTrace) {
                          return Image.asset('assets/images/sem_foto.png', fit: BoxFit.cover,);
                        },
                        fit: BoxFit.cover,
                      ),
                    ),
                  ),
                  ElevatedButton(onPressed: () {
                    if(_formKey.currentState!.validate()) {
                      // PersonagemDao().save(Personagem(nomeController.text, int.parse(forcaController.text), racaController.text, imagemController.text));
                      // ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Personagem criado com sucesso!')));
                      // Navigator.pop(context, true);
                      if(widget.isEditing) {
                        editChatacter(context);
                      }else {
                        registerCharacter(context);
                      }
                    }
                  },
                  child: const Text('Adicionar'),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
  void registerCharacter(BuildContext context) {
    CharacterService service = CharacterService();

    SharedPreferences.getInstance().then((prefs) {
      String? token = prefs.getString("accessToken");
      if(token!=null) {
        service.register(
          Personagem(
              nomeController.text,
              int.parse(forcaController.text),
              racaController.text,
              imagemController.text,
              widget.userId
          ), token,
        ).then((result) {
          String message = result
              ? 'Personagem adicionado com sucesso!'
              : 'Houve um erro ao adicionar um personagem!';

          Navigator.pop(context, message);
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

  void editChatacter(BuildContext context) {
    CharacterService service = CharacterService();

    SharedPreferences.getInstance().then((prefs) {
      String? token = prefs.getString("accessToken");
      if(token!=null) {
        service.edit(
          (widget.personagem?.id).toString(),
          Personagem(nomeController.text, int.parse(forcaController.text), racaController.text, imagemController.text, widget.userId), token,
        ).then((result) {
          String message = result
              ? 'Personagem editado com sucesso!'
              : 'Houve um erro ao editar o personagem!';

          Navigator.pop(context, message);
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
}
