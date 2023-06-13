using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private PlayerModel _playerModel;

    private void Start()
    {
        _playerModel = gameObject.GetComponent<PlayerModel>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var trash = collision.gameObject.GetComponent<Trash>();
        var coin = collision.gameObject.GetComponent<Coin>();
        var shield = collision.gameObject.GetComponent<Shield>();

        if (trash != null)
        {
            _playerModel.AddTrash(trash.Count);
            trash.TrashDestory();
        }

        if (coin != null)
        {
            _playerModel.AddCoins(coin.Count);
            coin.CoinDestroy();
        }

        if (shield != null)
        {
            _playerModel.ActiveShield();
            shield.ShieldDestroy();
        }
    }
}
