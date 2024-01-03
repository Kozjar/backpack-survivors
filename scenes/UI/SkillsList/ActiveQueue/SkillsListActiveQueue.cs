using Godot;
using System.Collections.Generic;

public partial class SkillsListActiveQueue : PanelContainer
{
  public LinkedList<Trigger> triggers = new();
  [Export] PackedScene emptySlotScene;
  [Export] Control skillsContainer;
  [Export] SkillResource initialTriggerResource;
  [Export] SkillResource initialAttackResource;
  public int totalSlots = 3;
  public int emptySlots => totalSlots - triggers.Count;


  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    CreateInitialSkills();
    BuildQueueFromList();
    BuildEmptySlots();
  }

  public void CreateInitialSkills()
  {
    var attack = new AttackSkill(initialAttackResource);
    var trigger = new Trigger(initialTriggerResource);
    trigger.Attack = attack;
    var initialTrigger = new LinkedListNode<Trigger>(trigger);

    triggers.AddFirst(initialTrigger);
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }

  public void BuildQueueFromList()
  {
    foreach (var trigger in triggers)
    {
      var triggerNode = trigger.skillResource.inventoryScene.Instantiate<TriggerView>();
      // triggerNode.Init(this, trigger);
      skillsContainer.AddChild(triggerNode);
    }
  }

  void BuildEmptySlots()
  {
    for (int i = 0; i < emptySlots; i++)
    {
      var emptyNode = emptySlotScene.Instantiate<EmptySkillSlot>();
      skillsContainer.AddChild(emptyNode);
    }
  }
}
