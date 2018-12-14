using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 삼각함수와 내적 정리 코드
/// </summary>
public class DotCode : MonoBehaviour
{
    public Vector2 P1;
    public Vector2 P2;
    public float Dot1;
    public float Radian1;
    public float Degree1;

    public Vector2 Foward;
    public Vector2 Target;
    public float Dot2;
    public float Radian2;
    public float Degree2;
    private void Update()
    {
        Vector2 normalP1 = P1.normalized;
        Vector2 normalP2 = P2.normalized;


        Dot1 = Round(Vector2.Dot(normalP1, normalP2));
        Radian1 = Round(Mathf.Acos(Dot1));
        Degree1 = Round(Radian1 * 180 / 3.14f);

        Foward = new Vector2(0, 1);
        Vector2 normalTarget = Target.normalized;
        Dot2 = Round(Vector2.Dot(Foward, normalTarget));
        Radian2 = Round(Mathf.Acos(Dot2));
        Degree2 = Round(Radian2 * 180 / 3.14f);
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(P1, Vector2.zero);
        Gizmos.DrawLine(P2, Vector2.zero);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(Foward,Vector2.zero);
        Gizmos.DrawLine(Target, Vector2.zero);
    }

    float Round(float r)
    {
        return (float)System.Math.Round(r, 2);
    }
}
