import 'package:entregar/components/personagem.dart';
import 'package:entregar/data/personagem_dao.dart';
import 'package:flutter/material.dart';

class FormScreen extends StatefulWidget {
  const FormScreen({super.key, required this.formContext});

  final BuildContext formContext;

  @override
  State<FormScreen> createState() => _FormScreenState();
}

class _FormScreenState extends State<FormScreen> {

  TextEditingController nomeController = TextEditingController();
  TextEditingController racaController = TextEditingController();
  TextEditingController forcaController = TextEditingController();
  TextEditingController imagemController = TextEditingController();

  final _formKey = GlobalKey<FormState>();

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
          title: const Text('Adicionar Personagem'),
          backgroundColor: Colors.lightGreen,
        ),
        body: Center(
          child: SingleChildScrollView(
            child: Container(
              height: 650,
              width: 375,
              decoration: BoxDecoration(
                color: Colors.lightGreen,
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
                      PersonagemDao().save(Personagem(nomeController.text, int.parse(forcaController.text), racaController.text, imagemController.text));
                      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Personagem criado com sucesso!')));
                      Navigator.pop(context, true);
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
}
