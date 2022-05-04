using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Texture64;

public class ROMTextureLoader
{
    public static Dictionary<string, Texture2D> gTextures = new Dictionary<string, Texture2D>();
    public static int extractionStatus = 0;

    static Texture2D Flip(Texture2D original)
    {
        var originalPixels = original.GetPixels();

        var newPixels = new Color[originalPixels.Length];

        var width = original.width;
        var rows = original.height;

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < rows; y++)
            {
                newPixels[x + y * width] = originalPixels[x + (rows - y - 1) * width];
            }
            // original.SetPixel(x, rows, Color.clear);
        }

        original.SetPixels(newPixels);
        original.Apply();
        return original;
    }

    [RuntimeInitializeOnLoadMethod]
    static void LoadROM()
    {
        if (!File.Exists(Application.persistentDataPath + "/baserom.us.ext.z64"))
        {
            var extender = Process.Start(Application.dataPath + "/sm64extend.exe", Application.dataPath + "/../baserom.us.z64");
            extender.WaitForExit();
            File.Copy(Application.dataPath + "/../baserom.us.ext.z64", Application.persistentDataPath + "/baserom.us.ext.z64");
            GC.WaitForPendingFinalizers();
            File.Delete(Application.dataPath + "/../baserom.us.ext.z64");
            LoadAssets();
            extractionStatus = 1;
        }
        else
        {
            extractionStatus = 2;
            LoadAssets();
        }
    }

    static void LoadAssets()
    {
        byte[] extRom = File.ReadAllBytes(Application.persistentDataPath + "/baserom.us.ext.z64");
        byte[] texPalette = { 0 }; //! currently only fully works with RGBA16 because of this
        string[] assets = File.ReadAllLines(Application.dataPath + "/assets.txt");
        for (int i = 0; i < assets.Length; i++)
        {
            if (assets[i].StartsWith("//"))
            {
                continue;
            }
            string[] args = assets[i].Split(",");
            if (args[0].Contains("flip"))
            {
                gTextures.Add(args[0], N64Graphics.RenderTexture(extRom, texPalette, int.Parse(args[1], System.Globalization.NumberStyles.HexNumber), int.Parse(args[3]), int.Parse(args[4]), (N64Codec)int.Parse(args[2]), N64IMode.AlphaCopyIntensity));
            }
            else if (args[0].Contains("hud"))
            {
                gTextures.Add(args[0], Flip(N64Graphics.RenderTexture(extRom, texPalette, int.Parse(args[1], System.Globalization.NumberStyles.HexNumber), int.Parse(args[3]), int.Parse(args[4]), (N64Codec)int.Parse(args[2]), N64IMode.AlphaCopyIntensity, true)));
            }
            else
            {
                gTextures.Add(args[0], Flip(N64Graphics.RenderTexture(extRom, texPalette, int.Parse(args[1], System.Globalization.NumberStyles.HexNumber), int.Parse(args[3]), int.Parse(args[4]), (N64Codec)int.Parse(args[2]), N64IMode.AlphaCopyIntensity)));
            }
        }
    }
}
