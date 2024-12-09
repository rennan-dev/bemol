import 'package:entregar/data/personagem_dao.dart';
import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

Future<Database> getDatabase() async {
  final String path = join(await getDatabasesPath(), 'nanatsu_no_taizai.db');
  return openDatabase(path, onCreate: (db, version) {
    db.execute(PersonagemDao.tableSQL);
  }, version: 2);
}