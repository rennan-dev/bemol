import 'dart:io';
import 'Guerreiro.dart';
import 'Mago.dart';
import './Feiticos.dart';
import './Rpg_Exceptions.dart';

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
    switch(opcao) {
      case 1: criar_personagem(guerreiros, magos); break;
        
      case 2: mostrar_personagens(guerreiros, magos); break;

      case 3: adicionar_feitico(magos); break;
        
      case 4: fazer_feitico(magos); break;
        
      case 5: atacar(guerreiros, magos); break;
        
      case 6: print('\nAté a próxima, viajante...\n'); break;
        
      default: print('Opção inválida. Tente novamente.');
    }
  }while(opcao != 6);
}

int menu_inicial() {
  int res = 0;
  print('------------------------------------------------------------------------------------');
  print('\nMenu Inicial');
  print('1 - Criar personagem');
  print('2 - Visualizar personagens');
  print('3 - Adicionar Feitiço');
  print('4 - Fazer um feitiço com um mago');
  print('5 - Atacar um personagem');
  print('6 - Sair da Aplicação');
  stdout.write('\nResposta: ');

  String? input = stdin.readLineSync(); 
  if (input != null) {
    res = int.tryParse(input) ?? 0; 
  }
  return res; 
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

void criar_personagem(List<Guerreiro> guerreiros, List<Mago> magos) {
  limparTela();
  print('------------------------------------------------------------------------------------');

  String nome = lerEntrada('Digite o nome do personagem: ');
  if (guerreiros.any((guerreiro) => guerreiro.getNome.toLowerCase() == nome.toLowerCase()) || 
      magos.any((mago) => mago.getNome.toLowerCase() == nome.toLowerCase())) {
    print('Nome de personagem já existe. Por favor, escolha um nome diferente.');
    return; 
  }

  String raca = lerEntrada('Digite a raça do personagem: ');
  int idade = int.parse(lerEntrada('Digite a idade do personagem: '));
  stdout.write('Digite a altura do personagem (pode ser nulo): ');
  double? altura = double.tryParse(stdin.readLineSync() ?? '');
  String classe = lerEntrada('Você quer ser um Guerreiro ou Mago? (digite "guerreiro" ou "mago"): ');

  // Verifica a escolha do usuário
  if (classe.toLowerCase() == 'guerreiro') {
    List<String> habilidades = ['Ataque físico', 'Quanto menos vida o guerreiro tiver, mais dano de ataque ele possui', 'Ao eliminar inimigos recebe uma recompensa maior em xp', 'Golpe com espada longa dão o dobro de dano'];
    Guerreiro guerreiro = new Guerreiro(nome, raca, idade, 100, 100, altura, false, habilidades);
    guerreiros.add(guerreiro);
    limparTela();
    print('\nGuerreiro criado:\n${guerreiro.exibirFicha()}');

  } else if (classe.toLowerCase() == 'mago') {
    List<String> habilidades = ['Ataque mágico', 'Possui recuperação de vida uma vez durante combate', 'Agachar deixa o mago invisível', 'Usar o Lançar Feitiço te gera desgaste e o mago perde 10 pontos de energia.'];
    Mago mago = new Mago(nome, raca, idade, 100, 100, altura, true, habilidades);
    magos.add(mago);
    limparTela();
    print('\nMago criado:\n${mago.exibirFicha()}');
  } else {
    print('\nRaça desconhecida. O personagem não foi criado.');
  }
}

void mostrar_personagens(List<Guerreiro> guerreiros, List<Mago> magos) {
  limparTela();
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

void adicionar_feitico(List<Mago> magos) {
  limparTela();
  print('------------------------------------------------------------------------------------');
  print('\nAdicionar Feitiço\n');

  print('\tMagos: ');
  magos.forEach((mago) {
    print('${mago.getNome}');
  });

  String nome = lerEntrada('\nDigite o nome do personagem: ');

  Mago? mago = magos.firstWhere(
    (m) => m.getNome.toLowerCase() == nome.toLowerCase(),
    orElse: () => Mago('', '', 0, 0, 0, 0, false, [])
  );

  if (mago.getNome.isEmpty) {
    print('Personagem não existe! Tente com outro');
  } else {
    print('\nEscolha o feitiço para adicionar:');
    print('1 - Fogo');
    print('2 - Gelo');
    print('3 - Relâmpago');
    print('4 - Cura');

    int feiticoSelecionado = int.tryParse(lerEntrada('Digite o número do feitiço: ')) ?? -1;

    Feiticos? feitico;
    switch (feiticoSelecionado) {
      case 1:
        feitico = Feiticos.fogo;
        break;
      case 2:
        feitico = Feiticos.gelo;
        break;
      case 3:
        feitico = Feiticos.relampago;
        break;
      case 4:
        feitico = Feiticos.cura;
        break;
      default:
        print('\nOpção inválida. Tente novamente.');
        return;
    }

    int poderFeitico = int.tryParse(lerEntrada('Digite o poder do feitiço: ')) ?? 0;
    mago.adicionarFeitico(feitico, poderFeitico);
    print('\nFeitiço ${feitico.name} adicionado com sucesso ao mago ${mago.getNome}!');
  }
}


void fazer_feitico(List<Mago> magos) {
  limparTela();
  print('------------------------------------------------------------------------------------');
  print('\nFazer magia\n');

  print('\tMagos: ');
  magos.forEach((mago) {
    print('${mago.getNome}');
  });

  String nome = lerEntrada('\nDigite o nome do personagem: ');

  Mago? mago = magos.firstWhere(
    (m) => m.getNome.toLowerCase() == nome.toLowerCase(),
    orElse: () => Mago('','',0,0,0,0,false,[])
  );

  if (mago.getNome.isEmpty) {
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
  try {
    limparTela();
    print('------------------------------------------------------------------------------------');
    print('Escolha um personagem para atacar:\n');

    for (int i = 0; i < guerreiros.length; i++) {
      print('${i + 1}. ${guerreiros[i].getNome} - Vida: ${guerreiros[i].getPontosVida} (Guerreiro)');
    }

    for (int i = 0; i < magos.length; i++) {
      print('${i + 1 + guerreiros.length}. ${magos[i].getNome} - Vida: ${magos[i].getPontosVida} (Mago)');
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
        print('${i + 1}. ${guerreiros[i].getNome} - Vida: ${guerreiros[i].getPontosVida} (Guerreiro)');
      }
    }

    for (int i = 0; i < magos.length; i++) {
      if ((i + guerreiros.length) != escolhaAtacante) {
        print('${i + 1 + guerreiros.length}. ${magos[i].getNome} - Vida: ${magos[i].getPontosVida} (Mago)');
      }
    }

    int escolhaAtacado = int.parse(lerEntrada('Escolha o número do personagem a ser atacado: ')) - 1;

    if (escolhaAtacado < 0 || escolhaAtacado >= (guerreiros.length + magos.length)) {
      print('Escolha inválida.');
      return;
    }

    // Determina o atacado
    dynamic atacadoEscolhido;
    if (escolhaAtacado < guerreiros.length) {
      atacadoEscolhido = guerreiros[escolhaAtacado];
    } else {
      atacadoEscolhido = magos[escolhaAtacado - guerreiros.length];
    }

    // Verifica se o personagem atacado está sem vida
    if (atacadoEscolhido.getPontosVida <= 0) {
      throw PersonagemDerrotadoException(personagem: atacadoEscolhido);
    }

    // Simula a lógica do ataque
    atacanteEscolhido.atacar(atacadoEscolhido);

  } on PersonagemDerrotadoException catch (e) {
    print(e.toString()); // Mostra a mensagem da exceção
    print('Voltando ao menu principal...');
  } catch (e) {
    print('Erro inesperado: $e');
  }
}


void limparTela() {
  print("\x1B[2J\x1B[0;0H");
}