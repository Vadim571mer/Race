public class SetupWorld
{
    public RCCP_CarController CarController { get; private set; }
    public bool IsRace { get; private set; } = false;
    
    public bool IsStart {get; private set;} = false;

    public void SetupCar(RCCP_CarController carController)
    {
        CarController = carController;
    }

    public void SetupRace(bool isRace)
    {
        IsRace = isRace;
    }

    public void StartRace()
    {
        IsStart = true;
    }
}