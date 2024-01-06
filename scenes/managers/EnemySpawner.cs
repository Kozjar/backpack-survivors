using Godot;
using System;

public partial class EnemySpawner : Node
{
  [Export] EnemySpawnPath path;
  [Export] Curve spawnCurve;
  [Export] PackedScene spawnEntity;
  [Export] float maxSpawnrate;
  float spawnProgress = 0;
  double timeElapsed = 0;

  public override void _Ready()
  {
    base._Ready();
    spawnCurve.MaxValue = SkillListGlobal.gameTime;
  }

  public override void _Process(double delta)
  {
    base._Process(delta);
    timeElapsed += delta;
    spawnProgress += GetCurveProgress(timeElapsed, delta);
    // GD.Print($"Spawn Progress: {spawnProgress}, Time Elapsed: {timeElapsed}, Delta: {delta}, local progress: {GetCurveProgress(timeElapsed, delta)}");
    SpawnEntities();
  }

  float GetCurveProgress(double timeElapsed, double delta)
  {
    float curveProgress = spawnCurve.Sample((float)(timeElapsed / SkillListGlobal.gameTime));
    // GD.Print($"Curve End: {curveEnd}");

    return (float)(curveProgress * maxSpawnrate * delta);
  }

  void SpawnEntities()
  {
    while (spawnProgress >= 1)
    {
      path.OnEnemySpawn(spawnEntity);
      spawnProgress -= 1;
    }
  }
}
