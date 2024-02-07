using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Formatting = System.Xml.Formatting;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

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
        _width = (int)mode.Width;
        _height = (int)mode.Height;
    }

    public Window(VideoMode mode, string title, Styles style) : base(mode, title, style) {
        _mode = mode;
        _title = title;
        _styles = style;
        _width = (int)mode.Width;
        _height = (int)mode.Height;
    }

    public Window(VideoMode mode, string title, Styles style, ContextSettings settings) : base(mode, title, style,
        settings) {
        _mode = mode;
        _title = title;
        _contextSettings = settings;
        _width = (int)mode.Width;
        _height = (int)mode.Height;
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

    public void Add(Button button) {
        _buttons.Add(button);
    }
    
    private float _buttonSpacing = 10f;
    static GridRow row1 = new(
        new GridColumn(30f),
        new GridColumn(0f, true),
        new GridColumn(30f)
    );

    static GridRow row2 = new(
        new GridColumn(40f),
        new GridColumn(0f, true),
        new GridColumn(30f)
    );
    
    static GridRow row3 = new(
        new GridColumn(30f),
        new GridColumn(0f, true),
        new GridColumn(50f)
    );

    GridStyle gridStyle = new(row1, row2, row3);
    public void Run() {
        SetView(new View(new Vector2f(_mode.Width / 2f, _mode.Height / 2f), new Vector2f(_mode.Width, _mode.Height)));
        
        gridStyle.ApplyStyle(_buttons, _width, _buttonSpacing);

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
        while (PollEvent(out var @event)) {
            switch (@event.Type) {
                case EventType.MouseMoved:
                    _mouseX = @event.MouseMove.X;
                    _mouseY = @event.MouseMove.Y;
                    break;
                case EventType.Resized:
                    SetView(new View(new Vector2f(@event.Size.Width / 2f, @event.Size.Height / 2f),
                        new Vector2f(@event.Size.Width, @event.Size.Height)));

                    _width = (int)@event.Size.Width;
                    _height = (int)@event.Size.Height;

                    // foreach (var button in _buttons) {
                    //     var relativeX = button.Position.X / _width;
                    //     var relativeY = button.Position.Y / _height;
                    //
                    //     var newButtonX = relativeX * _width;
                    //     var newButtonY = relativeY * _height;
                    //
                    //     newButtonX = Math.Min(Math.Max(newButtonX, 0), _width - button.Width);
                    //     newButtonY = Math.Min(Math.Max(newButtonY, 0), _height - button.Height);
                    //
                    //     var newButtonWidth = button.Width / _width * @event.Size.Width;
                    //     var newButtonHeight = button.Height / _height * @event.Size.Height;
                    //
                    //     button.SetPosition(newButtonX, newButtonY);
                    //     button.SetSize(newButtonWidth, newButtonHeight);
                    // }

                    gridStyle.ApplyStyle(_buttons, _width, _buttonSpacing);
                    
                    break;
                case EventType.Closed:
                    Close();
                    break;
                case EventType.MouseButtonPressed:
                    try {
                        var button = _buttons.First(ButtonHovering);
                        button.ToggleClicked();
                    }
                    catch (Exception) {
                        // ignored
                    }

                    while (PollEvent(out @event) && @event.Type == EventType.KeyPressed)
                        _buttons[0].SetSize(_mouseX, _mouseY);

                    break;
                case EventType.MouseButtonReleased:
                    foreach (var b in _buttons) b.ToggleOff();

                    break;
                case EventType.KeyPressed:
                    break;
            }

            if (@event is { Type: EventType.KeyPressed, Key.Code: Keyboard.Key.F11 }) {
                if (_isFullscreen) {
                }
                else {
                }

                _isFullscreen = !_isFullscreen;
            }
        }
    }

    private void Update() {
        var index = 1;
        // foreach (var button in _buttons) Console.WriteLine($"{index++} w: {button.Width} h: {button.Height}");
        // _buttons[0].BtnShape.Rotation += 1f;
    }

    private void Draw() {
        Clear(new Color(23, 34, 57));
        // Clear(Color.Green);
        foreach (var button in _buttons) Draw(button.BtnShape);
        Display();
    }
}