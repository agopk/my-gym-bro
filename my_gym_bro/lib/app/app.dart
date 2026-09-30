import 'package:flutter/material.dart';

class MyGymBroApp extends StatelessWidget {
  const MyGymBroApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'My Gym Bro',
      home: Scaffold(body: Center(child: Text('My Gym Bro'))),
    );
  }
}
