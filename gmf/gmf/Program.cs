using System.Collections;
using gmf;
using SFML.Graphics;
using SFML.Window;
using Window = gmf.Window;

var mode = new VideoMode(480, 700);
var window = new Window(mode, "gmf");

var colors = new Dictionary<int, Color> {
    { 0, Color.Black },
    { 1, Color.White },
    { 2, Color.Red },
    { 3, Color.Green },
    { 4, Color.Blue },
    { 5, Color.Yellow },
    { 6, Color.Magenta },
    { 7, Color.Cyan }
};

var index = 0;
for (var i = 0; i < 11; i++) {
    var button = new Button(30, 30);

    if (index >= 7) {
        index = 0;
    } else {
        index += 1;
    }
    
    button.BackGround(colors[index]);
    window.Add(button);
}

window.SetFramerateLimit(60);
window.Run();