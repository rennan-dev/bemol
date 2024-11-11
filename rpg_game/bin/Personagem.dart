import 'StatusDeVida.dart';

class Personagem {
  String _nome, _raca, _classe;
  int idade, _pontosVida, energia;
  double? altura;
  bool isMagico;
  List<String> habilidades;
  StatusDeVida statusDeVida;

  Personagem(this._nome, this._raca, this._classe, this.idade, this._pontosVida, this.energia, this.altura, this.isMagico, this.habilidades) : statusDeVida = StatusDeVida.vivo;

  //getters - started
  String get getNome {
    return _nome;
  }
  String get getRaca {
    return _raca;
  }
  String get getClasse {
    return _classe;
  }
  int get getPontosVida {
    return _pontosVida;
  }
  //getters - ended

  //setters - started
  void set setNome(String novoNome) {
    _nome = novoNome;
  }
  void set setRaca(String novaRaca) {
    _raca = novaRaca;
  }
  void set setClasse(String novaClasse) {
    _classe = novaClasse;
  }
  void set setPontosVida(int pontosVida) {
    try {
      if(pontosVida < 0) {
        throw ArgumentError('Os pontos de vida não podem ser negativos');
      }
      _pontosVida = pontosVida;
    }catch(e) {
      print('Erro: $e');
    }
  }
  //setters - ended

  String exibirFicha() {
  
  return '\n'
         'Nome: $_nome\nRaça: $_raca\nClasse: $_classe\n'
         'Idade: $idade\nVida: $_pontosVida\nStatus de Vida: ${statusDeVida.name}\nEnergia: $energia\n'
         'Altura: ${altura != null ? altura?.toStringAsFixed(2) : "Altura não especificada"}\nPossui Magia? $isMagico\n'
         'Conjunto de Habilidades:\n\t${habilidades.join('\n\t')}\n';
  }

  void atualizarStatus(Personagem personagem) {
    if(personagem._pontosVida>50) {
      personagem.statusDeVida = StatusDeVida.vivo;
    }else if(personagem._pontosVida>0 && personagem._pontosVida<=50) {
      personagem.statusDeVida = StatusDeVida.ferido;
    }else {
      personagem.statusDeVida = StatusDeVida.derrotado;
    }
  }
}