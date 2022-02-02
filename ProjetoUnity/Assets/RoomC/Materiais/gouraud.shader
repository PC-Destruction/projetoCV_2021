// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/gouraud"
{
    Properties
    {
        _MainColor ("Color", Color) = (1, 1, 1, 1)
        //I defined the position of a light source myself
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _LightPos ("LightPosition", Vector) = (0.07, 2, -10, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD1;
                float4 color : TEXCOORD0;
            };

            float4 _MainColor;
            float4 _LightPos;
            sampler2D _MainTex;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                //Convert the coordinate information and normal information of the point we handwritten before to the world coordinate system for calculation.
                float3 worldPos = mul(UNITY_MATRIX_M, v.vertex);
                float3 worldNor = mul(UNITY_MATRIX_M, v.normal);

                //Direction of light
                float3 lightDir = normalize(_LightPos);
                //Distance, used to calculate the attenuation of light
                //float3 dist = distance(_LightPos, worldPos);

                //Calculation of Diffuse Light.
                float lightPor = max(0, dot(worldNor, lightDir));
                //Attenuation coefficient, divided by 2 is a mysterious reason
                float atten = 20 / pow(length(_LightPos),2);

                //The final color displayed on the screen is interpolated and passed to the fragment function to display the color.
                o.color = _MainColor * lightPor * atten;

                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                
                return tex2D(_MainTex, i.uv) * i.color;
            }
            ENDCG
        }
    }

}
