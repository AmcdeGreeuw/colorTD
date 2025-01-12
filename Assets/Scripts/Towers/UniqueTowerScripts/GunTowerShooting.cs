using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GunTowerShooting : A_TowerShoot, IDisposable
{

    private Color _color = Color.yellow;
    void Start()
    {
        attackSpeed = 1f;
        range = 3f;
        orderChanged = inRangeOrderCorrection;
        EnemyWaves.EnemyDestroyed += enemyDied;
   
    }

    // Update is called once per frame
    void UpdateOrg()
    {
        //if (EnemyWaves.Enemies.Count > 0) { print(EnemyWaves.Enemies[0]); }

        checkRange();
        time += Time.deltaTime;
        if (time > attackSpeed && targetData != null)
        {
            shoot();
            time = 0;
            print("tookdmg");
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        var target = InRange();
        if (target == null) return;
        
            // nothing
        PointAtEnemy(target);
        
        if(time > attackSpeed)
        {
            TryAnimation("Shoot");
            time = 0;
            target.TakeDamage(this._color);
        }
                
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, range);
    }

    public void Dispose()
    {
        EnemyWaves.EnemyDestroyed -= enemyDied;
    }
}
