using System;
using UnityEngine;

public interface IMagicCreator
{
    void Init(Vector3 target, GameObject parent, Action spawned, int magicLevel);
    void ShootMagic(DamageMagic magic, Vector3 target);
    bool TryMagicCreate(ref float elapsedTimeAfterShooting);
}
