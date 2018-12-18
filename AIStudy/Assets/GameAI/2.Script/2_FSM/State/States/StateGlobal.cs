using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public override void Exit(Miner t)
    {
    }
}
