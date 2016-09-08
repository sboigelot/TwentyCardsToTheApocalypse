using NUnit.Framework;
using UnityEngine;

public class NewEditorTest
{
    [Test]
    public void EditorTest()
    {
        // Arrange
        var gameObject = new GameObject();

        // Act
        // Try to rename the GameObject
        string newGameObjectName = "My game object";
        gameObject.name = newGameObjectName;

        // Assert
        // The object has a new name
        Assert.AreEqual(newGameObjectName, gameObject.name);
    }
}