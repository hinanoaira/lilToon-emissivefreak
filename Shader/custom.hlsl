//----------------------------------------------------------------------------------------------------------------------
// Macro

// Custom variables
//#define LIL_CUSTOM_PROPERTIES \
//    float _CustomVariable;
#define LIL_CUSTOM_PROPERTIES \
float _UseEmissionParallax; \
float4 _EmissionAParallaxColor; \
float _EmissionAParallaxDepth; \
float _EmissionAParallaxDepthMaskInvert; \
float4 _EmissiveFreak1Color; \
float _EmissiveFreak1U; \
float _EmissiveFreak1V; \
float _EmissiveFreak1Depth; \
float _EmissiveFreak1DepthMaskInvert; \
float _EmissiveFreak1Breathing; \
float _EmissiveFreak1BreathingMix; \
float _EmissiveFreak1BlinkOut; \
float _EmissiveFreak1BlinkOutMix; \
float _EmissiveFreak1BlinkIn; \
float _EmissiveFreak1BlinkInMix; \
float _EmissiveFreak1HueShift; \
 \
float4 _EmissiveFreak2Color; \
float _EmissiveFreak2U; \
float _EmissiveFreak2V; \
float _EmissiveFreak2Depth; \
float _EmissiveFreak2DepthMaskInvert; \
float _EmissiveFreak2Breathing; \
float _EmissiveFreak2BreathingMix; \
float _EmissiveFreak2BlinkOut; \
float _EmissiveFreak2BlinkOutMix; \
float _EmissiveFreak2BlinkIn; \
float _EmissiveFreak2BlinkInMix; \
float _EmissiveFreak2HueShift;

// Custom textures
#define LIL_CUSTOM_TEXTURES \
TEXTURE2D(_EmissionAParallaxTex); float4 _EmissionAParallaxTex_ST; \
TEXTURE2D(_EmissionAParallaxMask); float4 _EmissionAParallaxMask_ST; \
TEXTURE2D(_EmissionAParallaxDepthMask); float4 _EmissionAParallaxDepthMask_ST; \
TEXTURE2D(_EmissiveFreak1Tex); float4 _EmissiveFreak1Tex_ST; \
TEXTURE2D(_EmissiveFreak1Mask); float4 _EmissiveFreak1Mask_ST; \
TEXTURE2D(_EmissiveFreak1DepthMask); float4 _EmissiveFreak1DepthMask_ST; \
TEXTURE2D(_EmissiveFreak2Tex); float4 _EmissiveFreak2Tex_ST; \
TEXTURE2D(_EmissiveFreak2Mask); float4 _EmissiveFreak2Mask_ST; \
TEXTURE2D(_EmissiveFreak2DepthMask); float4 _EmissiveFreak2DepthMask_ST;

// Add vertex shader input
//#define LIL_REQUIRE_APP_POSITION
//#define LIL_REQUIRE_APP_TEXCOORD0
//#define LIL_REQUIRE_APP_TEXCOORD1
//#define LIL_REQUIRE_APP_TEXCOORD2
//#define LIL_REQUIRE_APP_TEXCOORD3
//#define LIL_REQUIRE_APP_TEXCOORD4
//#define LIL_REQUIRE_APP_TEXCOORD5
//#define LIL_REQUIRE_APP_TEXCOORD6
//#define LIL_REQUIRE_APP_TEXCOORD7
//#define LIL_REQUIRE_APP_COLOR
#define LIL_REQUIRE_APP_NORMAL
#define LIL_REQUIRE_APP_TANGENT
//#define LIL_REQUIRE_APP_VERTEXID

// Add vertex shader output
//#define LIL_V2F_FORCE_TEXCOORD0
//#define LIL_V2F_FORCE_TEXCOORD1
//#define LIL_V2F_FORCE_POSITION_OS
//#define LIL_V2F_FORCE_POSITION_WS
//#define LIL_V2F_FORCE_POSITION_SS
//#define LIL_V2F_FORCE_NORMAL
//#define LIL_V2F_FORCE_TANGENT
//#define LIL_V2F_FORCE_BITANGENT
#define LIL_CUSTOM_V2F_MEMBER(id0,id1,id2,id3,id4,id5,id6,id7) \
    float3 normalDir : TEXCOORD ## id0; \
    float3 tangentDir : TEXCOORD ## id1; \
    float3 bitangentDir : TEXCOORD ## id2;

// Add vertex copy
#define LIL_CUSTOM_VERT_COPY \
    output.normalDir = normalize(UnityObjectToWorldNormal(input.normalOS)); \
    output.tangentDir = normalize(mul(unity_ObjectToWorld, float4(input.tangentOS.xyz, 0.0)).xyz); \
    output.bitangentDir = normalize(cross(output.normalDir, output.tangentDir) * input.tangentOS.w);

// Inserting a process into the vertex shader
//#define LIL_CUSTOM_VERTEX_OS
//#define LIL_CUSTOM_VERTEX_WS

// Inserting a process into pixel shader
//#define BEFORE_xx
//#define OVERRIDE_xx

//----------------------------------------------------------------------------------------------------------------------
// Information about variables
//----------------------------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------------------------
// Vertex shader inputs (appdata structure)
//
// Type     Name                    Description
// -------- ----------------------- --------------------------------------------------------------------
// float4   input.positionOS        POSITION
// float2   input.uv0               TEXCOORD0
// float2   input.uv1               TEXCOORD1
// float2   input.uv2               TEXCOORD2
// float2   input.uv3               TEXCOORD3
// float2   input.uv4               TEXCOORD4
// float2   input.uv5               TEXCOORD5
// float2   input.uv6               TEXCOORD6
// float2   input.uv7               TEXCOORD7
// float4   input.color             COLOR
// float3   input.normalOS          NORMAL
// float4   input.tangentOS         TANGENT
// uint     vertexID                SV_VertexID

//----------------------------------------------------------------------------------------------------------------------
// Vertex shader outputs or pixel shader inputs (v2f structure)
//
// The structure depends on the pass.
// Please check lil_pass_xx.hlsl for details.
//
// Type     Name                    Description
// -------- ----------------------- --------------------------------------------------------------------
// float4   output.positionCS       SV_POSITION
// float2   output.uv01             TEXCOORD0 TEXCOORD1
// float2   output.uv23             TEXCOORD2 TEXCOORD3
// float3   output.positionOS       object space position
// float3   output.positionWS       world space position
// float3   output.normalWS         world space normal
// float4   output.tangentWS        world space tangent

//----------------------------------------------------------------------------------------------------------------------
// Variables commonly used in the forward pass
//
// These are members of `lilFragData fd`
//
// Type     Name                    Description
// -------- ----------------------- --------------------------------------------------------------------
// float4   col                     lit color
// float3   albedo                  unlit color
// float3   emissionColor           color of emission
// -------- ----------------------- --------------------------------------------------------------------
// float3   lightColor              color of light
// float3   indLightColor           color of indirectional light
// float3   addLightColor           color of additional light
// float    attenuation             attenuation of light
// float3   invLighting             saturate((1.0 - lightColor) * sqrt(lightColor));
// -------- ----------------------- --------------------------------------------------------------------
// float2   uv0                     TEXCOORD0
// float2   uv1                     TEXCOORD1
// float2   uv2                     TEXCOORD2
// float2   uv3                     TEXCOORD3
// float2   uvMain                  Main UV
// float2   uvMat                   MatCap UV
// float2   uvRim                   Rim Light UV
// float2   uvPanorama              Panorama UV
// float2   uvScn                   Screen UV
// bool     isRightHand             input.tangentWS.w > 0.0;
// -------- ----------------------- --------------------------------------------------------------------
// float3   positionOS              object space position
// float3   positionWS              world space position
// float4   positionCS              clip space position
// float4   positionSS              screen space position
// float    depth                   distance from camera
// -------- ----------------------- --------------------------------------------------------------------
// float3x3 TBN                     tangent / bitangent / normal matrix
// float3   T                       tangent direction
// float3   B                       bitangent direction
// float3   N                       normal direction
// float3   V                       view direction
// float3   L                       light direction
// float3   origN                   normal direction without normal map
// float3   origL                   light direction without sh light
// float3   headV                   middle view direction of 2 cameras
// float3   reflectionN             normal direction for reflection
// float3   matcapN                 normal direction for reflection for MatCap
// float3   matcap2ndN              normal direction for reflection for MatCap 2nd
// float    facing                  VFACE
// -------- ----------------------- --------------------------------------------------------------------
// float    vl                      dot(viewDirection, lightDirection);
// float    hl                      dot(headDirection, lightDirection);
// float    ln                      dot(lightDirection, normalDirection);
// float    nv                      saturate(dot(normalDirection, viewDirection));
// float    nvabs                   abs(dot(normalDirection, viewDirection));
// -------- ----------------------- --------------------------------------------------------------------
// float4   triMask                 TriMask (for lite version)
// float3   parallaxViewDirection   mul(tbnWS, viewDirection);
// float2   parallaxOffset          parallaxViewDirection.xy / (parallaxViewDirection.z+0.5);
// float    anisotropy              strength of anisotropy
// float    smoothness              smoothness
// float    roughness               roughness
// float    perceptualRoughness     perceptual roughness
// float    shadowmix               this variable is 0 in the shadow area
// float    audioLinkValue          volume acquired by AudioLink
// -------- ----------------------- --------------------------------------------------------------------
// uint     renderingLayers         light layer of object (for URP / HDRP)
// uint     featureFlags            feature flags (for HDRP)
// uint2    tileIndex               tile index (for HDRP)

# define BEFORE_BLEND_EMISSION \
    float3x3 tangentTransform = float3x3(input.tangentDir, input.bitangentDir, input.normalDir); \
    float3 viewDirection = normalize(UnityWorldSpaceViewDir(fd.positionWS)); \
    \
    float3 emissionParallax = float3(0,0,0); \
    if(_UseEmissionParallax) { \
        emissionParallax = CalculateEmissionParallax( \
            fd.uv0, \
            tangentTransform, \
            viewDirection, \
            _EmissionAParallaxDepthMask, _EmissionAParallaxDepthMask_ST, \
            _EmissionAParallaxMask, _EmissionAParallaxMask_ST, \
            _EmissionAParallaxTex, _EmissionAParallaxTex_ST, \
            _EmissionAParallaxDepth, _EmissionAParallaxDepthMaskInvert, \
            _EmissionAParallaxColor.rgb \
        ); \
    } \
    \
    float3 emissiveFreak1 = CalculateEmissiveFreak( \
        fd.uv0, \
        tangentTransform, \
        viewDirection, \
        _EmissiveFreak1Tex, _EmissiveFreak1Tex_ST, \
        _EmissiveFreak1Mask, _EmissiveFreak1Mask_ST, \
        _EmissiveFreak1DepthMask, _EmissiveFreak1DepthMask_ST, \
        _EmissiveFreak1U, _EmissiveFreak1V, \
        _EmissiveFreak1Depth, _EmissiveFreak1DepthMaskInvert, \
        _EmissiveFreak1Breathing, _EmissiveFreak1BreathingMix, \
        _EmissiveFreak1BlinkOut, _EmissiveFreak1BlinkOutMix, \
        _EmissiveFreak1BlinkIn, _EmissiveFreak1BlinkInMix, \
        _EmissiveFreak1HueShift, \
        _EmissiveFreak1Color.rgb \
    ); \
    float3 emissiveFreak2 = CalculateEmissiveFreak( \
        fd.uv0, \
        tangentTransform, \
        viewDirection, \
        _EmissiveFreak2Tex, _EmissiveFreak2Tex_ST, \
        _EmissiveFreak2Mask, _EmissiveFreak2Mask_ST, \
        _EmissiveFreak2DepthMask, _EmissiveFreak2DepthMask_ST, \
        _EmissiveFreak2U, _EmissiveFreak2V, \
        _EmissiveFreak2Depth, _EmissiveFreak2DepthMaskInvert, \
        _EmissiveFreak2Breathing, _EmissiveFreak2BreathingMix, \
        _EmissiveFreak2BlinkOut, _EmissiveFreak2BlinkOutMix, \
        _EmissiveFreak2BlinkIn, _EmissiveFreak2BlinkInMix, \
        _EmissiveFreak2HueShift, \
        _EmissiveFreak2Color.rgb \
    ); \
     \
    fd.emissionColor = fd.emissionColor + emissionParallax + emissiveFreak1 + emissiveFreak2;
