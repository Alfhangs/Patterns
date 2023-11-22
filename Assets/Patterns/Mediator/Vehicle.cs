namespace Patterns.Mediator
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
