using UnityEngine;

public class PiranhaInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _piranhePref;
    private bool _isInstantiate = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isInstantiate)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Instantiate(_piranhePref, transform.position, Quaternion.identity);
                _isInstantiate = false;
            }
        }
        
    }

}
