using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _armor;

    public void TakeDamage(float enemyDamage)
    {
        enemyDamage -= _armor;
        if (enemyDamage < 0)
            enemyDamage = 0;
        _currentHealth -= enemyDamage;
        if (_currentHealth < 0)
            _currentHealth = 0;
    }
    public void RevivePlayer()
    {
        _currentHealth = _maxHealth;
        //setArmor
    }
    public void HealPlayer(float addedHealth)
    {
        _currentHealth += addedHealth;
    }
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
    public float GetAttackDamage()
    {
        return _attackDamage;
    }
    public float GetArmor()
    {
        return _armor;
    }
    public void SetAttackDamage(float attackDamage)
    {
        _attackDamage = attackDamage;
    }
    public void AddAttackDamage(float addedAttackDamage)
    {
        _attackDamage += addedAttackDamage;
    }
    public void SetCurrentHealth(float health)
    {
        _currentHealth = health;
    }
    public void SetArmor(float armor)
    {
        _armor = armor;
    }
}
