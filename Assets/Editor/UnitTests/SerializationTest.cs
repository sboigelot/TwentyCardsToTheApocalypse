using Assets.Scripts.Managers;
using NUnit.Framework;

public class SerializationTest
{
    [Test]
    public void LoadAllPrototypes()
    {
        PrototypeManager.Instance.LoadPrototypes();
    }

    [Test]
    public void LoadAllProfiles()
    {
        PrototypeManager.Instance.LoadPrototypes();
        SaveManager.Instance.LoadProfiles();
    }
}