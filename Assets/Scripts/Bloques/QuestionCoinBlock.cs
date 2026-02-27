using UnityEngine;

public class QuestionBlockCoin : BlockBase
{
    [Header("Coin Settings")]
    [SerializeField] private int _coinCount = 1;                 // monedas en el bloque
    [SerializeField] private GameObject _coinEffectPrefab;       // prefab de la moneda
    [SerializeField] private Sprite _usedSprite;                 // sprite del bloque sin monedas

    private SpriteRenderer _sr;

    protected override void Awake()
    {
        base.Awake();
        _sr = GetComponent<SpriteRenderer>();
    }

    protected override void OnHit(GameObject hitter)
    {
        if (_coinCount <= 0)
            return;

        SpawnCoinEffect();      


        //restamos una al contado de las monedas en el bloque
        _coinCount--;

        
        if (_coinCount <= 0) //cuando se acaban las monedas cambiamos el estado al bloque a usado y llamamos al metodo para cambiar el sprite
        {
            state = BlockState.Used; 
            OnBecomeUsed();
        }
        else  //si aun quedan monedas dejamos que el bloque sea golpeado de nuevo
        {
            state = BlockState.Idle;
        }
    }

    //instanciamos el prefab de la moneda en las coordenadas elegidas
    private void SpawnCoinEffect()
    {
        if (_coinEffectPrefab != null)
        {
            Instantiate(_coinEffectPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            Main.Player.PointsChange(100);
        }
    }


    //Cambiamos el sprite del bloque cuando ya no quean monedas
    protected override void OnBecomeUsed()
    {
        // Cambiar sprite a bloque gastado
        Animator animator = GetComponent<Animator>();
        if (animator != null)
            animator.SetBool("Used", true);
    }
}