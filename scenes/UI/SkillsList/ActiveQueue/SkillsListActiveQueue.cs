using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class SkillsListActiveQueue : PanelContainer, ISkillContainer
{
  public LinkedList<Trigger> triggers = new();
  [Export] PackedScene emptySlotScene;
  [Export] Control skillsContainer;
  [Export] TriggerResource initialTriggerResource;
  [Export] AttackResource initialAttackResource;
  public int totalSlots = 3;
  public int EmptySlots => totalSlots - triggers.Count;
  public EmptySkillSlot FirstEmptySlot => skillsContainer.GetChildren().OfType<EmptySkillSlot>().First();
  List<TriggerView> triggerNodes => skillsContainer.GetChildren().OfType<TriggerView>().ToList();

  TriggerView hiddenTrigger;
  EmptySkillSlot tmpSlot;


  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    CreateInitialSkills();
    BuildQueueFromList();
    BuildEmptySlots();
    SkillListGlobal.instance.DragStarted += OnDragStarted;
    SkillListGlobal.instance.DragEnded += OnDragEnded;
  }

  void OnDragStarted(SkillData skillData)
  {
    var triggerNode = triggerNodes.Find(node => node.skillData == skillData);
    if (triggerNode != null)
    {
      triggerNode.Visible = false;
      hiddenTrigger = triggerNode;
      tmpSlot = AddEmptySlot();
      tmpSlot.dropPreview.ShowDropPreview();
      skillsContainer.MoveChild(tmpSlot, triggerNode.GetIndex());
    }
  }

  void OnDragEnded()
  {
    if (hiddenTrigger != null)
    {
      hiddenTrigger.Visible = true;
      hiddenTrigger = null;
      tmpSlot.QueueFree();
    }
  }

  public void CreateInitialSkills()
  {
    var attack = initialAttackResource.CreateInstance();
    var trigger = initialTriggerResource.CreateInstance(attack);
    var initialTrigger = new LinkedListNode<Trigger>(trigger);

    triggers.AddFirst(initialTrigger);
  }

  public void BuildQueueFromList()
  {
    foreach (var trigger in triggers)
    {
      AddSkill(trigger);
    }
  }

  void BuildEmptySlots()
  {
    var existedEmptySlots = skillsContainer.GetChildren().OfType<EmptySkillSlot>();
    for (int i = 0; i < EmptySlots - existedEmptySlots.Count(); i++)
    {
      AddEmptySlot();
    }
  }

  EmptySkillSlot AddEmptySlot()
  {
    var emptyNode = emptySlotScene.Instantiate<EmptySkillSlot>();
    skillsContainer.AddChild(emptyNode);
    emptyNode.dropPreview.skillDropped += AddNewTrigger;
    return emptyNode;
  }

  LinkedListNode<Trigger> TriggerAt(int index)
  {
    var pointer = 0;
    foreach (var trigger in triggers)
    {
      if (index == pointer)
      {
        return triggers.Find(trigger);
      }
      pointer++;
    }

    return null;
  }

  public void AddNewTrigger(SkillDragData data)
  {
    var trigger = (Trigger)data.skillData;

    var index = FirstEmptySlot.GetIndex();

    if (index == 0)
    {
      triggers.AddFirst(trigger);
    }
    else
    {
      triggers.AddAfter(TriggerAt(index - 1), trigger);
    }

    var emptySlotToRemove = skillsContainer.GetChildren().OfType<EmptySkillSlot>().ToList().Find(node => node != tmpSlot);
    emptySlotToRemove?.QueueFree();
    var childNode = AddSkillReturned(trigger);
    skillsContainer.MoveChild(childNode, index);
  }

  public TriggerView AddSkillReturned(SkillData trigger)
  {
    var triggerNode = trigger.skillResource.inventoryScene.Instantiate<TriggerView>();
    triggerNode.Init(this, trigger);
    skillsContainer.AddChild(triggerNode);

    return triggerNode;
  }

  public void AddSkill(SkillData trigger)
  {
    AddSkillReturned(trigger);
  }

  public void RemoveSkill(SkillData skillData)
  {
    var skills = skillsContainer.GetChildren().OfType<TriggerView>().ToList();
    var skillToRemove = skills.Find(view => view.skillData == skillData);
    if (skillToRemove != null)
    {
      triggers.Remove((Trigger)skillData);
      skillToRemove.QueueFree();
      AddEmptySlot();
    }
  }
}
