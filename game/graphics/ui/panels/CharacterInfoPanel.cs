using game.assets;
using game.character;
using game.context;
using game.graphics.ui.custom;
using game_engine.events.system;
using game_engine.graphics.ui;
using game_engine.logger;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels;

class CharacterInfoPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.20f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.15f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private static readonly float _barLength = (2f / 3f) * _panelWidth;
    private static readonly float _barHeight = (1f / 4f) * _panelHeight;

    private readonly Vector2f _blockSize = new Vector2f(_barLength / 3f, _barHeight);

    private readonly ICharacter _character;
    
    private RectangleShape Avatar { get; }
    private Bar HealthBar { get; }
    private Bar EnergyBar { get; }
    private ICollection<CharacteristicBlock> Characetristics { get; }

    public CharacterInfoPanel(ICharacter character) 
        : base(GetInitialPosition(), GetInitialSize())
    {
        _character = character;

        Avatar = new RectangleShape(
            new Vector2f(_panelWidth / 3f, _panelHeight))
        {
            Position = Position + new Vector2f(_barLength, 0f),
            Texture = character.Avatar
        };

        FillColor = Palette.Instance.C07_PaleGreen;

        HealthBar = new Bar(
            Position, 
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

        Characetristics = GetCharacteristics(character.Statistics);
    }

    private CharacteristicBlock[] GetCharacteristics(ICharacterStatistics stats) =>
    [
        GetStrengthBlock(0, 0, stats.Strength),
        GetDexterityBlock(1, 0, stats.Dexterity),
        GetEnduranceBlock(2, 0, stats.Endurance),
        GetCharismaBlock(0, 1, stats.Charisma),
        GetWisdomBlock(1, 1, stats.Wisdom),
        GetInteligenceBlock(2, 1, stats.Inteligence)
    ];

    private CharacteristicBlock GetStrengthBlock(int col, int row, int value) => new CharacteristicBlock(
        _blockSize,
        Position + new Vector2f(0f, 2f * _barHeight) + new Vector2f(col * _blockSize.X, row * _blockSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        value
    );
    private CharacteristicBlock GetDexterityBlock(int col, int row, int value) => new CharacteristicBlock(
        _blockSize,
        Position + new Vector2f(0f, 2f * _barHeight) + new Vector2f(col * _blockSize.X, row * _blockSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        value
    );
    private CharacteristicBlock GetEnduranceBlock(int col, int row, int value) => new CharacteristicBlock(
        _blockSize,
        Position + new Vector2f(0f, 2f * _barHeight) + new Vector2f(col * _blockSize.X, row * _blockSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        value
    );
    private CharacteristicBlock GetCharismaBlock(int col, int row, int value) => new CharacteristicBlock(
        _blockSize,
        Position + new Vector2f(0f, 2f * _barHeight) + new Vector2f(col * _blockSize.X, row * _blockSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        value
    );
    private CharacteristicBlock GetWisdomBlock(int col, int row, int value) => new CharacteristicBlock(
        _blockSize,
        Position + new Vector2f(0f, 2f * _barHeight) + new Vector2f(col * _blockSize.X, row * _blockSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        value
    );
    private CharacteristicBlock GetInteligenceBlock(int col, int row, int value) => new CharacteristicBlock(
        _blockSize,
        Position + new Vector2f(0f, 2f * _barHeight) + new Vector2f(col * _blockSize.X, row * _blockSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        value
    );

    internal static Vector2f GetInitialPosition()
        => new Vector2f(
            HEngineSettings.Instance.WindowWidth - HEngineSettings.Instance.SmallOffsetX - _panelWidth,
            HEngineSettings.Instance.SmallOffsetY);

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        render.Draw(Avatar);
        HealthBar.Draw(render);
        EnergyBar.Draw(render);

        foreach (var characteristic in Characetristics)
        {
            characteristic.Draw(render);
        }
    }
}
