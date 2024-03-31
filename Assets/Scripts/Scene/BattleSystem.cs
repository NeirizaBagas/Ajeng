using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
    }


    [SerializeField] private BattleTrigger battleTrigger;
    // Start is called before the first frame update

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        
        battleTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }
    
    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
        }
        
    }

    private void StartBattle()
    {
        state = State.Active;
    }
}
