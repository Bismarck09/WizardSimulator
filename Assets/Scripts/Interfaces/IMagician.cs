using System;

public interface IMagician
{
    event Action<float> CausedDamage;
    void TakeDamage(float damage);
    void CheckAlive(float currentLives);
    void KillMe();
    float GetMaximumNumberOfLives();

}
