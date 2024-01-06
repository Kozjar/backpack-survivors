using Godot;
using System;
using System.Linq;

public partial class NestedSkillView : SkillView, ISkillContainer
{
  [Export] public SkillDropPreview dropPreview;
  [Export] public Control skillsContainer;

  // Called when the node enters the scene tree for the first time.
  // public override void _Ready()
  // {
  //   base._Ready();
  //   SkillListGlobal.instance.DragStarted += dropPreview.ShowDropPreview;
  //   SkillListGlobal.instance.DragEnded += dropPreview.HideDropPreview;
  // }

  public virtual void AddSkill(SkillData skillData)
  {
    if (skillData == null)
    {
      return;
    }

    var skillNode = skillData.skillResource.inventoryScene.Instantiate<SkillView>();
    skillNode.Init(this, skillData);

    skillsContainer.AddChild(skillNode);
  }

  public virtual void RemoveSkill(SkillData skillData)
  {
    var skills = skillsContainer.GetChildren().OfType<SkillView>().ToList();
    var skillToRemove = skills.Find(view => view.skillData == skillData);
    skillToRemove.QueueFree();
  }
}
