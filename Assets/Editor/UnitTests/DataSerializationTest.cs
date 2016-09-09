using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Assets.Scripts.Models;
using Assets.Scripts.Serialization;
using NUnit.Framework;
using UnityEditor.VersionControl;

public class DataSerializationTest
{
    [Test]
    public void SerializeCardTest()
    {
        var data = new Card
        {
            Name = "TestCard",
            DescriptionTextLocalCode = "description"
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
        Assert.AreEqual(data2.DescriptionTextLocalCode, "description");
    }

    [Test]
    public void SerializeCardList()
    {
        List<Card> data = new List<Card>
        {
            new Card { Name = "Test1" },
            new Card { Name = "Test2" },
            new Card { Name = "Test3" }
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
                new Card { Name = "Test1" },
                new Card { Name = "Test2" },
                new Card { Name = "Test3" }
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

    [Test]
    public void DerializeDeckTest()
    {
        string xml =
        @"<?xml version='1.0' encoding='Windows-1252'?>
        <Deck Name='Default'>
            <Card Name='Test Card 1' SpriteName='' DescriptionTextLocalCode='' LeftOptionTextLocalCode='' RightOptionTextLocalCode=''>
                <LeftEffect TurnDelay='0' HasDialog='true' DialogSpriteName='' DialogTextLocalCode=''
                            TargetName='' FunctionParam='0' CardEffectType='ShuffleDeck'/>
                <LeftEffect TurnDelay='1' HasDialog='false' DialogSpriteName='' DialogTextLocalCode=''
                            TargetName='Politic' FunctionParam='-5' CardEffectType='AffectWorldStat'/>
                <RightEffect TurnDelay='1' HasDialog='false' DialogSpriteName='' DialogTextLocalCode=''
                            TargetName='Politic' FunctionParam='-5' CardEffectType='AffectWorldStat'/>
            </Card>
            <Card Name='Test Card 2' SpriteName='' DescriptionTextLocalCode='' LeftOptionTextLocalCode='' RightOptionTextLocalCode=''>
                <LeftEffect TurnDelay='0' HasDialog='true' DialogSpriteName='' DialogTextLocalCode=''
                            TargetName='' FunctionParam='0' CardEffectType='ShuffleDeck'/>
                <LeftEffect TurnDelay='1' HasDialog='false' DialogSpriteName='' DialogTextLocalCode=''
                            TargetName='Politic' FunctionParam='-5' CardEffectType='AffectWorldStat'/>
                <RightEffect TurnDelay='1' HasDialog='false' DialogSpriteName='' DialogTextLocalCode=''
                            TargetName='Politic' FunctionParam='-5' CardEffectType='AffectWorldStat'/>
            </Card>
        </Deck>  ".Replace("'","\"");

        using (Stream sr = GenerateStreamFromString(xml))
        {
            var data2 = DataSerializer.Instance.DeSerialize<Deck>(sr);

            Assert.AreEqual("Default", data2.Name);
            Assert.AreEqual(2, data2.Cards.Count);
            Assert.AreEqual(2, data2.Cards[0].LeftEffects.Count);
            Assert.AreEqual(1, data2.Cards[0].RightEffects.Count);
        }
    }

    public Stream GenerateStreamFromString(string s)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}