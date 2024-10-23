import 'Personagem.dart';
import 'Combate.dart';

class Mago extends Personagem  implements Combate {
  String arma = 'Cajado Mágico';

  Mago(String nome, String raca, int idade, int vida, int energia, double altura, bool isMagico, List<String> habilidades): super(nome, raca, 'Mago', idade, vida, energia, altura, isMagico, habilidades);

  @override
  String exibirFicha() {
    return '${super.exibirFicha()}Arma: $arma\n';
  }

  void lancarFeitico() {
    print('------------------------------------------------------------------------------------');
    print(r'''
                  .

                   .
         /^\     .
    /\   "V"
   /__\   I      O  o
  //..\\  I     .
  \].`[/  I
  /l\/j\  (]    .  O
 /. ~~ ,\/I          .
 \\L__j^\/I       o
  \/--v}  I     o   .
  |    |  I   _________
  |    |  I c(`       ')o
  |    l  I   \.     ,/
_/j  L l\_!  _//^---^\\_    -Mago preparando seu feitiço
''');
  energia-=10;
  print('\n\n\n\t\t\-10 de energia\n\t\tEnergia atual: ${energia}');
  }

  void atacar(Personagem personagem) {
    print('------------------------------------------------------------------------------------');
    if(personagem.nome != nome) {
      if(personagem.vida>0) {
      print('\nCombate acontecendo');
      print('$nome atacando ${personagem.nome}');
      personagem.vida -= 10;
      print('Dano de ataque: 10\nVida atual de ${personagem.nome}: ${personagem.vida}');
      print("                             /\\");
      print("                            /  \\");
      print("                           |    |");
      print("                         --:'''':--");
      print("                           :'_' :");
      print("                           _:\"\":\\___");
      print("            ' '      ____.' :::     '._");
      print("           . *=====<<=)           \\    :");
      print("            .  '      '-'-'\\_      /'._.'");
      print("                             \\====:_ \"\"");
      print("                            .'     \\\\");
      print("                           :       :");
      print("                          /   :    \\");
      print("                         :   .      '.");
      print("         ,. _        pif :  : :      :");
      print("      '-'    ).          :__:-:__.;--'");
      print("    (        '  )        '-'   '-'");
      print(" ( -   .00.   - _");
      print("(    .'  _ )     )");
      print("'-  ()_.\\,\\,   -");
      }else {
        print('\nCombate não pode ocorrer porque ${personagem.nome} está sem vida\n');
      }
    }else {
      print('\nO personagem não pode atacar o mesmo personagem.\n');
    }
  }
}