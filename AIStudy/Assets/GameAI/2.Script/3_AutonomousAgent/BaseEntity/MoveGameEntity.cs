using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 움직이는 모든 물체
/// </summary>
public class MoveGameEntity : BaseGameEntity
{
    // 운반기 관련 변수
    protected Vector2 mVelocity; // 속도관련
    [SerializeField]
    protected Vector2 mHeading;// 엔티티가 향하는 벡터의 정규화 벡터.
    [SerializeField]
    protected Vector2 mSide; //방향벡터에 수직인 벡터
    [SerializeField]
    protected Vector2 mTarget;
    protected float fMass; //질량
    protected float fMaxSpeed; //최대속도
    protected float fMaxForce;// 최대추진력
    protected float fMaxTurnRadius; // 최대회전비율 rad/s

    public override void Active()
    {
        base.Active();
        mVelocity = Vector2.zero;
        mHeading = Vector2.zero;
        mSide = Vector2.zero;
        mTarget = Vector2.zero;
        fMass = 1;
        fMaxSpeed = 10;
        fMaxForce = 5;
        fMaxTurnRadius = 0.5f;
    }




    /// SetGet
    /// 
    public void SetVelocity(Vector2 Vec) { mVelocity = Vec; }
    public Vector2 GetVelolcity() { return mVelocity; }
    public Vector2 GetHeaing() { return mHeading; }
    public Vector2 GetSide() { return mSide; }
    public Vector2 GetTarget() { return mTarget; }
    public void SetTarget(Vector2 target) { mTarget = target; }
    public void SetfMass(float speed) { fMass = speed; }
    public float GetMass() { return fMass; }


    public  void SetMaxSpeed(float speed) { fMaxSpeed = speed; }
    public float GetMaxSpeed() { return fMaxSpeed; }

    public void SetfMaxForce(float speed) { fMaxForce = speed; }
    public float GetfMaxForce() { return fMaxForce; }

    public void SetfMaxTurnRadius(float speed) { fMaxTurnRadius = speed; }
    public float GetfMaxTurnRadius() { return fMaxTurnRadius; }



    protected Vector2 Truncate(Vector3 CurrentVec, float MaxSpeed)
    {
        if(CurrentVec.magnitude>MaxSpeed)
        {
            CurrentVec = CurrentVec.normalized *MaxSpeed;
            return CurrentVec;
        }
        return CurrentVec;
    }
}
