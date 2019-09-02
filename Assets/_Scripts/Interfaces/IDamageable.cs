﻿public interface IDamageable
{
    float Hp { get; }
    float MaxHp { get; }
    bool IsDead { get; }
    void GetDamage(float damageValue);
}