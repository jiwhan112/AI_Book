using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 움직이는 모든 물체
/// </summary>
public class MoveGameEntity : BaseGameEntity
{
    // 운반기 관련 변수
    protected Vector2 mVelocity;
    protected Vector2 mHeading;// 엔티티가 향하는 벡터의 정규화 벡터
    protected Vector2 mSide; //방향벡터에 수직인 벡터
    protected float dMass;
    protected float dMaxSpeed;
}
