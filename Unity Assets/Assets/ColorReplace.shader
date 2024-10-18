Shader "Custom/ColorReplace"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TargetColor ("Target Color", Color) = (1,1,1,1)
        _ReplacementColor ("Replacement Color", Color) = (1,1,1,1)
        _Threshold ("Threshold", Range(0,1)) = 0
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
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            fixed4 _TargetColor;
            fixed4 _ReplacementColor;
            float _Threshold;


            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, i.uv);
                float3 originalColor = texColor.rgb;

                // Color Replacement 1
                if (_Threshold == 1 || distance(originalColor, _TargetColor.rgb) <= _Threshold)
                {
                    texColor.rgb = _ReplacementColor.rgb;
                }
                
                return texColor;
            }
            ENDCG
        }
    }
}
