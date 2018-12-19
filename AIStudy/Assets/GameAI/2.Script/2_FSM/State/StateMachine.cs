using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{

    T mEntity;
    StateSuper<T> mCurrentState;
    StateSuper<T> mPrevState;
    StateSuper<T> mGlobalState; // FSM이 갱신될때마다 호출

    public StateMachine(T mEntity)
    {
        this.mEntity = mEntity;
        this.mCurrentState = null;
        this.mPrevState = null;
        this.mGlobalState = null;
    }

    // SetState
    public void SetCurrentState(StateSuper<T> t)
    {
        mCurrentState = t;
    }
    public void SetPrevState(StateSuper<T> t)
    {
        mPrevState = t;
    }
    public void SetGlobalState(StateSuper<T> t)
    {
        mGlobalState = t;
    }

    // Update
    public void UPDATE()
    {
        // 전역상태가 존재하면 execute 메소드 호출
        if (mGlobalState != null) mGlobalState.Execute(mEntity);
        // 현재 상태에 대해서 동일하게
        if (mCurrentState != null) mCurrentState.Execute(mEntity);
    }
    // Change
    public void ChangeState(StateSuper<T> newState)
    {
        if (newState == null) return;
        if (mCurrentState != null)
        {
            mPrevState = mCurrentState;
            mCurrentState.Exit(mEntity);
        }
        mCurrentState = newState;
        mCurrentState.Enter(mEntity);
    }

    public void RevertToPrevState()
    { ChangeState(mPrevState); }

    //Get
    public StateSuper<T> GetCurrentState() { return mCurrentState; }
    public StateSuper<T> GetPrevState() { return mPrevState; }
    public StateSuper<T> GetGlobalState() { return mGlobalState; }

    public bool isSameState(StateSuper<T> state) { return (mCurrentState == state) ? true : false; }

    // 현재 메시지를 처리 할 수 없으면 전역 엔티티로 변경되서 메시지를 처리함
    public bool HandleMessage(MAGADATA.Telegram msg)
    {
        /// 현재상태에서 처리가능한지 체크
        if (mCurrentState!=null && mCurrentState.OnMessage(mEntity, msg))
        {
            return true;
        }

        /// 전역 상태의 메시지로 넘겨 처리
        if (mGlobalState != null && mGlobalState.OnMessage(mEntity, msg))
        {
            return true;
        }
        return false;
    }

}
