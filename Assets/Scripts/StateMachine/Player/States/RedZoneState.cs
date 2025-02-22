public class RedZoneState : PlayerState
{
    private bool isActive;
    public override PlayerStates stateType {get {return(_stateType);} set {}}
    private PlayerStates _stateType = PlayerStates.RedZone;
    public RedZoneState(PlayerController player) : base(player) {}
    
    public override void Enter()
    {
        isActive = true;
        player.combat.redZone.SetActive(isActive);
    }
    public override void Exit() 
    {
        isActive = false;
        player.combat.redZone.SetActive(isActive);
    }
    public override void Update() 
    {
        isActive = !isActive;
        player.combat.redZone.SetActive(isActive);
    }
}