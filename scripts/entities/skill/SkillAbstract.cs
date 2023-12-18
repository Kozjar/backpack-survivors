using Godot;
using System;

public abstract class SkillAbstract
{
	public string title;
	public string description;
	public int maxLevel;
	public int level = 0;
	public SkillPriority priority;

	public SkillAbstract(string title, string description, int maxLevel, SkillPriority priority = SkillPriority.Default) {
    this.title = title;
    this.description = description;
    this.maxLevel = maxLevel;
		this.priority = priority;
	}

	public abstract void ModifyStats(UnitStatGroup playerStats);

	public int CompareTo(SkillAbstract skill) {
		return priority - skill.priority;
	}
}
