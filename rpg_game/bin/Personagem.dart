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