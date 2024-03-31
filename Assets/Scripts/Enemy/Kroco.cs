using UnityEngine;

public class Kroco : Enemy
{


    

    
    // Start is called before the first frame update
    protected override void Start()
    {
        rb.gravityScale = 12f;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

   





    //// Override the EnemyHit method from the base class
    //public override void EnemyHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    //{
    //    base.EnemyHit(_damageDone, _hitDirection, _hitForce);
    //   /* anim.SetTrigger("TakingDamage");*/ // di kelas turunan (Kroco)
    //    // Add your own additional functionality here if needed
    //}
}
