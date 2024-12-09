import 'package:entregar/components/forca_personagem.dart';
import 'package:entregar/data/personagem_dao.dart';
import 'package:flutter/material.dart';

class Personagem extends StatefulWidget {
  final String nome;
  final int forca;
  final String raca;
  final String image;

  Personagem(this.nome, this.forca, this.raca, this.image, {super.key});

  int life = 10;

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
                        ElevatedButton(onPressed: (){
                          setState(() {
                            widget.life<10?widget.life++:widget.life;
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
                            widget.life>0?widget.life--:widget.life;
                          });
                        },
                        onLongPress: () {
                         setState(() {
                            if(widget.life==0) {
                              PersonagemDao().delete(widget.nome);
                            }
                         });
                        },style: ElevatedButton.styleFrom(
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
                      value: widget.life/10,
                    )),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: Text('Vida ${widget.life*10}', style: const TextStyle(color: Colors.white, fontSize: 16),),
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