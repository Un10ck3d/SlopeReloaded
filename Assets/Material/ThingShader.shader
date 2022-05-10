Shader " Unlit/Thingshader" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
    _Scale("Texture Scale", Float) = 1.0
}
SubShader {
    Tags { 
        "RenderType"="Opaque" 
        "UniversalMaterialType" = "Unlit"
    }
    LOD 200

Lighting Off
CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;
float _Scale;

struct Input {
    float3 worldNormal;
    float3 worldPos;
};

void surf (Input IN, inout SurfaceOutput o) {
    float2 UV;
    fixed4 c;

    if (abs(IN.worldNormal.x) > 0.5) {
        UV = IN.worldPos.yz; // side
        c = tex2D(_MainTex, UV* _Scale / 2); // use WALLSIDE texture
    }
    else if (abs(IN.worldNormal.z) > 0.5) {
        UV = IN.worldPos.xy; // front
        c = tex2D(_MainTex, UV* _Scale / 2); // use WALL texture
    }
    else {
        UV = IN.worldPos.xz; // top
        c = tex2D(_MainTex, UV* _Scale / 2); // use FLR texture
    }

    o.Albedo = c.rgb;
    o.Emission = +c.rgb;
}
ENDCG
}

Fallback "Legacy Shaders/VertexUnlit"
}