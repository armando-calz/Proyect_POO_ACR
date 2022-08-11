using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEvent_HeroKnight : MonoBehaviour
{
    //cuando la animacion de slide acabe, va a mandar destruir las particulas "dust"
    public void destroyEvent()
    {
        Destroy(gameObject);
    }
}
