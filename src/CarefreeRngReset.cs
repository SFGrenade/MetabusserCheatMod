using JetBrains.Annotations;
using Modding;
using UnityEngine.SceneManagement;
using USceneManager = UnityEngine.SceneManagement.SceneManager;

namespace CarefreeRngReset;

[UsedImplicitly]
public class CarefreeRngReset : Mod
{
    public override string GetVersion() => "in Hall of Gods";

    public CarefreeRngReset() : base("Carefree RNG reset")
    {}

    public override void Initialize()
    {
        USceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene arg0, Scene arg1)
    {
        if (arg1.name != "GG_Workshop") return;

        var hc = HeroController.instance;
        if (hc != null)
        {
            ReflectionHelper.SetField<HeroController, int>(hc, "hitsSinceShielded", 7);
        }
    }
}