using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : Health
{
    AiAgent agent;
    private bool Died = false;
    public LevelManager lvlManager;

    protected override void OnStart() {
        agent = GetComponent<AiAgent>();
        lvlManager = FindObjectOfType<LevelManager>();
    }

    protected override void OnDeath(Vector3 direction) {
        AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
        if (!Died)
        {
            lvlManager.bots -= 1;
            Died = true;
        }
        deathState.direction = direction;
        agent.stateMachine.ChangeState(AiStateId.Death);
    }

    protected override void OnDamage(Vector3 direction) {

    }
}
