using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    //heal
    public float BossHPmax;
    public float BossCurrentHP;
    void Start()
    {
        BossCurrentHP = BossHPmax;
    }
    void Update()
    {
        ComprobarHPBoss();
    }
    public void BossHit(int daño)
    {
        BossCurrentHP -= daño;
        Debug.Log(BossCurrentHP);
    }
    void ComprobarHPBoss()
    {
        if (BossCurrentHP <= 0)
        {
            BossDie();
        }
    }
    void BossDie()
    {

        Destroy(gameObject, 0);
    }
}
