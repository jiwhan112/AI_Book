using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHome : StateSuper<Miner>
{
    private static StateHome _instance = null;
    private StateHome() { }
    private StateHome(StateHome state) { }

    public static StateHome Instance()
    {
        if (_instance == null) _instance = new StateHome();
        return _instance;
    }

    public override void Enter(Miner t)
    {
        //위치전환
        t.SetLocation(MAGADATA.LocationType.HOME);

    }

    public override void Execute(Miner t)
    {
        t.Recovery();
        if (t.AllRecovery())
            t.GetStateMachine().ChangeState(StateWork.Instance());

    }

    public override void Exit(Miner t)
    {
    }
    public override bool OnMessage(Miner t, MAGADATA.Telegram tel)
    {
        return false;
    }
}
