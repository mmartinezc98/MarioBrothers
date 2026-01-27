using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBricks : BlockBase
{
    protected override void OnHit(GameObject hitter)
    {
        //rompemos el ladrillo cuando le demos
        BreakBlock();

        /*
        // Cuando tengas tu sistema de tamaño del jugador, activa esto:

        bool playerIsBig = hitter.GetComponent<PlayerSize>()?.IsBig ?? false;

        if (playerIsBig)
        {
            BreakBlock();          // Mario grande → romper
        }
        else
        {
            state = BlockState.Idle;   // Mario pequeño → solo bump
        }
        */
    }

    private void BreakBlock()
    {
        state = BlockState.Broken;

        // Aquí podrás instanciar tus partículas de rotura cuando las tengas
        // Instantiate(breakParticlesPrefab, transform.position, Quaternion.identity);

        // Por ahora simplemente desaparece
        //gameObject.SetActive(false);

        //destruimos el bloque
        Destroy(gameObject);
    }


}
