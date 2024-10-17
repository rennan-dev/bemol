void main() {
  String nome = 'Rennan';
  String raca = 'Humano';
  String classe = 'Ladrão';

  int idade = 24;
  double altura = 1.73;
  bool ehMagico = false;
  int vida = 100;
  int energia = 155;

  List<String> habilidades = ['Agir furtivamente', 'Ser veloz', 'Golpe de adaga com mais dano'];

  print("Nome: ${nome}\n"
        "Raça: ${raca}\n"
        "Classe: $classe\n"
        "Idade: $idade\n"
        "Altura: $altura\n"
        "É mágico: $ehMagico\n"
        "Pontos de Vida: $vida\n"
        "Pontos de Energia: $energia\n"
        "Habilidades: $habilidades\n"
        "\nO personagem é maior de idade?");
  if(idade>=18) {
    print('sim\n');
  }else {
    print('não\n');
  }

  while(energia>0) {
    print('Personegem em batalha');
    print('Usando adaga do ladrão');
    energia-=20;
    if(energia<0) {
      energia=0;
    }
    print('-20 de energia, energia atual: ${energia}\n');
  }
}