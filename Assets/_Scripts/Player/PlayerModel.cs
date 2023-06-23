using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Header("Data currency")]
    [SerializeField] private double TrashCounter = 0;
    [SerializeField] private double minTrashForConvertCoins = 0;
    public double CoinsCounter = 0;

    [Header("Data player")]
    [HideInInspector] public bool Death = false;
    [SerializeField] private int _health;
    private int _maxHealth;
    public bool IsShield;

    [SerializeField] private GameObject _shield;
    [SerializeField] private GameObject _deathCollider;

    private PlayerModel _playerModel;

    private void Start()
    {
        _playerModel = GetComponent<PlayerModel>();
        _shield.SetActive(false);
    }
    #region TrashAndCoins
    public void AddTrash(int TrashCount)
    {
        TrashCounter = TrashCounter + TrashCount;
    }

    public void AddCoins(int CoinsCount)
    {
        CoinsCounter = CoinsCounter + CoinsCount;
    }

    public void Converter()
    {
        CoinsCounter = CoinsCounter + TrashCounter / minTrashForConvertCoins;
        CoinsCounter = Math.Round(CoinsCounter, 0, MidpointRounding.AwayFromZero);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            _playerModel.Converter();
            TrashCounter = 0;
        }
    }
    #endregion

    #region Shield
    public void ActiveShield()
    {
        IsShield = true;
        _shield.SetActive(true);
    }

    public void DisActiveShield()
    {
        IsShield = false;
        _shield.SetActive(false);
    }
    #endregion

    #region Health action
    public void AddHealth(int health)
    {
        if (_health < _maxHealth)
        {
            _health += health;
        }
    }

    public void RemoveHealth(int _damage)
    {

        if (IsShield)
        {
            DisActiveShield();
            return;
        }
        else if (_health > 0)
        {
            _health -= _damage;
        }

        if (_health == 0)
        {
            PlayerDeath();         
        }
    }

    private void PlayerDeath()
    {
        Death = true;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetHealth()
    {
        return _health;
    }

    
    #endregion
}
