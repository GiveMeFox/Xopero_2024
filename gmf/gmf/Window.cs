using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace gmf;

public class Window : RenderWindow {
    private string _title;
    private VideoMode _mode;
    private Styles _styles;
    private ContextSettings _contextSettings;
    private IntPtr _handle;
    private bool _isFullscreen;
    private int _mouseX;
    private int _mouseY;
    private int _width;
    private int _height;
    private List<Button> _buttons = [];

    public Window(VideoMode mode, string title) : base(mode, title) {
        _title = title;
        _mode = mode;
    }

    public Window(VideoMode mode, string title, Styles style) : base(mode, title, style) {
        _mode = mode;
        _title = title;
        _styles = style;
    }

    public Window(VideoMode mode, string title, Styles style, ContextSettings settings) : base(mode, title, style,
        settings) {
        _mode = mode;
        _title = title;
        _contextSettings = settings;
    }

    public Window(IntPtr handle) : base(handle) {
        _handle = handle;
        _title = "";
    }

    public Window(IntPtr handle, ContextSettings settings) : base(handle, settings) {
        _handle = handle;
        _contextSettings = settings;
        _title = "";
    }

    public void Run() {
        var button = new Button(50, 30);
        button.BackGround(Color.Black); 
        button.Outline(Color.Black, 2);
        button.SetPosition(60, 60);
        
        _buttons.Add(button);

        SetView(new View(new Vector2f(_mode.Width / 2f, _mode.Height / 2f), new Vector2f(_mode.Width, _mode.Height)));
        _buttons[0].SetPosition((_width - _buttons[0].Width) / 2f, (_height - _buttons[0].Height) / 2f);
        
        while (IsOpen) {
            HandleEvents();
            Update();
            Draw();
        }
    }

    private bool ButtonHovering(Button button) {
        var btnX = button.Position.X;
        var btnY = button.Position.Y;

        return _mouseX > btnX && _mouseX < btnX + button.Width &&
               _mouseY > btnY && _mouseY < btnY + button.Height;
    }
    
    private void HandleEvents() {
        // DispatchEvents();

        while (PollEvent(out var @event)) {
            switch (@event.Type) {
                case EventType.MouseMoved:
                    _mouseX = @event.MouseMove.X;
                    _mouseY = @event.MouseMove.Y;
                    break;
                case EventType.Resized:
                    SetView(new View(new Vector2f(@event.Size.Width / 2f, @event.Size.Height / 2f), new Vector2f(@event.Size.Width, @event.Size.Height)));
                    _width = (int) @event.Size.Width;
                    _height = (int) @event.Size.Height;
                    _buttons[0].SetPosition((_width - _buttons[0].Width) / 2f, (_height - _buttons[0].Height) / 2f);
                    break;
                case EventType.Closed:
                    Close();
                    break;
                case EventType.MouseButtonPressed:
                    try {
                        var button = _buttons.First(ButtonHovering);
                        button.ToggleClicked();
                    }
                    catch (Exception _) {
                        // ignored
                    }

                    while (PollEvent(out @event) && @event.Type == EventType.KeyPressed) {
                        _buttons[0].SetSize(_mouseX, _mouseY);
                    }
                    // button.Position = new Vector2f(@event.MouseMove.X, @event.MouseMove.Y);
                    
                    // Console.WriteLine($"x:{_mouseX} y:{_mouseY}");
                    break;
                case EventType.MouseButtonReleased:
                    foreach (var b in _buttons) {
                        b.ToggleOff();
                    }
                    break;
                case EventType.KeyPressed:
                    break;
            }

            if (@event is {
                    Type : EventType.KeyPressed,
                    Key.Code: Keyboard.Key.F11
                }) {
                if (_isFullscreen) {
                    
                }
                else {
                    
                }
                
                _isFullscreen = !_isFullscreen;
            }
        }
    }

    private void Update() {
        // _buttons[0].SetPosition((_width - _buttons[0].Width) / 2f, (_height - _buttons[0].Height) / 2f);
        // Console.WriteLine($"{_width} {_height}");
        // _buttons[0].BtnShape.Rotation += 1f;
        // _buttons[0].SetSize(_buttons[0].Width + 10f, _buttons[0].Height + 10f);
        // Console.WriteLine($"{_buttons[0].Width} {_buttons[0].Height}");
    }
    
    private void Draw() {
        Clear(new Color(23, 34, 57));
        foreach (var button in _buttons) Draw(button.BtnShape);
        Display();
    }
}
