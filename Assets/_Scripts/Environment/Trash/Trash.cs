using UnityEngine;

class Trash : MonoBehaviour
{
    public int Count;
    public void TrashDestory()
    {
        //TODO: Add animation or particle system
        Destroy(gameObject);
    }
}