import 'Personagem.dart';
import 'Combate.dart';
import './Feiticos.dart';

class Mago extends Personagem  implements Combate {
  String _arma = 'Cajado Mágico';
  Map<Feiticos, int> _feiticos = {};

  Mago(String nome, String raca, int idade, int vida, int energia, double altura, bool isMagico, List<String> habilidades): super(nome, raca, 'Mago', idade, vida, energia, altura, isMagico, habilidades);

  @override
  String exibirFicha() {

    return '${super.exibirFicha()}Arma: $_arma\n'
           'Tipo de Feitiço(s): ${_feiticos}';
  }

  //getters - started
  String get getArma{
    return _arma;
  }
  Map<Feiticos, int> get feiticos{
    return _feiticos;
  }
  //getters - ended

  //setters - stared
  void set setArma(String novaArma) {
    _arma = novaArma;
  }
  void set setFeiticos(Map<Feiticos, int> feiticos) {
    _feiticos = feiticos;
  }
  //setters - ended

  void adicionarFeitico(Feiticos feitico, int tipoFeitico) {
    _feiticos[feitico] = tipoFeitico;
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
    print('\n\n\n\t\t-10 de energia\n\t\tEnergia atual: ${energia}');
  }

  void atacar(Personagem personagem) {
    print('------------------------------------------------------------------------------------');
    if(personagem.getNome != getNome) {
      if(personagem.vida>0) {
      print('\nCombate acontecendo');
      print('$getNome atacando ${personagem.getNome}');
      personagem.vida -= 10;
      if(personagem.vida<0) { 
        personagem.vida = 0; 
      }
      print('Dano de ataque: 10\nVida atual de ${personagem.getNome}: ${personagem.vida}');
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
      
      atualizarStatus(personagem);
      
      }else {
        print('\nCombate não pode ocorrer porque ${personagem.getNome} está sem vida\n');
      }
    }else {
      print('\nO personagem não pode atacar o mesmo personagem.\n');
    }
  }
}