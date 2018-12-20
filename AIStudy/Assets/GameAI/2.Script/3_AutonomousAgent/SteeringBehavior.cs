using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 움직임 관련 함수들 캡슐화
/// </summary>
public class SteeringBehavior {
    public SteeringBehavior(Vehicle current)
    {
        OPTION = new bool[(int)SteerOption.MAX];
        for (int i = 0; i < OPTION.Length; i++)
        {
            OPTION[i] = false;
        }

        mCurrentVehicle = current;
    }

    public enum SteerOption
    {
        SEEK = 0,
        FLLE,
        ARRIVE,
        MAX
    };

    bool[] OPTION;

    Vehicle mCurrentVehicle;
    Vector2 mSteeringForce;
    public Deceleration mDecelerationType;
    public float fFLLERadius;

  

    Vector2 SEEK(Vector2 TargetPos)// 찾기
    {
        Vector2 desiredVelocity = (TargetPos - mCurrentVehicle.mPos).normalized * mCurrentVehicle.GetMaxSpeed();
        return desiredVelocity - mCurrentVehicle.GetVelolcity();
    }

    Vector2 FLLE(Vector2 TargetPos) //달아나기
    {
        if (Vector2.Distance(mCurrentVehicle.GetPosition(), TargetPos) > fFLLERadius)
        {
            return Vector2.zero;
        }
        Vector2 desiredVelocity = (mCurrentVehicle.mPos - TargetPos).normalized * mCurrentVehicle.GetMaxSpeed();
        return desiredVelocity - mCurrentVehicle.GetVelolcity();
    }

    public enum Deceleration { slow = 3, normal = 2, fast = 1 };
    Vector2 Arrive(Vector2 targetPos, Deceleration type)
    {
        Vector2 ToTarget = targetPos - mCurrentVehicle.GetPosition();
        float dist = ToTarget.magnitude;
        if (dist > 0)
        {
            //감속
            float decelerationTweaker = 1.0f;
            float speed = dist / decelerationTweaker * (float)type;

            speed = Mathf.Min(speed, mCurrentVehicle.GetMaxSpeed());
            Vector2 DesireVelocity = ToTarget * speed / dist;
            return DesireVelocity - mCurrentVehicle.GetVelolcity();
        }

        return Vector2.zero;
    }



    // 우선순위 계산
    //public Vector2 CalculatePrioritized()
    //{

    //}

    // 가중 합계
    public Vector2 CalculateWeightedSum()
    {
        mSteeringForce = Vector2.zero;

        // 무리이동 연결체 알고리즘 추가 
        // =====

        if (On(SteerOption.SEEK))
            mSteeringForce += SEEK(mCurrentVehicle.GetTarget());
        Debug.Log("SEEK:" + SEEK(mCurrentVehicle.GetTarget()));
        if (On(SteerOption.FLLE))
            mSteeringForce += FLLE(mCurrentVehicle.GetTarget());
        
        if (On(SteerOption.ARRIVE))
            mSteeringForce += Arrive(mCurrentVehicle.GetTarget(), mDecelerationType);

        Debug.Log("ARRIVE:" + Arrive(mCurrentVehicle.GetTarget(), mDecelerationType));

        return mSteeringForce;
    }

    //set Get
    public Vector2 GetSteeringForce() { return mSteeringForce; }
    bool On(SteerOption option) { return OPTION[(int)option]; }
    public void SetOn(SteerOption option) { OPTION[(int)option] = true; }
}
