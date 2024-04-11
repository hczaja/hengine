using game_contracts.assets;
using game_contracts.character;
using game_engine.settings;
using game_graphics.graphics.ui.custom;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.panels;

public class CharacterInfoPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.20f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.15f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private static readonly float _barLength = (2f / 3f) * _panelWidth;
    private static readonly float _barHeight = (1f / 8f) * _panelHeight;

    private readonly ICharacter _character;
    
    private CircleShape Avatar { get; }
    private BaseBar HealthBar { get; }
    private BaseBar EnergyBar { get; }
    private CircleShape ConsoleTrigger { get; }

    public CharacterInfoPanel(ICharacter character) 
        : base(GetInitialPosition(), GetInitialSize())
    {
        _character = character;

        Avatar = new CircleShape(50f)
        {
            Position = new Vector2f(22f, 1026f),
            Texture = new Texture("assets/textures/avatars/cat.png"),
        };

        HealthBar = new Bar(
            Position + new Vector2f(_panelHeight / 3f, _panelHeight) - 2 * new Vector2f(0f, _barHeight),
            _barLength, 
            _barHeight, 
            Palette.Instance.C02_DirtyRed, 
            character.Statistics.GetHealth(), 
            character.Statistics.MaxHealth);

        EnergyBar = new Bar(
            HealthBar.Position + new Vector2f(0f, _barHeight), 
            _barLength, 
            _barHeight, 
            Palette.Instance.C09_PaleYellow, 
            character.Statistics.GetEnergy(), 
            character.Statistics.MaxEnergy);

        ConsoleTrigger = new CircleShape(_panelHeight / 8)
        {
            Position = Position + new Vector2f(2 * Avatar.Radius, Avatar.Radius),
            Texture = new Texture("assets/textures/avatars/cat.png"),
        };
    }

    internal static Vector2f GetInitialPosition()
        => new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.WindowHeight - HEngineSettings.Instance.SmallOffsetY - _panelHeight);

    internal static Vector2f GetInitialSize()
        => new Vector2f(
            _panelWidth,
            _panelHeight);

    public override void DrawBy(RenderTarget render)
    {
        render.Draw(Avatar);
        render.Draw(ConsoleTrigger);

        HealthBar.DrawBy(render);
        EnergyBar.DrawBy(render);
    }
}
