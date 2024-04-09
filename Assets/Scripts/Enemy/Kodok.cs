using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kodok : Enemy
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
