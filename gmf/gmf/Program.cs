using gmf;
using SFML.Graphics;
using SFML.Window;
using Window = gmf.Window;

var mode = new VideoMode(480, 700);
var window = new Window(mode, "gmf");

window.SetFramerateLimit(60);
window.Run();