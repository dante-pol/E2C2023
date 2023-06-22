using UnityEngine;

public class PallaraxFollow : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private void Update()
    {
        gameObject.transform.position = new Vector3(_cameraTransform.position.x, 0, 0);
    }
}
