import 'package:flutter/material.dart';

class ForcaPersonagem extends StatelessWidget {
  const ForcaPersonagem({
    super.key,
    required this.forca,
  });

  final int forca;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Icon(Icons.star, color: forca>=1?Colors.blue:Colors.blue[100], size: 15,),
        Icon(Icons.star, color: forca>=2?Colors.blue:Colors.blue[100], size: 15,),
        Icon(Icons.star, color: forca>=3?Colors.blue:Colors.blue[100], size: 15,),
        Icon(Icons.star, color: forca>=4?Colors.blue:Colors.blue[100], size: 15,),
        Icon(Icons.star, color: forca>=5?Colors.blue:Colors.blue[100], size: 15,),
      ],
    );
  }
}