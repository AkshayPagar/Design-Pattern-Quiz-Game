using System;
using UnityEngine;

class HintManager
{
    private HintState currentState = null;
    private static HintManager hintManager;

    private static object obj = new object();

    private HintManager()
    {
    }
    public static HintManager GetInstance()
    {
        lock (obj)
        {
            if (hintManager == null)
            {
                hintManager = new HintManager();
                hintManager.TransitionTo(new HintNotUsed());
            }
        }

        return hintManager;
    }

    public void TransitionTo(HintState hintState)
    {
        this.currentState = hintState;
        this.currentState.SetHintManager(this);
    }
    public Int32 GetHintCount()
    {
        return this.currentState.RemainingHints();
    }
    public void Request()
    {
        this.currentState.UseHint();
    }
}

abstract class HintState
{
    protected HintManager hintManager;

    public void SetHintManager(HintManager hintManager)
    {
        this.hintManager = hintManager;
    }
    public abstract void UseHint();
    public abstract Int32 RemainingHints();
}

class HintUsed : HintState
{
    public override void UseHint()
    {
        Debug.Log("Hint Already Used");
    }
    public override Int32 RemainingHints()
    {
        return 0;
    }
}

class HintNotUsed : HintState
{
    public override void UseHint()
    {
        this.hintManager.TransitionTo(new HintUsed());
    }
    public override Int32 RemainingHints()
    {
        return 1;
    }
}

