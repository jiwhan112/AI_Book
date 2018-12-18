using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateSuper<T> {

    public abstract void Enter(T t);
    public abstract void Execute(T t);
    public abstract void Exit(T t);
}
