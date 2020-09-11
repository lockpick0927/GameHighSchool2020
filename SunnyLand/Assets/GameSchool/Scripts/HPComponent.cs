using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPComponent : MonoBehaviour
{
    private BoxCollider2D m_Box2D;

    public void Death()
    {
        m_Box2D = GetComponent<BoxCollider2D>();
        m_Box2D.isTrigger = true;
        var animators = GetComponent<Animator>();
        animators.SetBool("Die", true);

    }

    public void Remove()
    {
        Destroy(gameObject);
    }


}
