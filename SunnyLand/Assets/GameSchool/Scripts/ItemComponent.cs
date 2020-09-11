using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    public void BeAte()
    {
        var animators = GetComponent<Animator>();
        animators.SetBool("Eat", true);

        Debug.Log("먹다");
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
