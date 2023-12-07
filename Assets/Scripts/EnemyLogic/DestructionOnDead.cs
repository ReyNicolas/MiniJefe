public class DestructionOnDead : Destruction
{
    private void OnDestroy()
    {
        InstantiateFx();
    }
}