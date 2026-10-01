
using UnityEngine;

public class IInteractable : MonoBehaviour
{
    public virtual void Pick()
    {
        Debug.Log("PIcked UP");
    }

    public void Drop()
    {
        Debug.Log("Dropeed");
    }
}
