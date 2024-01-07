using Godot;
using System;

public partial class BossSpawner : Node
{
  [Export] Timer timer;
  [Export] PackedScene boss;
  [Export] EnemySpawnPath path;

  void SpawnArena()
  {

  }

  void SpawnBoss()
  {
    path.OnEnemySpawn(boss);
  }
}
