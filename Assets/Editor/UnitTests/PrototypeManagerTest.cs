using System;
using System.IO;
using Assets.Scripts.Managers;
using Assets.Scripts.Serialization;
using NUnit.Framework;

public class PrototypeManagerTest
{
    [Test]
    public void LoadAllPrototypes()
    {
        PrototypeManager.Instance.LoadPrototypes();

        MemoryStream ms = new MemoryStream();
        DataSerializer.Instance.Serialize(ms, PrototypeManager.Instance);
        ms.Flush();

        ms.Position = 0;
        var sr = new StreamReader(ms);
        var xml = sr.ReadToEnd();
        Console.WriteLine(xml);
    }

    [Test]
    public void LoadAllProfiles()
    {
        PrototypeManager.Instance.LoadPrototypes();
        SaveManager.Instance.LoadProfiles();
    }
}