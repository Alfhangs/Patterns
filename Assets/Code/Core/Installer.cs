using Patterns.Decoupling.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Installer : MonoBehaviour
{
    public abstract void Install(ServiceLocator serviceLocator);
}
