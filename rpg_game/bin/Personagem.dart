import 'StatusDeVida.dart';

class Personagem {
  String _nome, _raca, _classe;
  int idade, vida, energia;
  double altura;
  bool isMagico;
  List<String> habilidades;
  StatusDeVida statusDeVida;

  Personagem(this._nome, this._raca, this._classe, this.idade, this.vida, this.energia, this.altura, this.isMagico, this.habilidades) : statusDeVida = StatusDeVida.vivo;

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
  //setters - ended

  String exibirFicha() {
    String statusDeVidaStr = statusDeVida.toString().split('.').last;

    return '\n'
           'Nome: $_nome\nRaça: $_raca\nClasse: $_classe\n'
           'Idade: $idade\nVida: $vida\nStatus de Vida: $statusDeVidaStr\nEnergia: $energia\n'
           'Altura: $altura\nPossui Magia? $isMagico\n'
           'Conjunto de Habilidades:\n\t${habilidades.join('\n\t')}\n';
  }

  void atualizarStatus(Personagem personagem) {
    if(personagem.vida>50) {
      personagem.statusDeVida = StatusDeVida.vivo;
    }else if(personagem.vida>0 && personagem.vida<=50) {
      personagem.statusDeVida = StatusDeVida.ferido;
    }else {
      personagem.statusDeVida = StatusDeVida.derrotado;
    }
  }
}