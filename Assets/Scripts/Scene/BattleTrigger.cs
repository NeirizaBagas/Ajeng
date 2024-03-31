using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    [SerializeField] private int index;                                                              

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        
        if (collider.transform.TryGetComponent(out PlayerController player))
        {
            //ngaktifin border
           
            BattleManager.instance.TriggerBattleArea(index);

            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);

            gameObject.SetActive(false);
        }
    }


}
