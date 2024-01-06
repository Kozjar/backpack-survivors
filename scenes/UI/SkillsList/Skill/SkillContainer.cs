using Godot;
using System;

public interface ISkillContainer
{
  public void AddSkill(SkillData skillData);
  public void RemoveSkill(SkillData skillData);
}
