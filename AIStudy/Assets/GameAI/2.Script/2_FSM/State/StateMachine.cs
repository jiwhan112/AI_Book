using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{

    T mEntity;
    StateSuper<T> mCurrentState;
    StateSuper<T> mPrevState;
    StateSuper<T> mGlobalState;

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
    void ChangeState(StateSuper<T> newState)
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


}
