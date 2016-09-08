using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Assets.Scripts.Models;
using Assets.Scripts.Serialization;
using NUnit.Framework;

public class DataSerializationTest
{
    [Test]
    public void SerializeCardTest()
    {
        var data = new Card
        {
            Name = "TestCard"
        };

        MemoryStream ms = new MemoryStream();
        DataSerializer.Instance.Serialize(ms, data);
        ms.Flush();

        ms.Position = 0;
        var sr = new StreamReader(ms);
        var xml = sr.ReadToEnd();
        Console.WriteLine(xml);

        ms.Position = 0;
        var data2 = DataSerializer.Instance.DeSerialize<Card>(ms);

        Assert.AreEqual(data.Name, data2.Name);
    }

    [Test]
    public void SerializeCardList()
    {
        List<Card> data = new List<Card>
        {
            new Card {Name = "Test1"},
            new Card {Name = "Test2"},
            new Card {Name = "Test3"}
        };

        MemoryStream ms = new MemoryStream();
        DataSerializer.Instance.Serialize(ms, data);
        ms.Flush();
        
        ms.Position = 0;
        var sr = new StreamReader(ms);
        var xml = sr.ReadToEnd();
        Console.WriteLine(xml);

        ms.Position = 0;
        var data2 = DataSerializer.Instance.DeSerialize<List<Card>>(ms);

        Assert.AreEqual(data.Count, data2.Count);
        Assert.AreEqual(data[0].Name, data2[0].Name);
    }

    [Test]
    public void SerializeDeckTest()
    {
        var data = new Deck()
        {
            Name = "TestDeck",
            Cards = new List<Card>
            {
                new Card {Name = "Test1"},
                new Card {Name = "Test2"},
                new Card {Name = "Test3"}
            }
        };

        MemoryStream ms = new MemoryStream();
        DataSerializer.Instance.Serialize(ms, data);
        ms.Flush();

        ms.Position = 0;
        var sr = new StreamReader(ms);
        var xml = sr.ReadToEnd();
        Console.WriteLine(xml);

        ms.Position = 0;
        var data2 = DataSerializer.Instance.DeSerialize<Deck>(ms);

        Assert.AreEqual(data.Name, data2.Name);
        Assert.AreEqual(data.Cards[0].Name, data2.Cards[0].Name);
    }
}