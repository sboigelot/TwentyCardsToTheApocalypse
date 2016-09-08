using Assets.Scripts.Managers;
using NUnit.Framework;

public class PrototypeManagerTest
{
    [Test]
    public void LoadAllPrototypes()
    {
        PrototypeManager.Instance.LoadPrototypes();
    }
}