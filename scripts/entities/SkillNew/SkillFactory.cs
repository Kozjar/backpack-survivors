public class SkillFactory
{
  public static Trigger BuildSkill(TriggerResource resource, AttackSkill attack)
  {
    return new Trigger(resource, attack);
  }

  public static AttackSkill BuildSkill(AttackResource resource)
  {
    return new AttackSkill(resource);
  }

  public static SkillData BuildSkill(SkillResource skillResource)
  {
    return skillResource.CreateInstance();

    if (skillResource is TriggerResource)
    {
      return BuildSkill((TriggerResource)skillResource, null);
    }

    if (skillResource is AttackResource)
    {
      return BuildSkill((AttackResource)skillResource);
    }

    return new SkillData(skillResource);
  }
}
