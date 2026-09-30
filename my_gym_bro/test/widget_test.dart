import 'package:flutter_test/flutter_test.dart';
import 'package:my_gym_bro/app/app.dart';

void main() {
  testWidgets('shows the app name', (tester) async {
    await tester.pumpWidget(const MyGymBroApp());

    expect(find.text('My Gym Bro'), findsOneWidget);
  });
}
