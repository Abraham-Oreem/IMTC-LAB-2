
using UnityEngine;

public class ChangeColor : IInteractable
{
    public override void Pick()
    {
        base.Pick();
        Debug.Log("Change Color");
    }
}
