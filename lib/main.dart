import 'package:entregar/data/personagem_provider.dart';
import 'package:entregar/screens/login_screen/login_screen.dart';
import 'package:entregar/screens/initial_screen/initial_screen.dart';
import 'package:entregar/screens/cadastro_screen/cadastro_screen.dart'; // Certifique-se de importar suas telas
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  bool isLogged = await verifyToken();
  runApp(MyApp(isLogged: isLogged,));
}

Future<bool> verifyToken() async {
  SharedPreferences prefs = await SharedPreferences.getInstance();
  String? token = prefs.getString("accessToken");
  if(token!=null) {
    return true;
  }
  return false;
}

class MyApp extends StatelessWidget {
  final bool isLogged;
  const MyApp({super.key, required this.isLogged});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'AluraQuest',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      debugShowCheckedModeBanner: false,
      initialRoute: (isLogged)? '/initial' : '/login',
      //initialRoute: '/login',
      routes: {
        '/login': (context) => PersonagemProvider(child: LoginScreen()),
        '/initial': (context) => const InitialScreen(),
        '/signup': (context) => CadastroScreen(),
      },
    );
  }
}
