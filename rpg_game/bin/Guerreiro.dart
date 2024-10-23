import 'Personagem.dart';
import 'Combate.dart';

class Guerreiro extends Personagem implements Combate {
  String arma = 'Machado e Escudo';

  Guerreiro(String nome, String raca, int idade, int vida, int energia, double altura, bool isMagico, List<String> habilidades): super(nome, raca, 'Guerreiro', idade, vida, energia, altura, isMagico, habilidades);

  @override
  String exibirFicha() {
    return '${super.exibirFicha()}Arma: $arma\n';
  }

  void atacar(Personagem personagem) {
    print('------------------------------------------------------------------------------------');
    if(personagem.nome != nome) {
      if(personagem.vida>0) {
      print('\nCombate acontecendo');
      print('$nome atacando ${personagem.nome}');
      personagem.vida -= 15;
      print('Dano de ataque: 15\nVida atual de ${personagem.nome}: ${personagem.vida}');
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
      }else {
        print('\nCombate não pode ocorrer porque ${personagem.nome} está sem vida\n');
      }
    }else {
      print('\nO personagem não pode atacar o mesmo personagem.\n');
    }
  }
}