﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularAttack : AttackPattern
{
  
    public override void Shoot(Transform target)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, towersona.firePoint.position, towersona.firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = attackStrength;
        bullet.speed = bulletSpeed;

        if (bullet != null)
            bullet.Seek(target);
    }

    public override void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= attackRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

}
