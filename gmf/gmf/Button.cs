using SFML.Graphics;
using SFML.System;

namespace gmf;

public class Button {
    public float Width;
    public float Height;
    public Shape BtnShape;
    private bool _clicked;
    private Color FillColor;
    private Color OutlineColor;
    private float OutlineThickness;
    public Vector2f Position { get; private set; }
    
    public Button(float width, float height) {
        Width = width;
        Height = height;
        BtnShape = new RectangleShape(new Vector2f(Width, Height));
        BtnShape.Scale = new Vector2f(1, 2);
    }

    public void SetSize(float x, float y) {
        var rotation = BtnShape.Rotation;
        BtnShape = new RectangleShape(new Vector2f(x, y));
        BtnShape.FillColor = FillColor;
        BtnShape.OutlineColor = _clicked ? Color.White : Color.Black;
        BtnShape.OutlineThickness = OutlineThickness;
        BtnShape.Position = Position;
        BtnShape.Rotation = rotation;
        Width = x;
        Height = y;
    }

    public void SetPosition(float x, float y) {
        BtnShape.Position = new Vector2f(x, y);
        Position = new Vector2f(x, y);
    }
    
    public void AddPosition(float x, float y) {
        BtnShape.Position = new Vector2f(BtnShape.Position.X + x, BtnShape.Position.Y + y);
        Position = new Vector2f(Position.X + x, Position.Y + y);
    }

    public void BackGround(Color color) {
        BtnShape.FillColor = color;
        FillColor = color;
    }
    
    public void Outline(Color color) {
        BtnShape.OutlineColor = color;
        OutlineColor = color;
    }
    
    public void Outline(Color color, float thickness) {
        BtnShape.OutlineColor = color;
        BtnShape.OutlineThickness = thickness;
        OutlineColor = color;
        OutlineThickness = thickness;
    }
    
    public void ToggleClicked() {
        _clicked = !_clicked;
        BtnShape.OutlineColor = _clicked ? Color.White : Color.Black;
    }
    
    public void ToggleOff() {
        _clicked = false;
        BtnShape.OutlineColor = _clicked ? Color.White : Color.Black;
    }
}