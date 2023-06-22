using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform _target;

    private Material _material;

    private Vector2 offset = Vector2.zero;

    [SerializeField] private float _backgroundMovementSpeed = 1;

    private void Start()
    {
        _target = transform.root;
        _material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        offset = new Vector2(_target.position.x / _backgroundMovementSpeed / 100, 0);
        _material.mainTextureOffset = offset;
    }
}
