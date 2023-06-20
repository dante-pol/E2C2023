using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour
{
    private PlayerModel _pMod;
    private Buffs _buffs;
    [SerializeField] private double[] _prices = { 0, 0, 0 };
    [SerializeField] private Button[] _buttons = new Button[3];

    void Start()
    {
        _pMod = GetComponent<PlayerModel>();
        _buffs = GetComponent<Buffs>();
    }

    #region Buffs functions
    public void Buff1()
    {
        if (_pMod.CoinsCounter >= _prices[0])
        {
            _pMod.CoinsCounter -= _prices[0];
            _buffs.Buff1 = true;
            _buttons[0].interactable = false;
        }
    }
    public void Buff2()
    {
        if (_pMod.CoinsCounter >= _prices[1])
        {
            _pMod.CoinsCounter -= _prices[1];
            _buffs.Buff2 = true;
            _buttons[1].interactable = false;
        }
    }
    public void Buff3()
    {
        if (_pMod.CoinsCounter >= _prices[2])
        {
            _pMod.CoinsCounter -= _prices[2];
            _buffs.Buff3 = true;
            _buttons[2].interactable = false;
        }
    }
    #endregion
}
