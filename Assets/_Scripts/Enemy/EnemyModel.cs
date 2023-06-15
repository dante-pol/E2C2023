using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private int _health;

    public void RemoveHealth(int Damage)
    {
        _health -= Damage;
    }
}
