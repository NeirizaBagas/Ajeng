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
}
