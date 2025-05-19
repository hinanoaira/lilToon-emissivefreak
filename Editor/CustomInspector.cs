#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace lilToon
{
    public class lilToonFreakInspector : lilToonInspector
    {
        // Custom properties
        //MaterialProperty customVariable;
        MaterialProperty _UseEmissionParallax;
        MaterialProperty _EmissionAParallaxTex;
        MaterialProperty _EmissionAParallaxColor;
        MaterialProperty _EmissionAParallaxMask;
        MaterialProperty _EmissionAParallaxDepth;
        MaterialProperty _EmissionAParallaxDepthMask;
        MaterialProperty _EmissionAParallaxDepthMaskInvert;
        MaterialProperty _EmissiveFreak1Tex;
        MaterialProperty _EmissiveFreak1Color;
        MaterialProperty _EmissiveFreak1Mask;
        MaterialProperty _EmissiveFreak1U;
        MaterialProperty _EmissiveFreak1V;
        MaterialProperty _EmissiveFreak1Depth;
        MaterialProperty _EmissiveFreak1DepthMask;
        MaterialProperty _EmissiveFreak1DepthMaskInvert;
        MaterialProperty _EmissiveFreak1Breathing;
        MaterialProperty _EmissiveFreak1BreathingMix;
        MaterialProperty _EmissiveFreak1BlinkOut;
        MaterialProperty _EmissiveFreak1BlinkOutMix;
        MaterialProperty _EmissiveFreak1BlinkIn;
        MaterialProperty _EmissiveFreak1BlinkInMix;
        MaterialProperty _EmissiveFreak1HueShift;
        MaterialProperty _EmissiveFreak2Tex;
        MaterialProperty _EmissiveFreak2Color;
        MaterialProperty _EmissiveFreak2Mask;
        MaterialProperty _EmissiveFreak2U;
        MaterialProperty _EmissiveFreak2V;
        MaterialProperty _EmissiveFreak2Depth;
        MaterialProperty _EmissiveFreak2DepthMask;
        MaterialProperty _EmissiveFreak2DepthMaskInvert;
        MaterialProperty _EmissiveFreak2Breathing;
        MaterialProperty _EmissiveFreak2BreathingMix;
        MaterialProperty _EmissiveFreak2BlinkOut;
        MaterialProperty _EmissiveFreak2BlinkOutMix;
        MaterialProperty _EmissiveFreak2BlinkIn;
        MaterialProperty _EmissiveFreak2BlinkInMix;
        MaterialProperty _EmissiveFreak2HueShift;

        private static bool isShowCustomProperties;
        private const string shaderName = "lilToonFreak";

        protected override void LoadCustomProperties(MaterialProperty[] props, Material material)
        {
            isCustomShader = true;

            // If you want to change rendering modes in the editor, specify the shader here
            ReplaceToCustomShaders();
            isShowRenderMode = !material.shader.name.Contains("Optional");

            // If not, set isShowRenderMode to false
            //isShowRenderMode = false;

            //LoadCustomLanguage("");
            //customVariable = FindProperty("_CustomVariable", props);
            _UseEmissionParallax = FindProperty("_UseEmissionParallax", props);
            _EmissionAParallaxTex = FindProperty("_EmissionAParallaxTex", props);
            _EmissionAParallaxColor = FindProperty("_EmissionAParallaxColor", props);
            _EmissionAParallaxMask = FindProperty("_EmissionAParallaxMask", props);
            _EmissionAParallaxDepth = FindProperty("_EmissionAParallaxDepth", props);
            _EmissionAParallaxDepthMask = FindProperty("_EmissionAParallaxDepthMask", props);
            _EmissionAParallaxDepthMaskInvert = FindProperty("_EmissionAParallaxDepthMaskInvert", props);
            _EmissiveFreak1Tex = FindProperty("_EmissiveFreak1Tex", props);
            _EmissiveFreak1Color = FindProperty("_EmissiveFreak1Color", props);
            _EmissiveFreak1Mask = FindProperty("_EmissiveFreak1Mask", props);
            _EmissiveFreak1U = FindProperty("_EmissiveFreak1U", props);
            _EmissiveFreak1V = FindProperty("_EmissiveFreak1V", props);
            _EmissiveFreak1Depth = FindProperty("_EmissiveFreak1Depth", props);
            _EmissiveFreak1DepthMask = FindProperty("_EmissiveFreak1DepthMask", props);
            _EmissiveFreak1DepthMaskInvert = FindProperty("_EmissiveFreak1DepthMaskInvert", props);
            _EmissiveFreak1Breathing = FindProperty("_EmissiveFreak1Breathing", props);
            _EmissiveFreak1BreathingMix = FindProperty("_EmissiveFreak1BreathingMix", props);
            _EmissiveFreak1BlinkOut = FindProperty("_EmissiveFreak1BlinkOut", props);
            _EmissiveFreak1BlinkOutMix = FindProperty("_EmissiveFreak1BlinkOutMix", props);
            _EmissiveFreak1BlinkIn = FindProperty("_EmissiveFreak1BlinkIn", props);
            _EmissiveFreak1BlinkInMix = FindProperty("_EmissiveFreak1BlinkInMix", props);
            _EmissiveFreak1HueShift = FindProperty("_EmissiveFreak1HueShift", props);
            _EmissiveFreak2Tex = FindProperty("_EmissiveFreak2Tex", props);
            _EmissiveFreak2Color = FindProperty("_EmissiveFreak2Color", props);
            _EmissiveFreak2Mask = FindProperty("_EmissiveFreak2Mask", props);
            _EmissiveFreak2U = FindProperty("_EmissiveFreak2U", props);
            _EmissiveFreak2V = FindProperty("_EmissiveFreak2V", props);
            _EmissiveFreak2Depth = FindProperty("_EmissiveFreak2Depth", props);
            _EmissiveFreak2DepthMask = FindProperty("_EmissiveFreak2DepthMask", props);
            _EmissiveFreak2DepthMaskInvert = FindProperty("_EmissiveFreak2DepthMaskInvert", props);
            _EmissiveFreak2Breathing = FindProperty("_EmissiveFreak2Breathing", props);
            _EmissiveFreak2BreathingMix = FindProperty("_EmissiveFreak2BreathingMix", props);
            _EmissiveFreak2BlinkOut = FindProperty("_EmissiveFreak2BlinkOut", props);
            _EmissiveFreak2BlinkOutMix = FindProperty("_EmissiveFreak2BlinkOutMix", props);
            _EmissiveFreak2BlinkIn = FindProperty("_EmissiveFreak2BlinkIn", props);
            _EmissiveFreak2BlinkInMix = FindProperty("_EmissiveFreak2BlinkInMix", props);
            _EmissiveFreak2HueShift = FindProperty("_EmissiveFreak2HueShift", props);
        }

        protected override void DrawCustomProperties(Material material)
        {
            // GUIStyles Name   Description
            // ---------------- ------------------------------------
            // boxOuter         outer box
            // boxInnerHalf     inner box
            // boxInner         inner box without label
            // customBox        box (similar to unity default box)
            // customToggleFont label for box

            isShowCustomProperties = Foldout("Emissive Freak", "Emissive Freak", isShowCustomProperties);
            if (isShowCustomProperties)
            {
                EditorGUILayout.BeginVertical(boxOuter);
                m_MaterialEditor.ShaderProperty(_UseEmissionParallax, "Emission Parallax(Arktoon)");
                var useEmissionPara = _UseEmissionParallax.floatValue;
                if (useEmissionPara > 0)
                {
                    EditorGUILayout.BeginVertical(boxInner);
                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Texture & Color", "Texture and Color"), _EmissionAParallaxTex, _EmissionAParallaxColor);
                    m_MaterialEditor.TextureScaleOffsetProperty(_EmissionAParallaxTex);
                    lilEditorGUI.DrawLine();
                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("TexCol Mask", "Texture and Color Mask"), _EmissionAParallaxMask);
                    m_MaterialEditor.TextureScaleOffsetProperty(_EmissionAParallaxMask);
                    lilEditorGUI.DrawLine();
                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Depth & Mask", "Depth and Mask Texture"), _EmissionAParallaxDepthMask, _EmissionAParallaxDepth);
                    m_MaterialEditor.TextureScaleOffsetProperty(_EmissionAParallaxDepthMask);
                    m_MaterialEditor.ShaderProperty(_EmissionAParallaxDepthMaskInvert, "Invert Depth Mask");
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(boxOuter);
                EditorGUILayout.LabelField("Emissive Freak 1st(Arktoon)", customToggleFont);
                EditorGUILayout.BeginVertical(boxInner);
                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Texture & Color", "Texture and Color"), _EmissiveFreak1Tex, _EmissiveFreak1Color);
                m_MaterialEditor.TextureScaleOffsetProperty(_EmissiveFreak1Tex);
                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("TexCol Mask", "Texture and Color Mask"), _EmissiveFreak1Mask);
                m_MaterialEditor.TextureScaleOffsetProperty(_EmissiveFreak1Mask);
                lilEditorGUI.DrawLine();
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1U, "Scroll U");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1V, "Scroll V");
                lilEditorGUI.DrawLine();
                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Depth & Mask", "Depth and Mask Texture"), _EmissiveFreak1DepthMask, _EmissiveFreak1Depth);
                m_MaterialEditor.TextureScaleOffsetProperty(_EmissiveFreak1DepthMask);
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1DepthMaskInvert, "Invert Depth Mask");
                lilEditorGUI.DrawLine();
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1Breathing, "Breathing");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1BreathingMix, "Breathing Mix");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1BlinkOut, "Blink Out");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1BlinkOutMix, "Blink Out Mix");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1BlinkIn, "Blink In");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1BlinkInMix, "Blink In Mix");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak1HueShift, "Hue Shift");
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(boxOuter);
                EditorGUILayout.LabelField("Emissive Freak 2nd(Arktoon)", customToggleFont);
                EditorGUILayout.BeginVertical(boxInner);
                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Texture & Color", "Texture and Color"), _EmissiveFreak2Tex, _EmissiveFreak2Color);
                m_MaterialEditor.TextureScaleOffsetProperty(_EmissiveFreak2Tex);
                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("TexCol Mask", "Texture and Color Mask"), _EmissiveFreak2Mask);
                m_MaterialEditor.TextureScaleOffsetProperty(_EmissiveFreak2Mask);
                lilEditorGUI.DrawLine();
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2U, "Scroll U");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2V, "Scroll V");
                lilEditorGUI.DrawLine();
                m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Depth & Mask", "Depth and Mask Texture"), _EmissiveFreak2DepthMask, _EmissiveFreak2Depth);
                m_MaterialEditor.TextureScaleOffsetProperty(_EmissiveFreak2DepthMask);
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2DepthMaskInvert, "Invert Depth Mask");
                lilEditorGUI.DrawLine();
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2Breathing, "Breathing");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2BreathingMix, "Breathing Mix");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2BlinkOut, "Blink Out");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2BlinkOutMix, "Blink Out Mix");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2BlinkIn, "Blink In");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2BlinkInMix, "Blink In Mix");
                m_MaterialEditor.ShaderProperty(_EmissiveFreak2HueShift, "Hue Shift");
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();
            }
        }

        protected override void ReplaceToCustomShaders()
        {
            lts = Shader.Find(shaderName + "/lilToon");
            ltsc = Shader.Find("Hidden/" + shaderName + "/Cutout");
            ltst = Shader.Find("Hidden/" + shaderName + "/Transparent");
            ltsot = Shader.Find("Hidden/" + shaderName + "/OnePassTransparent");
            ltstt = Shader.Find("Hidden/" + shaderName + "/TwoPassTransparent");

            ltso = Shader.Find("Hidden/" + shaderName + "/OpaqueOutline");
            ltsco = Shader.Find("Hidden/" + shaderName + "/CutoutOutline");
            ltsto = Shader.Find("Hidden/" + shaderName + "/TransparentOutline");
            ltsoto = Shader.Find("Hidden/" + shaderName + "/OnePassTransparentOutline");
            ltstto = Shader.Find("Hidden/" + shaderName + "/TwoPassTransparentOutline");

            ltsoo = Shader.Find(shaderName + "/[Optional] OutlineOnly/Opaque");
            ltscoo = Shader.Find(shaderName + "/[Optional] OutlineOnly/Cutout");
            ltstoo = Shader.Find(shaderName + "/[Optional] OutlineOnly/Transparent");

            ltstess = Shader.Find("Hidden/" + shaderName + "/Tessellation/Opaque");
            ltstessc = Shader.Find("Hidden/" + shaderName + "/Tessellation/Cutout");
            ltstesst = Shader.Find("Hidden/" + shaderName + "/Tessellation/Transparent");
            ltstessot = Shader.Find("Hidden/" + shaderName + "/Tessellation/OnePassTransparent");
            ltstesstt = Shader.Find("Hidden/" + shaderName + "/Tessellation/TwoPassTransparent");

            ltstesso = Shader.Find("Hidden/" + shaderName + "/Tessellation/OpaqueOutline");
            ltstessco = Shader.Find("Hidden/" + shaderName + "/Tessellation/CutoutOutline");
            ltstessto = Shader.Find("Hidden/" + shaderName + "/Tessellation/TransparentOutline");
            ltstessoto = Shader.Find("Hidden/" + shaderName + "/Tessellation/OnePassTransparentOutline");
            ltstesstto = Shader.Find("Hidden/" + shaderName + "/Tessellation/TwoPassTransparentOutline");

            ltsl = Shader.Find(shaderName + "/lilToonLite");
            ltslc = Shader.Find("Hidden/" + shaderName + "/Lite/Cutout");
            ltslt = Shader.Find("Hidden/" + shaderName + "/Lite/Transparent");
            ltslot = Shader.Find("Hidden/" + shaderName + "/Lite/OnePassTransparent");
            ltsltt = Shader.Find("Hidden/" + shaderName + "/Lite/TwoPassTransparent");

            ltslo = Shader.Find("Hidden/" + shaderName + "/Lite/OpaqueOutline");
            ltslco = Shader.Find("Hidden/" + shaderName + "/Lite/CutoutOutline");
            ltslto = Shader.Find("Hidden/" + shaderName + "/Lite/TransparentOutline");
            ltsloto = Shader.Find("Hidden/" + shaderName + "/Lite/OnePassTransparentOutline");
            ltsltto = Shader.Find("Hidden/" + shaderName + "/Lite/TwoPassTransparentOutline");

            ltsref = Shader.Find("Hidden/" + shaderName + "/Refraction");
            ltsrefb = Shader.Find("Hidden/" + shaderName + "/RefractionBlur");
            ltsfur = Shader.Find("Hidden/" + shaderName + "/Fur");
            ltsfurc = Shader.Find("Hidden/" + shaderName + "/FurCutout");
            ltsfurtwo = Shader.Find("Hidden/" + shaderName + "/FurTwoPass");
            ltsfuro = Shader.Find(shaderName + "/[Optional] FurOnly/Transparent");
            ltsfuroc = Shader.Find(shaderName + "/[Optional] FurOnly/Cutout");
            ltsfurotwo = Shader.Find(shaderName + "/[Optional] FurOnly/TwoPass");
            ltsgem = Shader.Find("Hidden/" + shaderName + "/Gem");
            ltsfs = Shader.Find(shaderName + "/[Optional] FakeShadow");

            ltsover = Shader.Find(shaderName + "/[Optional] Overlay");
            ltsoover = Shader.Find(shaderName + "/[Optional] OverlayOnePass");
            ltslover = Shader.Find(shaderName + "/[Optional] LiteOverlay");
            ltsloover = Shader.Find(shaderName + "/[Optional] LiteOverlayOnePass");

            ltsm = Shader.Find(shaderName + "/lilToonMulti");
            ltsmo = Shader.Find("Hidden/" + shaderName + "/MultiOutline");
            ltsmref = Shader.Find("Hidden/" + shaderName + "/MultiRefraction");
            ltsmfur = Shader.Find("Hidden/" + shaderName + "/MultiFur");
            ltsmgem = Shader.Find("Hidden/" + shaderName + "/MultiGem");
        }

        // You can create a menu like this
        /*
        [MenuItem("Assets/TemplateFull/Convert material to custom shader", false, 1100)]
        private static void ConvertMaterialToCustomShaderMenu()
        {
            if(Selection.objects.Length == 0) return;
            TemplateFullInspector inspector = new TemplateFullInspector();
            for(int i = 0; i < Selection.objects.Length; i++)
            {
                if(Selection.objects[i] is Material)
                {
                    inspector.ConvertMaterialToCustomShader((Material)Selection.objects[i]);
                }
            }
        }
        */
    }
}
#endif