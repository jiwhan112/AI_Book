using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar : StateSuper<Miner>
{
    private static StateBar _instance = null;
    private StateBar() { }
    private StateBar(StateBar state) { }

    public static StateBar Instance()
    {
        if (_instance == null) _instance = new StateBar();
        return _instance;
    }

    public override void Enter(Miner t)
    {
        //위치전환
        t.SetLocation(MAGADATA.LocationType.BAR);

    }

    public override void Execute(Miner t)
    {

        if (t.PayBar())
            t.GoBar();
        else
            t.GetStateMachine().ChangeState(StateBank.Instance());
        if(t.FullThirsty()) t.GetStateMachine().ChangeState(StateWork.Instance());

    }

    public override void Exit(Miner t)
    {
    }
    public override bool OnMessage(Miner t, MAGADATA.Telegram tel)
    {
        return false;
    }
}
