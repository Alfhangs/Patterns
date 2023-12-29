namespace Patterns.Behaviour.Mediator
{
    public interface Vehicle
    {
        void BrakePressed();
        void BrakeRelease();
        void LeftPressed();
        void LeftRight();
        void ObstacleDetected();
    }
}
