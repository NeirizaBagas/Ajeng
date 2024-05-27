using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyboslvl3 : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject firePrefab;

    [SerializeField]
    private Transform lingkaran;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopAttack()
    {
        animator.SetBool("firee", false);
    }

    public void Shoot()
    {
        Debug.Log("Menembak peluru");
        GameObject go = Instantiate(firePrefab, lingkaran.position, Quaternion.identity);
        Vector3 direction = new Vector3(transform.localScale.x, 0, 0); // Arah horizontal berdasarkan scale enemy
        go.GetComponent<Projectile>().Setup(direction);
    }
}

