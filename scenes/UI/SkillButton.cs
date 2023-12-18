using Godot;
using System;

public partial class SkillButton : Button
{
  [Export] Label title;
  [Export] Label description;
  [Export] Label level;

  public void init(SkillAbstract skill) {
    title.Text = skill.title;
    description.Text = skill.description;
    level.Text = $"(Level: {skill.level + 1})";
  }
}
