float3 CalculateHSV(float3 baseTexture, float hueShift, float saturation, float value ){
    float4 baseTex4 = float4(baseTexture, 0.0);
    float4 hsv_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 hsv_p = lerp(float4(baseTex4.zy, hsv_k.wz), float4(baseTex4.yz, hsv_k.xy), step(baseTex4.z, baseTex4.y));
    float4 hsv_q = lerp(float4(hsv_p.xyw, baseTex4.x), float4(baseTex4.x, hsv_p.yzx), step(hsv_p.x, baseTex4.x));

    float chroma = hsv_q.x - min(hsv_q.w, hsv_q.y);
    float3 hsv = float3(abs(hsv_q.z + (hsv_q.w - hsv_q.y) / (6.0 * chroma + 1.0e-10)), chroma / (hsv_q.x + 1.0e-10), hsv_q.x);
    
    return (lerp(float3(1,1,1), saturate(3.0*abs(1.0-2.0*frac((hueShift+hsv.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1), (hsv.g*saturation))*(value*hsv.b));
}

float3 CalculateEmissionParallax(
    float2 uv0,
    float3x3 tangentTransform,
    float3 viewDirection,
    Texture2D depthMask, float4 depthMask_ST,
    Texture2D mask, float4 mask_ST,
    Texture2D tex, float4 tex_ST,
    float Depth,
    float DepthMaskInvert,
    float3 Color
) {
    float depthMaskVal = LIL_SAMPLE_2D(depthMask, sampler_linear_repeat, TRANSFORM_TEX(uv0, depthMask)).r;
    float2 transformedUV = Depth * (depthMaskVal - DepthMaskInvert) * mul(tangentTransform, viewDirection).xy + uv0;
    float maskVal = LIL_SAMPLE_2D(mask, sampler_linear_repeat, TRANSFORM_TEX(uv0, mask)).r;
    float3 texVal = LIL_SAMPLE_2D(tex, sampler_linear_repeat, TRANSFORM_TEX(transformedUV, tex)).rgb * Color;
    return texVal * maskVal;
}

float3 CalculateEmissiveFreak(
    float2 uv0,
    float3x3 tangentTransform,
    float3 viewDirection,
    Texture2D tex, float4 tex_ST,
    Texture2D mask, float4 mask_ST,
    Texture2D depthMask, float4 depthMask_ST,
    float U, float V, float Depth, float DepthMaskInvert,
    float Breathing, float BreathingMix,
    float BlinkOut, float BlinkOutMix,
    float BlinkIn, float BlinkInMix,
    float HueShift,
    float3 Color
) {
    float time = _Time.r;
    float invTexX = 1.0 / tex_ST.x;
    float invTexY = 1.0 / tex_ST.y;
    float2 uv = uv0 + float2(frac(U * time * invTexX), frac(time * V * invTexY));
    float3 texVal = CalculateEmissionParallax(
        uv,
        tangentTransform,
        viewDirection,
        depthMask, depthMask_ST,
        mask, mask_ST,
        tex, tex_ST,
        Depth, DepthMaskInvert,
        Color
    );
    float breathing = cos(Breathing * time) * 0.5 + 0.5;
    float blinkOut = 1.0 - frac(BlinkOut * time);
    float blinkIn = frac(BlinkIn * time);
    float hue = frac(HueShift * time);
    texVal = CalculateHSV(texVal, hue, 1.0, 1.0);
    float3 result = texVal;
    result = lerp(result, result * breathing, BreathingMix);
    result = lerp(result, result * blinkOut, BlinkOutMix);
    result = lerp(result, result * blinkIn, BlinkInMix);
    return result;
}
