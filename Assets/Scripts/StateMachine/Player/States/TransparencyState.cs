using UnityEngine;

public class TransparencyState : PlayerState
{
    private bool isTransparent;
    public override PlayerStates stateType {get {return(_stateType);} set {}}
    private PlayerStates _stateType = PlayerStates.Transparent;
    public TransparencyState(PlayerController player) : base(player) {}
    
    public override void Enter()
    {
        isTransparent = true;
        SetTransparency();
    }
    public override void Exit() 
    {
        isTransparent = false;
        SetTransparency();
    }
    public override void Update() 
    {
        isTransparent = !isTransparent;
        SetTransparency();
    }

    private void SetTransparency()
    {
        Color color = player.combat.playerSprite.color;
        color.a = isTransparent ? 0.5f : 1f;
        player.combat.playerSprite.color = color;
    }
}
