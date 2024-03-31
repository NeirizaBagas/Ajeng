using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    [SerializeField] private GameObject[] battleArea;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        for (int i = 0; i < battleArea.Length; i++)
        {
            battleArea[i].SetActive(false);
        }
    }

    public void TriggerBattleArea(int index) => battleArea[index].gameObject.SetActive(true);


    public void DeactivateBattleArea(int index) => battleArea[index].gameObject.SetActive(false);
     
}
