// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/NewSurfaceShader"
{
  Properties {
        _Color ("Color", Color) = (1,1,1,1)
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _intensityfactor ("Intensity Factor", float)=20
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass {
            Tags { "LightMode"="ForwardBase" }
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
 
            #include "UnityCG.cginc"
 
            float4 _LightColor0;
 
            fixed4 _Color;
            sampler2D _MainTex;
            float _intensityfactor;
 
            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 cameraRelativeWorldPos : TEXCOORD1;
            };
 
            v2f vert (appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                o.cameraRelativeWorldPos = mul(unity_ObjectToWorld, float4(v.vertex.xyz, 1)).xyz - _WorldSpaceCameraPos.xyz;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                half3 normal = normalize(cross(ddy(i.cameraRelativeWorldPos), ddx(i.cameraRelativeWorldPos)));
 
                half ndotl = saturate(dot(normal, _WorldSpaceLightPos0.xyz));
                half3 lighting = ndotl * _LightColor0.xyz + UNITY_LIGHTMODEL_AMBIENT.rgb /_intensityfactor;
 
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
 
                return fixed4(col.rgb * lighting, 1.0);
            }
 
            ENDCG
        }
    }
 }
