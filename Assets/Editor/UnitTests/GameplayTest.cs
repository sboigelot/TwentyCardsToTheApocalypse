using System.Linq;
using Assets.Scripts.Managers;
using NUnit.Framework;

public class GameplayTest
{
    [Test]
    public void StartDefaultNewGame()
    {
        PrototypeManager.Instance.LoadPrototypes();
        SaveManager.Instance.LoadProfiles();
        GameManager.Instance.NewGame(PrototypeManager.Instance.Prototypes.Apocalypses.First());
    }
}