using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MoveGameEntity
{
    // 월드정보

    // 조종행동 정보
    SteeringBehavior mSteeringBehavior;

    public override void Active()
    {
        base.Active();
        mSteeringBehavior = new SteeringBehavior(this);
        mSteeringBehavior.SetOn(SteeringBehavior.SteerOption.SEEK);
        mSteeringBehavior.SetOn(SteeringBehavior.SteerOption.ARRIVE);
    }

    // 계산
    public override void UPDATE()
    {
        base.UPDATE();
        // 운반기 리스트 내에 있는 각 조종 행동으로부터 조합된 힘을 계산
        Vector2 StreeForce = mSteeringBehavior.CalculateWeightedSum();
        Debug.Log(StreeForce);
        // 반환된 조종힘 업데이트

        // 가속도 = 힘/질량
        Vector2 accSpeed = StreeForce / fMass;
        // 속도 갱신
        mVelocity += accSpeed * Time.deltaTime;
        mVelocity = Truncate(mVelocity, fMaxSpeed);

        mPos += mVelocity * Time.deltaTime;
        
        if (mVelocity.magnitude>0.000001) //0 나눔오류로 계산에 이상이 생길 수 있음
        {
            mHeading = mVelocity.normalized;
            mSide = new Vector2(-mHeading.y, mHeading.x);
        }
        transform.position = mPos;
        // 화면밖에 넘어갈때 처리
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(mHeading.x,mHeading.y,0));
    }
}
