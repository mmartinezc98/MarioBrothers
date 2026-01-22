using UnityEngine;

public class Goomba : Enemies 
{  
    public override void OnStomped()
    {
        //TODO: ANIMACION SPRITES
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.1f);

    }
}
