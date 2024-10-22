import 'dart:io';

void main() {
  List<Guerreiro> guerreiros = [];
  List<Mago> magos = [];

  print('\n');
  print('''  
██████╗░██████╗░░██████╗░  ░██████╗░░█████╗░███╗░░░███╗███████╗
██╔══██╗██╔══██╗██╔════╝░  ██╔════╝░██╔══██╗████╗░████║██╔════╝
██████╔╝██████╔╝██║░░██╗░  ██║░░██╗░███████║██╔████╔██║█████╗░░
██╔══██╗██╔═══╝░██║░░╚██╗  ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░
██║░░██║██║░░░░░╚██████╔╝  ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗
╚═╝░░╚═╝╚═╝░░░░░░╚═════╝░  ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝
''');

  int opcao;
  do {
    opcao = menu_inicial();
    if(opcao == 1) {
      criar_personagem(guerreiros, magos);
    }else if(opcao == 2) {
      mostrar_personagens(guerreiros, magos);
    }else if(opcao == 3) {
      fazer_feitico(magos);
    }else if(opcao ==4) {
      atacar(guerreiros, magos);
    }
  } while (opcao != 5);
}

int menu_inicial() {
  int res = 0;
  print('------------------------------------------------------------------------------------');
  print('\nMenu Inicial');
  print('1 - Criar personagem');
  print('2 - Visualizar personagens');
  print('3 - Fazer um feitiço com um mago');
  print('4 - Atacar um personagem');
  print('5 - Sair da Aplicação');
  print('\nResposta: ');

  String? input = stdin.readLineSync(); 
  if (input != null) {
    res = int.tryParse(input) ?? 0; 
  }
  return res; 
}

class Personagem {
  String nome, raca, classe;
  int idade, vida, energia;
  double altura;
  bool isMagico;
  List<String> habilidades;

  Personagem(this.nome, this.raca, this.classe, this.idade, this.vida, this.energia, this.altura, this.isMagico, this.habilidades);

  String exibirFicha() {
    return '\n'
           'Nome: $nome\nRaça: $raca\nClasse: $classe\n'
           'Idade: $idade\nVida: $vida\nEnergia: $energia\n'
           'Altura: $altura\nPossui Magia? $isMagico\n'
           'Conjunto de Habilidades:\n\t${habilidades.join('\n\t')}\n';
  }
}

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

abstract class Combate {
  void atacar(Personagem personagem);
}

void criar_personagem(List<Guerreiro> guerreiros, List<Mago> magos) {
  print('------------------------------------------------------------------------------------');

  String nome = lerEntrada('Digite o nome do personagem: ');
  if (guerreiros.any((guerreiro) => guerreiro.nome.toLowerCase() == nome.toLowerCase()) || 
      magos.any((mago) => mago.nome.toLowerCase() == nome.toLowerCase())) {
    print('Nome de personagem já existe. Por favor, escolha um nome diferente.');
    return; 
  }

  String raca = lerEntrada('Digite a raça do personagem: ');
  int idade = int.parse(lerEntrada('Digite a idade do personagem: '));
  double altura = double.parse(lerEntrada('Digite a altura do personagem: '));
  String classe = lerEntrada('Você quer ser um Guerreiro ou Mago? (digite "guerreiro" ou "mago"): ');

  // Verifica a escolha do usuário
  if (classe.toLowerCase() == 'guerreiro') {
    List<String> habilidades = ['Ataque físico', 'Quanto menos vida o guerreiro tiver, mais dano de ataque ele possui', 'Ao eliminar inimigos recebe uma recompensa maior em xp', 'Golpe com espada longa dão o dobro de dano'];
    Guerreiro guerreiro = new Guerreiro(nome, raca, idade, 100, 100, altura, false, habilidades);
    guerreiros.add(guerreiro);
    print('\nGuerreiro criado:\n${guerreiro.exibirFicha()}');

  } else if (classe.toLowerCase() == 'mago') {
    List<String> habilidades = ['Ataque mágico', 'Possui recuperação de vida uma vez durante combate', 'Agachar deixa o mago invisível', 'Usar o Lançar Feitiço te gera desgaste e o mago perde 10 pontos de energia.'];
    Mago mago = new Mago(nome, raca, idade, 100, 100, altura, true, habilidades);
    magos.add(mago);
    print('\nMago criado:\n${mago.exibirFicha()}');
  } else {
    print('\nRaça desconhecida. O personagem não foi criado.');
  }
}

String lerEntrada(String prompt) {
  String? input;
  do {
    stdout.write(prompt); // O `stdout.write` coloca o cursor ao lado da pergunta
    input = stdin.readLineSync();
    if (input == null || input.isEmpty) {
      print('Entrada inválida. Por favor, tente novamente.');
    }
  } while (input == null || input.isEmpty); // Loop até receber uma entrada válida
  return input;
}

void mostrar_personagens(List<Guerreiro> guerreiros, List<Mago> magos) {
  print('------------------------------------------------------------------------------------');
  print('\nGuerreiros:\n');
  for(Guerreiro guerreiro in guerreiros) {
    print(guerreiro.exibirFicha());
  }

  print('\nMagos:\n');
  for(Mago mago in magos) {
    print(mago.exibirFicha());
  }
} 

void fazer_feitico(List<Mago> magos) {
  print('------------------------------------------------------------------------------------');
  print('\nFazer magia\n');
  String nome = lerEntrada('Digite o nome do personagem: ');

  Mago? mago = magos.firstWhere(
    (m) => m.nome.toLowerCase() == nome.toLowerCase(),
    orElse: () => Mago('','',0,0,0,0,false,[])
  );

  if (mago.nome.isEmpty) {
    print('Personagem não existe! Tente com outro');
  } else {
    if (mago.energia >= 10) {
      mago.lancarFeitico(); 
    } else {
      print('Energia insuficiente para lançar o feitiço. Energia atual: ${mago.energia}');
    }
  }
}

void atacar(List<Guerreiro> guerreiros, List<Mago> magos) {
  print('------------------------------------------------------------------------------------');
  print('Escolha um personagem para atacar:\n');

  for (int i = 0; i < guerreiros.length; i++) {
    print('${i + 1}. ${guerreiros[i].nome} - Vida: ${guerreiros[i].vida} (Guerreiro)');
  }

  for (int i = 0; i < magos.length; i++) {
    print('${i + 1 + guerreiros.length}. ${magos[i].nome} - Vida: ${magos[i].vida} (Mago)');
  }

  int escolhaAtacante = int.parse(lerEntrada('Escolha o número do personagem que atacará: ')) - 1;

  if (escolhaAtacante < 0 || escolhaAtacante >= (guerreiros.length + magos.length)) {
    print('Escolha inválida.');
    return;
  }

  // Determina o atacante
  dynamic atacanteEscolhido;
  if (escolhaAtacante < guerreiros.length) {
    atacanteEscolhido = guerreiros[escolhaAtacante];
  } else {
    atacanteEscolhido = magos[escolhaAtacante - guerreiros.length];
  }

  print('------------------------------------------------------------------------------------');
  print('Escolha um personagem para ser atacado:\n');

  for (int i = 0; i < guerreiros.length; i++) {
    if (i != escolhaAtacante) {
      print('${i + 1}. ${guerreiros[i].nome} - Vida: ${guerreiros[i].vida} (Guerreiro)');
    }
  }

  for (int i = 0; i < magos.length; i++) {
    if (guerreiros.length + i != escolhaAtacante) {
      print('${i + 1 + guerreiros.length}. ${magos[i].nome} - Vida: ${magos[i].vida} (Mago)');
    }
  }

  int escolhaDefensor = int.parse(lerEntrada('Escolha o número do personagem a ser atacado: ')) - 1;

  if (escolhaDefensor < 0 || escolhaDefensor >= (guerreiros.length + magos.length) || escolhaDefensor == escolhaAtacante) {
    print('Escolha inválida.');
    return;
  }

  dynamic defensorEscolhido;
  if (escolhaDefensor < guerreiros.length) {
    defensorEscolhido = guerreiros[escolhaDefensor];
  } else {
    defensorEscolhido = magos[escolhaDefensor - guerreiros.length];
  }

  if (atacanteEscolhido.vida <= 0) {
    print('${atacanteEscolhido.nome} não pode atacar porque está sem vida.');
  } else if (defensorEscolhido.vida <= 0) {
    print('${defensorEscolhido.nome} não pode ser atacado porque está sem vida.');
  } else {
    if (atacanteEscolhido is Guerreiro) {
      atacanteEscolhido.atacar(defensorEscolhido);
    } else if (atacanteEscolhido is Mago) {
      atacanteEscolhido.atacar(defensorEscolhido);
    }
  }
}
