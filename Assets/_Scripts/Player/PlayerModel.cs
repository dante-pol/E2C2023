using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Header("Data currency")]
    [SerializeField] private double TrashCounter = 0;
    [SerializeField] private double CoinsCounter = 0;
    [SerializeField] private double minTrashForConvertCoins = 0;

    [Header("Data player")]
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    
    private PlayerModel _playerModel;

    private bool _death = false;

    private void Start()
    {
        _playerModel = gameObject.GetComponent<PlayerModel>();

    }
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

    #region Health action
    public void AddHealth(int health)
    {
        if (_health < _maxHealth)
        {
            _health += health;
        }
    }

    public void RemoveHealth(int health)
    {
        if (_health > 0)
            _health -= health;

        if (_health == 0)
        {
            _death = true;
            PlayerDeath();
        }
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetHealth()
    {
        return _health;
    }

    private void PlayerDeath()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
