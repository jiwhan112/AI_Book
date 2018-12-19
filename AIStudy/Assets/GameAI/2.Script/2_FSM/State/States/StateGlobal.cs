using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 단순욕구 

public class StateGlobal : StateSuper<Miner>
{

    private static StateGlobal _instance = null;
    private StateGlobal() { }
    private StateGlobal(StateGlobal state) { }

    public static StateGlobal Instance()
    {
        if (_instance == null) _instance = new StateGlobal();
        return _instance;
    }

    public override void Enter(Miner t)
    {

    }

    public override void Execute(Miner t)
    {
        if (t.ThrstyToBar()) t.GetStateMachine().ChangeState(StateBar.Instance());
        if (t.TiredtoHome()) t.GetStateMachine().ChangeState(StateHome.Instance());
    }

    public override void Exit(Miner t)
    {
    }

    public override bool OnMessage(Miner t, MAGADATA.Telegram tel)
    {
        return false;
    }
}
