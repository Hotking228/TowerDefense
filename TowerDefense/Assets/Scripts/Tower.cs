using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float m_Radius = 5.0f;
    private Color GizmoColor = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, 0.3f);
    private Turret[] turrets;

    private Destructible target = null;

    private void Start()
    {
        turrets = GetComponentsInChildren<Turret>();
    }


    private void Update()
    {
        if (target == null)
        {
           
                var enter = Physics2D.OverlapCircle(transform.position, m_Radius);
                if (enter)
                {
                    target = enter.transform.root.GetComponent<Destructible>();
            
                }
           

    }
        else
        {

            Vector2 targetVector = (target.transform.position - transform.position);
            if (targetVector.magnitude <= m_Radius)
            {
                foreach (var turret in turrets)
                {

                    turret.transform.up = (target.transform.position - turret.transform.position).normalized;


                    turret.Fire();
                }
            }
            else
            {
                target = null;
            }
        }
           
    }
        





#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
        {
            Handles.color = GizmoColor;

            Handles.DrawSolidDisc(transform.position, transform.forward,m_Radius);

        

        }
#endif

}
