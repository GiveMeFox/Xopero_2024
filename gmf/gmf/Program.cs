using gmf;
using SFML.Graphics;
using SFML.Window;
using Window = gmf.Window;
using SFML.Graphics;
using Color = System.Drawing.Color;

var mode = new VideoMode(480, 700);
var window = new Window(mode, "gmf");

for (var i = 0; i < 11; i++) {
    var button = new Button(30, 30);
    var random = new Random();
    
    button.BackGround(random.Next(Enum.GetValues(typeof(Color)).Length));
}

window.SetFramerateLimit(60);
window.Run();