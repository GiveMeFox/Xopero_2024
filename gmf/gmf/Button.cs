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
    public Vector2f Position;

    public Button(float width, float height) {
        Width = width;
        Height = height;
        BtnShape = new RectangleShape(new Vector2f(Width, Height));
        
        BtnShape.FillColor = Color.Black;
        FillColor          = Color.Black;
        
        BtnShape.OutlineColor = Color.Black;
        OutlineColor          = Color.Black;
        
        BtnShape.OutlineThickness = 2f;
        OutlineThickness          = 2f;
    }

    public void SetSize(float x, float y) {
        var rotation = BtnShape.Rotation;
        BtnShape = new RectangleShape(new Vector2f(x, y));
        Width = x;
        Height = y;
        BtnShape.FillColor = FillColor;
        BtnShape.OutlineColor = _clicked ? Color.White : FillColor;
        BtnShape.OutlineThickness = OutlineThickness;
        BtnShape.Position = Position;
        BtnShape.Rotation = rotation;
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
        OutlineColor = BtnShape.OutlineColor;
    }

    public void ToggleOff() {
        _clicked = false;
        BtnShape.OutlineColor = Color.Black;
        OutlineColor = Color.Black;
    }
}