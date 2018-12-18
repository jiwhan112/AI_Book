using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 질량 및 힘/가속도 관련 코드
/// </summary>
public class Acceleration : MonoBehaviour
{

    public GameObject Obj;
    [Header("힘")]
    public float fForce; //힘
    [Header("물체질량")]
    public float fMass; //질량
    [Header("이동거리")]
    public float fCurrentDist; // 이동거리
    [Header("가속도")]
    public float fAccSpeed; //가속도
    [Header("현재속도")]
    public float fCurrentSpeed; // 현재 속도


    
    private void Start()
    {
        fCurrentDist = 0;
        fCurrentSpeed = 0;
        fAccSpeed = fForce / fMass; // 가속도 계산
    }

    private void Update()
    {
        // 등가 속도
        //float AddSpeed = Time.deltaTime * Speed;
        //if (Obj != null)
        //    Obj.transform.position = new Vector3(AddSpeed + Obj.transform.position.x, 0, 0);


        // 가속도
        fCurrentSpeed += fAccSpeed * Time.deltaTime;
        fCurrentDist += fCurrentSpeed * Time.deltaTime;
        if (Obj != null)
            Obj.transform.position = new Vector3(fCurrentDist, 0, 0);
        
    }
}
