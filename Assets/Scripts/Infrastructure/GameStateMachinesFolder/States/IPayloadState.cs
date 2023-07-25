namespace Assets.Scripts.Infrastructure.GameStateMachinesFolder.States
{
    public interface IPayloadState: IState
    {
        public void Enter(int level);
    }
}
