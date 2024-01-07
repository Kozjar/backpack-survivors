using Godot;
using System;

public partial class QueueSkillSelection : PanelContainer
{
  [Signal] public delegate void SkillSelectedEventHandler(SkillBaseResource skillResource);
  [Export] Label nameNode;
  [Export] Label descriptionNode;
  [Export] Label typeNode;
  [Export] TextureRect iconNode;
  [Export] Theme hoverTheme;
  Theme initialTheme;
  public SkillBaseResource skillResource;

  public void Init(SkillBaseResource skillResource)
  {
    this.skillResource = skillResource;
  }

  public override void _Ready()
  {
    initialTheme = Theme;
    nameNode.Text = skillResource.Name;
    descriptionNode.Text = skillResource.Description;
    typeNode.Text = SkillListGlobal.GetTypeText(skillResource);
    iconNode.Texture = skillResource.icon;

    MouseEntered += () => Theme = hoverTheme;
    MouseExited += () => Theme = initialTheme;
    GuiInput += OnInput;
  }

  public void OnInput(InputEvent @event)
  {
    // Mouse in viewport coordinates.
    if (@event is InputEventMouseButton eventMouseButton && !eventMouseButton.Pressed)
    {
      EmitSignal(SignalName.SkillSelected, skillResource);
    }
  }
}
