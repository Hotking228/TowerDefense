using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;


[RequireComponent(typeof(TDPatrolController))]
public class Enemy : MonoBehaviour
{
    
    public void Use(EnemyAsset asset)
    {
        SpriteRenderer sr = transform.Find("View").GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = asset.color;
            sr.transform.localScale = new Vector3(asset.spriteScale.x, asset.spriteScale.y, 1);

            sr.GetComponent<Animator>().runtimeAnimatorController = asset.animations;


            GetComponent<SpaceShip>().Use(asset);

        }
        CircleCollider2D collider = transform.Find("Collider").GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            collider.radius = asset.radius;
        }


    }
}
