﻿using game.assets;
using game.character.diary;
using game.events;
using game.graphics.ui.custom;
using game.graphics.ui.panels.inventory;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Reflection.Metadata;

namespace game.graphics.ui.panels.diary;

internal class QuestListPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.36f;
    private static readonly float _panelWidth = InventoryPanel.GetInitialSize().X * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.66f;
    private static readonly float _panelHeight = InventoryPanel.GetInitialSize().Y * _panelHeightRatio;

    private QuestListBlock QuestListBlock { get; set; }

    private readonly IDiary _diary;
    private readonly IEventHandler<SelectedQuestChangedEvent> _handler;

    public QuestListPanel(IDiary diary, IEventHandler<SelectedQuestChangedEvent> handler)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _diary = diary;
        _handler = handler;

        FillColor = Palette.Instance.C03_Brown;
        QuestListBlock = new QuestListBlock(diary);
    }

    internal static Vector2f GetInitialPosition()
    {
        var parent = DiaryPanel.GetInitialPosition();

        return parent + new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        QuestListBlock.Draw(render);
    }

    public override void Handle(KeyboardEvent @event)
    {
        if (@event.Key == Keyboard.Key.Tab)
        {
            QuestListBlock.SwitchList();
            _handler.Handle(new SelectedQuestChangedEvent(QuestListBlock.Pointer));
        }
    }
}