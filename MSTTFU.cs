using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

[BepInPlugin("com.tfu.texthud", "TextHUD", "1.0.0")]
public class TextHUD : BasePlugin
{
    internal static GameObject canvasObj;
    internal static Text fpsText;

    static float deltaTime;
    static Color currentColor;

    public override void Load()
    {
        var harmony = new Harmony("com.tfu.texthud");
        harmony.PatchAll();

        CreateUI();

        AddComponent<Updater>();
    }

    static void CreateUI()
    {
        if (canvasObj != null) return;

        canvasObj = new GameObject("HUDCanvas");
        Object.DontDestroyOnLoad(canvasObj);

        var canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 9999;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // ================= FPS TEXT =================
        var textObj = new GameObject("FPS");
        textObj.transform.SetParent(canvasObj.transform, false);

        fpsText = textObj.AddComponent<Text>();
        
        // 兼容性优化：Unity 6 中 Arial 可能会找不到，找不到就自动获取系统当前可用的 legacy 字体
        Font defaultFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
        if (defaultFont == null)
        {
            var allFonts = Resources.FindObjectsOfTypeAll<Font>();
            if (allFonts.Length > 0)
            {
                defaultFont = allFonts[0];
            }
        }
        fpsText.font = defaultFont;
        
        fpsText.fontSize = 18;
        fpsText.alignment = TextAnchor.UpperRight;
        fpsText.color = Color.green;

        var rect = fpsText.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(1, 1);
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(1, 1);
        rect.anchoredPosition = new Vector2(-10, -10);
        rect.sizeDelta = new Vector2(250, 80); // 稍微加高了一点高度，防止字数变多时被裁剪
    }

    class Updater : MonoBehaviour
    {
        void Update()
        {
            if (fpsText == null) return;

            // FPS计算
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

            float fps = 1f / deltaTime;
            float ms = deltaTime * 1000f;

            // 在最上面强制带上模组名称
            fpsText.text =
                "TextHUD v1.0.0\n" +
                $"FPS: {Mathf.RoundToInt(fps)}\n" +
                $"MS: {ms:0.0}";

            // 颜色逻辑 (只影响文字整体颜色)
            Color target =
                fps < 30 ? Color.red :
                fps < 50 ? Color.yellow :
                Color.green;

            if (target != currentColor)
            {
                currentColor = target;
                fpsText.color = target;
            }
        }
    }
}