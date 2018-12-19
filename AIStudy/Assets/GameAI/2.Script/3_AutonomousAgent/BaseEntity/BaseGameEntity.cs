using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 앞으로 게임에서 사용될 엔티티 기본형
/// </summary>
public class BaseGameEntity : MonoBehaviour {

    int iID;
    MAGADATA.EntityType eEntityType;
    bool bTag;

    static int NextID = 0; // 고유엔티티 부여
    int NextValidID() { return NextID++; }

    public Vector2 mPos;
    public Vector3 mScale;
    // 반경 길이
    public double dBoundingRadius;

    protected void Active()
    {
        iID = NextValidID();
        eEntityType = MAGADATA.EntityType.Default;
        mScale = Vector3.one;
        mPos = Vector2.zero;
        dBoundingRadius = 0.0f;
        bTag = false;
    }
    protected void Active(MAGADATA.EntityType entity)
    {
        iID = NextValidID();
        eEntityType = entity;
        mScale = Vector3.one;
        mPos = Vector2.zero;
        dBoundingRadius = 0.0f;
        bTag = false;
    }
    protected void Active(MAGADATA.EntityType entity, Vector2 pos, double r)
    {
        iID = NextValidID();
        eEntityType = entity;
        mScale = Vector3.one;
        mPos = pos;
        dBoundingRadius = r;
        bTag = false;
    }

    public virtual void UPDATE() { }
    public bool HandleMessage(MAGADATA.Telegram tel) { return false; }

    // 데이터 스트림으로 쓰고 읽는 부분
    public virtual void Write() { }
    public virtual void Read() { }


    //SetGet
    public int GetID() { return iID; }

    public MAGADATA.EntityType GetEntityType() { return eEntityType; }
    public void SetEntityType(MAGADATA.EntityType T) { eEntityType = T; }

    public bool GetTag() { return bTag; }
    public void Tag() { bTag = true; }
    public void UnTag() { bTag = false; }

    public Vector2 GetPosition() { return mPos; }
    public Vector3 GetScale() { return mScale; }

    public double GetBoundingRadius() { return dBoundingRadius; }
    public void SetBoundingRadius(double r) { dBoundingRadius = r; }
}
