float3 CalculateHSV(float3 baseTexture, float hueShift, float saturation, float value ){
    float4 baseTex4 = float4(baseTexture, 0.0);
    float4 hsv_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 hsv_p = lerp(float4(baseTex4.zy, hsv_k.wz), float4(baseTex4.yz, hsv_k.xy), step(baseTex4.z, baseTex4.y));
    float4 hsv_q = lerp(float4(hsv_p.xyw, baseTex4.x), float4(baseTex4.x, hsv_p.yzx), step(hsv_p.x, baseTex4.x));

    float chroma = hsv_q.x - min(hsv_q.w, hsv_q.y);
    float3 hsv = float3(abs(hsv_q.z + (hsv_q.w - hsv_q.y) / (6.0 * chroma + 1.0e-10)), chroma / (hsv_q.x + 1.0e-10), hsv_q.x);
    
    return (lerp(float3(1,1,1), saturate(3.0*abs(1.0-2.0*frac((hueShift+hsv.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1), (hsv.g*saturation))*(value*hsv.b));
}