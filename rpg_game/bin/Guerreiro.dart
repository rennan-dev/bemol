import 'Personagem.dart';
import 'Combate.dart';

class Guerreiro extends Personagem implements Combate {
  String _arma = 'Machado e Escudo';

  Guerreiro(String nome, String raca, int idade, int vida, int energia, double altura, bool isMagico, List<String> habilidades): super(nome, raca, 'Guerreiro', idade, vida, energia, altura, isMagico, habilidades);

  @override
  String exibirFicha() {
    return '${super.exibirFicha()}Arma: $_arma\n';
  }

  //getters - started
  String get getArma{
    return _arma;
  }
  //getters - ended

  //setters - stared
  void set setArma(String novaArma) {
    _arma = novaArma;
  }
  //setters - ended

  void atacar(Personagem personagem) {
    print('------------------------------------------------------------------------------------');
    if(personagem.getNome != getNome) {
      if(personagem.vida>0) {
      print('\nCombate acontecendo');
      print('$getNome atacando ${personagem.getNome}');
      personagem.vida -= 15;
      if(personagem.vida<0) { 
        personagem.vida = 0; 
      }
      print('Dano de ataque: 15\nVida atual de ${personagem.getNome}: ${personagem.vida}');
      print(
        "  ,   A           {}\n"
        " / \\, | ,        .--.\n"
        "|    =|= >      /.--.\\\n"
        " \\ /` | `       |====|\n"
        "  `   |         |`::`|  \n"
        "      |     .-;`\\..../`;_.-^-._\n"
        "     /\\\\/  /  |...::..|`   :   `|\n"
        "     |:'\\ |   /'''::''|   .:.   |\n"
        "      \\ /\\;-,/\\   ::  |..:::::..|\n"
        "      |\\ <` >  >._::_.| ':::::' |\n"
        "      | `\"\"`  /   ^^  |   ':'   |\n"
        "      |       |       \\    :    /\n"
        "      |       |        \\   :   / \n"
        "      |       |___/\\___|`-.:.-`\n"
        "      |        \\_ || _/    `\n"
        "      |        <_ >< _>\n"
        "      |        |  ||  |\n"
        "      |        |  ||  |\n"
        "      |       _\\.:||:./_\n"
        "      |      /____/\\____\\\n"
      );

      atualizarStatus(personagem);
      
      }else {
        print('\nCombate não pode ocorrer porque ${personagem.getNome} está sem vida\n');
      }
    }else {
      print('\nO personagem não pode atacar o mesmo personagem.\n');
    }
  }
}