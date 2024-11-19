

import 'package:entregar/components/forca_personagem.dart';
import 'package:flutter/material.dart';

class PersonagemCard extends StatefulWidget {
  final String nome;
  final int forca;
  final String raca;
  final String image;

  const PersonagemCard(this.nome, this.forca, this.raca, this.image, {super.key});

  @override
  State<PersonagemCard> createState() => _PersonagemCardState();
}

class _PersonagemCardState extends State<PersonagemCard> {
  int life = 10;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8),
      child: Stack(
        children: [
          Container(
            decoration: BoxDecoration(borderRadius: BorderRadius.circular(4), color: Colors.lightGreen,), height: 140,),
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
                        child: Image.asset(widget.image, fit: BoxFit.cover,
                        )),
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
                        ElevatedButton(onPressed: (){
                          setState(() {
                            life<10?life++:life;
                          });
                        }, style: ElevatedButton.styleFrom(
                          minimumSize: const Size(40, 40),
                          backgroundColor: Colors.green,
                          shape: const CircleBorder(),
                        ),
                          child: const Icon(Icons.arrow_drop_up_outlined, color: Colors.white),
                        ),
                        ElevatedButton(onPressed: (){
                          setState(() {
                            life>0?life--:life;
                          });
                        }, style: ElevatedButton.styleFrom(
                          minimumSize: const Size(40, 40),
                          backgroundColor: Colors.green,
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
                      value: life/10,
                    )),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: Text('Vida ${life*10}', style: const TextStyle(color: Colors.white, fontSize: 16),),
                  ),
                ],
              ),
            ],
          )
        ],
      ),
    );
  }
}