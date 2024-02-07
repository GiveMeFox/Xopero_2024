using gmf;
using SFML.Graphics;
using SFML.Window;
using Window = gmf.Window;

var mode = new VideoMode(480, 700);
var window = new Window(mode, "gmf");

var btn1 = new Button(30, 30);
btn1.BackGround(Color.Red);
window.Add(btn1);

var btn2 = new Button(30, 30);
btn2.BackGround(Color.Blue);
window.Add(btn2);

var btn3 = new Button(30, 30);
btn3.BackGround(Color.Green);
window.Add(btn3);

var btn4 = new Button(30, 30);
btn4.BackGround(Color.Red);
window.Add(btn4);

var btn5 = new Button(30, 30);
btn5.BackGround(Color.Blue);
window.Add(btn5);

var btn6 = new Button(30, 30);
btn6.BackGround(Color.Green);
window.Add(btn6);

var btn7 = new Button(30, 30);
btn7.BackGround(Color.Red);
window.Add(btn7);

var btn8 = new Button(30, 30);
btn8.BackGround(Color.Blue);
window.Add(btn8);

var btn9 = new Button(30, 30);
btn9.BackGround(Color.Green);
window.Add(btn9);

window.SetFramerateLimit(60);
window.Run();