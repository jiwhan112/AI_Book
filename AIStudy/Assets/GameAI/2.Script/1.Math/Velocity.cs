using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{

    public GameObject Obj;
    public float AccSpeed;
    public float CurrentX ; //이동거리 X
    public float Time1;
    public float Timer;
    private float CurrentSpeed;

    public float X;
    private void Start()
    {
        Timer = 0;
        CurrentX = 0;
        CurrentSpeed = 0;
    }

    private void Update()
    {
        // 등가 속도
        //float AddSpeed = Time.deltaTime * Speed;
        //if (Obj != null)
        //    Obj.transform.position = new Vector3(AddSpeed + Obj.transform.position.x, 0, 0);


        CurrentX = Obj.transform.position.x + 0.5f * AccSpeed * Time.deltaTime * Time.deltaTime;
        if (Obj != null)
            Obj.transform.position = new Vector3(CurrentX, 0, 0);

        Timer += Time.deltaTime;
        if (2 > Timer)
            Time1 = Obj.transform.position.x;
    }
}
